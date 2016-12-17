var ajaxHelper = new AjaxHelper();

$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //已选择的行ID
    selections = [];
});


var $table = $("#editable-sample");

//多选删除
$("#DeleteAll").click(function () {
    selections = getIdSelections();

    bootbox.confirm({
        message: "确定删除所选数据?",
        buttons: {
            confirm: {
                label: '确定',
                className: 'btn-success'
            },
            cancel: {
                label: '取消',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                //然后发送异步请求的信息到后台删除数据 
                delcallback = function (data) {
                    if (data) {
                        //后台删除成功后，前台移除元素
                        $table.bootstrapTable('remove', {
                            field: 'ID',
                            values: selections
                        });

                        bootbox.alert({
                            message: "删除成功",
                            size: 'small',
                            backdrop: true
                        });
                    }
                }
                ajaxHelper.delete("/api/NewsApi/DeleteByIDList?ids=" + selections, null, delcallback);
            }
        }
    });
})

//初始化select的change事件
$("#sel_exportoption").change(function () {
    $table.bootstrapTable('refreshOptions', {
        exportDataType: $(this).val()
    });
});

//获取选中行ID
function getIdSelections() {
    return $.map($table.bootstrapTable('getSelections'), function (row) {
        return row.ID
    });
}


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#editable-sample').bootstrapTable({
            url: '/api/NewsApi/GetAll',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            dataType: "json",
            striped: true,                      //是否显示行间隔色
            cache: true,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "client",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 5,                       //每页的记录行数（*）
            pageList: [5, 10, 20],        //可供选择的每页的行数（*）
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: false,                //是否启用点击选中行 
            uniqueId: "ID",                     //每一行的唯一标识，一般为主键列
            showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //适用于移动设备
            search: true,
            sortable: true,
            silentSort: true,
            strictSearch: false,
            showExport: true,                     //是否显示导出
            exportDataType: "basic",              //basic', 'all', 'selected'.
            columns: [{
                checkbox: true
            }, {
                field: 'ID',
                title: '编号',
                align: 'center',
                sortable: true
            }, {
                field: 'Title',
                title: '标题',
                align: 'center',
                sortable: true
            }, {
                field: 'Author',
                title: '作者',
                align: 'center',
                sortable: true
            },
            {
                field: 'Source',
                title: '来源',
                align: 'center',
                sortable: true
            },
            {
                field: 'IsElite',
                title: '是否推荐',
                align: 'center',
                sortable: true
            }, {
                field: 'operation',
                title: '操作',
                align: 'center',
                formatter: function (value, row, index) {
                    var s = '<a class="btn btn-primary btn-xs" href="/WebAdmin/News/Edit/' + row.ID + '"><i class="fa fa-pencil"></i></a>';
                    var d = '<a class="btn btn-danger btn-xs" name="del"><i class="fa fa-trash-o"></i></a>';
                    return s + ' ' + d;
                },
                events: 'operateEvents'
            }],
            paginationPreText: "上一页",
            paginationNextText: "下一页"
        });

    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset  //页码
        };
        return temp;
    };
    return oTableInit;
};

window.operateEvents = {
    'click a[name="del"]': function (e, value, row, index) {
        bootbox.confirm({
            message: "确定删除所选数据?",
            buttons: {
                confirm: {
                    label: '确定',
                    className: 'btn-success'
                },
                cancel: {
                    label: '取消',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    //然后发送异步请求的信息到后台删除数据 
                    delcallback = function (data) {
                        if (data) {
                            //后台删除成功后，前台移除元素
                            $table.bootstrapTable('remove', {
                                field: 'ID',
                                values: [row.ID]
                            });

                            bootbox.alert({
                                message: "删除成功",
                                size: 'small',
                                backdrop: true
                            });
                        }
                    }
                    ajaxHelper.delete("/api/NewsApi/DeleteNews?id=" + row.ID, null, delcallback);
                }
            }
        });
    }
};
