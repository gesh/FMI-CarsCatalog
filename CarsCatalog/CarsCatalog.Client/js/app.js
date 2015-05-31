'use strict';

var app = angular.module('cars-catalog', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/manufacturers', {
                templateUrl: 'views/partials/manufacturers.html',
                controller: 'ManufacturersController'
            })
            .when('/cars', {
                templateUrl: 'views/partials/cars.html',
                controller: 'CarsController'
            })
            .when('/add-manufacturer', {
                templateUrl: 'views/partials/add-manufacturer.html',
                controller: 'AddManufacturerController'
            })
            .when('/add-car', {
                templateUrl: 'views/partials/add-car.html',
                controller: 'AddCarController'
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:23610');