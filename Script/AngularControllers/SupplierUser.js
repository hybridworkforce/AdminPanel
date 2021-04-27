var app = angular.module("SuppproApp", []);

app.controller('SuppproController', function ($scope, $http, $window) {
    //add
    $scope.btntext = "Save";
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..";
        console.log($scope.supplieronboard);
        $http({
            method: 'POST',
            url: '/SupplierPro/supplier',
            data: $scope.supplieronboard,
            dataType: 'json'
        }).then(function (d) {
            $scope.supplieronboard = null;
            $scope.btntext = 'Save';
            console.log(d);
            alert(d.data);
        }), function () {
            alert('Failed..!!');
        }
    };

    //all detailes
    $http.get("/SupplierPro/Getprosupplier").then(function (d) {
        $scope.supplieronboard = d.data;
    }, function (error) {
        alert('failed');
    });

    //All user info view by id
    $scope.loadrecord = function (id) {
        $http.get("/SupplierPro/Get_supplierid?id=" + id).then(function (d) {
            $scope.supplieronboard = d.data[0];
        }, function (error) {
            alert('failed');
        });
    };

    // Delete record 
    $scope.deleterecord = function (id) {
        $http.get("/SupplierPro/delete_supplier?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/SupplierPro/Get_supplier").then(function (d) {
                $scope.supplieronboard = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    // Update record
    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        console.log($scope.supplieronboard);
        $http({
            method: 'POST',
            url: '/SupplierOnboard/update_record',
            data: $scope.supplieronboard
        }).then(function (d) {
            $scope.supplieronboard = null;
            $scope.btntext = 'Update';
            console.log(d);
            alert(d.data);
        }), function () {
            alert('Failed');
        }
    };


    //reports pdf
    $scope.PdfReportsp = function () {
        $window.open("/Report/SpExportPdf");
    };
    //report Excel
    $scope.ExcelReportsp = function () {
        $window.open("/Report/SpExportExcel");
    };


});
