﻿// for filter model, responsive I filter style
var modal = document.getElementById('myModal');
// Get the button that opens the modal
var btn = document.getElementById("FabBtn");
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
// When the user clicks the button, open the modal
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
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



var swiper = new Swiper('.swiper-container', {});


$.ajax({
    type: "POST",
    url: "GetSortingButtonSection",
    data: {
        SectionId: "_SortingButtonsSection"
    },
    success: function (result) {
        //     alert(result);
        $("#_SortingButtonsSection").html(result);



    }
});



$.ajax({
    type: "POST",
    url: "GetDormitoryResultView",
    data: {
        SectionId: "SearchResultSection"
    },
    success: function (result) {
        //     alert(result);
        $("#SearchResultSection").html(result);


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


    }
});


$.ajax({
    type: "POST",
    url: "GetFilterbottomFacilities",
    data: {
        SectionId: "_FilterbottomFacilities"
    },
    success: function (result) {
        //     alert(result);
        $("#_FilterbottomFacilities").html(result);
        $(".targetFilterInput").change(function () {
            SearchRooms();
        });


    }
});





$(".targetFilterInput").change(function () {
    SearchRooms();
});

function SearchRooms() {
    insertLoaderInSearchArea();

    $.ajax({
        type: "POST",
        url: "GetRoomResultView",
        data: {
            SectionId: "SearchResultSection"
        },
        success: function (result) {
            //     alert(result);
            $("#SearchResultSection").html(result);


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



            $('#DealEnds').countdown('2018/12/12 24:00:00')
                .on('update.countdown', function (event) {
                    var format = '%H:%M:%S';
                    if (event.offset.totalDays > 0) {
                        format = '%-d day%!d ' + format;
                    }
                    if (event.offset.weeks > 0) {
                        format = '%-w week%!w ' + format;
                    }
                    $(this).html('Deal ends in ' + event.strftime(format));
                })
                .on('finish.countdown', function (event) {
                    $(this).html('This offer has expired!')
                        .parent().addClass('disabled');

                });

        }
    });
}

function insertLoaderInSearchArea() {
    var loader = "<div class=\"text-center mt-5\"> <div class=\"lds-ring\"><div></div><div></div><div></div><div></div></div> </div>";
    $("#SearchResultSection").html(loader);
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
            SearchRooms();
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
            f[b].textContent = a[b]
        });

        c.noUiSlider.on('change.one', function () {
            SearchRooms();
        });
    }


    // Events

    if ($sliderContainer.length) {
        $sliderContainer.each(function () {
            init($(this));
        });
    }

})();
