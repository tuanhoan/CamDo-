function getChungTu(hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/HopDong/GetChungTu",
        data: { hopDongId: hopDongId },
        success: function (data) {
            $('#chungTuContent').html(data);
            $(".delete-image").click(function (e) {
                e.preventDefault();
                var result = confirm("bạn có chắc muốn xóa ảnh này?");
                var src = $(this).closest('.uploaded-image').find('img').attr("src");
                var type = $(this).closest('form').find('input[name=ChungTuType]').val();
                var $form = $('#frmDeleteImage');
                var data = $form.serializeArray();

                data.push({ name: "ChungTuType", value: type });
                data.push({ name: "Src", value: src });

                var elementDelete = $(this).closest('.uploaded-image');
                if (result) {
                    $.ajax({
                        method: "POST",
                        url: $form.attr("action"),
                        data: data,
                        success: function (res) {
                            if (res.isSuccessed) {
                                elementDelete.remove();
                            }
                        }
                    })
                }
            });
        }
    })
}
