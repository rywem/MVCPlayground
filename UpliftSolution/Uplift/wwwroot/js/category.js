﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

//Source video: https://www.udemy.com/course/master-aspnet-core-3-advanced/learn/lecture/15532028#overview  (c41)
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url" : "/admin/category/GetAll",
            "type": "GET",
            "datatype" : "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "displayOrder", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Category/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Category/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>
                                &nbsp;
                            </div>
                            `;
                }, "width" : "30%"
            }
        ], 
        "language": {
            "emptyTable" : "No records found"
        },
        "width" : "100%"
    });
}