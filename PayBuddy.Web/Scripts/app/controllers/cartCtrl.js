app.controller("cartCtrl", ['$scope', '$location', 'ds', 'response', function cartCtrl($scope, response, ds, response) {

    $scope.addProduct = function (item) {

        var id = parseInt(localStorage.getItem('userRef'));
        if (item !== null && item !== undefined) {
            var items = {
                userId: id,
                productId: item.productId,
                subTotal: item.cost,
                quantity: 1
            };
            ds.cart.postCarts.post(items).then(function (jsonResult) {
                debugger
                rx.log.success("Product Added.")
                $scope.$apply();
            });
        }
        else {
        }

    };

    $scope.getProducts = function () {
        var userId = parseInt(localStorage.getItem('userRef'));
        ds.cart.getByCarts.get({ id: userId }).then(function (jsonResult) {
            $scope.cartList = jsonResult;
            $scope.getTotal();
            $scope.$apply();
        });


    };

    $scope.removeItem = function (item) {
        debugger
        var userId = parseInt(localStorage.getItem('userRef'));
        ds.cart.deleteCarts.del(item).then(function (jsonResult) {
            if (jsonResult == "Item Deleted.") {
                var data = rx.linq(angular.copy($scope.cartList)).where("t => t.cartId != " + item.cartId).toList()
                $scope.cartList = data;
                $scope.getTotal();
            }
            else {
                rx.log.error("delete operation failed.")
            }
            $scope.$apply();
        });
    };




    //display product list
    $scope.viewProduct = function () {
        $scope.product = {};
        ds.admin.getProducts.get().then(function (jsonResult) {
            $scope.productList = jsonResult;
            console.log($scope.productList);
            //$scope.arr = $scope.product.length;
            $scope.$apply();
        });
    };


    $scope.getSubTotal = function (item) {
        debugger
        item.subTotal = item.quantity * item.cost;
        var cartList = rx.json.del($scope.cartList, item);
        cartList.push(item);
        $scope.cartList = cartList;
        $scope.getTotal();
    }

    $scope.getTotal = function ()
    {
        //var array = rx.linq($scope.cartList).select("x=>x.subTotal");
        var array = $scope.cartList.map(a => a.subTotal);
        $scope.total = rx.linq(array).sum("a=>a");
    }

}]);