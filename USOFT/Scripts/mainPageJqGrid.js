jQuery(document).ready(function () {
    $("#grid").jqGrid({
        url: "/Main/GetUserData",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['UserId', 'User Name', 'NIK', 'Branch Name', 'Privililage', 'Is Active'],
        colModel: [
            { key: true, Name: true, name: 'UserId', index: 'UserId', editable: true },
            { key: false, name: 'UserName', index: 'UserName', editable: true },
            { key: false, name: 'NIK', index: 'NIK', editable: true },
            { key: false, name: 'BranchName', index: 'BranchName', editable: true },
            { key: false, name: 'PrivilegeName', index: 'PrivilegeName', editable: true },
            { key: false, name: 'IsActive', index: 'IsActive', editable: true, edittype: 'select', editoptions: { value: { 'A': 'Active', 'I': 'InActive' } } }],
        pager: jQuery('#pager'),
        rowNum: 20,
        rowList: [10, 20, 30, 40],
        height: "auto",
        width: '70',
        viewrecords: false,
        caption: 'UserId',
        
        emptyrecords: 'No records to display',
        jsonReader: {
           
            page: "page",
            total: "total",
            records: "records",
            cell: "cell",
            repeatitems: false,
            Id: "id",
            root: function (obj) {
                return obj;
        },

        autowidth: true,
        multiselect: false
        }).navGrid('#pager', { edit: true, add: true, del: true, search: false, refresh: true },
            {
                // edit options
                zIndex: 100,
                url: '/TodoList/Edit',
                closeOnEscape: true,
                closeAfterEdit: true,
                recreateForm: true,
                afterComplete: function (response) {
                    if (response.responseText) {
                        alert(response.responseText);
                    }
                }
            },
        //    {
        //        // add options
        //        zIndex: 100,
        //        url: "/TodoList/Create",
        //        closeOnEscape: true,
        //        closeAfterAdd: true,
        //        afterComplete: function (response) {
        //            if (response.responseText) {
        //                alert(response.responseText);
        //            }
        //        }
        //    },
        //    {
        //        // delete options
        //        zIndex: 100,
        //        url: "/TodoList/Delete",
        //        closeOnEscape: true,
        //        closeAfterDelete: true,
        //        recreateForm: true,
        //        msg: "Are you sure you want to delete this task?",
        //        afterComplete: function (response) {
        //            if (response.responseText) {
        //                alert(response.responseText);
        //            }
        //        }
        //    });

    });

    //    if (rowid && rowid !== lastsel) {

    //        if (lastsel)
    //            jQuery('#grid').jqGrid('restoreRow', lastsel);
    //        jQuery('#grid').jqGrid('editRow', rowid, true);
    //        lastsel = rowid;
    //    }
    //    function getColDescription(colName, jqGridSelector) {
    //        var description = '';
    //        if (colName != '') {
    //            var colModel = $(jqGridSelector).getGridParam('colModel');
    //            $.each(colModel, function (index, model) {
    //                if (model.name == colName) {
    //                    description = model.description;
    //                    return false;
    //                }

    //            });
    //        }

    //        return description;
    //    }

});