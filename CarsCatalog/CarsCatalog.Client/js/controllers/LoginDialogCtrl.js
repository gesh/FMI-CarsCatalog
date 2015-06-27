var ctrlName = "LoginDialogCtrl";
app.controller(ctrlName, ['$scope', '$rootScope', '$log', '$modalInstance', '$timeout',
    function ($scope, $rootScope, $log, $modalInstance, $timeout) {

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };



    }]);