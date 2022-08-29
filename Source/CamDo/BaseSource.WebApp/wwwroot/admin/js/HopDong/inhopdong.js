$(document).on("click", "#inhopdong", function () {
    var request = { hopdongid: $("#hopdongid").val() }

    ajaxTypeGet("HopDong/InHopDong", request).then(res => {
        var mywindow = window.open('', 'PRINT');
        mywindow.document.write(res);
        mywindow.document.close(); // necessary for IE >= 10
        mywindow.focus(); // necessary for IE >= 10*/

        mywindow.print();
        mywindow.close();
    })
});

$(document).on("click", "#muabaohiem", function () {
    console.log("hehe");
    ajaxTypeGet("HopDong/MuaHopDong").then(res => {
        $("#_modalMuaBaoHiem").html(res);
        $("#modal-muabaohiem").modal("show");
    })
});