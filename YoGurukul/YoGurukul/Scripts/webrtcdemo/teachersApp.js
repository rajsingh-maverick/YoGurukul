﻿var WebRtcDemo = WebRtcDemo || {};

// todo:
//  cleanup: proper module loading
//  cleanup: promises to clear up some of the async chaining
//  feature: multiple chat partners

WebRtcDemo.App = (function (viewModel, connectionManager) {
    var _mediaStream,
        _hub,
        _callEndedRDeclined = false

        _connect = function (username, onSuccess, onFailure) {
            // Set Up SignalR Signaler
            var hub = $.connection.webRtcHub;
            $.support.cors = true;
            $.connection.hub.url = '/signalr/hubs';
            $.connection.hub.start()
                .done(function () {
                    console.log('connected to SignalR hub... connection id: ' + _hub.connection.id);
                    //Tell the hub what our username is
                    var userID = $('#UserID').val();
                    var sessionID = $('#SessionID').val();
                    console.info("UserID: ", sessionID)
                    hub.server.join(username, userID, sessionID);
                    if (onSuccess) {
                        onSuccess(hub);
                    }
                })
                .fail(function (event) {
                    if (onFailure) {
                        onFailure(event);
                    }
                });
            // Setup client SignalR operations
            _setupHubCallbacks(hub);
            _hub = hub;
        },

        _start = function (hub) {
            // Show warning if WebRTC support is not detected
            if (webrtcDetectedBrowser == null) {
                console.log('Your browser doesnt appear to support WebRTC.');
                $('.browser-warning').show();
            }

            // Then proceed to the next step, gathering username
            _getUsername();
        },

        _getUsername = function () {
            var username = $('#hdnUserFullName').val();
            var targetUserId = $('#targetUserID').val();
            console.info("TargetUserID", targetUserId);
            _startSession(username, targetUserId);
        },

        _startSession = function (username) {
            viewModel.Username(username); // Set the selected username in the UI
            viewModel.Loading(true); // Turn on the loading indicator

            // Ask the user for permissions to access the webcam and mic
            getUserMedia(
                {
                    // Permissions to request
                    video: true,
                    audio: true
                },
                function (stream) { // succcess callback gives us a media stream
                    $('.instructions').hide();

                    // Now we have everything we need for interaction, so fire up SignalR
                    _connect(username, function (hub) {
                        // tell the viewmodel our conn id, so we can be treated like the special person we are.
                        viewModel.MyConnectionId(hub.connection.id);

                        // Initialize our client signal manager, giving it a signaler (the SignalR hub) and some callbacks
                        console.log('initializing connection manager');
                        connectionManager.initialize(hub.server, _callbacks.onReadyForStream, _callbacks.onStreamAdded, _callbacks.onStreamRemoved);

                        // Store off the stream reference so we can share it later
                        _mediaStream = stream;
                        console.info("Type of stream", stream);
                        // Load the stream into a video element so it starts playing in the UI
                        console.log('playing my local video feed');
                        var videoElement = document.querySelector('.video.mine');
                        attachMediaStream(videoElement, _mediaStream);

                        // Hook up the UI
                        _attachUiHandlers();

                        viewModel.Loading(false);
                    }, function (event) {
                        alertify.alert('<h4>Failed SignalR Connection</h4> We were not able to connect you to the signaling server.<br/><br/>Error: ' + JSON.stringify(event));
                        viewModel.Loading(false);
                    });
                },
                function (error) { // error callback
                    alertify.alert('<h4>Failed to get hardware access!</h4> Do you have another browser type open and using your cam/mic?<br/><br/>You were not connected to the server, because I didn\'t code to make browsers without media access work well. <br/><br/>Actual Error: ' + JSON.stringify(error));
                    viewModel.Loading(false);
                }
            );
        },

        _callInitiallyToTargetUser = function (targetUserId) {
            var targetConnectionId;
            _hub.server.getOnlineUsers().done(function (result) {
                for (var i = 0; i < result.length; i++) {
                    if (result[i].UserID == targetUserId) {
                        targetConnectionId = result[i].ConnectionId;
                        break;
                    }
                }
                console.info("TargetUserID", targetUserId);
                console.info("TargetConnectionID", targetConnectionId);
                // Make sure we are in a state where we can make a call
                if (viewModel.Mode() !== 'idle') {
                    //alertify.error('Sorry, you are already in a call.');
                    alert('Sorry, you are already in a call.');
                    return;
                }
                if (targetConnectionId != viewModel.MyConnectionId()) {
                    var callingUserConnectionID;
                    // Initiate a call
                    _hub.server.callUser(targetConnectionId);
                    var userID = parseInt($('#UserID').val());
                    for (var i = 0; i < result.length; i++) {
                        if (result[i].UserID == userID) {
                            callingUserConnectionID = result[i].ConnectionId;
                        }
                    }
                    $('#hdnCallingUserConnectionId').val(_hub.connection.id);
                    // UI in calling mode
                    viewModel.Mode('calling');
                }
            })
        },

        _setupHubCallbacks = function (hub) {
            // Hub Callback: Call Accepted
            hub.client.callAccepted = function (acceptingUser) {
                console.log('call accepted from: ' + JSON.stringify(acceptingUser) + '.  Initiating WebRTC call and offering my stream up...');
                _callEndedRDeclined = true;
                // Callee accepted our call, let's send them an offer with our video stream
                connectionManager.initiateOffer(acceptingUser.ConnectionId, _mediaStream);

                // Set UI into call mode
                viewModel.Mode('incall');
            };

            // Hub Callback: Call Declined
            hub.client.callDeclined = function (decliningConnectionId, reason) {
                console.log('call declined from: ' + decliningConnectionId);

                // Let the user know that the callee declined to talk
                alertify.error(reason);

                // Back to an idle UI
                viewModel.Mode('idle');
            };

            // Hub Callback: Call Ended
            hub.client.callEnded = function (connectionId, reason) {
                console.log('call with ' + connectionId + ' has ended: ' + reason);
                //_callEndedRDeclined = true

                // Let the user know why the server says the call is over
                alertify.error(reason);

                // Close the WebRTC connection
                connectionManager.closeConnection(connectionId);

                // Set the UI back into idle mode
               // viewModel.Mode('idle');
            };

            // Hub Callback: Update User List
            hub.client.updateUserList = function (userList) {
                viewModel.setUsers(userList);
                //When the list is updated, then call the student.
                _callStudent(userList)
            };

            // Hub Callback: WebRTC Signal Received
            hub.client.receiveSignal = function (callingUser, data) {
                connectionManager.newSignal(callingUser.ConnectionId, data);
            };
        },
         _attachUiHandlers = function () {
             console.log("Attach handlers")
             // Add click handler to users in the "Users" pane
             $('.user').live('click', function () {
                 var userID = $(this).attr('userId');
                 console.log(userID)
                 // Find the target user's SignalR client id
                 var targetConnectionId = $(this).attr('data-cid');

                 // Make sure we are in a state where we can make a call
                 if (viewModel.Mode() !== 'idle') {
                     alertify.error('Sorry, you are already in a call.  Conferencing is not yet implemented.');
                     return;
                 }

                 // Then make sure we aren't calling ourselves.
                 if (targetConnectionId != viewModel.MyConnectionId()) {
                     // Initiate a call
                     _hub.server.callUser(targetConnectionId);

                     // UI in calling mode
                     viewModel.Mode('calling');
                 } else {
                     alertify.error("Ah, nope.  Can't call yourself.");
                 }
             });

             // Add handler for the hangup button
             $('.hangup').click(function () {
                 // Only allow hangup if we are not idle
                 if (viewModel.Mode() != 'idle') {
                     _hub.server.hangUp();
                     connectionManager.closeAllConnections();
                     viewModel.Mode('idle');
                 }
             });
         },

        _callStudent = function (userList) {
            var studentIsOnline = false;
            var targetUserID = $('#targetUserID').val();
            var targetUser;
            console.info("TargetUserID: ", targetUserID)
            console.log("Updated user list: ", userList)
            if (userList.length > 1) {
                for (var i = 0; i < userList.length; i++) {
                    if (userList[i].UserID == targetUserID) {
                        targetUser = userList[i];
                        studentIsOnline = true;
                        break;
                    }
                }
                console.info("Target user id is: ", { targetConnectionID: targetUser.ConnectionId, loggedInUserID: $('#UserID').val() })
                if (!_callEndedRDeclined) {
                    var timeout = setTimeout(function () {
                        _hub.server.callUser(targetUser.ConnectionId);
                        $('#partnerName').html(targetUser.Username)
                        $('#me').html('You');
                    }, 2500);
                }
            }
        }

        // Connection Manager Callbacks
        _callbacks = {
            onReadyForStream: function (connection) {
                // The connection manager needs our stream
                // todo: not sure I like this
                connection.addStream(_mediaStream);
            },
            onStreamAdded: function (connection, event) {
                console.log('binding remote stream to the partner window');

                // Bind the remote stream to the partner window
                var otherVideo = document.querySelector('.video.partner');
                attachMediaStream(otherVideo, event.stream); // from adapter.js
            },
            onStreamRemoved: function (connection, streamId) {
                // todo: proper stream removal.  right now we are only set up for one-on-one which is why this works.
                console.log('removing remote stream from partner window');

                // Clear out the partner window
                var otherVideo = document.querySelector('.video.partner');
                otherVideo.src = '';
            }
        };

    return {
        start: _start, // Starts the UI process
        getStream: function () { // Temp hack for the connection manager to reach back in here for a stream
            return _mediaStream;
        }
    };
})(WebRtcDemo.ViewModel, WebRtcDemo.ConnectionManager);

    // Kick off the app
    WebRtcDemo.App.start();
