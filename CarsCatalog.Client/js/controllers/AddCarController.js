'use strict';

app.controller('AddCarController', function AddCarController ($scope, carsData) {

	$scope.postCarData = function(car,addCarForm) {
		carsData.postCarData(car);
	}

});