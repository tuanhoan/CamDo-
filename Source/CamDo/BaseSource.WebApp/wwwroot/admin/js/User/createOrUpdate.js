$(document).on("change", "#btnAddCuaHang", function () {
    if ($(this).val() == "AddCuaHang") {
        ajaxTypeGet(UrlCreate.OpenModal).then(res => {
            $("#_modalAddCuahang").html(res);
            $("#modalCuahang").modal("show");
        })

    }
});

function editUserRole(id) {
    ajaxTypeGet(UrlCreate.OpenModal).then(res => {
        $("#_modalAddRole").html(res);
        $("#EditUserRole").modal("show");
    })
}
function deleteUser() {
    $.ajax({
        method: "POST",
        url: '@Url.Action("DeleteUser", "User")',
        data: { userId: $("#txtUserId").val() },
        success: function (res) {
            alert("Success!");
        }, error: function (error) {
            alert("Error!");
        }
    });
}
