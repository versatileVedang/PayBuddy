'use strict';
app.factory("cartDs", ['clientcontext', function cartDs(clientcontext)
{
    var key = 'cartDs',
        cartDs =
            {
                getby:
                {
                    Carts: 'api/cart/getItem'
                },

                get:
                {
                     Carts: 'api/cart'
                },

                post:
                {
                    Carts: 'api/cart'
                },

                del:
                {
                    Carts: 'api/cart'
                }
            };

    return clientcontext.initializeApi(cartDs,key);

}]);