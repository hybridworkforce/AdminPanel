var app = angular.module("FileApp", []);

app.controller('FileCtrl', function ($scope, $http) {
    //all detailes
    $http.get("/Uplodfile/Get_file").then(function (d) {
        $scope.documents = d.data;
    }, function (error) {
        alert('failed');
    });
    // Delete recordfile
    $scope.deleterecord = function (id) {
        $http.get("/Uploadfile/deletefile?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Uplodfile/Get_file").then(function (d) {
                $scope.documents = d.data;
            }, function (error) {
                alert('Failed..!');
            });
        }, function (error) {
            alert('Failed..!!');
        });
    };
});