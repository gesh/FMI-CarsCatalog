'use strict';

app.factory('carsData', function($http, $log) {

	return {
		getCarsData: function(successCallBack) {
		    $http({ method: 'GET', url: 'http://localhost:1860/api/Cars' })
				.success(function(data, status, headers, config) {
					successCallBack(data);
				})
				.error(function(data, status, headers, config) {
					$log.error(data);
				})
		},
		postCarData: function (car) {
		    console.log(JSON.stringify(car));
            $http.post(
                'http://localhost:1860/api/Cars',
                JSON.stringify(car),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).success(function (data) {
                if(data){
                	alert('success');
                }
            });
		}
	}

})