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


//sessionStorage.setItem('label', 'value');
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

      

 

        var lockonScrollAlert = true;
        $(window).scroll(function () {
            var hT = $('#onScrollAlert').offset().top,
                hH = $('#onScrollAlert').outerHeight(),
                wH = $(window).height(),
                wS = $(this).scrollTop();
            //console.log((hT - wH), wS);
            if (wS > (hT + hH + 300 - wH) && lockonScrollAlert) {
                //alert('I have scrolled to Highly Rated Dormitories');
                lockonScrollAlert = false;
                var loader = "<div class=\"text-center mt-5\"> <div class=\"lds-ring\"><div></div><div></div><div></div><div></div></div> </div>";
                $("#onScrollAlert").html(loader);

                $.ajax({
                    type: "POST",
                    url: "GetOnScrollAlert",
                    data: {
                        SectionId: "onScrollAlert"
                    },
                    success: function (result) {
                        //     alert(result);
                        setTimeout(function () {
                            $("#onScrollAlert").html(result);
                        }, 500);




                    }
                });


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


$.ajax({
    type: "POST",
    url: "GetDormitoryTypesFilter",
    data: {
        SectionId: "_DormitoryTypes"
    },
    success: function (result) {
        //     alert(result);
        $("#_DormitoryTypesFilter").html(result);
     

    }
});


$.ajax({
    type: "POST",
    url: "GetDormitoriesFilter",
    data: {
        SectionId: "_DormitoriesList"
    },
    success: function (result) {
        //     alert(result);
        $("#_DormitoriesFilter").html(result);
     


    }
});

$("#_DormitoryTypesFilter").change(function () {

    $.ajax({
        type: "POST",
        url: "GetDormitoriesFilter/" + $("#_DormitoryTypesFilter option:selected").val(),
        data: {
            SectionId: "_DormitoriesList"
        },
        success: function (result) {
            //     alert(result);
            $("#_DormitoriesFilter").html(result);



        }
    });

});



var swiper_room = new Swiper('.swiper_container_room', {});

$(".targetFilterInput").change(function () {
    SearchRooms();
});
$(".targetFilterInputStatic").change(function () {
    SearchRooms();
});



//Global vars
var PriceMin = 0;
var PriceMax = 10000000;
var RoomArea = 1000000;
var sortId = 1;// 
function SearchRooms() {
    insertLoaderInSearchArea();
  
    var checkedVals = $('.targetFilterInput:checkbox:checked').map(function () {
        return this.value;
    }).get();
 
    console.log("dynamic values",checkedVals.join(","));
    var isCheckedShowAvailable = $('#ShowAvailable').is(':checked');
    var isCheckedShowDiscountsOnly = $('#ShowDiscounts').is(':checked');
    var DormitoriesMultiSelect = $('#_DormitoriesFilter').val();
    var DormitoryType = $('#_DormitoryTypesFilter').val();
    var PrivateDormitory = $('#privateDormitories').is(':checked');
    var SchoolDormitory = $('#schoolDormitories').is(':checked');

    var RatingStar1 = $('#RatingStar1').is(':checked');
    var RatingStar2 = $('#RatingStar2').is(':checked');
    var RatingStar3 = $('#RatingStar3').is(':checked');
    var RatingStar4 = $('#RatingStar4').is(':checked');
    var RatingStar5 = $('#RatingStar5').is(':checked');
  var RatingUnrated = $('#RatingUnrated').is(':checked');
    //console.log($('.targetFilterInput').val());
    $.ajax({
        type: "POST",
        url: "GetRoomResultView",
        data: {
            SectionId: "SearchResultSection",
            FeaturesIds: checkedVals,
            DormitoryTypeIds: DormitoryType,
            DormitoryNameIds: DormitoriesMultiSelect,
            PriceMin: PriceMin,
            PriceMax: PriceMax,
            RoomArea: RoomArea,
            ShowAvailable: isCheckedShowAvailable,
            ShowDiscountsOnly: isCheckedShowDiscountsOnly,
            PrivateDormitories: PrivateDormitory,
            SchoolDormitories: SchoolDormitory,
            sortId: sortId,

            RatingStar1:RatingStar1,
            RatingStar2:RatingStar2,
            RatingStar3:RatingStar3,
            RatingStar4:RatingStar4,
            RatingStar5:RatingStar5,
            RatingUnrated:RatingUnrated

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




        
            //mansory js
            var lockonScrollAlert = true;
            $(window).scroll(function () {
                var hT = $('#onScrollAlert').offset().top,
                    hH = $('#onScrollAlert').outerHeight(),
                    wH = $(window).height(),
                    wS = $(this).scrollTop();
                //console.log((hT - wH), wS);
                if (wS > (hT + hH + 300 - wH) && lockonScrollAlert) {
                    //alert('I have scrolled to Highly Rated Dormitories');
                    lockonScrollAlert = false;
                    var loader = "<div class=\"text-center mt-5\"> <div class=\"lds-ring\"><div></div><div></div><div></div><div></div></div> </div>";
                    $("#onScrollAlert").html(loader);

                    $.ajax({
                        type: "POST",
                        url: "GetOnScrollAlert",
                        data: {
                            SectionId: "onScrollAlert"
                        },
                        success: function (result) {
                            //     alert(result);
                            setTimeout(function () {
                                $("#onScrollAlert").html(result);
                            }, 500);




                        }
                    });


                }
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
        };

        noUiSlider.create(c, options);

        c.noUiSlider.on('update', function (a, b) {
            d.textContent = a[b];
            //console.log(a + "update " + b);
        });

        c.noUiSlider.on('change.one', function (a, b) {
            console.log(a + "Room area");
            RoomArea = a[0];

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
            f[b].textContent = a[b];
        });

        c.noUiSlider.on('change.one', function (a, b) {
            console.log(a[0] + "min " + a[1] + "max " + "Price range");
            PriceMin = a[0];
            PriceMax = a[1];
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
