'use strict';

app.factory('calculatorService', ['$http', 'ngAuthSettings', 'localStorageService', function ($http, ngAuthSettings, localStorageService) {

   
    var calculatorServiceFactory = {};

    var _getCalculator = function (id) {

        var suffixId = '';
        if (id != undefined)
            suffixId = '/' + id;

        return $http.get(this.serviceBase() + 'api/calculator' + suffixId).then(function (results) {
            return results;
        });
    };

    var _getCalculations = function () {
        console.log("test");
       
        return $http.get(this.serviceBase() + 'api/calculator/calculatons').then(function (results) {
            return results;
        });
    };

    var _saveCalculator = function (data) {
          return $http.post(this.serviceBase() + 'api/calculator', data).then(function (results) {
            return results;
        });
    };

    var _deleteCalculator = function (id) {
        return $http.delete(this.serviceBase() + 'api/calculator/' + id).then(function (results) {
            return results;
        });
    };
    

    var _calculate = function (data) {

         return $http.post(this.serviceBase() + 'api/calculator/calculate', data).then(function (results) {
            return results;
        });
    };

    var _calcultorChoices = function (data) {

         return $http.post(this.serviceBase() + 'api/calculator/operations', data).then(function (results) {
            return results;
        });
    };

    calculatorServiceFactory.serviceBase = function () {
   
        var dbTypeData = localStorageService.get('dbTypeData');
        if (dbTypeData) {
            console.log('calculator service');
            console.log(dbTypeData);
            if (dbTypeData.dbType == '1')
                return   'http://localhost/ngauthenticationapi/';
            return  'http://localhost/ngauthenticationapisql/';
        }
    };

    calculatorServiceFactory.getCalculator = _getCalculator;
    calculatorServiceFactory.saveCalculator = _saveCalculator;
    calculatorServiceFactory.calculate = _calculate;
    calculatorServiceFactory.getCalcultorChoices = _calcultorChoices;
    calculatorServiceFactory.getCalculations = _getCalculations;
    calculatorServiceFactory.deleteCalculator = _deleteCalculator;
    return calculatorServiceFactory;

}]);