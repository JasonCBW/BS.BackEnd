//全选按钮 
$("#selectAll").on("change", function () {
    if ($(this).prop("checked")) {
        //遍历所有复选框并勾选
        $("#app").find("input").each(function () {
            $(this).prop("checked", true);
        })
    }
    else {
        $("#app").find("input").each(function () {
            $(this).prop("checked", false);
        })
    }
})

//批量删除
$("#deleteAll").click(function () {
    //需要删除的ID数组
    var ids = "";
    $("#app").find("input").each(function () {
        if ($(this).prop("checked")) {
            ids += $(this).val() + ",";
        }
    })
    if (ids.length <= 0) {
        bootbox.alert("请先勾选需要删除的数据再进行本操作!");
        return;
    }
    else {
        //弹出对话确认框
        bootbox.confirm({
            message: "删除后数据将不可恢复,确定删除所选数据?",
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
                    //最后去掉最后的逗号,
                    ids = ids.substring(0, ids.length - 1);
                    //然后发送异步请求的信息到后台删除数据
                    var postData = { Ids: ids };
                    $.get("/WebAdmin/NewsClass/DeleteByIDList", postData, function (data) {
                        if (data) {
                            bootbox.alert({
                                message: data,
                                size: 'small',
                                backdrop: true,
                                callback: function () {
                                    window.location.reload();
                                }
                            })
                        }
                    });
                }
            }
        });
    }
})

//单个删除
$("a[name='delete']").click(function () {
    var id = $(this).attr("id");
    //弹出对话确认框
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
                var postData = { ID: id };
                $.get("/WebAdmin/NewsClass/DeleteByID", postData, function (data) {
                    if (data) {
                        bootbox.alert({
                            message: data,
                            size: 'small',
                            backdrop: true,
                            callback: function () {
                                window.location.reload();
                            }
                        })
                    }
                });
            }
        }
    });
})

