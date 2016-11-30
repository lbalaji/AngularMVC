'use strict';
app.factory('calculatorService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var calculatorServiceFactory = {};

    var _getCalculator = function (id) {

        var suffixId = '';
        if (id != undefined)
            suffixId = '/' + id;

        return $http.get(serviceBase + 'api/calculator' + suffixId).then(function (results) {
            return results;
        });
    };

    var _getCalculations = function () {
        console.log("test");
        return $http.get(serviceBase + 'api/calculator/calculatons').then(function (results) {
            return results;
        });
    };

    var _saveCalculator = function (data) {
        console.log("service called");
        return $http.post(serviceBase + 'api/calculator',data).then(function (results) {
            return results;
        });
    };

    var _deleteCalculator = function (id) {
        return $http.delete(serviceBase + 'api/calculator/' + id).then(function (results) {
            return results;
        });
    };
    

    var _calculate = function (data) {

        return $http.post(serviceBase + 'api/calculator/calculate',data).then(function (results) {
            return results;
        });
    };

    var _calcultorChoices = function (data) {

        return $http.post(serviceBase + 'api/calculator/operations', data).then(function (results) {
            return results;
        });
    };

    calculatorServiceFactory.getCalculator = _getCalculator;
    calculatorServiceFactory.saveCalculator = _saveCalculator;
    calculatorServiceFactory.calculate = _calculate;
    calculatorServiceFactory.getCalcultorChoices = _calcultorChoices;
    calculatorServiceFactory.getCalculations = _getCalculations;
    calculatorServiceFactory.deleteCalculator = _deleteCalculator;
    return calculatorServiceFactory;

}]);