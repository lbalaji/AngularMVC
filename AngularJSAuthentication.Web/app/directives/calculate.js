 
app.directive('calculate', ['calculatorService', function (calculatorService) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                    scope.$watch(attrs.ngModel, function (v) {
                        if (scope.calculation != null) {
                            calculatorService.calculate(scope.calculation).then(function (results) {
                                console.log(results.data);
                                scope.calculation.result = results.data.result;
                            }, function (error) {
                                //alert(error.data.message);
                            });
                        }
                });
            }
        };
}]);
 
 