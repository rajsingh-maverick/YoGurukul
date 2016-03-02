﻿"use strict";
var shared = angular.module("app.shared", []);
angular.module("app.shared").controller("app.shared.webService", ["$http", "$q", function ($http, $p) {

    var service = {};

    service.get = function (url) {
        var deferred = $q.defer();

        $http({
            method: "GET",
            url: "api/home"
        }).
        success(function (result, status, headers, config) {
            deferred.resolve(result.data);
        }).
        error(function (data, status, headers, config) {
            deferred.reject(data);
        });
        return deferred.promise;
    };
    return service;
}]);