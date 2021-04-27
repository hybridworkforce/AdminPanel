var app = angular.module("ContactApp", []);

app.controller("ContactCrt", function ($scope, $http) {
    //add data
    $scope.btntext = "save";
    $scope.savedata = function () {
        $scope.btntext = "please wait";
        console.log($scope.contact);
        $http({
            method: 'POST',
            url: '/Contact/contacts',
            data: $scope.contact
        }).then(function (d) {
            $scope.contact = null;
            $scope.btntext = "save";
            console.log(d);
            alert(d.data);
        }), function () {
            alert('failed');
        }
    };
    //view
    $http.get("/Contact/Get_info_contact").then(function (d) {
        $scope.contact = d.data;
    }, function (error) {
        alert('failed');
    }); 

})