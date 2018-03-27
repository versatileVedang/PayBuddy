'use strict';
app.factory("userDs", ['clientcontext', function userDs(clientcontext) {
    var key = 'userDs',
        userDs = {
            getby:
            {
                Users: '/api/user/getUser'
            },

            post:
            {
                Users: '/api/user'
            },

            put:
            {
                Users: '/api/user'
            }
        };
    return clientcontext.initializeApi(userDs, key);
}]);