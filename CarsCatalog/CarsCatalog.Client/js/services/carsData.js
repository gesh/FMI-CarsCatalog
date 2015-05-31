'use strict';

app.factory('carsData', function($http, $log) {

	return {
		getCarsData: function(successCallBack) {
			$http({ method: 'GET', url: 'http://localhost:25632/api/cars'})
				.success(function(data, status, headers, config) {
					successCallBack(data);
				})
				.error(function(data, status, headers, config) {
					$log.error(data);
				})
		},
		postCarData: function(car){
            $http.post(
                'http://localhost:25632/api/cars',
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