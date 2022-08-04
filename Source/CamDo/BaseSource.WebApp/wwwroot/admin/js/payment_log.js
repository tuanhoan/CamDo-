function getListPaymentLog(hdId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong/GetListPaymentLog",
        data: { hdId: hdId },
        success: function (data) {
            $('#divContent-ListPayment').html(data);
        }
    })
}
function getInfoPaymentByDate(hdId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong/GetInfoPaymentByDate",
        data: { hdId: hdId },
        success: function (data) {
            $('#divContent-Tralaitheongay').html(data);
        }
    })
}

function createPayment(id, hdId) {
    var customerPay = 0;
    var customerPayVal = $('#input-customer-pay-' + id).val();
    if (customerPayVal != "") {
        customerPay = customerPayVal.replaceAll(",", "") * 1;
    }
    $.ajax({
        type: "POST",
        url: "/Admin/HopDong/CreatePayment",
        data: { paymentId: id, hdId: hdId, customerPay: customerPay },
        success: function (res) {
            console.log(res);
            if (res.isSuccessed == true) {
                toastr.info(res.message);
                loadInfoWhenChangePayment(res.resultObj, hdId);
                hienThiGhiNoHD(res.resultObj.tongTienGhiNo);
            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }

    })
}

function loadInfoWhenChangePayment(result, hdId) {
    setTimeout(function () {
        getListPaymentLog(hdId);
        getInfoPaymentByDate(hdId);
    }, 500);

    $('#lblLastDateOfPay').text(result.ngayDongLaiGanNhat);
    $('#lblPaymentMoney').text(format(result.tongTienLaiDaDong));

}


function deletePayment(id, hdId) {
    $.ajax({
        type: "POST",
        url: "/Admin/HopDong/DeletePayment",
        data: { paymentId: id },
        success: function (res) {
            if (res.isSuccessed == true) {
                toastr.info(res.message);
                loadInfoWhenChangePayment(res.resultObj, hdId);
                hienThiGhiNoHD(res.resultObj.tongTienGhiNo);
            } else if (res.message != null) {
                $('#chkDeletePayment-' + id).prop('checked', true);
                toastr.error(res.message);
            }
        }

    })
}
function hienThiGhiNoHD(tongTienGhiNo) {
    $('#lblCustomerDebitMoney').text(format(tongTienGhiNo) + " VNĐ");
    $('#lblLoanDebitMoney').text(format(tongTienGhiNo) + " VNĐ");

    if (tongTienGhiNo <= 0) {
        $('#lblCustomerDebitMoney').removeClass("text-success").addClass("text-danger");
        $('#lblLoanDebitMoney').removeClass("text-success").addClass("text-danger");
    }
    else {
        $('#lblCustomerDebitMoney').removeClass("text-danger").addClass("text-success");
        $('#lblLoanDebitMoney').removeClass("text-danger").addClass("text-success");

    }
}


function changePaymentDate(thiz, hdId) {
    var date = $(thiz).val();
    $.ajax({
        type: "POST",
        url: "/Admin/HopDong/ChangePaymentDate",
        data: { hdId: hdId, dateChange: date },
        success: function (res) {
            if (res.isSuccessed == true) {
                $('#frmDongLaiTheoNgay #CountDay').val(res.resultObj.countDay);
                $('#frmDongLaiTheoNgay .tienlai').html(format(res.resultObj.moneyInterest));
                $('#frmDongLaiTheoNgay .tongtienlai').html(format(res.resultObj.moneyInterest));
                $('#frmDongLaiTheoNgay #CustomerPay').val(res.resultObj.customerPay);
            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    })
}

$("body").on("submit", 'form[data-name="frmDongLaiTheoNgay"]', function (e) {
    e.preventDefault();
    var $form = $(this);
    var $btnSubmit = $form.find("button[type='submit']");
    $btnSubmit.attr("disabled", "true");
    var hdId = $form.find("input[name='HdId']").val();

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
                toastr.info(res.message);
                loadInfoWhenChangePayment(res.resultObj, hdId);
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

function getNotePayment(id, isToggle) {
    $.ajax({
        type: "GET",
        url: "/Admin/HD_PaymentLogNote/GetNoteByPayment",
        data: { paymentId: id },
        success: function (data) {
            if (isToggle) {
                $('.note-payment-' + id).slideToggle();
            }
            $('#note-result-' + id).html(data);
        }
    })
}
function createPaymentNote(id) {
    var $form = $('#frmPaymentNote-' + id);
    $.ajax({
        method: "POST",
        url: "/Admin/HD_PaymentLogNote/Create",
        data: $form.serializeArray(),
        success: function (res) {
            $form.find(".field-validation-valid").empty();
            if (res.isSuccessed == true) {
                $form[0].reset();
                getNotePayment(id);
                toastr.info(res.resultObj);
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });

            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
}
function printPayment(id) {
    $.ajax({
        method: "GET",
        url: "/Admin/HopDong/InKyDongLai",
        data: { paymentId: id },
        success: function (res) {
            if (res.isSuccessed == true) {
                var mywindow = window.open('', "123", 'height=' + $(window).height() + ',width=' + $(window).width());
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