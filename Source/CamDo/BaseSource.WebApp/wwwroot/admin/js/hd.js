﻿var lstThuocTinh = [];

function initGetKhachHangByName() {
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
                return false;
            }
            else {
                $('.frmHD #CMND').val(i.item.cmnd);
                $('.frmHD #DiaChi').val(i.item.diaChi);
                $('.frmHD #SDT').val(i.item.sdt);
                $("#KhacHangId").val(i.item.id);
            }

        },
        minLength: 3
    })
}

function getThuocTinhByTaiSan() {
    var id = $('#HangHoaId').val();
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong/GetListThuocTinhByTaiSan",
        data: { id: id },
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
    debugger;
    if (lstThuocTinh.length > 0) {
        for (var i = 0; i < lstThuocTinh.length; i++) {
            html += '<div class="form-group row">' +
                '<label class="control-label col-md-2">' + lstThuocTinh[i].name + '</label>' +
                '<div class="col-md-3">' +
                '<input type="text" class="form-control" onchange="setValueThuocTinh(this)" data-idx="' + i + '" value="' + lstThuocTinh[i].value+'" placeholder="Nhập ' + lstThuocTinh[i].name + '"/>' +
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
    $("#hd-modal .modal-body").html('<i class="fas fa-fw fa-spin fa-spinner"></i>');
    $("#hd-modal").modal('show');
    $.ajax({
        method: "GET",
        url: $(this).data("url"),
        data: { id: $(this).data("id") },
        success: function (res) {
            $("#hd-modal .modal-body").html(res);
            setMoneyTextBox(".money-textbox");
            getMoTaHinhThucLai();
            getThuocTinhByTaiSan();
            initGetKhachHangByName();
            loadListThuocTinh();
            $("body").on("submit", 'form[data-name="ajaxFormHopDong"]', function (e) {
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
        }, error: function (error) {
            alert("Error!");
        }
    });
})