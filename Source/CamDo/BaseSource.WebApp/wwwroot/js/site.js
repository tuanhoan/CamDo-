
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
            $btnSubmit.removeAttr("disabled");
            $form.find(".field-validation-valid").empty();
            if (res.isSuccessed == true) {
                localStorage.setItem("IsSuccessed", res.isSuccessed);
                localStorage.setItem("Message", "Successed!");

                window.location.href = res.resultObj;
            } else if (res.validationErrors != null && res.validationErrors.length) {
                $.each(res.validationErrors, function (i, v) {
                    $form.find("span[data-valmsg-for='" + v.pos + "']").html(v.error);
                });
              
            } else if (res.message != null) {
                alert(res.message);
            }
        }
    });
});

$(document).ready(function () {
    //get it if Message key found
    if (localStorage.getItem("IsSuccessed") !== null && localStorage.getItem("Message") !== null) {
        if (localStorage.getItem("IsSuccessed") == "true") {
            //toastr.info(localStorage.getItem("Message"));
            alert(localStorage.getItem("Message"));
        } else {
            //toastr.error(localStorage.getItem("Message"));
            alert(localStorage.getItem("Message"));
        }
        localStorage.clear();
    }
});
function setMoneyTextBox(selector) {
    new AutoNumeric(selector, { currencySymbol: '', decimalPlacesOverride: 0, showWarnings: false, decimalPlaces:'0' })
    $(selector).change(function () {
        var value = $(this).val();
        value = value.replaceAll(",", "");
        if (value == "") {
            value = 0;
        }
        $(this).next().val(value);

    });

}
function ajaxGet(url, data = {}) {
    return $.ajax({
        url: url,
        type: 'GET',
        data : data
    });
}