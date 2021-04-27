var app = angular.module("signIt", ["signIt"]);

app.controller("SignCtrl", function ($scope) {
    $scope.init = function () {
        $scope.newSignature = {};
        $scope.signatures = [];

        $scope.moveToList = [];
        $scope.lineToList = [];

    };
    
    $scope.addSign = function (newSignature) {
        newSignature.Sign = { "moveToList": $scope.moveToList, "lineToList": $scope.lineToList };
        $scope.signatures.push(newSignature);
        $scope.newSignature = {};
        $scope.clear();
    };

    $scope.clear = function () {
        var canvas = document.getElementById('canvas');
        var context = canvas.getContext('2d');
        context.clearRect(0, 0, 900, 300);
        $scope.moveToList = [];
        $scope.lineToList = [];
        $scope.newSignature = {};
    };
	
	$scope.init();

});

app.directive("drawing", function () {
    return {
        restrict: "A",
        link: function (scope, element) {
            var ctx = element[0].getContext('2d');

            var drawing = false;

            var lastX;
            var lastY;

            element.bind('mousedown', function (event) {
                if (event.offsetX !== undefined) {
                    lastX = event.offsetX;
                    lastY = event.offsetY;
                } else {
                    lastX = event.layerX - event.currentTarget.offsetLeft;
                    lastY = event.layerY - event.currentTarget.offsetTop;
                }

                ctx.beginPath();

                drawing = true;
            });
            element.bind('mousemove', function (event) {
                if (drawing) {

                    if (event.offsetX !== undefined) {
                        currentX = event.offsetX;
                        currentY = event.offsetY;
                    } else {
                        currentX = event.layerX - event.currentTarget.offsetLeft;
                        currentY = event.layerY - event.currentTarget.offsetTop;
                    }

                    draw(lastX, lastY, currentX, currentY);

                    lastX = currentX;
                    lastY = currentY;
                }

            });
            element.bind('mouseup', function (event) {
                drawing = false;
            });

            function draw(lX, lY, cX, cY) {

                ctx.moveTo(lX, lY);

                ctx.lineTo(cX, cY);

                ctx.strokeStyle = "#4bf";

                ctx.stroke();

                var objMoveTo;
                var objLineTo;

                objMoveTo = { "lx": lX, "ly": lY };
                objLineTo = { "cx": cX, "cy": cY };

                scope.moveToList.push(objMoveTo);
                scope.lineToList.push(objLineTo);
            }



        }
    };
});

app.directive("redraw", function () {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            var ctx = element[0].getContext('2d');

            ctx.beginPath();

            var indexSign = attrs.index;

            for (var i = 0; i < scope.signatures[indexSign].Sign.moveToList.length; i++) {
                draw(scope.signatures[indexSign].Sign.moveToList[i].lx, scope.signatures[indexSign].Sign.moveToList[i].ly, scope.signatures[indexSign].Sign.lineToList[i].cx, scope.signatures[indexSign].Sign.lineToList[i].cy);
            }

            function draw(lX, lY, cX, cY) {

                ctx.moveTo(lX, lY);

                ctx.lineTo(cX, cY);

                ctx.strokeStyle = "#4bf";

                ctx.stroke();
            }
        }
    };
});

app.directive("validateForm", function () {
    return {
        restrict: 'A',
        require: '^form',
        link: function (scope, el, attrs, formCtrl) {
            var inputEl = el[0].querySelector("[name]");
            var inputNgEl = angular.element(inputEl);
            var inputName = inputNgEl.attr('name');

            inputNgEl.on('change', function () {
                el.toggleClass('has-error', formCtrl[inputName].$invalid && formCtrl[inputName].$dirty);
            }
            );
        }
    }
});
