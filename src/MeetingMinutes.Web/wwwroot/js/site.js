﻿$('input[name="userType"]').on('change', function () {
    var userType = $(this).val();

    $.get('/api/customers/' + userType, function (data) {
        $('#customer-name').empty().append('<option selected disabled>Select customer name...</option>');
        $.each(data, function (_index, customer) {
            $('#customer-name').append($('<option></option>').attr('value', customer.customerId).text(customer.customerName));
        });
    }).fail(function () {
        console.error('Failed to load customers');
    });
});

var products = [];
var slCounter = 1;

$('#add-item').on('click', function (e) {
    e.preventDefault();

    if ($('#product-name option:selected').is(':disabled')) {
        toastMessage("Please select an interested product or service.")
        return;
    }

    var productName = $('#product-name option:selected').text();
    var quantity = $('#quantity').val();
    var unit = $('#unit').val();
    var productId = $('#product-name').find('option:selected').val();

    var newData = {
        sl: slCounter,
        productName: productName,
        quantity: quantity || 'N/A',
        unit: unit || 'N/A',
        productServiceId: productId,
    };
    slCounter++;

    gridApi.applyTransaction({
        add: [newData],
    });
    products.push(newData);
});

function removeSelected() {
    setTimeout(() => {
        const selectedData = gridApi.getSelectedRows();
        gridApi.applyTransaction({ remove: selectedData });
        products = products.filter(product => product.sl !== selectedData.sl);
    }, 10);
}

function remove(sl) {
    gridApi.forEachNode(function (node) {
        if (node.data.sl === sl) {
            gridApi.applyTransaction({
                remove: [node.data],
            });
        }
    });
}

$("#meeting-form").validate({
    // Specify validation rules
    rules: {
        CustomerType: {
            required: true,
            minlength: 1
        },
        CustomerId: {
            required: true
        },
        Place: {
            required: true,
            minlength: 5,
            maxlength: 200
        },
        ClientSide: {
            required: true,
            minlength: 5
        },
        HostSide: {
            required: true,
            minlength: 5
        },
        Agenda: {
            required: true,
            minlength: 5
        },
        Discussion: {
            required: true,
            minlength: 5
        },
        Decision: {
            required: true,
            minlength: 5
        }
    },
    submitHandler: function (form) {
        let data = $(form).serializeArray().reduce((obj, item) => {
            obj[item.name] = item.value;
            return obj;
        }, {});

        data.ProductServices = products;

        const dateInput = $('#date');
        const timeInput = $('#time');

        // Ensure the date and time values are present
        if (dateInput.val() && timeInput.val()) {
            data.Datetime = `${$('#date').val()}T${$('#time').val()}`;
        } else if (dateInput.val()) {
            data.Datetime = `${$('#date').val()}T00:00`;
        }

        console.log(data);

        $.ajax({
            url: '/',
            type: "POST",
            data: data,
            success: () => {
                toastMessage('Meeting saved successfully!', ToastColor.Green)
            },
            error: () => {
                toastMessage('Internal server error. Please try again later.')
            }
        });

        // No need to return false here since we handle form submission manually
    }
});
