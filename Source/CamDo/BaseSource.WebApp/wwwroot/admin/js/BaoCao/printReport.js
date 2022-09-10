$(document).on("click", "#printreportblance", function () {
    console.log("vô");
    ajaxTypeGet("/Admin/BaoCao/PrintReportBlance").then(res => {

        //var mywindow = window.open('', "Lịch đóng tiền", 'height=' + $(window).height() + ',width=' + $(window).width());
        //console.log(res);
        //mywindow.document.write(res);

        //mywindow.document.close(); // necessary for IE >= 10
        //mywindow.focus(); // necessary for IE >= 10

        //setTimeout(function () {
        //    mywindow.print();
        //    mywindow.close();
        //}, 500);
        var mywindow = window.open('', 'PRINT');
        mywindow.document.write(res);
        mywindow.document.close(); // necessary for IE >= 10
        mywindow.focus(); // necessary for IE >= 10*/

        mywindow.print();
        mywindow.close();
    })
});
 