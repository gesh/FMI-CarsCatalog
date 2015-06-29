'use strict';

app.factory('carsDataSrv', function($http, $log, Restangular, baseServiceUrl) {

    var path = '/api/Cars';
    var carApi = Restangular.allUrl('Cars', baseServiceUrl + path);

	return {
		getData: function() {
		    return carApi.getList();
		},
		getAll: function() {
		    $http({ method: 'GET', dataType: 'jsonp', url: baseServiceUrl + path })
				.success(function (data, status, headers, config) {
				    console.log(data);
				})
				.error(function (data, status, headers, config) {
				    $log.error(data);
				})
		},
		postData: function (car) {
		    console.log(JSON.stringify(car));
		    return $http.post(
                baseServiceUrl + '/api/Cars',
                JSON.stringify(car),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            );
		}
	}

})