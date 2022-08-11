function chonMauHopDong() {
    $("#print-paw-modal .modal-title").html('Chọn mẫu hợp đồng in');
    $("#print-paw-modal .modal-body").html('<i class="fas fa-fw fa-spin fa-spinner"></i>');
    $("#print-paw-modal").modal('show');
    $.ajax({
        type: "GET",
        url: '/Admin/Pawn/ChonMauHopDong',
        success: function (res) {
            $("#print-paw-modal .modal-body").html(res);

            $('form[data-name="ajaxFormPrintTemplate"]').submit(function (e) {
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
                            toastr.info(res.resultObj);
                            $('#print-paw-modal').modal("hide");
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
        },

    });
}
function SetPrintView(data) {
    $('input:radio[class=rdPrintCamDo][value=' + data + ']').click();
}
