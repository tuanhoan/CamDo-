$(document).on("change", "#btnAddCuaHang", function () {
    if ($(this).val() == "AddCuaHang") {
        ajaxTypeGet(UrlCreate.OpenModal).then(res => {
            $("#_modalAddCuahang").html(res);
            $("#modalCuahang").modal("show");

        })
 
    }
});
