var injector = angular.injector(['rx']);
//var rxEncoder = injector.get('rxEncode');
app.config(['$routeProvider', 'tempConfig', '$locationProvider', function ($routeProvider, tempConfig, $locationProvider) {
    $routeProvider.when(tempConfig.hashurl.signIn, {
        controller: tempConfig.controllers.userAuthenticationCtrl,
        templateUrl: tempConfig.getTemplate("User/SignIn/SignIn")
    }).when(tempConfig.hashurl.signUp, {
        controller: tempConfig.controllers.userCtrl,
        templateUrl: tempConfig.getTemplate("User/SignUp/SignUp")
    }).when(tempConfig.hashurl.dashboard, {
        controller: tempConfig.controllers.userCtrl,
        templateUrl: tempConfig.getTemplate("User/Dashboard/Dashboard")
    }).when(tempConfig.hashurl.putUser, {
        controller: tempConfig.controllers.userCtrl,
        templateUrl: tempConfig.getTemplate("User/PutUser/PutUser")
    }).when(tempConfig.hashurl.userList, {
        controller: tempConfig.controllers.adminCtrl,
        templateUrl: tempConfig.getTemplate("Admin/Users/UserList/UserList")
    }).when(tempConfig.hashurl.viewUser, {
        controller: tempConfig.controllers.adminCtrl,
        templateUrl: tempConfig.getTemplate("Admin/Users/ViewUser/ViewUser")
    }).when(tempConfig.hashurl.productList, {
        controller: tempConfig.controllers.adminCtrl,
        templateUrl: tempConfig.getTemplate("Admin/Products/ProductList/ProductList")
    }).when(tempConfig.hashurl.postProduct, {
        controller: tempConfig.controllers.adminCtrl,
        templateUrl: tempConfig.getTemplate("Admin/Products/PostProduct/PostProduct")
    }).when(tempConfig.hashurl.putProduct, {
        controller: tempConfig.controllers.adminCtrl,
        templateUrl: tempConfig.getTemplate("Admin/Products/PutProduct/PutProduct")
    }).when(tempConfig.hashurl.viewProduct, {
        controller: tempConfig.controllers.adminCtrl,
        templateUrl: tempConfig.getTemplate("Admin/Products/ViewProduct/ViewProduct")
    }).when(tempConfig.hashurl.sonyProducts, {
        controller: tempConfig.controllers.userCtrl,
        templateUrl: tempConfig.getTemplate("User/Brands/Sony/SonyProducts")
    }).when(tempConfig.hashurl.pumaProducts, {
        controller: tempConfig.controllers.userCtrl,
        templateUrl: tempConfig.getTemplate("User/Brands/Puma/PumaProducts")
        })
        .when(tempConfig.hashurl.Cart, {
            controller: tempConfig.controllers.cartCtrl,
            templateUrl: tempConfig.getTemplate("User/Cart/ShoppingCart")
        })
      
}]);