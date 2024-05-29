$('input[name="userType"]').on('change', function () {
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
        productId: productId,
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
