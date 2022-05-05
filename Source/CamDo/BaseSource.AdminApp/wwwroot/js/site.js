

$(function () {
    // toastr ======================================================//
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-left",
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

$("#page-top").on("click", 'button[data-toggle="btn-confirm"]', function (e) {
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
        var lstThuocTinh = $('.repeatThuocTinh').repeaterVal();
        var thuoctinh = JSON.stringify(lstThuocTinh.groupthuoctinh);
        $form.find("input[id='ListThuocTinh']").val(JSON.stringify(thuoctinh));
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