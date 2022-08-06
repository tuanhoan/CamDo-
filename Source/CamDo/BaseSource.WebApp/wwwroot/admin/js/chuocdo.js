function getInfoChuocDo(hopDongId, ngayChuocDo) {
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
                toastr.info(res.resultObj);
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
function inChuocDo(id) {
    $.ajax({
        method: "GET",
        url: "/Admin/HopDong/InHDChuocDo",
        data: { hopDongId: id },
        success: function (res) {
            if (res.isSuccessed == true) {
                var mywindow = window.open('', "Chuộc đồ", 'height=' + $(window).height() + ',width=' + $(window).width());
                mywindow.document.write(res.resultObj);

                mywindow.document.close(); // necessary for IE >= 10
                mywindow.focus(); // necessary for IE >= 10

                setTimeout(function () {
                    mywindow.print();
                    mywindow.close();
                }, 500);
            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
}