'use strict';

app.controller('AddCarController', function AddCarController($scope, carsData) {
    $scope.status = { done: false };
    $scope.anotherOne = function () {
        $scope.status.done = false;
    };
    $scope.postCarData = function (car, addCarForm) {
        $scope.done = false;
	    carsData.postCarData(car).then(function (data) {
	        $scope.msg = "Done";
	        $scope.status.done = true;
	    }, function () {
	        $scope.msg = "Failed";
	        $scope.status.done = true;
	    });
	    
	    console.log($scope.addCarForm)
	}

});