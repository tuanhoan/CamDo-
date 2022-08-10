function chonMauHopDong() {
    $("#print-paw-modal .modal-title").html('Chọn mẫu hợp đồng in');
    $("#print-paw-modal .modal-body").html('<i class="fas fa-fw fa-spin fa-spinner"></i>');
    $("#print-paw-modal").modal('show');
    $.ajax({
        type: "GET",
        url: '/Admin/Pawn/ChonMauHopDong',
        success: function (res) {
            $("#print-paw-modal .modal-body").html(res);
        },

    });
}
function SetPrintView(data) {
    $('input:radio[name=rdPrintCamDo][value=' + data + ']').click();
}