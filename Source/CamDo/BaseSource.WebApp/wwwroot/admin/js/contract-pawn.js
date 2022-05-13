function addContractPawn(thiz, id) {
    $("#pawn-modal .modal-body").html('<i class="fas fa-fw fa-spin fa-spinner"></i>');
    $("#pawn-modal").modal('show');
    $.ajax({
        method: "GET",
        url: $(thiz).data("url"),
        data: { id: id },
        success: function (res) {
            $("#pawn-modal .modal-body").html(res);

            //$('#form-edit-role').submit(function (e) {
            //    e.preventDefault();
            //    $.ajax({
            //        method: $('#form-edit-role').attr('method'),
            //        url: $('#form-edit-role').attr('action'),
            //        data: $('#form-edit-role').serializeArray(),
            //        success: function (res) {
            //            location.reload();
            //        }
            //    });
            //});
        }, error: function (error) {
            alert("Error!");
        }
    });
}