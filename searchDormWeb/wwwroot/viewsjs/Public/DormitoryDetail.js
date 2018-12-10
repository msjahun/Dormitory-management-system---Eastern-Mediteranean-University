


$.ajax({
    type: "POST",
    url: "GetTopnavDormitorySection",
    data: {
        SectionId: "_TopnavDormitorySection"
    },
    success: function (result) {
        //     alert(result);
        $("#_TopnavDormitorySection").html(result);



    }
});


$.ajax({
    type: "POST",
    url: "GetCommentsSection",
    data: {
        SectionId: "comments_section"
    },
    success: function (result) {
        //     alert(result);
        $("#comments_section").html(result);



    }
});



        $.ajax({
            type: "POST",
            url: "GetDormitoryDescriptionSection",
            data: {
                SectionId: "_DormitoryDescriptionSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_DormitoryDescriptionSection").html(result);



            }
        });







var lock_RoomSection = true;
$(window).scroll(function () {
    var hT = $('#_RoomSection').offset().top,
        hH = $('#_RoomSection').outerHeight(),
        wH = $(window).height(),
        wS = $(this).scrollTop();
    //console.log((hT - wH), wS);
    if (wS > (hT + hH - wH) && lock_RoomSection) {
        //alert('I have scrolled to Highly Rated Dormitories');
        lock_RoomSection = false;

        $.ajax({
            type: "POST",
            url: "GetRoomSection",
            data: {
                SectionId: "_RoomSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_RoomSection").html(result);



            }
        });


    }
});




var lock_AreaInfoSection = true;
$(window).scroll(function () {
    var hT = $('#_AreaInfoSection').offset().top,
        hH = $('#_AreaInfoSection').outerHeight(),
        wH = $(window).height(),
        wS = $(this).scrollTop();
    //console.log((hT - wH), wS);
    if (wS > (hT + hH - wH) && lock_AreaInfoSection) {
        //alert('I have scrolled to Highly Rated Dormitories');
        lock_AreaInfoSection = false;

        $.ajax({
            type: "POST",
            url: "GetAreaInfoSection",
            data: {
                SectionId: "_AreaInfoSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_AreaInfoSection").html(result);



            }
        });


    }
});




var lock_FacilitiesSection = true;
$(window).scroll(function () {
    var hT = $('#_FacilitiesSection').offset().top,
        hH = $('#_FacilitiesSection').outerHeight(),
        wH = $(window).height(),
        wS = $(this).scrollTop();
    //console.log((hT - wH), wS);
    if (wS > (hT + hH - wH) && lock_FacilitiesSection) {
        //alert('I have scrolled to Highly Rated Dormitories');
        lock_FacilitiesSection = false;

        $.ajax({
            type: "POST",
            url: "GetFacilitiesSection",
            data: {
                SectionId: "_FacilitiesSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_FacilitiesSection").html(result);



            }
        });


    }
});



var lock_GoodToKnowSection = true;
$(window).scroll(function () {
    var hT = $('#_GoodToKnowSection').offset().top,
        hH = $('#_GoodToKnowSection').outerHeight(),
        wH = $(window).height(),
        wS = $(this).scrollTop();
    //console.log((hT - wH), wS);
    if (wS > (hT + hH - wH) && lock_GoodToKnowSection) {
        //alert('I have scrolled to Highly Rated Dormitories');
        lock_GoodToKnowSection = false;

        $.ajax({
            type: "POST",
            url: "GetGoodToKnowSection",
            data: {
                SectionId: "_GoodToKnowSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_GoodToKnowSection").html(result);



            }
        });


    }
});


var lock_ReviewBottomSection = true;
$(window).scroll(function () {
    var hT = $('#_ReviewBottomSection').offset().top,
        hH = $('#_ReviewBottomSection').outerHeight(),
        wH = $(window).height(),
        wS = $(this).scrollTop();
    //console.log((hT - wH), wS);
    if (wS > (hT + hH - wH) && lock_ReviewBottomSection) {
        //alert('I have scrolled to Highly Rated Dormitories');
        lock_ReviewBottomSection = false;

        $.ajax({
            type: "POST",
            url: "GetReviewBottomSection",
            data: {
                SectionId: "_ReviewBottomSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_ReviewBottomSection").html(result);



            }
        });


    }
});



//var lock_SlidersSection = true;
//$(window).scroll(function () {
//    var hT = $('#_SlidersSection').offset().top,
//        hH = $('#_SlidersSection').outerHeight(),
//        wH = $(window).height(),
//        wS = $(this).scrollTop();
//    //console.log((hT - wH), wS);
//    if (wS > (hT + hH - wH) && lock_SlidersSection) {
//        //alert('I have scrolled to Highly Rated Dormitories');
//        lock_TopnavDormitorySection = false;

//        $.ajax({
//            type: "POST",
//            url: "GetTopnavDormitorySection",
//            data: {
//                SectionId: "_SlidersSection"
//            },
//            success: function (result) {
//                //     alert(result);
//                $("#_SlidersSection").html(result);



//            }
//        });


//    }
//});


