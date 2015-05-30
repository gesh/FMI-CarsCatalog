'use strict';

app.controller('CarsController', function CarsController ($scope, carsData) {


	carsData.getCarsData(function(data){
		//console.log(data);
		$scope.cars = data;
		console.log($scope.cars);
	});
});