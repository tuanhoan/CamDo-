﻿function getInfoChuocDo(hopDongId, ngayChuocDo) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong_ChuocDo/GetInfoChuocDo",
        data: { hopDongId: hopDongId, ngayChuocDo: ngayChuocDo },
        success: function (data) {
            $('#divContent-chuocdo').html(data);
        }
    })
}
function loadChuocDo(thiz, hopDongId) {
    var ngayChuoc = $(thiz).val();
    getInfoChuocDo(hopDongId, ngayChuoc);
}
function tinhTongTienChuoc(thiz) {
    var tienKhac = parseFloat($(thiz).val().replaceAll(",", "") * 1);
    var tongTienChuocCurrent = parseFloat($('#TongTienChuoc').val());
    var total = tienKhac + tongTienChuocCurrent;
    $('#lblChuocdo_MoneyNeed').text(format(total) + " VNĐ");
}
$("body").on("submit", 'form[id="frmChuocDo"]', function (e) {
    e.preventDefault();
    var $form = $(this);
    var $btnSubmit = $form.find("button[type='submit']");
    $btnSubmit.attr("disabled", "true");

    $.ajax({
        method: $form.attr("method"),
        url: $form.attr("action"),
        data: $form.serializeArray(),
        beforeSend: function () {
            $btnSubmit.append(`<i class="fas fa-sync-alt fa-fw fa-spin"></i>`);
        },
        complete: function () {
            $btnSubmit.find("i").removeClass("fa-sync-alt fa-fw fa-spin");
        },
        success: function (res) {
            $btnSubmit.removeAttr("disabled");
            $form.find(".field-validation-valid").empty();
            if (res.isSuccessed == true) {
                toastr.info(res.message);
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
