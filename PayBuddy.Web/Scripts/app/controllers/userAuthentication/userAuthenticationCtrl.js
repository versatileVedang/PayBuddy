app.controller("userAuthenticationCtrl", ['$scope', '$http', function userAuthenticationCtrl($scope, $http) {

    $scope.initSignIn = function () {
        $scope.user = {};
    };

    $scope.signIn = function (user) {
        $http({
            method: "POST",
            url: "api/userAuthentication",
            data: { email: user.email, password: user.password }
        }).then(function mySuccess(response) {
            if (response.data.message === true) {

                if (response.data.data.roleId == 2) {
                    var displayName = response.data.data.firstName;
                    localStorage.setItem("name", displayName);
                    localStorage.setItem("userRef", response.data.data.userId);
                    window.open("User#/dashboard", "_self");
                }
                else {
                    var displayName = response.data.data.firstName;
                    localStorage.setItem("name", displayName);
                    window.open("Admin", "_self");
                }
                
            }
            else if (response.data == "4") {
                $scope.authMessage = "Password is not correct";
            }
            else if (response.data == "5") {
                $scope.authMessage = "Email Does Not Exist";
            }
            else {
                $scope.authMessage = "Please Enter Your Email and Password";
            }
        }, function myError(response) {
            alert("Something went wrong");
        });
    };
}]);

