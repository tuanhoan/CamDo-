var lstThuocTinh = [];


function getKhachHangByName() {
    $("#TenKhachHang").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Admin/KhachHang/GetByName',
                data: { "info": request.term },
                dataType: "json",
                success: function (data) {
                    if (data.length > 0) {
                        response($.map(data, function (item) {
                            return {
                                label: item.ten,
                                value: item.ten,
                                id: item.id,
                                cmnd: item.cmnd,
                                diaChi: item.diaChi,
                                sdt: item.sdt
                            };
                        }))
                    }
                    else {
                        response([{ label: 'No results found.', val: -1 }]);
                    }

                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });
        },
        select: function (e, i) {
            if (i.item.val == -1) {
                //Clear the AutoComplete TextBox.
                $("#TenKhachHang").val("");
                $("#KhacHangId").val(0);
                $('.clear-info-customer').css("display", "none");
                return false;
            }
            else {
                $('.clear-info-customer').css("display", "block");
                $('.frmHD #CMND').val(i.item.cmnd);
                $('.frmHD #DiaChi').val(i.item.diaChi);
                $('.frmHD #SDT').val(i.item.sdt);
                $("#KhacHangId").val(i.item.id);
            }

        },
        minLength: 3
    })
}
$("body").on("click", '.clear-info-customer', function (e) {
    $(this).css("display", "none");
    $('.frmHD #TenKhachHang').val("");
    $('.frmHD #CMND').val("");
    $('.frmHD #DiaChi').val("");
    $('.frmHD #SDT').val("");
    $("#KhacHangId").val(0);
});



function getThuocTinhByTaiSan() {
    var id = $('#HangHoaId').val();
    var hdID = $('.frmHD #Id').val();
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong/GetListThuocTinhByTaiSan",
        data: { id: id, hdID: hdID },
        success: function (data) {
            if (data.length > 0) {
                lstThuocTinh = data;
                loadListThuocTinh();
            }
        }
    })
}

function setValueThuocTinh(thiz) {
    var idx = $(thiz).attr("data-idx");
    var item = lstThuocTinh[idx];
    if (item) {
        item.value = $(thiz).val();
    }
}
function loadListThuocTinh() {
    var html = "";
    if (lstThuocTinh.length > 0) {
        for (var i = 0; i < lstThuocTinh.length; i++) {
            html += '<div class="form-group row">' +
                '<label class="control-label col-md-2">' + lstThuocTinh[i].name + '</label>' +
                '<div class="col-md-3">' +
                '<input type="text" class="form-control" onchange="setValueThuocTinh(this)" data-idx="' + i + '" value="' + lstThuocTinh[i].value + '" placeholder="Nhập ' + lstThuocTinh[i].name + '"/>' +
                '</div></div>';
        };
    }
    $('#collapseTaiSan').html(html);
}

function getMoTaHinhThucLai() {
    var type = $('#HD_HinhThucLai').val();
    console.log(type);
    $.ajax({
        type: "GET",
        url: "/Admin/MoTaHinhThucLai/GetMoTaHinhThucLai",
        data: { hinhThucLai: type },
        success: function (data) {
            if (data && data.length > 0) {
                $('.tyLeLai').html(data[0].tyLeLai);
                $('.motaKyLai').html(data[0].moTaKyLai);
                $('.thoiGianVay').html(data[0].thoiGianDisplay);
                $('.moTaKyLai').html(data[0].moTaKyLai);
            }
        }
    })
}



$("body").on("click", '.addEditHD', function (e) {
    $("#hd-modal .modal-title").html('Thêm mới hợp đồng');
    $("#hd-modal .modal-body").html('<i class="fas fa-fw fa-spin fa-spinner"></i>');
    $("#hd-modal").modal('show');
    var idHd = $(this).data("id");
    $.ajax({
        method: "GET",
        url: $(this).data("url"),
        data: { id: idHd },
        success: function (res) {
            $("#hd-modal .modal-body").html(res);
            setMoneyTextBox(".money-textbox");
            getMoTaHinhThucLai();
            getKhachHangByName();

            getThuocTinhByTaiSan();


            saveHopDong();
        }, error: function (error) {
            alert("Error!");
        }
    });
})

$("body").on("click", '.detaileHD', function (e) {
    $("#hd-modal .modal-body").html('<i class="fas fa-fw fa-spin fa-spinner"></i>');
    $("#hd-modal .modal-title").html('Bảng chi tiết Hợp đồng cầm đồ');
    $("#hd-modal").modal('show');
    var idHd = $(this).data("id");
    $.ajax({
        method: "GET",
        url: $(this).data("url"),
        data: { id: idHd },
        success: function (res) {
            $("#hd-modal .modal-body").html(res);
            var triggerTabList = [].slice.call(document.querySelectorAll('.nav-item'))
            triggerTabList.forEach(function (triggerEl) {
                var tabTrigger = new bootstrap.Tab(triggerEl)

                triggerEl.addEventListener('click', function (event) {
                    event.preventDefault()
                    tabTrigger.show()
                })
            })
            setMoneyTextBox(".money-textbox");
            saveHopDong();

        }, error: function (error) {
            alert("Error!");
        }
    });
})

function saveHopDong() {
    $('form[data-name="ajaxFormHopDong"]').on("submit", function (e) {
        e.preventDefault();
        var $form = $(this);
        var $btnSubmit = $form.find("button[type='submit']");
        var modal = $btnSubmit.data("modal");
        $btnSubmit.attr("disabled", "true");

        $('#ListThuocTinhHangHoa').val(JSON.stringify(lstThuocTinh));

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
                    $('#hd-modal').modal("hide");
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
}
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
    var customerPay = $('#input-customer-pay-' + id).val();
    $.ajax({
        type: "POST",
        url: "/Admin/HopDong/CreatePayment",
        data: { paymentId: id, hdId: hdId, customerPay: customerPay },
        success: function (res) {
            console.log(res);
            if (res.isSuccessed == true) {
                toastr.info(res.message);
                loadInfoWhenChangePayment(res.resultObj, hdId);

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
            } else if (res.message != null) {
                $('#chkDeletePayment-' + id).prop('checked', true);
                toastr.error(res.message);
            }
        }

    })
}
function changePaymentDate(thiz, hdId) {
    var date = $(thiz).val();
    $.ajax({
        type: "POST",
        url: "/Admin/HopDong/ChangePaymentDate",
        data: { hdId: hdId, dateChange: date },
        success: function (res) {
            if (res.isSuccessed == true) {
                $('#dvInfoDongLaiTheoNgay #CountDay').val(res.resultObj.countDay);
                $('#dvInfoDongLaiTheoNgay .tienlai').html(format(res.resultObj.moneyInterest));
                $('#dvInfoDongLaiTheoNgay .tongtienlai').html(format(res.resultObj.moneyInterest));
                $('#dvInfoDongLaiTheoNgay #CustomerPay').val(res.resultObj.customerPay);
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

function getNotePayment(id) {
    $.ajax({
        type: "GET",
        url: "/Admin/HD_PaymentLogNote/GetNoteByPayment",
        data: { paymentId: id },
        success: function (data) {
            $('.note-payment-' + id).slideToggle();
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