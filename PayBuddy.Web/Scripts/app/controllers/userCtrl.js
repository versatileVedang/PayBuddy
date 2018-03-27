﻿
app.controller("userCtrl", ['$scope', '$location', 'ds', 'response', 'request', function userCtrl($scope, $location, ds, response, request) {

    $scope.initUser = function () {
        $scope.displayName = localStorage.getItem("name");
    };
    $scope.signOut = function () {
        localStorage.removeItem("name");
        window.open("Index#/signIn", "_ self");
    };


    $scope.signUp = function (user) {
        rx.progress.show();
        var gender = parseInt(user.gender);
        var contact = parseInt(user.contact);
        if ($scope.user !== null && $scope.user !== undefined) {
            var users = {
                firstName: user.firstName,
                lastName: user.lastName,
                password: user.password,    
                email: user.email,
                genderId: gender,
                address: user.address,
                contact: contact
            };
            ds.user.postUsers.post(users).then(function (jsonResult) {
                rx.progress.hide();
                response.redirect('/signIn');
                $scope.$apply();
            });
        }
        else {
            rx.log.error("Error");
        }
    };

    $scope.redirectToPutUser = function () {
        var id = parseInt(localStorage.getItem('userRef'));
        response.redirect('/putUser/' + id);
    };

    $scope.initPutUser = function () {
        var myTabObj = [
            {
                "title": "Basic Profile",
                "url": "/Templates/User/BasicProfile/BasicProfile.html",
                "selected": true,
                "icon": "glyphicon glyphicon-pushpin",
                "iconTitle": "Basic Profile"
            },
            {
                "title": "Change Password",
                "url": "/Templates/User/ChangePassword/ChangePassword.html",
                "icon": "glyphicon glyphicon-thumbs-up",
                "iconTitle": "Change Password"
            }
        ];
        $scope.myTabObj = myTabObj;
        $scope.myActiveTab = 0;
        $scope.myChangeData = false;
        $scope.cssclass = {
            headerclass: "sidebar-right-control",
            contentclass: "sidebar-right-content"
        };
    };

    $scope.initPutProfile = function () {
        var userId = parseInt(localStorage.getItem('userRef'));
        ds.user.getByUsers.get({ id: userId }).then(function (jsonResult) {
            $scope.user = jsonResult;
            var gender = jsonResult.genderId.toString();
            var contact = jsonResult.contact.toString();
            $scope.user.contact = contact;
            rx.progress.hide();
            $scope.$apply();
        });
    };

    $scope.updateProfile = function (user) {
        rx.progress.show();
        var userId = parseInt(localStorage.getItem('userRef'));
        if ($scope.user !== null && $scope.user !== undefined) {
            var gender = parseInt(user.genderId);
            var contact = parseInt(user.contact);
            var users = {
                userId: userId,
                firstName: user.firstName,
                lastName: user.lastName,
                email: user.email,
                genderId: gender,
                address: user.address,
                contact: contact,
                roleId: user.roleId
            };
            ds.user.putUsers.put(users).then(function (jsonResult) {
                rx.progress.hide();
                response.redirect('/dashboard');
                $scope.$apply();
            });
        }
        else {
            rx.log.error("Error");
        }
    };

    $scope.updatePassword = function (user) {
        rx.progress.show();
        var userId = parseInt(localStorage.getItem('userRef'));
        if ($scope.user !== null && $scope.user !== undefined) {
            var users = {
                userId: userId,
                password: user.newPassword
            };
            ds.user.putUsers.put(users).then(function (jsonResult) {
                rx.progress.hide();
                response.redirect('/dashboard');
                $scope.$apply();
            });
        }
    };


   

}]);

