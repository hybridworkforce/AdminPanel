var app = angular.module("QueueApp", []);

app.controller("queuecrl", function ($scope, $http, $window) {

    //ADD_queue
    $scope.btnsubmit = 'save';
    $scope.savedata = function () {
        $scope.btnsubmit = "please wait";
        console.log($scope.queue);
        $http({
            method: 'POST',
            url: '/queue/Add_queue',
            data: $scope.queue
        }).then(function (d) {
            $scope.queue = null;
            $scope.btnsubmit = 'save';
            console.log(d);
            alert(d.data);
        }), function () {
            alert('failed');
        }
    }
    //All user info view
    $http.get("/queue/get_queue").then(function (d) {
        $scope.queue = d.data;
    }, function (error) {
        alert('failed');
    });
    //reports
    $scope.PdfReportque = function () {
        $window.open("/Queuemanagement/ExportPdfqu");
    };
    //report Excel
    $scope.ExcelReportque = function () {
        $window.open("/Queuemanagement/ExportExcelqu");
    };
});