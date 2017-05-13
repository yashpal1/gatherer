/// <reference path="AngularApp.js" />
/// <reference path="E:\FW Projects\Gather_GIT_2\Gatherer\GatherApp\Scripts/angular.min.js" />
/// <reference path="E:\FW Projects\Gather_GIT_2\Gatherer\GatherApp\Scripts/angular.js" />
Mod.controller("ctrlLogin", ['$scope', '$http', '$window', function ($scope, $http, $window) {
    $scope.login = function () {
        if ($scope.userName == '' || $scope.userName == undefined) {
            alert("Please Enter User Name");
        }
        if ($scope.userPass == '' || $scope.userPass == undefined) {
            alert("Please Enter Password");
        }
        var data = $.param({ UserId: $scope.userName, Password: $scope.userPass});
           
            $http.post("Login/login", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
                if (response.data == "Incorrect") {
                    alert("Username or Password is not correct");

                }
                else {
                    $window.location.href = 'Home/index';
                }
                
            }), function (error) {
                alert(error);
            }
       
    }
}]);