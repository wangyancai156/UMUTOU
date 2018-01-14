
$(function () {
    BindOrganizationTree();
    initTable();
});


function RemoveUsers(sender) {
    var url = "@Url.Action("RemoveUsers", "Users")";

    var userId = $(sender).attr("userid");
    $.post(url, { "userid": userId }, function (data) {
        //$.messeger.alert("友情提示",,)
        alert(data);
        initTable();
    });
}

function AddUsers() {

    var url = "@Url.Action("AddUsers", "Users")";
    var usersname = $("#usersname").val();
    var usersid = $("#usersid").val();
    var userspwd = $("#userspwd").val();
    var request = { "UserName": usersname, "Id": usersid, "UserPwd": userspwd };

    $.post(url, request, function (data) {
        //alert(data);
        initTable();
        CloseAddUsers();
    });
}


function ShowUpdateUsers(sender) {
    var userId = $(sender).attr("userid");
    var $table = $('#table');
    var row = $table.bootstrapTable('getRowByUniqueId', userId);

    $("#usersname").val(row.UserName);
    $("#usersid").val(row.Id);
    $("#userspwd").val(row.UserPwd);
    $('#myModal').modal('show')

}

function CloseAddUsers() {
    $('#myModal').modal('hide')
    $("#usersname").val("");
    $("#usersid").val("");
    $("#userspwd").val("");
}

function UpdateUsers(sender) {

    var url = $.Url.Action("UpdateUsers", "Users");
    var usersname = $("#usersname").val();
    var usersid = $("#usersid").val();
    var userspwd = $("#userspwd").val();
    var request = { "UserName": usersname, "Id": usersid, "UserPwd": userspwd };
    $.post(url, function (data) {
        //$.messeger.alert("友情提示",,)
        CloseAddUsers();
        alert(data);
        initTable();
    });
}

function initTable() {

    var url = "@Url.Action("GetUsersOfBootStrap", "Users")";

    $('#table').bootstrapTable('destroy');
    $("#table").bootstrapTable({
        method: "get",  //使用get请求到服务器获取数据
        url: url, //获取数据的Servlet地址
        striped: true,      //是否显示行间隔色
        dataType: "json",
        cache: false,      //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        sortable: false,      //是否启用排序
        sortOrder: "asc",     //排序方式
        pagination: true, //启动分页
        pageSize: 50,  //每页显示的记录数
        pageNumber: 1, //当前第几页
        pageList: [20, 50, 100],  //记录数可选列表
        search: false,  //是否启用查询
        //showColumns: true,  //显示下拉框勾选要显示的列
        showRefresh: false,  //显示刷新按钮
        sortName: 'Id', // 设置默认排序为 name
        uniqueId: "Id",      //每一行的唯一标识，一般为主键列
        showToggle: false,     //是否显示详细视图和列表视图的切换按钮
        toolbar: "#toolbar",
        columns: [
            {
                field: 'Id',
                title: '员工编号',
                align: 'center'
            }
            , { field: 'UserName', title: '员工名称', align: 'center' }
            , { field: 'UserPwd', title: '登录密码', align: 'center' }
            , { field: 'LastSignTime', title: '最后登录时间', align: 'center' }
            , {
                field: 'SignState', title: '状态',
                align: 'center',
                width: '6%',
                formatter: function (value, row, index) {
                    var result = "";
                    if (value == "0" || value == null) {
                        result = '无效';
                    } else {
                        result = '有效';
                    }
                    return result;
                }
            }
             , {
                 field: 'SignState', title: '操作',
                 align: 'center',
                 width: '10%',
                 formatter: function (value, row, index) {
                     var result = "";
                     result = ' <span class="glyphicon glyphicon-pencil col-xs-2"  onclick="ShowUpdateUsers(this)"  userid=' + row.Id + '> </span> ';
                     result += ' <span class="glyphicon glyphicon-trash col-xs-2" onclick="RemoveUsers(this)" userid=' + row.Id + ' ></span> ';
                     return result;
                 }

             }
        ]
    });
};

function BindOrganizationTree() {

    var url = $.Url.Action("GetOrganization", "Organization");
    $.get(url, function (data) {
        $('#tree').treeview({
            data: data,
            levels: 5,
            color: "#000000",
            backColor: "#FFFFFF",
            onNodeChecked: function (event, data) {
                alert(data.Id);
            },
            onNodeSelected: function (event, data) {
                alert(data.Id);
            }
        });
    });
}




//step1.初始化项目列表
function Bindgrd_PermissionList(grdid) {
    //1.1初始化补库列表
    $('#' + grdid).datagrid({
        title: '岗位列表',
        iconCls: 'icon-edit', //图标
        nowrap: false,
        collapsible: false, //是否可折叠的

        url: $.Url.Action("GetPermission", "Permission"),
        pagination: false, //分页控件
        rownumbers: true, //行号
        remoteSort: true,
        fitColumns: true,
        method: 'get',
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'Id', title: '岗位代码', width: 100, align: 'center', sortable: 'true' },
            { field: 'PermissionName', title: '岗位名称', width: 100, align: 'center', sortable: 'true' },
            { field: 'PermissionNote', title: '岗位说明', width: 100, align: 'center', sortable: 'true' }
        ]],
        //singleSelect: false,
        //selectOnCheck: true,
        //checkOnSelect: true

        //该事件是数据成功加载后赋予的功能
        onLoadSuccess: function (data) {

            if (data) {
                $.each(data.rows, function (index, item) {
                    if (item.checked) {
                        $('#' + grdid).datagrid('checkRow', index);
                    }
                });
            }

        }

    });
}