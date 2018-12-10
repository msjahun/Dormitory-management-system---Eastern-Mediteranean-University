$.ajax({
    type: "POST",
    url: "Home/GetHomeBackgroundImages",

    success: function (result) {
        //     alert(result);


        function changeBackground() {
            // #wallpaper_fullScreen

            var imageUrls = result;

            var section = document.getElementById("wallpaper_fullScreen");   // Get the first <h1> element in the document
            var att = document.createAttribute("style");       // Create a "class" attribute
            att.value = "background-image: url('" + imageUrls[Math.floor((Math.random() * 4) + 0)] + "'); background-position: center 60%; background-repeat: no-repeat; background-size: auto;";                           // Set the value of the class attribute
            section.setAttributeNode(att);
            setTimeout(changeBackground, 5000);
        }
        setTimeout(changeBackground, 5000);
    }
})



var swiper3 = new Swiper('#swiper-row3', {});
var swiper1 = new Swiper('#swiper-row1', {});


var swiper2 = new Swiper('#swiper-row2', {});

$.ajax({
    type: "POST",
    url: "Home/GetHomeDormitoriesPartial",
    data: {
        SectionId: "CoolOfferAndDeals",
        SwiperId: "swiper-row3"
    },
    success: function (result) {
        //     alert(result);
        $("#CoolOfferAndDeals").html(result);
        swiper3 = new Swiper('#swiper-row3', {
            slidesPerView: slidesPerView(),
            centeredSlides: true,

            spaceBetween: 20,

            autoplay: {
                delay: 2500,
                disableOnInteraction: true
            },
            loop: true

        });
   

    }
});

$.ajax({
    type: "POST",
    url: "Home/GetHomeDormitoriesPartial",
    data: {
        SectionId: "HighlyRatedDormitories",
        SwiperId: "swiper-row2"
    },
    success: function (result) {
        //     alert(result);
        $("#HighlyRatedDormitories").html(result);
        swiper2 = new Swiper('#swiper-row2', {
            slidesPerView: slidesPerView(),
            centeredSlides: true,
            resize: true,
            spaceBetween: 20,
            navigation: {
                nextEl: '.swiper-button-next',
                prevEl: '.swiper-button-prev'
            },
            autoplay: {
                delay: 2200,
                disableOnInteraction: true
            },
            loop: true,
            pagination: {
                el: '.swiper-pagination',
                clickable: true
            },
        });


    }
})

$.ajax({
    type: "POST",
    url: "Home/GetHomeDormitoriesPartial",
    data: {
        SectionId: "PopularDormitories",
        SwiperId: "swiper-row1"
    },
    success: function (result) {
        //     alert(result);
        $("#PopularDormitories").html(result);
        swiper1 = new Swiper('#swiper-row1', {
            slidesPerView: slidesPerView(),
            centeredSlides: true,
            resize: true,
            spaceBetween: 20,
            navigation: {
                nextEl: '.swiper-button-next',
                prevEl: '.swiper-button-prev'
            },
            autoplay: {
                delay: 3000,
                disableOnInteraction: true
            },
            loop: true,
            pagination: {
                el: '.swiper-pagination',
                clickable: true
            }
        });


    }
})




$(window).resize(function () {
    var ww = $(window).width()
    if (ww > 1000) {
        swiper1.params.slidesPerView = swiper2.params.slidesPerView = swiper3.params.slidesPerView = 4;

    }
    if (ww > 468 && ww <= 1000) {
        swiper1.params.slidesPerView = swiper2.params.slidesPerView = swiper3.params.slidesPerView = 2;

    }
    if (ww <= 468) {
        swiper1.params.slidesPerView = swiper2.params.slidesPerView = swiper3.params.slidesPerView = 1;

    }

});
$(window).trigger('resize');


function slidesPerView() {

    var ww = $(window).width()
    if (ww > 1000) {
        return 4;

    }
    if (ww > 468 && ww <= 1000) {
        return 2;

    }
    if (ww <= 468) {
        return 1;

    }
}