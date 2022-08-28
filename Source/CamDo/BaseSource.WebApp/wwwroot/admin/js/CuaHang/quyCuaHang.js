$(document).on("click", "#btnSaveQuyDauNgay", function () {
    var money = $("#txtMoney").val();
    var dataForm1 = $("#frmData1").serialineObject();
    var dataForm2 = $("#frmData2").serialineObject();

    var request = {nameObject1 : dataForm1, nameObject2 : dataForm2}

    ajaxTypePost(UrlCreate.Inhopdong, request ).then(res => {
        $("#_resultInhondong").html(res);
        $("#idbatky").val(res.money);
        windown.print();

    })
});