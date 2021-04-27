/*var app = angular.module("SuppproApp", []).directive('fileModel', ['$parse', function ($parse) {
    return {
        scope: true,
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var files = event.target.files;
                console.log("files", files);
                //iterate files since 'multiple' may be specified on the element
                if (files.length == 0) {
                    scope.$emit("fileSelected", { file: null, field: event.target.name });
                } else {
                    for (var i = 0; i < files.length; i++) {
                        //emit event upward
                        scope.$emit("fileSelected", { file: files[i], field: event.target.name });
                    }
                }
            });
        }
    };
}]);

app.controller('SuppproController', function ($scope, $http) {
    $scope.$on("fileSelected", function (event, args) {
        $scope.$apply(function () {
            console.log("args.file", args.file);
            switch (args.field) {
                case "file_uploder":
                    $scope.supplieronboard.file_uploder = args.file;
                    break;
                default:
                    break;
            }
        });
    });

    //add
    $scope.btntext = "Save";
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..";
        console.log($scope.supplieronboard);
        $http({
            method: 'POST',
            url: '/SupplierPro/Addsupplier',
            data: $scope.supplieronboard,
            dataType: 'json'
        }).then(function (d) {
            $scope.btntext = 'Save';
            console.log(d);
            alert(d.data);
            if (d.data > 0)
                $scope.uploadFile(d.data);
            else
                alert("Failed");
            // $scope.supplieronboard = null;
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
    // Delete record 
    $scope.deleteprorecord = function (id) {
        $http.get("/SupplierPro/deletesupplier?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/SupplierPro/Getprosupplier").then(function (d) {
                $scope.supplieronboard = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    // File Uploader
    $scope.uploadFile = function (sid) {
        console.log("file_uploder", $scope.supplieronboard.file_uploder);

        var fd = new FormData();
        angular.forEach($scope.supplieronboard.file_uploder, function (file) {
       
            fd.append('file', file);
        };
        fd.append('sid', sid);
        console.log("fd", fd);
        $http({
            method: 'POST',
            url: '/SupplierPro/doc_files',
            headers: { 'Content-Type': undefined },
            data: fd
        }).then(function (data) {
            
            // SUCCESS MESSAGE
        })
    }
);*/
