

'use strict';


app.controller('homeController', ['$scope', 'employeeService', function ($scope, employeeService) {
    $scope.message = "Now viewing home!";

    $scope.employees = {
        EmployeeId: "",
        FirstName: "",
        LastName: ""
    };

    employeeService.getEmployees($scope);
}])


app.service('employeeService', ['$http', function ($http) {
    this.getEmployees = function ($scope) {
        return $http({
            method: "GET",
            url: "../api/employees",
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.employees = data;
            $scope.json = angular.toJson(data);
            //alert($scope.json);
            console.log($scope.json);
        }).error(function (data) {
            //alert("some issue");
            console.log(data);
        });;
    };
}]);

