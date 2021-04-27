var app = angular.module('LoginApp', []);

app.controller("LoginController", function ($scope, $http) {
    $scope.btntext = "Login";
    $scope.login = function () {
        $scope.btntext = "please wait";
        $http({
            method: "POST",
            url: '/Home/userlogin',
            data: $scope.user
        }).then(function (d) {
            $scope.btntext = "Login";
            console.log(d);
            if (d.data == 1 ) {
                window.location.href = '/Home/Projectowner';
            }
            else if (d.data == 2)
            {
                window.location.href = '/Home/Processowner';
            }
            else if (d.data == 3)
            {
                window.location.href = '/Home/Clerk';
            }
            else {
                alert('please enter vaild email or password');
            }
            $scope.user = null;
        }),function () {
            alert('failed');
        }
    }

});