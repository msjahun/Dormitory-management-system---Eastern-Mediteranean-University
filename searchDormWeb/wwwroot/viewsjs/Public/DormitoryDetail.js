


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


var swiper = new Swiper('.swiper-container', {});

$.ajax({
    type: "POST",
    url: "GetSlidersSection",
    data: {
        SectionId: "_SlidersSection"
    },
    success: function (result) {
        //     alert(result);
        $("#_SlidersSection").html(result);


        swiper = new Swiper('.swiper-container', {
            slidesPerView: 'auto',
            centeredSlides: true,
            spaceBetween: 30,
            watchActiveIndex: true,
            navigation: {
                nextEl: '.swiper-button-next',
                prevEl: '.swiper-button-prev',
            },
            autoplay: {
                delay: 2500,
                disableOnInteraction: false
            },
            pagination: {
                el: '.swiper-pagination',
                clickable: true
            }
        });


        swiper.on('slideChange', function () {
            //  console.log('slide changed' + swiper.activeIndex);
            $('.grid-item').removeClass('grid-item-active');
            $('#grid-item' + swiper.activeIndex).addClass('grid-item-active');


        });

        setTimeout(function () {
            $('.grid').masonry({
                // options
                itemSelector: '.grid-item'

            });

            $('#grid-item0').addClass('grid-item-active');
        }, 50);





    }
});




function swiperClick(index) {
    //   alert(index);
    swiper.slideTo(index, 1, false);
}





if ($(window).width() >= 991) {
    //console.log("Conditions are met");

    var element = $('#comments_section').detach();
    $('#CommentSectionLgScreens').append(element);
} else {
    // console.log("Conditions are not met");
    var element2 = $('#comments_section').detach();
    $('#CommentSectionSmScreens').append(element2);


}
window.onresize = function (event) {
    if ($(window).width() >= 991) {
        //console.log("Conditions are met");

        var element = $('#comments_section').detach();
        $('#CommentSectionLgScreens').append(element);
    } else {
        // console.log("Conditions are not met");
        var element2 = $('#comments_section').detach();
        $('#CommentSectionSmScreens').append(element2);


    }
};




// for filter model, responsive I filter style
var modal = document.getElementById('myModal');
// Get the button that opens the modal
var btn = document.getElementById("FabBtn");
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
// When the user clicks the button, open the modal
btn.onclick = function () {
    modal.style.display = "block";
}


// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

//on screen change check $(window).width(); //then display or hide filter
window.onresize = function (event) {
    if ($(window).width() >= 990) {
        //    console.log("Conditions are met");
        modal.style.display = "block";
    } else {
        // console.log("Conditions are not met");
        modal.style.display = "none";
    }
};

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}