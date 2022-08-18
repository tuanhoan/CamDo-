//Trả bớt gốc

function getHistoryLoanExtra(type, hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong_VayRutGoc/GetByHopDong",
        data: { hopDongId: hopDongId },
        success: function (data) {
            if (type == "tab-trabotgoc") {
                $('#divContent-ListTraGoc').html(data);
                setMoneyTextBox('#SoTienTraGocDisplay');
            }
            else {
                $('#divContent-ListVayThem').html(data);
                setMoneyTextBox('#SoTienVayThemDisplay');
            }
            var tongTienVayHienTai = $('#lblTotalMoney').text();
            $('.lblTongTienVayHienTai').text(tongTienVayHienTai);
        }
    })
}
$("body").on("submit", 'form[id="frmTraBotGoc"]', function (e) {
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
                $form[0].reset();
                setTimeout(getHistoryLoanExtra("tab-trabotgoc", hopDongId), 2000);
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

$("body").on("click", '.btn-xoatragoc', function (e) {
    e.preventDefault();
    if (confirm($(this).attr("data-title"))) {
        var $btnSubmit = $(this);
        $btnSubmit.attr("disabled", "true");
        var hopdongId = $btnSubmit.data("hopdongid");
        $.ajax({
            url: $btnSubmit.attr("data-href"),
            method: 'POST',
            beforeSend: function () {
                $btnSubmit.append(`<i class="fas fa-sync-alt fa-fw fa-spin ms-2"></i>`);
            },
            complete: function () {
                $btnSubmit.find("i").remove();
            },
            success: function (res) {
                if (res.isSuccessed == true) {
                    toastr.info(res.message);
                    getHistoryLoanExtra("tab-trabotgoc", hopdongId);
                    $('.lblTongTienVayHienTai').text(format(res.resultObj));
                } else {
                    toastr.error(res.message);
                    $btnSubmit.removeAttr("disabled");
                }
            }
        });
    }
});


$("body").on("submit", 'form[id="frmVayThem"]', function (e) {
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
                var hopDongId = $form.find('input[name=HopDongId]').val();
                toastr.info(res.message);
                $form[0].reset();
               
                setTimeout(getHistoryLoanExtra("tab-vaythem", hopDongId), 2000);
                $('.lblTongTienVayHienTai').text(format(res.resultObj));
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });

            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
});


$("body").on("click", '.btn-xoavaythem', function (e) {
    e.preventDefault();
    if (confirm($(this).attr("data-title"))) {
        var $btnSubmit = $(this);
        $btnSubmit.attr("disabled", "true");
        var hopdongId = $btnSubmit.data("hopdongid");
        $.ajax({
            url: $btnSubmit.attr("data-href"),
            method: 'POST',
            beforeSend: function () {
                $btnSubmit.append(`<i class="fas fa-sync-alt fa-fw fa-spin ms-2"></i>`);
            },
            complete: function () {
                $btnSubmit.find("i").remove();
            },
            success: function (res) {
                if (res.isSuccessed == true) {
                    toastr.info(res.message);
                    setTimeout(getHistoryLoanExtra("tab-vaythem", hopdongId), 2000);
                    $('.lblTongTienVayHienTai').text(format(res.resultObj));
                } else {
                    toastr.error(res.message);
                    $btnSubmit.removeAttr("disabled");
                }
            }
        });
    }
});

