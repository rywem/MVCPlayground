﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url" : "/admin/frequency/GetAll",
            "type": "GET",
            "datatype" : "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "frequencyCount", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Frequency/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width 100px'>
                                    <i class='fas fa-pen'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Frequency/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px'>
                                    <i class='fas fa-trash'></i> Delete
                                </a>
                                &nbsp;
                            </div>                            
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable" : "No records found"
        },
        "width" : "100%"
    });
}

function Delete(url) {
    // Use Sweet Alert to give popup confirming delete.
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the content!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, Delete it.",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}