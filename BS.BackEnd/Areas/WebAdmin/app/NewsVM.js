﻿var ajaxHelper = new AjaxHelper()

//定义Vue组件
var vum = new Vue({
    el: ".panel",
    data: {
        PageIndex: 1,
        NewsList: []
    },
    mounted: function () {
        this.getNewsList();
    },
    computed: {
        checkAll: {
            //getter
            get: function () {
                return this.NewsList.reduce(function (prev, curr) {
                    return prev && curr.Selected;
                }, true); 
            },
            // setter
            set: function (val) {
                this.NewsList.forEach(function (item) {
                    item.Selected = val;
                });
            }
        }
    },
    methods: {
        getNewsList: function () {
            var vm = this;
            pageData = { pageIndex: vm.PageIndex };
            callback = function (data) {
                var list = JSON.parse(data);
                var pages = list["PageCount"];
                vm.NewsList = list["Rows"];
                vm.initPage(vm.PageIndex, pages);
            }
            ajaxHelper.get("/api/NewsApi/GetNewsByPage", pageData, callback)
        },
        initPage: function (pageindex, totals) {
            let element = $('.pagination')
            let options = {
                bootstrapMajorVersion: 3,
                currentPage: pageindex,
                totalPages: totals
            }
            element.bootstrapPaginator(options);
        }, 
        deleteSingle: function (index, item) {
            var vum = this;
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
                        delcallback = function (data) {
                            if (data) {
                                bootbox.alert({
                                    message: "删除成功",
                                    size: 'small',
                                    backdrop: true
                                });
                                //删除后重新加载当前页数据
                                paging(vum.PageIndex);
                            }
                        }
                        ajaxHelper.delete("/api/NewsApi/DeleteNews?id=" + item.ID, null, delcallback);
                    }
                }
            });
        }
    }
})

//分页的回调事件
function paging(page) {
    data = { pageIndex: page };
    callback = function (data) {
        var list = JSON.parse(data);
        vum.PageIndex = list["CurrentPage"];
        var pages = list["PageCount"];
        vum.NewsList = list["Rows"];
        vum.initPage(vum.PageIndex, pages);
    }
    ajaxHelper.get("/api/NewsApi/GetNewsByPage", data, callback)
}