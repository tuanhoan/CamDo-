$(document).on("click", "#btnAddBaoHiem", function () {
    ajaxTypeGet("MuaBaoHiem").then(res => {
        $("#modal_BuyInsurance").html(res);
        $("#modal_create_BuyInsurance1").modal("show");
    })
});


$(document).on("click", "#btnSubmit", function () {
    e.preventDefault();
    var formData = new FormData($("#ajaxFormBaoHiem"));
    var $form = $("#ajaxFormBaoHiem");

    $.ajax({
        method: $form.attr("method"),
        url: $form.attr("action"),
        data: formData,
        dataType: "json",
        beforeSend: function () {
            $btnSubmit.append(`<i class="fas fa-sync-alt fa-fw fa-spin"></i>`);
        },
        complete: function () {
            $btnSubmit.find("i").remove();
        },
        success: function (res) {
            $btnSubmit.removeAttr("disabled");
            $form.find(".field-validation-valid").empty();
            console.log(res);
            if (res.isSuccessed == true) {
                localStorage.setItem("IsSuccessed", res.isSuccessed);
                localStorage.setItem("Message", res.resultObj);

                location.reload();
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    console.log(v);
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });

            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
});