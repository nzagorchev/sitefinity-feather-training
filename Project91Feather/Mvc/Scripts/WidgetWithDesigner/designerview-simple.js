console.log('loaded');

//var module = angular.module('customModule', []);
//angular.module('designer').requires.push('customModule');

// load designer module
var module = angular.module('designer');

// designer controller for the Simple designer
module.controller('SimpleCtrl', ['$scope', 'propertyService',
    function ($scope, propertyService) {

        $scope.feedback.showLoadingIndicator = true;

        propertyService.get()
            .then(function (data) {
                if (data) {
                    console.log('here');
                    debugger;
                    $scope.properties = propertyService.toAssociativeArray(data.Items);

                    console.log($scope.properties);
                }
            },
            function (data) {
                $scope.feedback.showError = true;
                if (data)
                    $scope.feedback.errorMessage = data.Detail;
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });
    }]);