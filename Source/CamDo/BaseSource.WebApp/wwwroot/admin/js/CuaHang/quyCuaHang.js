$(document).ready(function () {
    GetData();
    GetDataThongKe();
});
$(document).on("click", "#btnCreateQuyDauNgay", function () {
    var model = $("#frmCreateQuyDauNgay").serializeObject();
    ajaxTypePost(URLQuyCH.CreateQuyDauNgay, model).then(res => {
        if (res == 1) {
            GetDataThongKe();
            GetData();
        }
    })

});

$(document).on("click", "#btnCreateTienDauNgay", function () {
    var model = $("#frmCreateTienDauNgay").serializeObject();
    ajaxTypePost(URLQuyCH.CreateTienDauNgay, model).then(res => {
        if (res == 1) {
            GetDataThongKe();
            GetData();
        }
    })

});


function GetData() {
    ajaxTypePost(URLQuyCH.GetData).then(res => {
        $("#_resultTable").html(res);
    })
}

function GetDataThongKe() {
    ajaxTypePost(URLQuyCH.GetDataThongKe).then(res => {
        $("#_resultThongKe").html(res);
    })
}