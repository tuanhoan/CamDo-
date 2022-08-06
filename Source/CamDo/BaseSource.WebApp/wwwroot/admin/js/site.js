$(".asyncPartial").each(function (i, item) {
    var url = $(item).data("url");
    if (url && url.length > 0) {
        $(item).load(url, function () {
            feather.replace();
        });
    }
});
function format(data) {
    data = parseFloat(data);
    return data.toLocaleString('en');
}
$("#choose-shop").on("click", function (e) {
    e.preventDefault();
    $('.list-shop').slideToggle();
});

var chooseShop = document.getElementById('choose-shop');
document.addEventListener('click', function (event) {
    var isClickInsideElement = chooseShop.contains(event.target);
    if (!isClickInsideElement) {
        if ($('.list-shop').css("display") == "block") {
            $('.list-shop').slideToggle();
        }

    }
});
$(function () {
    // toastr ======================================================//
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    // end toastr ==================================================//

    //get it if Message key found
    if (localStorage.getItem("IsSuccessed") !== null && localStorage.getItem("Message") !== null) {
        if (localStorage.getItem("IsSuccessed") == "true") {
            toastr.info(localStorage.getItem("Message"));
        } else {
            toastr.error(localStorage.getItem("Message"));
        }
        localStorage.clear();
    }
  
});

$("#page-top").on("click", 'button[data-bs-toggle="btn-confirm"]', function (e) {
    e.preventDefault();

    if (confirm($(this).attr("data-title"))) {
        var $btnSubmit = $(this);
        $btnSubmit.attr("disabled", "true");

        var isRedirect = "false";
        if (typeof $btnSubmit.attr("data-redirect") !== 'undefined') {
            isRedirect = $btnSubmit.attr("data-redirect");
        }
        var isReloadPartial = "false";
        if (typeof $btnSubmit.attr("data-reloadpartial") !== 'undefined') {
            isReloadPartial = $btnSubmit.attr("data-reloadpartial");
        }
        $.ajax({
            url: $btnSubmit.attr("data-href"),
            method: 'POST',
            beforeSend: function () {
                $btnSubmit.append(`<i class="fas fa-sync-alt fa-fw fa-spin ml-2"></i>`);
            },
            complete: function () {
                $btnSubmit.find("i").remove();
            },
            success: function (res) {
                if (res.isSuccessed == true) {
                    if (isReloadPartial == "true") {
                        var $partial = $btnSubmit.closest('.asyncPartial');
                        $partial.load($partial.find('input[name="UrlReloadPartial"]').val());

                        toastr.info("Successed!");
                    } else {
                        localStorage.setItem("IsSuccessed", res.isSuccessed);
                        localStorage.setItem("Message", "Successed!");

                        if (isRedirect == "true") {
                            window.location.href = res.resultObj;
                        } else {
                            window.location.reload();
                        }
                    }
                } else {
                    toastr.error(res.message);

                    $btnSubmit.removeAttr("disabled");
                }
            }
        });
    }
});


$('form[data-name="ajaxForm"]').submit(function (e) {
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
            $form.find(".field-validation-valid").empty();
            if (res.isSuccessed == true) {
                localStorage.setItem("IsSuccessed", res.isSuccessed);
                localStorage.setItem("Message", "Successed!");

                window.location.href = res.resultObj;
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });
                $btnSubmit.removeAttr("disabled");
            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
});



$('form[data-name="ajaxFormUpload"]').submit(function (e) {
    e.preventDefault();

    var formData = new FormData(this);

    var $form = $(this);
    var $btnSubmit = $form.find("button[type='submit']");

    $btnSubmit.attr("disabled", "true");
    $.ajax({
        method: $form.attr("method"),
        url: $form.attr("action"),
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        beforeSend: function () {
            $btnSubmit.append(`<i class="fas fa-sync-alt fa-fw fa-spin"></i>`);
        },
        complete: function () {
            $btnSubmit.find("i").remove();
        },
        success: function (res) {
            $form.find(".field-validation-valid").empty();
            if (res.isSuccessed == true) {
                localStorage.setItem("IsSuccessed", res.isSuccessed);
                localStorage.setItem("Message", "Successed!");

                window.location.href = res.resultObj;
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });
                $btnSubmit.removeAttr("disabled");
            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
});

$('form[data-name="ajaxFormHangHoa"]').submit(function (e) {
    e.preventDefault();
    var $form = $(this);
    if ($('.group-thuoctinh-item').length > 0) {
        var lstTempThuocTinh = $('.repeatThuocTinh').repeaterVal();
        var lstThuocTinh = [];
        for (var i = 0; i < lstTempThuocTinh.groupthuoctinh.length; i++) {
            if (lstTempThuocTinh.groupthuoctinh[i].thuoctinh != "") {
                lstThuocTinh.push(lstTempThuocTinh.groupthuoctinh[i].thuoctinh)
            }
        }
        if (lstThuocTinh.length > 0) {
            $form.find("input[id='ListThuocTinh']").val(JSON.stringify(lstThuocTinh));
        }
    }
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
            $form.find(".field-validation-valid").empty();
            if (res.isSuccessed == true) {
                localStorage.setItem("IsSuccessed", res.isSuccessed);
                localStorage.setItem("Message", "Successed!");

                window.location.href = res.resultObj;
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });
                $btnSubmit.removeAttr("disabled");
            } else if (res.message != null) {
                toastr.error(res.message);
            }
        }
    });
});
function setMoneyTextBox(selector) {
    new AutoNumeric.multiple(selector, { currencySymbol: '', decimalPlacesOverride: 0, showWarnings: false, decimalPlaces: '0' })
    $(selector).change(function () {
        var value = $(this).val();
        value = value.replaceAll(",", "") * 1;
        if (value == "" || value < 0) {
            value = 0;
            $(this).val(value);
        }
        $(this).next().val(value);

    });

}
$("body").on("click", '.btn-changeShop', function (e) {
    var name = $(this).data("name");
    $(this).attr("disabled", "true");
    $.ajax({
        url: $(this).attr("data-href"),
        method: 'POST',
        data: { id: $(this).data("id") },
        beforeSend: function () {
            $(this).html('<i class="fas fa-sync-alt fa-fw fa-spin"></i>');
        },
        success: function () {
            toastr.info("Chuyển sang cửa hàng " + name + " thành công");
            setTimeout(function () {
                window.location.reload();
            }, 500);
        }
    });
});

/*=======Edit profile- Change Password========*/

$("body").on("click", '#change-pass', function (e) {
    e.preventDefault();
    $.ajax({
        url: $(this).attr("data-href"),
        method: 'GET',
        success: function (data) {
            $('#modalContainer').html(data);
            $('#modalChangePass').modal("show");
        }
    });
});
$("body").on("click", '#edit-profile', function (e) {
    e.preventDefault();
    $.ajax({
        url: $(this).attr("data-href"),
        method: 'GET',
        success: function (data) {
            $('#modalContainer').html(data);
            $('#modalEditProfile').modal("show");
        }
    });
});

$("body").on("submit", 'form[data-name="ajaxFormModal"]', function (e) {
    e.preventDefault();
    var $form = $(this);
    var $btnSubmit = $form.find("button[type='submit']");
    var modal = $btnSubmit.data("modal");
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
                $(modal).modal("hide");
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
/*=======END Edit profile- Change Password========*/

/*=======Feedback========*/
$('form[data-name="ajaxFormFeedBack"]').submit(function (e) {
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
                $form[0].reset();
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
/*=======END Feedback========*/
