
    $('#buttonSearch').click(function () {
        $("#grid").jqGrid({
            url: "/IT/GetITTaskList",
            datatype: 'JSON',
            mtype: "POST",

            postData: {

                ParamField: function () {
                    return $("#ParamField option:selected").val();
                },

                DepartementCode: (function () {
                    return $("#Date").val();
                }),
                BranchId: (function () {
                    return $("#Branch option:selected").val();
                }),
                BranchId: (function () {
                    return $("#ProblemType option:selected").val();
                }),
                BranchId: (function () {
                    return $("#ItemType option:selected").val();
                }),
                BranchId: (function () {
                    return $("#PIC option:selected").val();
                }),
                BranchId: (function () {
                    return $("#TerminatedBy option:selected").val();
                }),
                BranchId: (function () {
                    return $("#Priority option:selected").val();
                }),
                BranchId: (function () {
                    return $("#Status option:selected").val();
                }),
            },
            colNames: ['No', 'Date', 'User', 'Branch', 'Problem Type', 'Type','Priority','Status','PIC','Terminated By','Action'],
            colModel: [
                { key: true, Name: true, name: 'ActivityNo', editable: true },
                { key: false, name: 'ActivityDate', editable: true },
                { key: false, name: 'UserName', editable: true },
                { key: false, name: 'BranchName', editable: true },
                { key: false, name: 'Type', editable: true },
                { key: false, name: 'Priority', editable: true },
                { key: false, name: 'Status', editable: true },
                { key: false, name: 'PIC', editable: true },
                { key: false, name: 'TerminatedBy', editable: true },
                { key: false, name: 'IsActive', editable: true, edittype: 'select', editoptions: { value: { 'A': 'Active', 'I': 'InActive' } } },
                {
                    name: 'Edit', title: false,
                    formatter: function (cellvalue, options, rowObject) {
                        return '<a href="/Main/Edit?value=' + rowObject.UserId + '">' +
                            "Edit" + "</a>";
                    }
                }
            ],

            pager: '#pager',
            rowNum: 10,
            rowList: [10, 20, 30, 40],
            height: '80%',
            width: '70%',
            viewrecords: true,
            caption: 'UserId',
            emptyrecords: 'No records to display',

            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                cell: "cell",
                id: "id",
                userdata: "userdata",
            },

            multiselect: false
        })
        $("#grid").trigger("reloadGrid", [{ page: 1 }]);

    });

