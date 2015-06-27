'use strict';

app.factory('manufacturersData', function($http, $log, baseServiceUrl) {

	return {
		getManufacturersData: function(successCallBack) {
		    $http({ method: 'GET', url: baseServiceUrl + '/api/manufacturers' })
				.success(function(data, status, headers, config) {
					successCallBack(data);
				})
				.error(function(data, status, headers, config) {
					$log.error(data);
				})
		},
		postManufacturerData: function (manufacturer) {
		    console.log(manufacturer);

            $http.post(
                baseServiceUrl + '/api/manufacturers',
                JSON.stringify(manufacturer),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).success(function (data) {
                if(data){
                	alert('success');
                }
            }).error(function(error){
                console.log(error);
            });
		}
	}

})