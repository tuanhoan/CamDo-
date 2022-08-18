var lstThuocTinh = [];

function initAutocomplete() {
    var typeCustomer = $('input[name=CustomerType]:checked').val();
    if (typeCustomer == "OldCustomer") {
        $("#TenKhachHang").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/Admin/KhachHang/GetByName',
                    data: { "info": request.term },
                    dataType: "json",
                    success: function (data) {
                        if (data.length > 0) {
                            response($.map(data, function (item) {
                                console.log(item);
                                return {
                                    label: item.ten,
                                    value: item.ten,
                                    id: item.id,
                                    cmnd: item.cmnd,
                                    diaChi: item.diaChi,
                                    sdt: item.sdt,
                                    ngaycap: item.cmnD_NgayCap,
                                    noicap: item.cmnD_NoiCap
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
                    $("#KhachHangId").val(0);
                    $('.clear-info-customer').css("display", "none");
                    return false;
                }
                else {
                    $('.clear-info-customer').css("display", "block");
                    $('.frmHD #CMND').val(i.item.cmnd);
                    $('.frmHD #DiaChi').val(i.item.diaChi);
                    $('.frmHD #SDT').val(i.item.sdt);
                    $("#KhachHangId").val(i.item.id);
                    if (i.item.ngaycap != null && i.item.ngaycap != "") {
                        var ngaycap = i.item.ngaycap.split('T')[0];
                        $("#CMND_NgayCap").val(ngaycap).trigger("change");
                    }
                    $("#CMND_NoiCap").val(i.item.noicap);
                }

            },
            minLength: 1
        })
    }
    else {
        if ($("#TenKhachHang").hasClass("ui-autocomplete-input")) {
            $("#TenKhachHang").autocomplete("destroy")
        }
    }

}
$("body").on("click", '.clear-info-customer', function (e) {
    $(this).css("display", "none");
    $('.frmHD #TenKhachHang').val("");
    $('.frmHD #CMND').val("");
    $('.frmHD #DiaChi').val("");
    $('.frmHD #SDT').val("");
    $("#KhachHangId").val(0);
    $("#CMND_NoiCap").val('');
    $("#CMND_NgayCap").val('').trigger("change");
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
            html += '<div class="mb-3">' +
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
    $.ajax({
        type: "GET",
        url: "/Admin/MoTaHinhThucLai/GetMoTaHinhThucLai",
        data: { hinhThucLai: type },
        success: function (data) {
            if (data && data.length > 0) {

                if (type === 0 || type === "") {
                    $('.group_hidden').hide();
                } else {
                    $('.group_hidden').show();
                }

                $('.tyLeLai').html(data[0].tyLeLai);
                $('.motaKyLai').html(data[0].moTaKyLai);
                $('.thoiGianVay').html(data[0].thoiGianDisplay);
                $('.moTaKyLai').html(data[0].moTaKyLai);
                var soNgayVay = "Số " + data[0].thoiGianDisplay.toLowerCase() + " vay";
                $('.lblThoiGianVay').text(soNgayVay);
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
            initAutocomplete();
            getThuocTinhByTaiSan();
            saveHopDong();

            $('input[name=CustomerType]').change(function () {
                if ($(this).val() == "NewCustomer") {
                    $('#KhachHangId').val(0);
                }
                initAutocomplete();
            });

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
    var typeTab = $(this).data("tab");
    $.ajax({
        method: "GET",
        url: $(this).data("url"),
        data: { id: idHd, tabActive: typeTab },
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
            $("#hd-modal").on("hidden.bs.modal", function () {
                location.reload();
            });
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
}
