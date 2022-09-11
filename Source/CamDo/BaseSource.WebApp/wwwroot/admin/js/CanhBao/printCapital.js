$(document).on("click", "#printcapital", function () {
    ajaxTypeGet("/Admin/CanhBao/PrintCapital").then(res => {
        var mywindow = window.open('', 'PRINT');
        mywindow.document.write(res);
        mywindow.document.close(); // necessary for IE >= 10
        mywindow.focus(); // necessary for IE >= 10*/

        mywindow.print();
        mywindow.close();
    })
});

$(document).on("click", "#printloan", function () {
    ajaxTypeGet("/Admin/CanhBao/PrintLoan").then(res => {
        var mywindow = window.open('', 'PRINT');
        mywindow.document.write(res);
        mywindow.document.close(); // necessary for IE >= 10
        mywindow.focus(); // necessary for IE >= 10*/

        mywindow.print();
        mywindow.close();
    })
});


$(document).on("click", "#printpawn", function () {
    ajaxTypeGet("/Admin/CanhBao/PrintPawn").then(res => {
        var mywindow = window.open('', 'PRINT');
        mywindow.document.write(res);
        mywindow.document.close(); // necessary for IE >= 10
        mywindow.focus(); // necessary for IE >= 10*/

        mywindow.print();
        mywindow.close();
    })
});

 