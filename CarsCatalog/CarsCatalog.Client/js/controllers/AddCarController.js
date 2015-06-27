'use strict';

app.controller('AddCarController', function AddCarController($scope, carsData) {
    $scope.status = { done: false };
    $scope.anotherOne = function () {
        $scope.status.done = false;
    };
    $scope.postCarData = function (car, addCarForm) {
        if (!addCarForm.$valid)
        {
            console.log(addCarForm);
            $scope.status.error = "Wrong data";
            return;
        }
        $scope.status.error = "";
        $scope.status.inProg = true;
	    carsData.postCarData(car).then(function (data) {
	        $scope.msg = "Done";
	        $scope.status.done = true;
	        $scope.status.inProg = false;
	    }, function () {
	        $scope.msg = "Failed";
	        $scope.status.done = true;
	        $scope.status.inProg = false;
	    });
	    
	    console.log($scope.addCarForm)
	}

});