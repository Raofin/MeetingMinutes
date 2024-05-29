
var rowData = [
    { sl: 1, productName: "Product A", quantity: 10, unit: "kg", edit: true, delete: false },
    { sl: 2, productName: "Product B", quantity: 20, unit: "pieces", edit: true, delete: true },
];

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
            return "<button class='btn btn-danger' style='padding: 2px 10px'>Delete</button>";
        },
        sortable: true,
        filter: true,
        headerClass: "center-header",
        resizable: false,
    },
];

var gridOptions = {
    columnDefs: columnDefs,
    rowData: rowData,
    domLayout: "autoHeight",
    defaultColDef: {
        resizable: true,
    },
    rowDrag: true,
    rowDragEntireRow: true,
    rowDragManaged: true,
    alwaysShowVerticalScroll: true,
};

gridOptions.onCellMouseOver = function (event) {
    if (event.event.target && event.event.target.offsetParent.classList.contains("ag-row")) {
        event.event.target.offsetParent.setAttribute("draggable", "true");
        event.event.target.offsetParent.addEventListener(
            "dragstart",
            function (e) {
                e.dataTransfer.setData("text/plain", "dummy");
            },
            true
        );
    }
};

var eGridDiv = document.querySelector("#myGrid");
new agGrid.Grid(eGridDiv, gridOptions);

document.getElementById("myGrid").style.maxHeight = "500px";
