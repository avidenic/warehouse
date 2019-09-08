'use strict';

var connection = new signalR.HubConnectionBuilder().withUrl('/product-status').build();

connection.on('customers', function (data) {
    var customers = document.getElementById('customers');
    if (!customers) {
        return;
    }
    customers.innerHTML = '';
    for (var i = 0; i < data.length; i++) {
        var li = document.createElement('li');
        var customer = data[i];
        li.id = customer.name;
        li.appendChild(getText(customer));
        customers.appendChild(li);
    }
});

connection.on('update', function (data) {
    var customer = document.getElementById(data.name);
    customer.innerHTML = '';
    customer.appendChild(getText(data));
});

var getText = function(customer) {
    return document.createTextNode('Customer "' + customer.name + '", product quantity: ' + customer.quantity);
}

connection.start();
