'use strict';
app.factory("ds", ['userDs', 'adminDs' ,'cartDs',function ds(userDs, adminDs,cartDs) {
    return {
        user: userDs,
        admin: adminDs,
        cart : cartDs
    };
}]);