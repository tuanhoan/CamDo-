function getCuahang_TransactionLog(hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/CuaHang_TransactionLog/GetCuaHang_TransactionLog",
        data: { hopDongId: hopDongId },
        success: function (data) {
            $('#divContent-CuaHang_TransactionLog').html(data);
            taoNhacNo();
        }
    })
}

//lịch sử nhắc nợ
function geHopDong_DebtNote(hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong_DebtNote/GeHopDong_DebtNote",
        data: { hopDongId: hopDongId },
        success: function (data) {
            $('#divContent-CommentDebt').html(data);

        }
    })
}
function taoNhacNo() {
    $('#frmNhacNo').on("submit", function (e) {
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
                $btnSubmit.find("i").remove();
            },
            success: function (res) {
                $btnSubmit.removeAttr("disabled");
                $form.find(".field-validation-valid").empty();
                if (res.isSuccessed == true) {
                    toastr.success(res.message);
                    var hopDongId = $form.find('input[name=HopDongId]').val();
                    $form[0].reset();
                    geHopDong_DebtNote(hopDongId);
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
}