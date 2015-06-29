'use strict';

app.controller('CarsController', function CarsController ($scope, carsDataSrv) {

	carsDataSrv.getData().then(function(data){
<<<<<<< HEAD
	    $scope.cars = data;
	    console.log($scope.cars);
=======
		$scope.cars = data;
		console.log($scope.cars);
>>>>>>> parent of 4dd5a2e... cors for manufacturers
	});
});