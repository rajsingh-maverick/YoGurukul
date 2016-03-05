/// <reference path="../Scripts/angular.min.js" />

var shared = angular.module("app.shared", []);

var mainApp = angular.module('app.main', ['ui.bootstrap', 'ui.router', 'app.shared']);

mainApp.config(function ($stateProvider, $urlRouterProvider) {

   
    $stateProvider // HOME STATES AND NESTED VIEWS ========================================
        .state('home', {
            url: '/home',
            controller: 'app.main.controller',
            templateUrl: '/app/module/home/home.tpl.html'
        })

        // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
        .state('about', {
            // we'll get to this in a bit       
        
        });

    $urlRouterProvider.otherwise('/home');

});