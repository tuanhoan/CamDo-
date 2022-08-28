$(document).on("change", "#btnAddCuaHang", function () {
    if ($(this).val() == "AddCuaHang") {
        ajaxGet(UrlCreate.OpenModal).then(res => {
            $("#_modalAddCuahang").html(res);
            $("#modalCuahang").modal("show");
        })
 
    }
});