var WebRtcDemo = WebRtcDemo || {};

// todo:
//  cleanup: proper module loading
//  cleanup: promises to clear up some of the async chaining
//  feature: multiple chat partners

WebRtcDemo.App = (function (viewModel, connectionManager) {
    var _mediaStream,
        _hub,
     isSessionStarted = false;


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
                    var sessionID = $('#spnId').text();
                    var obj = {
                        UserID: userID,
                        SessionID: sessionID,
                        Username: username
                    }
                    console.info("My connection details: ", obj)
                    hub.server.join(username, userID, 0);
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
            var targetUserId = $('#htnTargetUserID').val();
            console.info("TargetUserID", targetUserId);
            _startSession(username, targetUserId);
        },

        _startSession = function (username, targetUserId, targetConnectionId) {
            viewModel.Username(username); // Set the selected username in the UI
            viewModel.Loading(true); // Turn on the loading indicator
            $('.instructions').hide();
            // Now we have everything we need for interaction, so fire up SignalR
            _connect(username, function (hub) {
                // tell the viewmodel our conn id, so we can be treated like the special person we are.
                viewModel.MyConnectionId(hub.connection.id);

                // Initialize our client signal manager, giving it a signaler (the SignalR hub) and some callbacks
                console.log('initializing connection manager');
                connectionManager.initialize(hub.server, _callbacks.onReadyForStream, _callbacks.onStreamAdded, _callbacks.onStreamRemoved);
                //_callInitiallyToTargetUser(targetUserId);
                viewModel.Loading(false);
            }, function (event) {
                alertify.alert('<h4>Failed SignalR Connection</h4> We were not able to connect you to the signaling server.<br/><br/>Error: ' + JSON.stringify(event));
                viewModel.Loading(false);
            });
        },

                _setupHubCallbacks = function (hub) {
                    // Hub Callback: Incoming Call
                    hub.client.incomingCall = function (callingUser) {
                        console.log('incoming call from: ' + JSON.stringify(callingUser));
                        $("#tableSessions > tbody tr").each(function (i, row) {
                            var tableRow = $(row)[0];
                            var cell = parseInt($(tableRow.cells[0]).html())
                            if (cell == callingUser.SessionID) {
                                console.info("tableRow: ", tableRow)
                                var td = $($(row)[0].cells[6]);
                                var elem = $(td).find("a");
                                console.log(elem);
                                elem.html("In Progress");
                            }
                        })
                        
                    };

                    // Hub Callback: Call Accepted
                    hub.client.callAccepted = function (acceptingUser) {
                        console.log('call accepted from: ' + JSON.stringify(acceptingUser) + '.  Initiating WebRTC call and offering my stream up...');

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
                        $('#btnJoin').hide();
                    };

                    //Hub callback: Update session list
                    hub.client.updateSessionList = function (sessionID) {
                        $("#tableSessions > tbody tr").each(function (i, row) {
                            var tableRow = $(row)[0];
                            var cell = parseInt($(tableRow.cells[0]).html())
                            if (cell == sessionID) {
                                $('#upcomingSessions').load('/Student/_UpcomingSessions')
                                    hub.server.hangUp();
                                    connectionManager.closeAllConnections();
                                    viewModel.Mode('idle');
                                    var username = $('#hdnUserFullName').val();
                                    var userID = $('#UserID').val();
                                    hub.server.join(username, userID, 0)
                            }
                        })
                    }

                    // Hub Callback: Call Ended
                    hub.client.callEnded = function (connectionId, reason) {
                        console.log('call with ' + connectionId + ' has ended: ' + reason);

                        // Let the user know why the server says the call is over
                        alertify.error(reason);

                        // Close the WebRTC connection
                        connectionManager.closeConnection(connectionId);

                        // Set the UI back into idle mode
                        viewModel.Mode('idle');
                        $('#btnJoin').hide();
                    };

                    // Hub Callback: Update User List
                    hub.client.updateUserList = function (userList) {
                        viewModel.setUsers(userList);
                        //Here we can do anything what should happen when any user comes online.
                        console.info("Updated user list: ", userList)
                        _updateJoinButton(userList);
                    };

                    // Hub Callback: WebRTC Signal Received
                    hub.client.receiveSignal = function (callingUser, data) {
                        connectionManager.newSignal(callingUser.ConnectionId, data);
                        console.info("Signal recieved from: ", callingUser.Username)
                    };
                },

                _updateJoinButton = function(userList) {

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


