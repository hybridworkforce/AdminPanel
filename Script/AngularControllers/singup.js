var app = angular.module("SingupApp", []);

app.controller("SingupController", function ($scope, $http, $window) {

    //ADD_USER
    $scope.btnsubmit = 'save';
    $scope.savedata = function () {
        $scope.btnsubmit = "please wait";
        console.log($scope.registration);
        $http({
            method: 'POST',
            url: '/Reg/Regsiter',
            data: $scope.registration,
            dataType: 'json'
        }).then(function (d) {
            $scope.registration = null;
            $scope.btnsubmit = 'save';
            console.log(d);
            alert(d.data);
        }),function () {
            alert('failed');
        }
    }

    //All user info view
    $http.get("/Reg/Get_user").then(function (d) {
        $scope.registration = d.data;
    }, function (error) {
        alert('failed');
    });

   

    //All user info view by id
    $scope.loadrecord = function (id) {
        $http.get("/Reg/Get_userbyid?id="+id).then(function (d) {
            $scope.registration = d.data[0];
        }, function (error) {
            alert('failed');
        });
    };
    // Update record
    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        console.log($scope.registration);
        $http({
            method: 'POST',
            url: '/Reg/update_record',
            data: $scope.registration
        }).then(function (d) {
            $scope.registration = null;
            $scope.btntext = "Update";
            console.log(d);
            alert(d.data);
        }), (function () {
            alert('Failed');
        });
    };
    // Delete record user
   $scope.deleterecord = function (id) {
        $http.get("/Reg/delete_record?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Reg/Get_user").then(function (d) {
                $scope.registration = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    //reports
    $scope.PdfReport = function () {
        $window.open("/Reg/ExportPdf");
    };
    //report Excel
    $scope.ExcelReport = function () {
        $window.open("/Reg/ExportExcel");
    };
   
});