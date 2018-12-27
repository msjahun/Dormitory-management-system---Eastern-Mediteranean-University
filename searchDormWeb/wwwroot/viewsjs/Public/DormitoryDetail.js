

var dormitory_id = $('#dormitoryId').val();
$.ajax({
    type: "POST",
    url: location.origin + "/Dormitory/GetTopnavDormitorySection/" + dormitory_id,
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
    url: location.origin + "/Dormitory/GetCommentsSection/" + dormitory_id,
    data: {
        SectionId: "comments_section"
    },
    success: function (result) {
        //     alert(result);
        $("#comments_section").html(result);



    }
});


//alert(sessionStorage.getItem('label'));
        $.ajax({
            type: "POST",
            url: location.origin + "/Dormitory/GetDormitoryDescriptionSection/" + dormitory_id,
            data: {
                SectionId: "_DormitoryDescriptionSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_DormitoryDescriptionSection").html(result);




                var lockonScrollAlert_1 = true;
                $(window).scroll(function () {
                    var hT = $('#onScrollAlert_1').offset().top,
                        hH = $('#onScrollAlert_1').outerHeight(),
                        wH = $(window).height(),
                        wS = $(this).scrollTop();
                    //console.log((hT - wH), wS);
                    if (wS > (hT + hH + 300 - wH) && lockonScrollAlert_1) {
                        //alert('I have scrolled to Highly Rated Dormitories');
                        lockonScrollAlert_1 = false;
                        var loader = "<div class=\"text-center mt-5\"> <div class=\"lds-ring\"><div></div><div></div><div></div><div></div></div> </div>";
                        $("#onScrollAlert").html(loader);

                        $.ajax({
                            type: "POST",
                            url: location.origin + "/Dormitory/GetOnScrollAlert/" + dormitory_id,
                            data: {
                                SectionId: "onScrollAlert_1"
                            },
                            success: function (result) {
                                //     alert(result);
                                setTimeout(function () {
                                    $("#onScrollAlert_1").html(result);
                                }, 500);




                            }
                        });


                    }
                });

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
            url: location.origin + "/Dormitory/GetRoomSection/" + dormitory_id,
            data: {
                SectionId: "_RoomSection"
            },
            success: function (result) {
                //     alert(result);
                $("#_RoomSection").html(result);


                var lockonScrollAlert_2 = true;
                $(window).scroll(function () {
                    var hT = $('#onScrollAlert_2').offset().top,
                        hH = $('#onScrollAlert_2').outerHeight(),
                        wH = $(window).height(),
                        wS = $(this).scrollTop();
                    //console.log((hT - wH), wS);
                    if (wS > (hT + hH + 300 - wH) && lockonScrollAlert_2) {
                        //alert('I have scrolled to Highly Rated Dormitories');
                        lockonScrollAlert_2 = false;
                        var loader = "<div class=\"text-center mt-5\"> <div class=\"lds-ring\"><div></div><div></div><div></div><div></div></div> </div>";
                        $("#onScrollAlert_2").html(loader);

                        $.ajax({
                            type: "POST",
                            url: location.origin + "/Dormitory/GetOnScrollAlert/" + dormitory_id,
                            data: {
                                SectionId: "onScrollAlert_2"
                            },
                            success: function (result) {
                                //     alert(result);
                                setTimeout(function () {
                                    $("#onScrollAlert_2").html(result);
                                }, 500);




                            }
                        });


                    }
                });


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
            url: location.origin + "/Dormitory/GetAreaInfoSection/" + dormitory_id,
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
            url: location.origin + "/Dormitory/GetFacilitiesSection/" + dormitory_id,
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
            url: location.origin + "/Dormitory/GetGoodToKnowSection/" + dormitory_id,
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
            url: location.origin + "/Dormitory/GetReviewBottomSection/" + dormitory_id,
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
    url: location.origin + "/Dormitory/GetSlidersSection/" + dormitory_id,
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
                prevEl: '.swiper-button-prev'
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
            $('#grid-item-' + swiper.activeIndex).addClass('grid-item-active');


        });

        setTimeout(function () {
            $('.grid').masonry({
                // options
                itemSelector: '.grid-item'

            });

            $('#grid-item-0').addClass('grid-item-active');
           
            $('.grid-item').imagefill({ throttle: 1000 / 60 });
     

        }, 50);





    }
});




function swiperClick(index) {
    //   alert(index);
    swiper.slideTo(index, 1, false);
}








// for filter model, responsive I filter style
var modal = document.getElementById('myModal');
// Get the button that opens the modal
var btn = document.getElementById("FabBtn");
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
// When the user clicks the button, open the modal
btn.onclick = function () {
    if (modal.style.display == "block") {
        modal.style.display = "none";
    } else {
        modal.style.display = "block";
    }
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

// our noUi sliders
//intialization and listeners

var SingleSlider = (function () {

    // Variables

    var $sliderContainer = $(".input-slider-container");


    // Methods

    function init($this) {
        var $slider = $this.find('.input-slider');
        var sliderId = $slider.attr('id');
        var minValue = $slider.data('range-value-min');
        var maxValue = $slider.data('range-value-max');

        var sliderValue = $this.find('.range-slider-value');
        var sliderValueId = sliderValue.attr('id');
        var startValue = sliderValue.data('range-value-low');

        var c = document.getElementById(sliderId),
            d = document.getElementById(sliderValueId);

        var options = {
            start: [parseInt(startValue)],
            connect: [true, false],
            //step: 1000,
            range: {
                'min': [parseInt(minValue)],
                'max': [parseInt(maxValue)]
            }
        }

        noUiSlider.create(c, options);

        c.noUiSlider.on('update', function (a, b) {
            d.textContent = a[b];
        });

        c.noUiSlider.on('change.one', function () {
           // SearchRooms();
        });

    }


    // Events

    if ($sliderContainer.length) {
        $sliderContainer.each(function () {
            init($(this));
        });
    }

})();




var RangeSlider = (function () {

    // Variables

    var $sliderContainer = $("#input-slider-range");


    // Methods

    function init($this) {
        var c = document.getElementById("input-slider-range"),
            d = document.getElementById("input-slider-range-value-low"),
            e = document.getElementById("input-slider-range-value-high"),
            f = [d, e];

        noUiSlider.create(c, {
            start: [parseInt(d.getAttribute('data-range-value-low')), parseInt(e.getAttribute('data-range-value-high'))],
            connect: !0,
            range: {
                min: parseInt(c.getAttribute('data-range-value-min')),
                max: parseInt(c.getAttribute('data-range-value-max'))
            }
        }), c.noUiSlider.on("update", function (a, b) {
            f[b].textContent = a[b];
        });

        c.noUiSlider.on('change.one', function () {
           // SearchRooms();
        });
    }


    // Events

    if ($sliderContainer.length) {
        $sliderContainer.each(function () {
            init($(this));
        });
    }

})();



