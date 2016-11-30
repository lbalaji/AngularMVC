'use strict';
app.controller('calculatorListController', ['$scope', '$location','$window', 'calculatorService', function ($scope, $location,$window, calculatorService) {

    $scope.calculations = [];

    $scope.loadCalculation = function (){
        calculatorService.getCalculations().then(function (results) {
            console.log("Calculation entry");
            $scope.calculations = results.data;

        }, function (error) {
             alert(error.data.message);
        });
    }


    $scope.add = function () {
        $location.path('/calculator');
    }

    $scope.edit = function (id) {
        console.log(id);
        $location.path('/calculator').search({id:id});
    }

    

    $scope.delete = function (id) {
        var deletecalc = $window.confirm('Are you absolutely sure you want to delete?');

        if (deletecalc) {
            calculatorService.deleteCalculator(id).then(function (results) {

                $scope.loadCalculation();

            }, function (error) {
                //alert(error.data.message);
            });
        }
    }
    $scope.loadCalculation();
}]);