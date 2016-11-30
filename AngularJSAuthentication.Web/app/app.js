
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/ngauthenticationweb/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/ngauthenticationweb/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/ngauthenticationweb/app/views/signup.html"
    });

    $routeProvider.when("/calculations", {
        controller: "calculatorListController",
        templateUrl: "/ngauthenticationweb/app/views/calculations.html"
    });

    $routeProvider.when("/calculator/:id?", {
        controller: "calculatorController",
        templateUrl: "/ngauthenticationweb/app/views/calculator.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/ngauthenticationweb/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/ngauthenticationweb/app/views/tokens.html"
    });

    

    $routeProvider.otherwise({ redirectTo: "/home" });

});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://localhost/ngauthenticationapi/',
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


