var app = angular.module("QueueApp", []);

app.controller("queuecrl", function ($scope, $http) {

    //ADD_queue
    $scope.btnsubmit = 'save';
    $scope.savedata = function () {
        $scope.btnsubmit = "please wait";
        console.log($scope.queue);
        $http({
            method: 'POST',
            url: '/QueueMgtCtrl/Add_queue',
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
    $http.get("/Queuemanagement/get_queuemgt").then(function (d) {
        $scope.queue = d.data;
    }, function (error) {
        alert('failed');
    });
});