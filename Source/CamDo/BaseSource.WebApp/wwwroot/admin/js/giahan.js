function getListGiaHan(hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong_GiaHan/GetByHopDong",
        data: { hopDongId: hopDongId },
        success: function (data) {
            $('#divContent-GiaHan').html(data);
        }
    })
}
$("body").on("submit", 'form[id="frmGiaHan"]', function (e) {
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
                var hopDongId = $form.find('input[name=HopDongId]').val();
                toastr.info(res.message);
                setTimeout(getListGiaHan(hopDongId), 2000);
                $('.lblTongTienVayHienTai').text(format(res.resultObj));
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
