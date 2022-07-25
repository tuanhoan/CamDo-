
function getListAlarmLog(hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong_AlarmLog/GeHopDong_AlarmLog",
        data: { hopDongId: hopDongId },
        success: function (data) {
            $('#divContent-HenGio').html(data);

        }
    })
}
function saveHenGio(type) {
    if (type) {
        $('#frmHenGio').find('input[name=IsDisable]').val(true);
    }
    else {
        $('#frmHenGio').find('input[name=IsDisable]').val(false);
    }
    var $form = $('#frmHenGio');
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
                var hopDongId = $form.find('input[name=HopDongId]').val();
                toastr.info(res.resultObj);
                $form[0].reset();
                setTimeout(getListAlarmLog(hopDongId), 2000);
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
}
