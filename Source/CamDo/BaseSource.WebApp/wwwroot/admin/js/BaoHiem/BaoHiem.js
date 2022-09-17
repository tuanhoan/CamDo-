$(document).on("click", "#btnAddBaoHiem", function () {
    ajaxTypeGet("MuaBaoHiem").then(res => {
        $("#modal_BuyInsurance").html(res);
        $("#modal_create_BuyInsurance1").modal("show");
    })
    //$("#modal_create_BuyInsurance").modal("show");
});