// Initialize bootstrap toast message
const ToastColor = {
    Red: 'danger',
    Green: 'success',
    Yellow: 'warning',
    Blue: 'primary'
}

function toastMessage(message, type = ToastColor.Red, timer = 4000) {
    let container = $('#toast-container')
    if (container.length === 0) {
        container = $('<div>').attr('id', 'toast-container').css({
            'position': 'fixed',
            'z-index': 11,
            'bottom': '40px',
            'right': '0',
            'margin-right': '0.5rem',
        }).appendTo('body')
    }

    let toastDiv = $('<div>').addClass('toast align-items-center text-bg-' + type + ' border-0 mb-2')
        .attr({
            'role': 'alert',
            'aria-live': 'assertive',
            'aria-atomic': 'true',
            'data-bs-delay': timer
        })
        .html(`
            <div class="d-flex">
                <div class="toast-body" style="font-size: 1.05rem">
                    ${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
        `)

    container.append(toastDiv)
    new bootstrap.Toast(toastDiv[0]).show()
}

function toastMessageNext(message, type = ToastColor.Red, timer = 6000) {
    let toastMessage = {
        message: message,
        type: type,
        timer: timer
    }

    sessionStorage.setItem('toastMessage', JSON.stringify(toastMessage))
}


// Initialize tippy.js
tippy.setDefaultProps({
    delayanimation: 'perspective-subtle',
    theme: 'light'
})

function setTippyContent() {
    tippy('[pop]', {
        content: (reference) => reference.getAttribute('pop')
    })
}

setTippyContent()


// Initialize AG Grid
var columnDefs = [
    { headerName: "SL #", field: "sl", maxWidth: 80, flex: 0, rowDrag: (params) => !params.node.group, sortable: true, filter: true },
    { headerName: "Interested Product/Service Name", field: "productName", minWidth: 300, flex: 2, sortable: true, filter: true },
    { headerName: "Quantity", field: "quantity", maxWidth: 120, flex: 1, sortable: true, filter: true },
    { headerName: "Unit", field: "unit", maxWidth: 120, flex: 1, sortable: true, filter: true },
    {
        headerName: "Edit",
        field: "edit",
        maxWidth: 100,
        cellRenderer: function (params) {
            return "<button class='btn btn-primary' style='padding: 2px 10px'>Edit</button>";
        },
        sortable: true,
        filter: true,
        headerClass: "center-header",
    },
    {
        headerName: "Delete",
        field: "delete",
        maxWidth: 100,
        cellRenderer: function (params) {
            return `<button class='btn btn-danger' style='padding: 2px 10px' onclick='removeSelected()'>Delete</button>`;
        },
        sortable: true,
        filter: true,
        headerClass: "center-header",
        resizable: false,
    },
];

var gridOptions = {
    columnDefs: columnDefs,
    rowData: [],
    domLayout: "autoHeight",
    defaultColDef: {
        resizable: true,
    },
    rowDrag: true,
    rowDragEntireRow: true,
    rowDragManaged: true,
    alwaysShowVerticalScroll: true,
    rowSelection: "single",
};

var eGridDiv = document.querySelector("#grid");
let gridApi = agGrid.createGrid(eGridDiv, gridOptions);
$("#grid").css("max-height", "500px");