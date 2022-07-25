$("body").on("submit", 'form[data-name="frmTraNo"]', function (e) {
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
            $form[0].reset();
            if (res.isSuccessed == true) {
                toastr.info(res.message);
                if (res.resultObj > 0) {
                    $('#lblDisplayDebitOrOverMoney').text("Tiền thừa KH");
                    $('#lblCustomerDebitMoney').text(format(res.resultObj) + " VND");
                    $('#lblDisplayLoanDebit').text("Tiền thừa HĐ");
                    $('#lblLoanDebitMoney').text(format(res.resultObj) + " VND");
                }
                else {
                    $('#lblDisplayDebitOrOverMoney').text("Nợ cũ KH");
                    $('#lblCustomerDebitMoney').text(format(res.resultObj) + " VND");
                    $('#lblDisplayLoanDebit').text("Nợ cũ HĐ");
                    $('#lblLoanDebitMoney').text(format(res.resultObj) + " VND");
                }
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

$("body").on("submit", 'form[data-name="frmGhiNo"]', function (e) {
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
            $form[0].reset();
            if (res.isSuccessed == true) {
                toastr.info(res.message);
                if (res.resultObj > 0) {
                    $('#lblDisplayDebitOrOverMoney').text("Tiền thừa KH");
                    $('#lblCustomerDebitMoney').text(format(res.resultObj) + " VND");
                    $('#lblDisplayLoanDebit').text("Tiền thừa HĐ");
                    $('#lblLoanDebitMoney').text(format(res.resultObj) + " VND");
                }
                else {
                    $('#lblDisplayDebitOrOverMoney').text("Nợ cũ KH");
                    $('#lblCustomerDebitMoney').text(format(res.resultObj) + " VND");
                    $('#lblDisplayLoanDebit').text("Nợ cũ HĐ");
                    $('#lblLoanDebitMoney').text(format(res.resultObj) + " VND");
                }
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