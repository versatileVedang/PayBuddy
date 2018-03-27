app.constant('tempConfig',
    {
        hashurl: {
            signIn: '/signIn',
            signUp: '/signUp',
            dashboard: '/dashboard',
            putUser: '/putUser/:userId',
            userList: '/userList',
            productList: '/productList',
            postProduct: '/postProduct',
            putProduct: '/putProduct/:productId',
            viewProduct: '/viewProduct/:productId',
            sonyProducts: '/sonyProducts',
            pumaProducts: '/pumaProducts',
            Cart: '/Cart'
            
        },
        controllers: {

            userAuthenticationCtrl: 'userAuthenticationCtrl',
            userCtrl: 'userCtrl',
            adminCtrl: 'adminCtrl'
        },
        getTemplate: function (tmplname) {
            return "Templates/" + tmplname + ".html";
        }
    });