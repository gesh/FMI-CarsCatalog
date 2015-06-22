'use strict';
app.controller('AddManufacturerController', function AddManufacturerController ($scope, manufacturersData) {

	$scope.postManufacturerData = function(manufacturer,addManufacturerForm) {
	    manufacturersData.postManufacturerData(manufacturer);
	}

});

