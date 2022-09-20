$('#recipeCarousel').carousel({
    interval: 10000
})

$('.carousel .carousel-item').each(function () {
    var minPerSlide = 4;
    var next = $(this).next();
    if (!next.length) {
        next = $(this).siblings(':first');
    }
    next.children(':first-child').clone().appendTo($(this));

    for (var i = 0; i < minPerSlide; i++) {
        next = next.next();
        if (!next.length) {
            next = $(this).siblings(':first');
        }

        next.children(':first-child').clone().appendTo($(this));
    }
});

function Accept(id) {
    $.ajax({
        url: '/Admin/Friendship/Accept',
        type: 'POST',
        data: { UserRequestId: id },
        success: function (res) {
            if (res.isSuccessed == true) {
                toastr.info(res.resultObj);
            }
            else if (res.message != null) {
                toastr.error(res.message);
            }
            else {
                toastr.error("Có lỗi xảy ra. Vui lòng đợi trong giây lát");
            }
        },
        error: function (data) {
            toastr.error("Có lỗi xảy ra. Vui lòng đợi trong giây lát");
        }
    });
};
function Deline(id) {
    $.ajax({
        url: '/Admin/Friendship/Deline',
        type: 'POST',
        data: { UserRequestId: id },
        success: function (res) {
            if (res.isSuccessed == true) {
                toastr.info(res.resultObj);
            }
            else if (res.message != null) {
                toastr.error(res.message);
            }
            else {
                toastr.error("Có lỗi xảy ra. Vui lòng đợi trong giây lát");
            }
        },
        error: function (data) {
            toastr.error("Có lỗi xảy ra. Vui lòng đợi trong giây lát");
        }
    });
};