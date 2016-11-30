'use strict';
app.controller('calculatorController', ['$scope', '$location', '$routeParams', 'calculatorService',
    function ($scope, $location,$routeParams, calculatorService) {

    $scope.calculation = null;
    $scope.message = "";
    $scope.choices = [];

    if ($routeParams.id != undefined)
        $scope.id = $routeParams.id;
    else  
        $scope.id = "";

        calculatorService.getCalculator($scope.id).then(function (results) {
       
        $scope.calculation = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

    calculatorService.getCalcultorChoices().then(function (results) {
        $scope.choices = results.data;
    }, function (error) {
        //alert(error.data.message);
    });

    $scope.cancel = function() {
        console.log("cancel");
        $location.path('/calculations/').search('');
    };

  
    $scope.save = function () {
        console.log("save");
        calculatorService.saveCalculator($scope.calculation).then(function (results) {
            console.log(results.data);
            $scope.choices = results.data;
            $location.path('/calculations/').search('');
        }, function (error) {
            //alert(error.data.message);
        }); 
    };

    
}]);