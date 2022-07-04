function getCuahang_TransactionLog(hopDongId) {
    $.ajax({
        type: "GET",
        url: "/Admin/CuaHang_TransactionLog/GetCuaHang_TransactionLog",
        data: { hopDongId: hopDongId },
        success: function (data) {
            $('#divContent-CuaHang_TransactionLog').html(data);
        }
    })
}