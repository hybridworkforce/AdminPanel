var app = angular.module("RuleApp", []);

app.controller('RuleCtrl', function ($scope, $http, $window) {

    //all detailes
    $http.get("/Rulebook/Get_rule").then(function (d) {
        $scope.supplieronboard = d.data;
    }, function (error) {
        alert('failed');
    });
    //by id rule
    $scope.loadrecord = function (id) {
        $http.get("/Rulebook/Get_ruleid?id=" + id).then(function (d) {
            $scope.supplieronboard = d.data[0];
        }, function (error) {
            alert('failed');
        });
    };
    // Update rule
    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        console.log($scope.supplieronboard);
        $http({
            method: 'POST',
            url: '/Rulebook/updated_rules',
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
    //reports
    $scope.PdfReport = function () {
        $window.open("/Rulebook/ExportPdf");
    };
    //report Excel
    $scope.ExcelReport = function () {
        $window.open("/Rulebook/ExportExcel");
    };

});