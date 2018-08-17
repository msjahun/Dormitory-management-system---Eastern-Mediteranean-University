$(document).ready(function () {

    $('.border_hover_map').click(function () {
        alert("I have been clicked");
       // $(this).toggleClass('box-success');
    });

    $('.border_hover_map').hover(function () {
        alert("I have been hovered");
        //$(this).addClass('box-warning');
    });

    $('.border_hover_map').mouseleave(function () {
            alert("I have mouseleave");
           // $(this).addClass('box-success');
        });

    var name_of_dormitoryPosted = " ";
    var dormitory_typePosted = 0;
    var min_price_of_roomPosted = 0;
    var max_price_of_roomPosted = 100000000000;
    var min_RoomAreaPosted = 0;
    var max_RoomAreaPosted = 100000;
    var room_areaPostedMin = 0;
    var room_areaPostedMax = 100000;

    var facility_TVPosted = " ";
    var facility_InternetPosted = " ";
    var facility_Wc_showerPosted = " ";
    var facility_KitchenettePosted = " ";
    var facility_bedPosted = " ";

    var facility_air_conditionPosted = " " ;
    var facility_central_acPosted = " ";
    var facility_refrigeratorPosted = " ";
    var facility_laundryPosted = " ";
    var facility_cafeteriaPosted = " ";
    var facility_room_telPosted = " ";
    var facility_generatorPosted = " ";
    var langIDPosted = 1;
    var sort_byPosted = "Null";

    var price_2000_to_2499 = { min: 0, max: 1000000 };
    var price_2500_to_2999 = { min: 0, max: 1000000 };
    var price_3000_to_3499 = { min: 0, max: 1000000 };
    var price_4000_to_4999 = { min: 0, max: 1000000 };
    var price_5000_to_6000 = { min: 0, max: 1000000 };
    var price_greater_than_6000 = { min: 0, max: 1000000 };

    var room_area_10_to_20 = { min: 0, max: 1000000 };
    var room_area_21_to_25 = { min: 0, max: 1000000 };
    var room_area_26_to_30 = { min: 0, max: 1000000 };
    var room_area_greater_than_30 = { min: 0, max: 1000000 };




    langIDPosted = $('#hiddenLanguageId').val();
    get_main_search_loader();
    get_filter_values();
   // alert(max_price_of_roomPosted + " " + min_price_of_roomPosted);
    $.ajax({
        type: "POST",
        url: "/Home/GetView",
        data: {
            name_of_dormitory: name_of_dormitoryPosted,
            dormitory_type: dormitory_typePosted,
            min_price_of_room:0,
            max_price_of_room: 10000,
            room_areaMin: room_areaPostedMin,
            room_areaMax: room_areaPostedMax,
            langId: langIDPosted,
            facility_TV: facility_TVPosted,
            facility_Internet: facility_InternetPosted,
            facility_Wc_shower: facility_Wc_showerPosted,
            facility_Kitchenette: facility_KitchenettePosted,
            facility_bed: facility_bedPosted,

            facility_air_condition: facility_air_conditionPosted,
            facility_central_ac: facility_central_acPosted,
            facility_refrigerator: facility_refrigeratorPosted,
            facility_laundry: facility_laundryPosted,
            facility_cafeteria: facility_cafeteriaPosted,
            facility_room_tel: facility_room_telPosted,
            facility_generator: facility_generatorPosted,
            sort_by: sort_byPosted
        },
        success: function (result) {
            //     alert(result);
            $("#search_results").html(result);
        }
    })



   //Submit Button
    $("#btnSubmit").click(function () {

        search_main();

    });


    $("#search_btn_modal-default_fab_map").click(function () {
      // alert("hello Responsiveness");
       // search_main();

        price_2000_to_2499 = { min: 0, max: 1000000 };
        price_2500_to_2999 = { min: 0, max: 1000000 };
        price_3000_to_3499 = { min: 0, max: 1000000 };
        price_4000_to_4999 = { min: 0, max: 1000000 };
        price_5000_to_6000 = { min: 0, max: 1000000 };
        price_greater_than_6000 = { min: 0, max: 1000000 };

        room_area_10_to_20 = { min: 0, max: 1000000 };
        room_area_21_to_25 = { min: 0, max: 1000000 };
        room_area_26_to_30 = { min: 0, max: 1000000 };
        room_area_greater_than_30 = { min: 0, max: 1000000 };
        get_main_map_area_loader();
        get_mini_model_search_loader();
        get_filter_values_modal_default_fab_map();

        $.ajax({
            type: "POST",
            url: "/Home/GetSearchResultMapViewResponsive",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                price_2000_to_2499: price_2000_to_2499,
                price_2500_to_2999: price_2500_to_2999,
                price_3000_to_3499: price_3000_to_3499,
                price_4000_to_4999: price_4000_to_4999,
                price_5000_to_6000: price_5000_to_6000,
                price_greater_than_6000: price_greater_than_6000,

                room_area_10_to_20: room_area_10_to_20,
                room_area_21_to_25: room_area_21_to_25,
                room_area_26_to_30: room_area_26_to_30,
                room_area_greater_than_30: room_area_greater_than_30,

                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                //     alert(result);
                $("#map_list_result").html(result);
                $("#map_area_column").html(" <div id=\"map\" class=\"map_area_column\"> </div>");
                var mapOptions = {
                    center: new google.maps.LatLng(35.147259871259195, 33.9071613550185),
                    zoom: 15,
                    mapTypeId: 'terrain'
                }
                var map = new google.maps.Map(document.getElementById("map"), mapOptions);
                mapResultInit(map);
                addInfoWindows(map);
            }
        })

    });

    
    $("#search_btn_responsive_modal").click(function () {
     //   alert("hello Responsiveness");
       // search_main();

        price_2000_to_2499 = { min: 0, max: 1000000 };
        price_2500_to_2999 = { min: 0, max: 1000000 };
        price_3000_to_3499 = { min: 0, max: 1000000 };
        price_4000_to_4999 = { min: 0, max: 1000000 };
        price_5000_to_6000 = { min: 0, max: 1000000 };
        price_greater_than_6000 = { min: 0, max: 1000000 };

        room_area_10_to_20 = { min: 0, max: 1000000 };
        room_area_21_to_25 = { min: 0, max: 1000000 };
        room_area_26_to_30 = { min: 0, max: 1000000 };
        room_area_greater_than_30 = { min: 0, max: 1000000 };
        get_main_search_loader();
        get_filter_values_responsive_modals();

        $.ajax({
            type: "POST",
            url: "/Home/GetSearchResultResponsive",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                price_2000_to_2499: price_2000_to_2499,
                price_2500_to_2999: price_2500_to_2999,
                price_3000_to_3499: price_3000_to_3499,
                price_4000_to_4999: price_4000_to_4999,
                price_5000_to_6000: price_5000_to_6000,
                price_greater_than_6000: price_greater_than_6000,

                room_area_10_to_20: room_area_10_to_20,
                room_area_21_to_25: room_area_21_to_25,
                room_area_26_to_30: room_area_26_to_30,
                room_area_greater_than_30: room_area_greater_than_30,

                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                //     alert(result);
                $("#search_results").html(result);
            }
        })

    });

    function init_values() {
         name_of_dormitoryPosted = " ";
         dormitory_typePosted = 0;
         min_price_of_roomPosted = 0;
         max_price_of_roomPosted = 100000000000;
         min_RoomAreaPosted = 0;
         max_RoomAreaPosted = 100000;
         room_areaPostedMin = 0;
         room_areaPostedMax = 100000;

         facility_TVPosted = " ";
         facility_InternetPosted = " ";
         facility_Wc_showerPosted = " ";
         facility_KitchenettePosted = " ";
         facility_bedPosted = " ";

         facility_air_conditionPosted = " ";
         facility_central_acPosted = " ";
         facility_refrigeratorPosted = " ";
         facility_laundryPosted = " ";
         facility_cafeteriaPosted = " ";
         facility_room_telPosted = " ";
         facility_generatorPosted = " ";
         langIDPosted = 1;
         sort_byPosted = "Null";

         price_2000_to_2499 = { min: 0, max: 1000000 };
         price_2500_to_2999 = { min: 0, max: 1000000 };
         price_3000_to_3499 = { min: 0, max: 1000000 };
         price_4000_to_4999 = { min: 0, max: 1000000 };
         price_5000_to_6000 = { min: 0, max: 1000000 };
         price_greater_than_6000 = { min: 0, max: 1000000 };

         room_area_10_to_20 = { min: 0, max: 1000000 };
         room_area_21_to_25 = { min: 0, max: 1000000 };
         room_area_26_to_30 = { min: 0, max: 1000000 };
         room_area_greater_than_30 = { min: 0, max: 1000000 };


    }

    //Submit Button
    $("#btnSubmitResponsive").click(function () {
     //   alert("woah!!!");
        //search_main();

        price_2000_to_2499 = { min: 0, max: 1000000 };
        price_2500_to_2999 = { min: 0, max: 1000000 };
        price_3000_to_3499 = { min: 0, max: 1000000 };
        price_4000_to_4999 = { min: 0, max: 1000000 };
        price_5000_to_6000 = { min: 0, max: 1000000 };
        price_greater_than_6000 = { min: 0, max: 1000000 };

        room_area_10_to_20 = { min: 0, max: 1000000 };
        room_area_21_to_25 = { min: 0, max: 1000000 };
        room_area_26_to_30 = { min: 0, max: 1000000 };
        room_area_greater_than_30 = { min: 0, max: 1000000 };

        get_main_search_loader();
        get_filter_values();
        

       
        $.ajax({
            type: "POST",
            url: "/Home/GetSearchResultResponsive",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                price_2000_to_2499: price_2000_to_2499,
                price_2500_to_2999: price_2500_to_2999,
                price_3000_to_3499: price_3000_to_3499,
                price_4000_to_4999: price_4000_to_4999,
                price_5000_to_6000: price_5000_to_6000,
                price_greater_than_6000: price_greater_than_6000,  

                room_area_10_to_20: room_area_10_to_20,
                room_area_21_to_25: room_area_21_to_25,
                room_area_26_to_30: room_area_26_to_30,
                room_area_greater_than_30: room_area_greater_than_30,
             
                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                //     alert(result);
                $("#search_results").html(result);
            }
        })

       

    });
     //Submit Button
    $("#search_btn_modal_map").click(function () {
     // alert("woah!!!");
        //search_main();

      
        get_main_map_area_loader();
        get_mini_model_search_loader();
        get_filter_values_modal_map();
        
        $.ajax({
            type: "POST",
            url: "/Home/GetMapView",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                min_price_of_room: min_price_of_roomPosted,
                max_price_of_room: max_price_of_roomPosted,
                room_areaMin: room_areaPostedMin,
                room_areaMax: room_areaPostedMax,
                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                //     alert(result);
                $("#map_list_result").html(result);
                $("#map_area_column").html(" <div id=\"map\" class=\"map_area_column\"> </div>");
                var mapOptions = {
                    center: new google.maps.LatLng(35.147259871259195, 33.9071613550185),
                    zoom: 15,
                    mapTypeId: 'terrain'
                }
                var map = new google.maps.Map(document.getElementById("map"), mapOptions);
                mapResultInit(map);
                addInfoWindows(map);
                
            }
        })
       

    });

    function search_sort_main() {

        //<a class="" id="nextLangId"  href="/FeesAndFacilities/Index/tr" title="Türkçe">tr</a>
        get_main_search_loader();
        get_sort_filter_values();

        //  alert(max_price_of_roomPosted + " " + min_price_of_roomPosted);
        $.ajax({
            type: "POST",
            url: "/Home/GetView",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                min_price_of_room: min_price_of_roomPosted,
                max_price_of_room: max_price_of_roomPosted,
                room_areaMin: min_RoomAreaPosted,
                room_areaMax: max_RoomAreaPosted,
                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                //     alert(result);
                $("#search_results").html(result);
            }
        })
        console.log("should have loaded partial view");
    }

    function search_main() {

        //<a class="" id="nextLangId"  href="/FeesAndFacilities/Index/tr" title="Türkçe">tr</a>
        get_main_search_loader();
        get_filter_values();

        //  alert(max_price_of_roomPosted + " " + min_price_of_roomPosted);
        $.ajax({
            type: "POST",
            url: "/Home/GetView",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                min_price_of_room: min_price_of_roomPosted,
                max_price_of_room: max_price_of_roomPosted,
                room_areaMin: min_RoomAreaPosted,
                room_areaMax: max_RoomAreaPosted,
                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                //     alert(result);
                $("#search_results").html(result);
            }
        })
        console.log("should have loaded partial view");
    }

    //Map button
    $("#map_image_top, #map_image_side").click(function () {
        get_mini_model_search_loader();
        get_filter_values_modal_map();
        langIDPosted = $('#hiddenLanguageId').val();
        $.ajax({
            type: "POST",
            url: "/Home/GetMapView",
            data: {

                name_of_dormitory: name_of_dormitoryPosted,
                dormitory_type: dormitory_typePosted,
                min_price_of_room: min_price_of_roomPosted,
                max_price_of_room: max_price_of_roomPosted,
                room_areaMin: room_areaPostedMin,
                room_areaMax: room_areaPostedMax,
                langId: langIDPosted,
                facility_TV: facility_TVPosted,
                facility_Internet: facility_InternetPosted,
                facility_Wc_shower: facility_Wc_showerPosted,
                facility_Kitchenette: facility_KitchenettePosted,
                facility_bed: facility_bedPosted,

                facility_air_condition: facility_air_conditionPosted,
                facility_central_ac: facility_central_acPosted,
                facility_refrigerator: facility_refrigeratorPosted,
                facility_laundry: facility_laundryPosted,
                facility_cafeteria: facility_cafeteriaPosted,
                facility_room_tel: facility_room_telPosted,
                facility_generator: facility_generatorPosted,
                sort_by: sort_byPosted
            },
            success: function (result) {
                    // alert("I should technically render map");
                $("#map_list_result").html(result);
                $("#map_area_column").html(" <div id=\"map\" class=\"map_area_column\"> </div>");
                var mapOptions = {
                    center: new google.maps.LatLng(35.147259871259195, 33.9071613550185),
                    zoom: 15,
                    mapTypeId: 'terrain'
                }
                var map = new google.maps.Map(document.getElementById("map"), mapOptions);
                mapResultInit(map);
                addInfoWindows(map);
            }
        })




    });


    $('#selectedDormitoryType_main_topside').on('change', function () {
       //  alert(this.value + "I am the one who knocks");

   

        var dormitory_typePosted = this.value;
        var langIDPosted = 1;
        langIDPosted = $('#hiddenLanguageId').val();
        $.ajax({
            type: "POST",
            url: "/Home/GetDormitoriesBasedOnType",
            data: {
                dormitory_type: dormitory_typePosted,
                langId: langIDPosted 
                
            },
            success: function (result) {
                //     alert(result);
                $("#selectedDormitoryName_main_topside").html(result);
            }
        })

    })


    $('#selectedDormitoryType_modal_map').on('change', function () {
        //  alert(this.value + "I am the one who knocks");



        var dormitory_typePosted = this.value;
        var langIDPosted = 1;
        langIDPosted = $('#hiddenLanguageId').val();
        $.ajax({
            type: "POST",
            url: "/Home/GetDormitoriesBasedOnType",
            data: {
                dormitory_type: dormitory_typePosted,
                langId: langIDPosted

            },
            success: function (result) {
                //     alert(result);
                $("#selectedDormitoryName_modal_map").html(result);
            }
        })

    })


    $('#selectedDormitoryType_modal-default_fab_map').on('change', function () {
        //  alert(this.value + "I am the one who knocks");



        var dormitory_typePosted = this.value;
        var langIDPosted = 1;
        langIDPosted = $('#hiddenLanguageId').val();
        $.ajax({
            type: "POST",
            url: "/Home/GetDormitoriesBasedOnType",
            data: {
                dormitory_type: dormitory_typePosted,
                langId: langIDPosted

            },
            success: function (result) {
                //     alert(result);
                $("#selectedDormitoryName_modal-default_fab_map").html(result);
            }
        })

    })

    
    $('#selectedDormitoryType_modal_responsive').on('change', function () {
       //  alert(this.value + "I am the one who knocks");

   

        var dormitory_typePosted = this.value;
        var langIDPosted = 1;
        langIDPosted = $('#hiddenLanguageId').val();
        $.ajax({
            type: "POST",
            url: "/Home/GetDormitoriesBasedOnType",
            data: {
                dormitory_type: dormitory_typePosted,
                langId: langIDPosted 
                
            },
            success: function (result) {
                //     alert(result);
                $("#selectedDormitoryName_modal_responsive").html(result);
            }
        })

    })


    function get_sort_values() {

        if ($('#sort_price_btn').is(':checked')) {
            console.log("Sort by price selected");
            sort_byPosted = "Price";
        }

        if ($('#sort_alpha_btn').is(':checked')) {
            console.log("Sort by alphabetical order selected");
            sort_byPosted = "a-z";
        }

        if ($('#sort_roomArea_btn').is(':checked')) {
            console.log("Sort by room area selected");
            sort_byPosted = "area";
        }
    }
    function paginationx() {
        alert("I don enter");
        var maxRange = 10 * parseInt($(this).html());
        var minRange = maxRange - 9;
        alert("HTML: " + $(this).html() + " range min:" + minRange + "range max" + maxRange);
    }

    $("#paginationx").click(function () {

        var maxRange = 10 * parseInt($(this).html());
        var minRange = maxRange - 9;
        alert("HTML: " + $(this).html() + " range min:" + minRange + "range max" + maxRange);
    });

    $('#sort_price_btn_label').on('click', function () {
        // $(this).toggleClass('box-warning')// button text will be "finished!"
      //  alert("sort alpha btn");
        sort_byPosted = "Price";
        search_sort_main();
    });

    $('#sort_alpha_btn_label').on('click', function () {
        // $(this).toggleClass('box-warning')// button text will be "finished!"
      //  alert("sort alpha btn");
        sort_byPosted = "a-z";
        search_sort_main();
    });

    $('#sort_roomArea_btn_label').on('click', function () {
        // $(this).toggleClass('box-warning')// button text will be "finished!"
       // alert("sort alpha btn");
        sort_byPosted = "area";
        search_sort_main();
    });


    function get_filter_values() {
        init_values();
        langIDPosted = $('#hiddenLanguageId').val();
        if ($('#minimal-radio-tv-room_main_topside').is(':checked')) {
            // console.log("#minimal-radio-tv-1 checked");
            if (langIDPosted == 2)

                facility_TVPosted = "TV | Odada";
            else
                facility_TVPosted = "TV | In room";
            console.log(facility_TVPosted);

        }

        if ($('#minimal-radio-tv-hall_main_topside').is(':checked')) {
            //console.log("#minimal-radio-tv-2 checked");
            if (langIDPosted == 2)
                facility_TVPosted = "TV | Salonda";
            else
                facility_TVPosted = "TV | In Hall";

            console.log(facility_TVPosted);
        }


        if ($('#minimal-radio-internet-cable_main_topside').is(':checked')) {
            //console.log(" #minimal-radio-internet-1 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablolu";
            else
                facility_InternetPosted = "Internet | Cable";
            console.log(facility_InternetPosted);
        }

        if ($('#minimal-radio-internet-wireless_main_topside').is(':checked')) {
            //console.log("#minimal-radio-internet-2 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablosuz";
            else
                facility_InternetPosted = "Internet | Wireless";
            console.log(facility_InternetPosted);

        }


        if ($('#minimal-radio-wc-room_main_topside').is(':checked')) {
            //console.log("#minimal-radio-wc-1 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Odada";
            else
                facility_Wc_showerPosted = "WC-shower | In room";

            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-common_main_topside').is(':checked')) {
            // console.log("#minimal-radio-wc-2 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Ortak";
            else
                facility_Wc_showerPosted = "WC-shower | Common";
            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-flats_main_topside').is(':checked')) {
            console.log("#minimal-radio-wc-3 checked");
            if (langIDPosted == 2)
                 facility_Wc_showerPosted = "WC - Dus | Katta";
            else
               facility_Wc_showerPosted = "WC-shower | Flats";

        }

        if ($('#minimal-radio-kitchenette-room_main_topside').is(':checked')) {
            // console.log("#minimal-radio-kitchenette-1 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Odada";
            else
                console.log(facility_KitchenettePosted);
        }


        if ($('#minimal-radio-kitchenette-flats_main_topside').is(':checked')) {
            console.log("#minimal-radio-kitchenette-2 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Katta";
            else
                facility_KitchenettePosted = "Kitchenette | Flats";
            console.log(facility_KitchenettePosted);
        }

        if ($('#minimal-radio-bed-bunk_main_topside').is(':checked')) {
            console.log("#minimal-radio-bed-1 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Ranza";
            else
                facility_bedPosted = "Bed | Bunk";
            console.log(facility_bedPosted);
        }

        if ($('#minimal-radio-bed-normal_main_topside').is(':checked')) {
            // console.log("#minimal-radio-bed-2 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Normal";
            else
                facility_bedPosted = "Bed | Normal";
            console.log(facility_bedPosted);

        }

        if ($('#minimal-checkbox-air_condition_main_topside').is(':checked')) {
            //console.log("#minimal-checkbox-air_condition");
            if (langIDPosted == 2)
                facility_air_conditionPosted = "Klima";
            else
                facility_air_conditionPosted = "Air-condition";
            console.log(facility_air_conditionPosted);

        }

        if ($('#minimal-checkbox-central_main_topside').is(':checked')) {
            //  console.log("#minimal-checkbox-central is cheched");
            if (langIDPosted == 2)
                facility_central_acPosted = "Merkezi Isitma | Isitma";
            else
                facility_central_acPosted = "Central conditioning system | Cooling";
            console.log(facility_central_acPosted);
        }


        if ($('#minimal-checkbox-refriferator_main_topside').is(':checked')) {
            //  console.log("#minimal-checkbox-refriferator is cheched");
            if (langIDPosted == 2)
                facility_refrigeratorPosted = "Buzdolabi";
            else
                facility_refrigeratorPosted = "Refrigerator";
            console.log(facility_refrigeratorPosted);
        }


        if ($('#minimal-checkbox-Laundry_main_topside').is(':checked')) {
            //console.log("#minimal-checkbox-Laundry is cheched");
            if (langIDPosted == 2)
                facility_laundryPosted = "Çamasirhane";
            else
                facility_laundryPosted = "Laundry";
            console.log(facility_laundryPosted);
        }


        if ($('#minimal-checkbox-cafeteria_main_topside').is(':checked')) {
            // console.log("#minimal-checkbox-cafeteria is cheched");
            if (langIDPosted == 2)
                facility_cafeteriaPosted = "Kafeterya";
            else
                facility_cafeteriaPosted = "Cafeteria";
            console.log(facility_cafeteriaPosted);

        }


        if ($('#minimal-checkbox-room_main_topside').is(':checked')) {
            //    console.log("#minimal-checkbox-room is cheched");
            if (langIDPosted == 2)
                facility_room_telPosted = "Oda Telefonmu";
            else
                facility_room_telPosted = "Room tel.";
            console.log(facility_room_telPosted);

        }



        if ($('#minimal-checkbox-generator_main_topside').is(':checked')) {
            //console.log("#minimal-checkbox-generator is cheched");
            if (langIDPosted == 2)
                facility_generatorPosted = "Jeneratör";
            else
                facility_generatorPosted = "Generator";
            console.log(facility_generatorPosted);
        }

        if ($('#selectedDormitoryType_main_topside').find(":selected").text().length != 0) {
            //console.log("Selected dormitory type :" + $('#selectedDormitoryType').find(":selected").text());

            dormitory_typePosted = parseInt($('#selectedDormitoryType_main_topside').find(":selected").val());
            console.log(dormitory_typePosted + " " + $('#selectedDormitoryType_main_topside').find(":selected").val());
        }

        if ($('#selectedDormitoryName_main_topside').find(":selected").text().length != 0) {
            //  console.log("Selected dormitory name:" + $('#selectedDormitoryName').find(":selected").text());
            name_of_dormitoryPosted = $('#selectedDormitoryName_main_topside').find(":selected").text();
            console.log(name_of_dormitoryPosted);
        }











        if ($('#minimal-price_2000_to_2499_main_topside').is(':checked')) {
            console.log("#minimal-price_2000_to_2499 is cheched");
            price_2000_to_2499 = {min:2000, max:2499};
        }

        if ($('#minimal-price_2500_to_2999_main_topside').is(':checked')) {
            console.log("#minimal-price_2500_to_2999 is cheched");
             price_2500_to_2999 = { min: 2500, max: 2999 };;
        }
        if ($('#minimal-price_3000_to_3499_main_topside').is(':checked')) {
            console.log("#minimal-price_3000_to_3499 is cheched");
             price_3000_to_3499 = { min: 3000, max: 3499 };
        }
        if ($('#minimal-price_4000_to_4999_main_topside').is(':checked')) {
            console.log("#minimal-price_4000_to_4999 is cheched");
             price_4000_to_4999 = { min: 4000, max: 4999 };
        }

        if ($('#minimal-price_5000_to_6000_main_topside').is(':checked')) {
            console.log("#minimal-price_5000_to_6000 is cheched");
             price_5000_to_6000 = { min: 5000, max: 6000 };
        }
        if ($('#minimal-price_greater_than_6000_main_topside').is(':checked')) {
            console.log("#minimal-price_greater_than_6000_ is cheched");
             price_greater_than_6000 = { min: 6001, max: 100000 };
        }







        if ($('#minimal-room_area_10_to_20_main_topside').is(':checked')) {
            console.log("minimal-room_area_10_to_20 is cheched");
        room_area_10_to_20 = { min: 10, max: 20 };
        }

        if ($('#minimal-room_area_21_to_25_main_topside').is(':checked')) {
            console.log("minimal-room_area_21_to_25 is cheched");
            room_area_21_to_25 = { min: 21, max: 25 };
        }
        if ($('#minimal-room_area_26_to_30_main_topside').is(':checked')) {
            console.log("minimal-room_area_26_to_30 is cheched");
            room_area_26_to_30 = { min: 26, max: 30 };
        }

        if ($('#minimal-room_area_greater_than_30_main_topside').is(':checked')) {
            console.log("minimal-room_area_greater_than_30 is cheched");
             room_area_greater_than_30 = { min: 31, max: 100000 };
        }




        var minPrice = $('#minimal_price_range_main_topside').val().substr(0, $('#minimal_price_range_main_topside').val().indexOf(','));
        min_price_of_roomPosted = minPrice;

        var maxPrice = $('#minimal_price_range_main_topside').val().substr($('#minimal_price_range_main_topside').val().indexOf(",") + 1);
        max_price_of_roomPosted = maxPrice;

        console.log("price range: " + minPrice + " " + maxPrice);


        var minRoomArea = $('#minimal_room_area_range_main_topside').val().substr(0, $('#minimal_room_area_range_main_topside').val().indexOf(','));
        min_RoomAreaPosted = minRoomArea;

        var maxRoomArea = $('#minimal_room_area_range_main_topside').val().substr($('#minimal_room_area_range_main_topside').val().indexOf(",") + 1);
        max_RoomAreaPosted = maxRoomArea;

        console.log("Room area range: " + minRoomArea + " " + maxRoomArea);


        if ($('#sort_price_btn').is(':checked')) {
            console.log("Sort by price selected");
            sort_byPosted = "Price";
        }

        if ($('#sort_alpha_btn').is(':checked')) {
            console.log("Sort by alphabetical order selected");
            sort_byPosted = "a-z";
        }

        if ($('#sort_roomArea_btn').is(':checked')) {
            console.log("Sort by room area selected");
            sort_byPosted = "area";
        }

      

    }

    function get_sort_filter_values() {
        langIDPosted = $('#hiddenLanguageId').val();
        if ($('#minimal-radio-tv-room_main_topside').is(':checked')) {
            // console.log("#minimal-radio-tv-1 checked");
            if (langIDPosted == 2)

                facility_TVPosted = "TV | Odada";
            else
                facility_TVPosted = "TV | In room";
            console.log(facility_TVPosted);

        }

        if ($('#minimal-radio-tv-hall_main_topside').is(':checked')) {
            //console.log("#minimal-radio-tv-2 checked");
            if (langIDPosted == 2)
                facility_TVPosted = "TV | Salonda";
            else
                facility_TVPosted = "TV | In Hall";

            console.log(facility_TVPosted);
        }


        if ($('#minimal-radio-internet-cable_main_topside').is(':checked')) {
            //console.log(" #minimal-radio-internet-1 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablolu";
            else
                facility_InternetPosted = "Internet | Cable";
            console.log(facility_InternetPosted);
        }

        if ($('#minimal-radio-internet-wireless_main_topside').is(':checked')) {
            //console.log("#minimal-radio-internet-2 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablosuz";
            else
                facility_InternetPosted = "Internet | Wireless";
            console.log(facility_InternetPosted);

        }


        if ($('#minimal-radio-wc-room_main_topside').is(':checked')) {
            //console.log("#minimal-radio-wc-1 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Odada";
            else
                facility_Wc_showerPosted = "WC-shower | In room";

            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-common_main_topside').is(':checked')) {
            // console.log("#minimal-radio-wc-2 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Ortak";
            else
                facility_Wc_showerPosted = "WC-shower | Common";
            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-flats_main_topside').is(':checked')) {
            console.log("#minimal-radio-wc-3 checked");
            if (langIDPosted == 2)
                 facility_Wc_showerPosted = "WC - Dus | Katta";
            else
                 facility_Wc_showerPosted = "WC-shower | Flats";

        }

        if ($('#minimal-radio-kitchenette-room_main_topside').is(':checked')) {
            // console.log("#minimal-radio-kitchenette-1 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Odada";
            else
                console.log(facility_KitchenettePosted);
        }


        if ($('#minimal-radio-kitchenette-flats_main_topside').is(':checked')) {
            console.log("#minimal-radio-kitchenette-2 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Katta";
            else
                facility_KitchenettePosted = "Kitchenette | Flats";
            console.log(facility_KitchenettePosted);
        }

        if ($('#minimal-radio-bed-bunk_main_topside').is(':checked')) {
            console.log("#minimal-radio-bed-1 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Ranza";
            else
                facility_bedPosted = "Bed | Bunk";
            console.log(facility_bedPosted);
        }

        if ($('#minimal-radio-bed-normal_main_topside').is(':checked')) {
            // console.log("#minimal-radio-bed-2 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Normal";
            else
                facility_bedPosted = "Bed | Normal";
            console.log(facility_bedPosted);

        }

        if ($('#minimal-checkbox-air_condition_main_topside').is(':checked')) {
            //console.log("#minimal-checkbox-air_condition");
            if (langIDPosted == 2)
                facility_air_conditionPosted = "Klima";
            else
                facility_air_conditionPosted = "Air-condition";
            console.log(facility_air_conditionPosted);

        }

        if ($('#minimal-checkbox-central_main_topside').is(':checked')) {
            //  console.log("#minimal-checkbox-central is cheched");
            if (langIDPosted == 2)
                facility_central_acPosted = "Merkezi Isitma | Isitma";
            else
                facility_central_acPosted = "Central conditioning system | Cooling";
            console.log(facility_central_acPosted);
        }


        if ($('#minimal-checkbox-refriferator_main_topside').is(':checked')) {
            //  console.log("#minimal-checkbox-refriferator is cheched");
            if (langIDPosted == 2)
                facility_refrigeratorPosted = "Buzdolabi";
            else
                facility_refrigeratorPosted = "Refrigerator";
            console.log(facility_refrigeratorPosted);
        }


        if ($('#minimal-checkbox-Laundry_main_topside').is(':checked')) {
            //console.log("#minimal-checkbox-Laundry is cheched");
            if (langIDPosted == 2)
                facility_laundryPosted = "Çamasirhane";
            else
                facility_laundryPosted = "Laundry";
            console.log(facility_laundryPosted);
        }


        if ($('#minimal-checkbox-cafeteria_main_topside').is(':checked')) {
            // console.log("#minimal-checkbox-cafeteria is cheched");
            if (langIDPosted == 2)
                facility_cafeteriaPosted = "Kafeterya";
            else
                facility_cafeteriaPosted = "Cafeteria";
            console.log(facility_cafeteriaPosted);

        }


        if ($('#minimal-checkbox-room_main_topside').is(':checked')) {
            //    console.log("#minimal-checkbox-room is cheched");
            if (langIDPosted == 2)
                facility_room_telPosted = "Oda Telefonmu";
            else
                facility_room_telPosted = "Room tel.";
            console.log(facility_room_telPosted);

        }



        if ($('#minimal-checkbox-generator_main_topside').is(':checked')) {
            //console.log("#minimal-checkbox-generator is cheched");
            if (langIDPosted == 2)
                facility_generatorPosted = "Jeneratör";
            else
                facility_generatorPosted = "Generator";
            console.log(facility_generatorPosted);
        }

        if ($('#selectedDormitoryType_main_topside').find(":selected").text().length != 0) {
            //console.log("Selected dormitory type :" + $('#selectedDormitoryType').find(":selected").text());

            dormitory_typePosted = parseInt($('#selectedDormitoryType_main_topside').find(":selected").val());
            console.log(dormitory_typePosted + " " + $('#selectedDormitoryType_main_topside').find(":selected").val());
        }

        if ($('#selectedDormitoryName_main_topside').find(":selected").text().length != 0) {
            //  console.log("Selected dormitory name:" + $('#selectedDormitoryName').find(":selected").text());
            name_of_dormitoryPosted = $('#selectedDormitoryName_main_topside').find(":selected").text();
            console.log(name_of_dormitoryPosted);
        }







        init_values();



        if ($('#minimal-price_2000_to_2499_main_topside').is(':checked')) {
            console.log("#minimal-price_2000_to_2499 is cheched");
            price_2000_to_2499 = { min: 2000, max: 2499 };
        }

        if ($('#minimal-price_2500_to_2999_main_topside').is(':checked')) {
            console.log("#minimal-price_2500_to_2999 is cheched");
            price_2500_to_2999 = { min: 2500, max: 2999 };;
        }
        if ($('#minimal-price_3000_to_3499_main_topside').is(':checked')) {
            console.log("#minimal-price_3000_to_3499 is cheched");
            price_3000_to_3499 = { min: 3000, max: 3499 };
        }
        if ($('#minimal-price_4000_to_4999_main_topside').is(':checked')) {
            console.log("#minimal-price_4000_to_4999 is cheched");
            price_4000_to_4999 = { min: 4000, max: 4999 };
        }

        if ($('#minimal-price_5000_to_6000_main_topside').is(':checked')) {
            console.log("#minimal-price_5000_to_6000 is cheched");
            price_5000_to_6000 = { min: 5000, max: 6000 };
        }
        if ($('#minimal-price_greater_than_6000_main_topside').is(':checked')) {
            console.log("#minimal-price_greater_than_6000_ is cheched");
            price_greater_than_6000 = { min: 6001, max: 100000 };
        }







        if ($('#minimal-room_area_10_to_20_main_topside').is(':checked')) {
            console.log("minimal-room_area_10_to_20 is cheched");
            room_area_10_to_20 = { min: 10, max: 20 };
        }

        if ($('#minimal-room_area_21_to_25_main_topside').is(':checked')) {
            console.log("minimal-room_area_21_to_25 is cheched");
            room_area_21_to_25 = { min: 21, max: 25 };
        }
        if ($('#minimal-room_area_26_to_30_main_topside').is(':checked')) {
            console.log("minimal-room_area_26_to_30 is cheched");
            room_area_26_to_30 = { min: 26, max: 30 };
        }

        if ($('#minimal-room_area_greater_than_30_main_topside').is(':checked')) {
            console.log("minimal-room_area_greater_than_30 is cheched");
            room_area_greater_than_30 = { min: 31, max: 100000 };
        }




        var minPrice = $('#minimal_price_range_main_topside').val().substr(0, $('#minimal_price_range_main_topside').val().indexOf(','));
        min_price_of_roomPosted = minPrice;

        var maxPrice = $('#minimal_price_range_main_topside').val().substr($('#minimal_price_range_main_topside').val().indexOf(",") + 1);
        max_price_of_roomPosted = maxPrice;

        console.log("price range: " + minPrice + " " + maxPrice);


        var minRoomArea = $('#minimal_room_area_range_main_topside').val().substr(0, $('#minimal_room_area_range_main_topside').val().indexOf(','));
        min_RoomAreaPosted = minRoomArea;

        var maxRoomArea = $('#minimal_room_area_range_main_topside').val().substr($('#minimal_room_area_range_main_topside').val().indexOf(",") + 1);
        max_RoomAreaPosted = maxRoomArea;

        console.log("Room area range: " + minRoomArea + " " + maxRoomArea);





    }

    function get_filter_values_modal_default_fab_map() {
        init_values();
        langIDPosted = $('#hiddenLanguageId').val();

        if ($('#minimal-radio-tv-room_modal-default_fab_map').is(':checked')) {
            // console.log("#minimal-radio-tv-1 checked");
            if (langIDPosted == 2)

                facility_TVPosted = "TV | Odada";
            else
                facility_TVPosted = "TV | In room";
            console.log(facility_TVPosted);

        }

        if ($('#minimal-radio-tv-hall_modal-default_fab_map').is(':checked')) {
            //console.log("#minimal-radio-tv-2 checked");
            if (langIDPosted == 2)
                facility_TVPosted = "TV | Salonda";
            else
                facility_TVPosted = "TV | In Hall";

            console.log(facility_TVPosted);
        }


        if ($('#minimal-radio-internet-cable_modal-default_fab_map').is(':checked')) {
            //console.log(" #minimal-radio-internet-1 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablolu";
            else
                facility_InternetPosted = "Internet | Cable";
            console.log(facility_InternetPosted);
        }

        if ($('#minimal-radio-internet-wireless_modal-default_fab_map').is(':checked')) {
            //console.log("#minimal-radio-internet-2 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablosuz";
            else
                facility_InternetPosted = "Internet | Wireless";
            console.log(facility_InternetPosted);

        }


        if ($('#minimal-radio-wc-room_modal-default_fab_map').is(':checked')) {
            //console.log("#minimal-radio-wc-1 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Odada";
            else
                facility_Wc_showerPosted = "WC-shower | In room";

            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-common_modal-default_fab_map').is(':checked')) {
            // console.log("#minimal-radio-wc-2 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Ortak";
            else
                facility_Wc_showerPosted = "WC-shower | Common";
            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-flats_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-radio-wc-3 checked");
            if (langIDPosted == 2)
                var facility_Wc_showerPosted = "WC - Dus | Katta";
            else
                var facility_Wc_showerPosted = "WC-shower | Flats";

        }

        if ($('#minimal-radio-kitchenette-room_modal-default_fab_map').is(':checked')) {
            // console.log("#minimal-radio-kitchenette-1 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Odada";
            else
                console.log(facility_KitchenettePosted);
        }


        if ($('#minimal-radio-kitchenette-flats_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-radio-kitchenette-2 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Katta";
            else
                facility_KitchenettePosted = "Kitchenette | Flats";
            console.log(facility_KitchenettePosted);
        }

        if ($('#minimal-radio-bed-bunk_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-radio-bed-1 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Ranza";
            else
                facility_bedPosted = "Bed | Bunk";
            console.log(facility_bedPosted);
        }

        if ($('#minimal-radio-bed-normal_modal-default_fab_map').is(':checked')) {
            // console.log("#minimal-radio-bed-2 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Normal";
            else
                facility_bedPosted = "Bed | Normal";
            console.log(facility_bedPosted);

        }

        if ($('#minimal-checkbox-air_condition_modal-default_fab_map').is(':checked')) {
            //console.log("#minimal-checkbox-air_condition");
            if (langIDPosted == 2)
                facility_air_conditionPosted = "Klima";
            else
                facility_air_conditionPosted = "Air-condition";
            console.log(facility_air_conditionPosted);

        }

        if ($('#minimal-checkbox-central_modal-default_fab_map').is(':checked')) {
            //  console.log("#minimal-checkbox-central is cheched");
            if (langIDPosted == 2)
                facility_central_acPosted = "Merkezi Isitma | Isitma";
            else
                facility_central_acPosted = "Central conditioning system | Cooling";
            console.log(facility_central_acPosted);
        }


        if ($('#minimal-checkbox-refriferator_modal-default_fab_map').is(':checked')) {
            //  console.log("#minimal-checkbox-refriferator is cheched");
            if (langIDPosted == 2)
                facility_refrigeratorPosted = "Buzdolabi";
            else
                facility_refrigeratorPosted = "Refrigerator";
            console.log(facility_refrigeratorPosted);
        }


        if ($('#minimal-checkbox-Laundry_modal-default_fab_map').is(':checked')) {
            //console.log("#minimal-checkbox-Laundry is cheched");
            if (langIDPosted == 2)
                facility_laundryPosted = "Çamasirhane";
            else
                facility_laundryPosted = "Laundry";
            console.log(facility_laundryPosted);
        }


        if ($('#minimal-checkbox-cafeteria_modal-default_fab_map').is(':checked')) {
            // console.log("#minimal-checkbox-cafeteria is cheched");
            if (langIDPosted == 2)
                facility_cafeteriaPosted = "Kafeterya";
            else
                facility_cafeteriaPosted = "Cafeteria";
            console.log(facility_cafeteriaPosted);

        }


        if ($('#minimal-checkbox-room_modal-default_fab_map').is(':checked')) {
            //    console.log("#minimal-checkbox-room is cheched");
            if (langIDPosted == 2)
                facility_room_telPosted = "Oda Telefonmu";
            else
                facility_room_telPosted = "Room tel.";
            console.log(facility_room_telPosted);

        }



        if ($('#minimal-checkbox-generator_modal-default_fab_map').is(':checked')) {
            //console.log("#minimal-checkbox-generator is cheched");
            if (langIDPosted == 2)
                facility_generatorPosted = "Jeneratör";
            else
                facility_generatorPosted = "Generator";
            console.log(facility_generatorPosted);
        }

        if ($('#selectedDormitoryType_modal-default_fab_map').find(":selected").text().length != 0) {
            //console.log("Selected dormitory type :" + $('#selectedDormitoryType').find(":selected").text());

            dormitory_typePosted = parseInt($('#selectedDormitoryType_modal-default_fab_map').find(":selected").val());
            console.log(dormitory_typePosted + " " + $('#selectedDormitoryType_modal-default_fab_map').find(":selected").val());
        }

        if ($('#selectedDormitoryName_modal-default_fab_map').find(":selected").text().length != 0) {
            //  console.log("Selected dormitory name:" + $('#selectedDormitoryName').find(":selected").text());
            name_of_dormitoryPosted = $('#selectedDormitoryName_modal-default_fab_map').find(":selected").text();
            console.log(name_of_dormitoryPosted);
        }











        if ($('#minimal-price_2000_to_2499_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-price_2000_to_2499 is cheched");
            price_2000_to_2499 = { min: 2000, max: 2499 };
        }

        if ($('#minimal-price_2500_to_2999_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-price_2500_to_2999 is cheched");
            price_2500_to_2999 = { min: 2500, max: 2999 };;
        }
        if ($('#minimal-price_3000_to_3499_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-price_3000_to_3499 is cheched");
            price_3000_to_3499 = { min: 3000, max: 3499 };
        }
        if ($('#minimal-price_4000_to_4999_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-price_4000_to_4999 is cheched");
            price_4000_to_4999 = { min: 4000, max: 4999 };
        }

        if ($('#minimal-price_5000_to_6000_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-price_5000_to_6000 is cheched");
            price_5000_to_6000 = { min: 5000, max: 6000 };
        }
        if ($('#minimal-price_greater_than_6000_modal-default_fab_map').is(':checked')) {
            console.log("#minimal-price_greater_than_6000_ is cheched");
            price_greater_than_6000 = { min: 6001, max: 100000 };
        }







        if ($('#minimal-room_area_10_to_20_modal-default_fab_map').is(':checked')) {
            console.log("minimal-room_area_10_to_20 is cheched");
            room_area_10_to_20 = { min: 10, max: 20 };
        }

        if ($('#minimal-room_area_21_to_25_modal-default_fab_map').is(':checked')) {
            console.log("minimal-room_area_21_to_25 is cheched");
            room_area_21_to_25 = { min: 21, max: 25 };
        }
        if ($('#minimal-room_area_26_to_30_modal-default_fab_map').is(':checked')) {
            console.log("minimal-room_area_26_to_30 is cheched");
            room_area_26_to_30 = { min: 26, max: 30 };
        }

        if ($('#minimal-room_area_greater_than_30_modal-default_fab_map').is(':checked')) {
            console.log("minimal-room_area_greater_than_30 is cheched");
            room_area_greater_than_30 = { min: 31, max: 100000 };
        }




        minPrice = $('#minimal_price_range_modal-default_fab_map').val().substr(0, $('#minimal_price_range_modal-default_fab_map').val().indexOf(','));
        min_price_of_roomPosted = minPrice;

        maxPrice = $('#minimal_price_range_modal-default_fab_map').val().substr($('#minimal_price_range_modal-default_fab_map').val().indexOf(",") + 1);
        max_price_of_roomPosted = maxPrice;

        console.log("price range: " + minPrice + " " + maxPrice);



        minRoomArea = $('#minimal_room_area_range_modal-default_fab_map').val().substr(0, $('#minimal_room_area_range_modal-default_fab_map').val().indexOf(','));
        room_areaPostedMin = minRoomArea;

        maxRoomArea = $('#minimal_room_area_range_modal-default_fab_map').val().substr($('#minimal_room_area_range_modal-default_fab_map').val().indexOf(",") + 1);
        room_areaPostedMax = maxRoomArea;

        console.log("Room area range: " + minRoomArea + " " + maxRoomArea);


        if ($('#sort_price_btn').is(':checked')) {
            console.log("Sort by price selected");
            sort_byPosted = "Price";
        }

        if ($('#sort_alpha_btn').is(':checked')) {
            console.log("Sort by alphabetical order selected");
            sort_byPosted = "a-z";
        }

        if ($('#sort_roomArea_btn').is(':checked')) {
            console.log("Sort by room area selected");
            sort_byPosted = "area";
        }

      

    }
    
    function get_filter_values_modal_map() {
        init_values();
        langIDPosted = $('#hiddenLanguageId').val();
        if ($('#minimal-radio-tv-room_modal_map').is(':checked')) {
            // console.log("#minimal-radio-tv-1 checked");
            if (langIDPosted == 2)

                facility_TVPosted = "TV | Odada";
            else
                facility_TVPosted = "TV | In room";
            console.log(facility_TVPosted);

        }

        if ($('#minimal-radio-tv-hall_modal_map').is(':checked')) {
            //console.log("#minimal-radio-tv-2 checked");
            if (langIDPosted == 2)
                facility_TVPosted = "TV | Salonda";
            else
                facility_TVPosted = "TV | In Hall";

            console.log(facility_TVPosted);
        }


        if ($('#minimal-radio-internet-cable_modal_map').is(':checked')) {
            //console.log(" #minimal-radio-internet-1 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablolu";
            else
                facility_InternetPosted = "Internet | Cable";
            console.log(facility_InternetPosted);
        }

        if ($('#minimal-radio-internet-wireless_modal_map').is(':checked')) {
            //console.log("#minimal-radio-internet-2 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablosuz";
            else
                facility_InternetPosted = "Internet | Wireless";
            console.log(facility_InternetPosted);

        }


        if ($('#minimal-radio-wc-room_modal_map').is(':checked')) {
            //console.log("#minimal-radio-wc-1 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Odada";
            else
                facility_Wc_showerPosted = "WC-shower | In room";

            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-common_modal_map').is(':checked')) {
            // console.log("#minimal-radio-wc-2 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Ortak";
            else
                facility_Wc_showerPosted = "WC-shower | Common";
            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-flats_modal_map').is(':checked')) {
            console.log("#minimal-radio-wc-3 checked");
            if (langIDPosted == 2)
                var facility_Wc_showerPosted = "WC - Dus | Katta";
            else
                var facility_Wc_showerPosted = "WC-shower | Flats";

        }

        if ($('#minimal-radio-kitchenette-room_modal_map').is(':checked')) {
            // console.log("#minimal-radio-kitchenette-1 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Odada";
            else
                console.log(facility_KitchenettePosted);
        }


        if ($('#minimal-radio-kitchenette-flats_modal_map').is(':checked')) {
            console.log("#minimal-radio-kitchenette-2 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Katta";
            else
                facility_KitchenettePosted = "Kitchenette | Flats";
            console.log(facility_KitchenettePosted);
        }

        if ($('#minimal-radio-bed-bunk_modal_map').is(':checked')) {
            console.log("#minimal-radio-bed-1 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Ranza";
            else
                facility_bedPosted = "Bed | Bunk";
            console.log(facility_bedPosted);
        }

        if ($('#minimal-radio-bed-normal_modal_map').is(':checked')) {
            // console.log("#minimal-radio-bed-2 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Normal";
            else
                facility_bedPosted = "Bed | Normal";
            console.log(facility_bedPosted);

        }

        if ($('#minimal-checkbox-air_condition_modal_map').is(':checked')) {
            //console.log("#minimal-checkbox-air_condition");
            if (langIDPosted == 2)
                facility_air_conditionPosted = "Klima";
            else
                facility_air_conditionPosted = "Air-condition";
            console.log(facility_air_conditionPosted);

        }

        if ($('#minimal-checkbox-central_modal_map').is(':checked')) {
            //  console.log("#minimal-checkbox-central is cheched");
            if (langIDPosted == 2)
                facility_central_acPosted = "Merkezi Isitma | Isitma";
            else
                facility_central_acPosted = "Central conditioning system | Cooling";
            console.log(facility_central_acPosted);
        }


        if ($('#minimal-checkbox-refriferator_modal_map').is(':checked')) {
            //  console.log("#minimal-checkbox-refriferator is cheched");
            if (langIDPosted == 2)
                facility_refrigeratorPosted = "Buzdolabi";
            else
                facility_refrigeratorPosted = "Refrigerator";
            console.log(facility_refrigeratorPosted);
        }


        if ($('#minimal-checkbox-Laundry_modal_map').is(':checked')) {
            //console.log("#minimal-checkbox-Laundry is cheched");
            if (langIDPosted == 2)
                facility_laundryPosted = "Çamasirhane";
            else
                facility_laundryPosted = "Laundry";
            console.log(facility_laundryPosted);
        }


        if ($('#minimal-checkbox-cafeteria_modal_map').is(':checked')) {
            // console.log("#minimal-checkbox-cafeteria is cheched");
            if (langIDPosted == 2)
                facility_cafeteriaPosted = "Kafeterya";
            else
                facility_cafeteriaPosted = "Cafeteria";
            console.log(facility_cafeteriaPosted);

        }


        if ($('#minimal-checkbox-room_modal_map').is(':checked')) {
            //    console.log("#minimal-checkbox-room is cheched");
            if (langIDPosted == 2)
                facility_room_telPosted = "Oda Telefonmu";
            else
                facility_room_telPosted = "Room tel.";
            console.log(facility_room_telPosted);

        }



        if ($('#minimal-checkbox-generator_modal_map').is(':checked')) {
            //console.log("#minimal-checkbox-generator is cheched");
            if (langIDPosted == 2)
                facility_generatorPosted = "Jeneratör";
            else
                facility_generatorPosted = "Generator";
            console.log(facility_generatorPosted);
        }

        if ($('#selectedDormitoryType_modal_map').find(":selected").text().length != 0) {
            //console.log("Selected dormitory type :" + $('#selectedDormitoryType').find(":selected").text());

            dormitory_typePosted = parseInt($('#selectedDormitoryType_modal_map').find(":selected").val());
            console.log(dormitory_typePosted + " " + $('#selectedDormitoryType_modal_map').find(":selected").val());
        }

        if ($('#selectedDormitoryName_modal_map').find(":selected").text().length != 0) {
            //  console.log("Selected dormitory name:" + $('#selectedDormitoryName').find(":selected").text());
            name_of_dormitoryPosted = $('#selectedDormitoryName_modal_map').find(":selected").text();
            console.log(name_of_dormitoryPosted);
        }











        if ($('#minimal-price_2000_to_2499_modal_map').is(':checked')) {
            console.log("#minimal-price_2000_to_2499 is cheched");
            price_2000_to_2499 = { min: 2000, max: 2499 };
        }

        if ($('#minimal-price_2500_to_2999_modal_map').is(':checked')) {
            console.log("#minimal-price_2500_to_2999 is cheched");
            price_2500_to_2999 = { min: 2500, max: 2999 };;
        }
        if ($('#minimal-price_3000_to_3499_modal_map').is(':checked')) {
            console.log("#minimal-price_3000_to_3499 is cheched");
            price_3000_to_3499 = { min: 3000, max: 3499 };
        }
        if ($('#minimal-price_4000_to_4999_modal_map').is(':checked')) {
            console.log("#minimal-price_4000_to_4999 is cheched");
            price_4000_to_4999 = { min: 4000, max: 4999 };
        }

        if ($('#minimal-price_5000_to_6000_modal_map').is(':checked')) {
            console.log("#minimal-price_5000_to_6000 is cheched");
            price_5000_to_6000 = { min: 5000, max: 6000 };
        }
        if ($('#minimal-price_greater_than_6000_modal_map').is(':checked')) {
            console.log("#minimal-price_greater_than_6000_ is cheched");
            price_greater_than_6000 = { min: 6001, max: 100000 };
        }







        if ($('#minimal-room_area_10_to_20_modal_map').is(':checked')) {
            console.log("minimal-room_area_10_to_20 is cheched");
            room_area_10_to_20 = { min: 10, max: 20 };
        }

        if ($('#minimal-room_area_21_to_25_modal_map').is(':checked')) {
            console.log("minimal-room_area_21_to_25 is cheched");
            room_area_21_to_25 = { min: 21, max: 25 };
        }
        if ($('#minimal-room_area_26_to_30_modal_map').is(':checked')) {
            console.log("minimal-room_area_26_to_30 is cheched");
            room_area_26_to_30 = { min: 26, max: 30 };
        }

        if ($('#minimal-room_area_greater_than_30_modal_map').is(':checked')) {
            console.log("minimal-room_area_greater_than_30 is cheched");
            room_area_greater_than_30 = { min: 31, max: 100000 };
        }




        minPrice = $('#minimal_price_range_modal_map').val().substr(0, $('#minimal_price_range_modal_map').val().indexOf(','));
        min_price_of_roomPosted = minPrice;

         maxPrice = $('#minimal_price_range_modal_map').val().substr($('#minimal_price_range_modal_map').val().indexOf(",") + 1);
        max_price_of_roomPosted = maxPrice;

        console.log("price range: " + minPrice + " " + maxPrice);


        
        minRoomArea = $('#minimal_room_area_range_modal_map').val().substr(0, $('#minimal_room_area_range_modal_map').val().indexOf(','));
        room_areaPostedMin  = minRoomArea;

         maxRoomArea = $('#minimal_room_area_range_modal_map').val().substr($('#minimal_room_area_range_modal_map').val().indexOf(",") + 1);
        room_areaPostedMax = maxRoomArea;

        console.log("Room area range: " + minRoomArea + " " + maxRoomArea);


        if ($('#sort_price_btn').is(':checked')) {
            console.log("Sort by price selected");
            sort_byPosted = "Price";
        }

        if ($('#sort_alpha_btn').is(':checked')) {
            console.log("Sort by alphabetical order selected");
            sort_byPosted = "a-z";
        }

        if ($('#sort_roomArea_btn').is(':checked')) {
            console.log("Sort by room area selected");
            sort_byPosted = "area";
        }

       
    }


    function get_filter_values_responsive_modals() {
        init_values();
        langIDPosted = $('#hiddenLanguageId').val();

        if ($('#minimal-radio-tv-room_modal_responsive').is(':checked')) {
            // console.log("#minimal-radio-tv-1 checked");
            if (langIDPosted == 2)

                facility_TVPosted = "TV | Odada";
            else
                facility_TVPosted = "TV | In room";
            console.log(facility_TVPosted);

        }

        if ($('#minimal-radio-tv-hall_modal_responsive').is(':checked')) {
            //console.log("#minimal-radio-tv-2 checked");
            if (langIDPosted == 2)
                facility_TVPosted = "TV | Salonda";
            else
                facility_TVPosted = "TV | In Hall";

            console.log(facility_TVPosted);
        }


        if ($('#minimal-radio-internet-cable_modal_responsive').is(':checked')) {
            //console.log(" #minimal-radio-internet-1 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablolu";
            else
                facility_InternetPosted = "Internet | Cable";
            console.log(facility_InternetPosted);
        }

        if ($('#minimal-radio-internet-wireless_modal_responsive').is(':checked')) {
            //console.log("#minimal-radio-internet-2 checked");
            if (langIDPosted == 2)
                facility_InternetPosted = "Internet | Kablosuz";
            else
                facility_InternetPosted = "Internet | Wireless";
            console.log(facility_InternetPosted);

        }


        if ($('#minimal-radio-wc-room_modal_responsive').is(':checked')) {
            //console.log("#minimal-radio-wc-1 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Odada";
            else
                facility_Wc_showerPosted = "WC-shower | In room";

            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-common_modal_responsive').is(':checked')) {
            // console.log("#minimal-radio-wc-2 checked");
            if (langIDPosted == 2)
                facility_Wc_showerPosted = "WC - Dus | Ortak";
            else
                facility_Wc_showerPosted = "WC-shower | Common";
            console.log(facility_Wc_showerPosted);
        }

        if ($('#minimal-radio-wc-flats_modal_responsive').is(':checked')) {
            console.log("#minimal-radio-wc-3 checked");
            if (langIDPosted == 2)
                var facility_Wc_showerPosted = "WC - Dus | Katta";
            else
                var facility_Wc_showerPosted = "WC-shower | Flats";

        }

        if ($('#minimal-radio-kitchenette-room_modal_responsive').is(':checked')) {
            // console.log("#minimal-radio-kitchenette-1 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Odada";
            else
                console.log(facility_KitchenettePosted);
        }


        if ($('#minimal-radio-kitchenette-flats_modal_responsive').is(':checked')) {
            console.log("#minimal-radio-kitchenette-2 checked");
            if (langIDPosted == 2)
                facility_KitchenettePosted = "Mutfak | Katta";
            else
                facility_KitchenettePosted = "Kitchenette | Flats";
            console.log(facility_KitchenettePosted);
        }

        if ($('#minimal-radio-bed-bunk_modal_responsive').is(':checked')) {
            console.log("#minimal-radio-bed-1 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Ranza";
            else
                facility_bedPosted = "Bed | Bunk";
            console.log(facility_bedPosted);
        }

        if ($('#minimal-radio-bed-normal_modal_responsive').is(':checked')) {
            // console.log("#minimal-radio-bed-2 checked");
            if (langIDPosted == 2)
                facility_bedPosted = "Yatak Türü | Normal";
            else
                facility_bedPosted = "Bed | Normal";
            console.log(facility_bedPosted);

        }

        if ($('#minimal-checkbox-air_condition_modal_responsive').is(':checked')) {
            //console.log("#minimal-checkbox-air_condition");
            if (langIDPosted == 2)
                facility_air_conditionPosted = "Klima";
            else
                facility_air_conditionPosted = "Air-condition";
            console.log(facility_air_conditionPosted);

        }

        if ($('#minimal-checkbox-central_modal_responsive').is(':checked')) {
            //  console.log("#minimal-checkbox-central is cheched");
            if (langIDPosted == 2)
                facility_central_acPosted = "Merkezi Isitma | Isitma";
            else
                facility_central_acPosted = "Central conditioning system | Cooling";
            console.log(facility_central_acPosted);
        }


        if ($('#minimal-checkbox-refriferator_modal_responsive').is(':checked')) {
            //  console.log("#minimal-checkbox-refriferator is cheched");
            if (langIDPosted == 2)
                facility_refrigeratorPosted = "Buzdolabi";
            else
                facility_refrigeratorPosted = "Refrigerator";
            console.log(facility_refrigeratorPosted);
        }


        if ($('#minimal-checkbox-Laundry_modal_responsive').is(':checked')) {
            //console.log("#minimal-checkbox-Laundry is cheched");
            if (langIDPosted == 2)
                facility_laundryPosted = "Çamasirhane";
            else
                facility_laundryPosted = "Laundry";
            console.log(facility_laundryPosted);
        }


        if ($('#minimal-checkbox-cafeteria_modal_responsive').is(':checked')) {
            // console.log("#minimal-checkbox-cafeteria is cheched");
            if (langIDPosted == 2)
                facility_cafeteriaPosted = "Kafeterya";
            else
                facility_cafeteriaPosted = "Cafeteria";
            console.log(facility_cafeteriaPosted);

        }


        if ($('#minimal-checkbox-room_modal_responsive').is(':checked')) {
            //    console.log("#minimal-checkbox-room is cheched");
            if (langIDPosted == 2)
                facility_room_telPosted = "Oda Telefonmu";
            else
                facility_room_telPosted = "Room tel.";
            console.log(facility_room_telPosted);

        }



        if ($('#minimal-checkbox-generator_modal_responsive').is(':checked')) {
            //console.log("#minimal-checkbox-generator is cheched");
            if (langIDPosted == 2)
                facility_generatorPosted = "Jeneratör";
            else
                facility_generatorPosted = "Generator";
            console.log(facility_generatorPosted);
        }

        if ($('#selectedDormitoryType_modal_responsive').find(":selected").text().length != 0) {
            //console.log("Selected dormitory type :" + $('#selectedDormitoryType').find(":selected").text());

            dormitory_typePosted = parseInt($('#selectedDormitoryType_modal_responsive').find(":selected").val());
            console.log(dormitory_typePosted + " " + $('#selectedDormitoryType_modal_responsive').find(":selected").val());
        }

        if ($('#selectedDormitoryName_modal_responsive').find(":selected").text().length != 0) {
            //  console.log("Selected dormitory name:" + $('#selectedDormitoryName').find(":selected").text());
            name_of_dormitoryPosted = $('#selectedDormitoryName_modal_responsive').find(":selected").text();
            console.log(name_of_dormitoryPosted);
        }











        if ($('#minimal-price_2000_to_2499_modal_responsive').is(':checked')) {
            console.log("#minimal-price_2000_to_2499 is cheched");
            price_2000_to_2499 = { min: 2000, max: 2499 };
        }

        if ($('#minimal-price_2500_to_2999_modal_responsive').is(':checked')) {
            console.log("#minimal-price_2500_to_2999 is cheched");
            price_2500_to_2999 = { min: 2500, max: 2999 };;
        }
        if ($('#minimal-price_3000_to_3499_modal_responsive').is(':checked')) {
            console.log("#minimal-price_3000_to_3499 is cheched");
            price_3000_to_3499 = { min: 3000, max: 3499 };
        }
        if ($('#minimal-price_4000_to_4999_modal_responsive').is(':checked')) {
            console.log("#minimal-price_4000_to_4999 is cheched");
            price_4000_to_4999 = { min: 4000, max: 4999 };
        }

        if ($('#minimal-price_5000_to_6000_modal_responsive').is(':checked')) {
            console.log("#minimal-price_5000_to_6000 is cheched");
            price_5000_to_6000 = { min: 5000, max: 6000 };
        }
        if ($('#minimal-price_greater_than_6000_modal_responsive').is(':checked')) {
            console.log("#minimal-price_greater_than_6000_ is cheched");
            price_greater_than_6000 = { min: 6001, max: 100000 };
        }







        if ($('#minimal-room_area_10_to_20_modal_responsive').is(':checked')) {
            console.log("minimal-room_area_10_to_20 is cheched");
            room_area_10_to_20 = { min: 10, max: 20 };
        }

        if ($('#minimal-room_area_21_to_25_modal_responsive').is(':checked')) {
            console.log("minimal-room_area_21_to_25 is cheched");
            room_area_21_to_25 = { min: 21, max: 25 };
        }
        if ($('#minimal-room_area_26_to_30_modal_responsive').is(':checked')) {
            console.log("minimal-room_area_26_to_30 is cheched");
            room_area_26_to_30 = { min: 26, max: 30 };
        }

        if ($('#minimal-room_area_greater_than_30_modal_responsive').is(':checked')) {
            console.log("minimal-room_area_greater_than_30 is cheched");
            room_area_greater_than_30 = { min: 31, max: 100000 };
        }




        var minPrice = $('#minimal_price_range_modal_responsive').val().substr(0, $('#minimal_price_range_modal_responsive').val().indexOf(','));
        min_price_of_roomPosted = minPrice;

        var maxPrice = $('#minimal_price_range_modal_responsive').val().substr($('#minimal_price_range_modal_responsive').val().indexOf(",") + 1);
        max_price_of_roomPosted = maxPrice;

        console.log("price range: " + minPrice + " " + maxPrice);


        var minRoomArea = $('#minimal_room_area_range_modal_responsive').val().substr(0, $('#minimal_room_area_range_modal_responsive').val().indexOf(','));
        min_RoomAreaPosted = minRoomArea;

        var maxRoomArea = $('#minimal_room_area_range_modal_responsive').val().substr($('#minimal_room_area_range_modal_responsive').val().indexOf(",") + 1);
        max_RoomAreaPosted = maxRoomArea;

        console.log("Room area range: " + minRoomArea + " " + maxRoomArea);


        if ($('#sort_price_btn').is(':checked')) {
            console.log("Sort by price selected");
            sort_byPosted = "Price";
        }

        if ($('#sort_alpha_btn').is(':checked')) {
            console.log("Sort by alphabetical order selected");
            sort_byPosted = "a-z";
        }

        if ($('#sort_roomArea_btn').is(':checked')) {
            console.log("Sort by room area selected");
            sort_byPosted = "area";
        }

    

    }



    function get_main_search_loader() {
        $.ajax({
            type: "POST",
            url: "/Home/GetMainSearchLoader",
            data: {
                dormitory_type: dormitory_typePosted,
                langId: langIDPosted

            },
            success: function (result) {
                //     alert(result);
                $("#search_results").html(result);
            }
        })

    }

    function get_main_map_area_loader() {
        $.ajax({
            type: "POST",
            url: "/Home/GetMapAreaLoader",
            success: function (result) {
                //     alert(result);
                $("#map_area_column").html(result);
            }
        })

    }


    function get_mini_model_search_loader() {
        $.ajax({
            type: "POST",
            url: "/Home/GetMiniSearchMapLoader",

            data: {
                dormitory_type: dormitory_typePosted,
                langId: langIDPosted

            },
            success: function (result) {
                //     alert(result);
                $("#map_list_result").html(result);
            }
        })

    }

 
        $('#minimal-radio-tv-room_main_topside').on('ifClicked', function (event) {

              //  alert('Well done, Sir');
                $('#minimal-radio-tv-hall_main_topside').iCheck('uncheck');
            
        });

        $('#minimal-radio-tv-hall_main_topside').on('ifClicked', function (event) {

              //  alert('Well done, Sir');
                $('#minimal-radio-tv-room_main_topside').iCheck('uncheck');
            
        });


        $('#minimal-radio-internet-cable_main_topside').on('ifClicked', function (event) {

              //  alert('Well done, Sir');
                $('#minimal-radio-internet-wireless_main_topside').iCheck('uncheck');
            
        });

        $('#minimal-radio-internet-wireless_main_topside').on('ifClicked', function (event) {
              //  alert('Well done, Sir');
                $('#minimal-radio-internet-cable_main_topside').iCheck('uncheck');
            
        });

        $('#minimal-radio-wc-room_main_topside').on('ifClicked', function (event) {
              //  alert('Well done, Sir');
                $('#minimal-radio-wc-common_main_topside').iCheck('uncheck');
                $('#minimal-radio-wc-flats_main_topside').iCheck('uncheck');
            
        });

        $('#minimal-radio-wc-common_main_topside').on('ifClicked', function (event) {
              //  alert('Well done, Sir');
                $('#minimal-radio-wc-room_main_topside').iCheck('uncheck');
                $('#minimal-radio-wc-flats_main_topside').iCheck('uncheck');
            
        });

        $('#minimal-radio-wc-flats_main_topside').on('ifClicked', function (event) {
               // alert('Well done, Sir');
                $('#minimal-radio-wc-room_main_topside').iCheck('uncheck');
                $('#minimal-radio-wc-common_main_topside').iCheck('uncheck');
            
        });


        $('#minimal-radio-kitchenette-room_main_topside').on('ifClicked', function (event) {
              //  alert('Well done, Sir');
                $('#minimal-radio-kitchenette-flats_main_topside').iCheck('uncheck');

            

        });


        $('#minimal-radio-kitchenette-flats_main_topside').on('ifClicked', function (event) {
              //  alert('Well done, Sir');
                $('#minimal-radio-kitchenette-room_main_topside').iCheck('uncheck');

            

        });



        $('#minimal-radio-bed-bunk_main_topside').on('ifClicked', function (event) {
              //  alert('Well done, Sir');
                $('#minimal-radio-bed-normal_main_topside').iCheck('uncheck');
            
        });


        $('#minimal-radio-bed-normal_main_topside').on('ifClicked', function (event) {
               // alert('Well done, Sir');
                $('#minimal-radio-bed-bunk_main_topside').iCheck('uncheck');
            
        });

    $('#minimal-radio-tv-room_modal-default_fab_map').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-tv-hall_modal-default_fab_map').iCheck('uncheck');

    });

    $('#minimal-radio-tv-hall_modal-default_fab_map').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-tv-room_modal-default_fab_map').iCheck('uncheck');

    });


    $('#minimal-radio-internet-cable_modal-default_fab_map').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-internet-wireless_modal-default_fab_map').iCheck('uncheck');

    });

    $('#minimal-radio-internet-wireless_modal-default_fab_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-internet-cable_modal-default_fab_map').iCheck('uncheck');

    });

    $('#minimal-radio-wc-room_modal-default_fab_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-wc-common_modal-default_fab_map').iCheck('uncheck');
        $('#minimal-radio-wc-flats_modal-default_fab_map').iCheck('uncheck');

    });

    $('#minimal-radio-wc-common_modal-default_fab_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-wc-room_modal-default_fab_map').iCheck('uncheck');
        $('#minimal-radio-wc-flats_modal-default_fab_map').iCheck('uncheck');

    });

    $('#minimal-radio-wc-flats_modal-default_fab_map').on('ifClicked', function (event) {
        // alert('Well done, Sir');
        $('#minimal-radio-wc-room_modal-default_fab_map').iCheck('uncheck');
        $('#minimal-radio-wc-common_modal-default_fab_map').iCheck('uncheck');

    });


    $('#minimal-radio-kitchenette-room_modal-default_fab_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-kitchenette-flats_modal-default_fab_map').iCheck('uncheck');



    });


    $('#minimal-radio-kitchenette-flats_modal-default_fab_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-kitchenette-room_modal-default_fab_map').iCheck('uncheck');



    });



    $('#minimal-radio-bed-bunk_modal-default_fab_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-bed-normal_modal-default_fab_map').iCheck('uncheck');

    });


    $('#minimal-radio-bed-normal_modal-default_fab_map').on('ifClicked', function (event) {
        // alert('Well done, Sir');
        $('#minimal-radio-bed-bunk_modal-default_fab_map').iCheck('uncheck');

    });



    $('#minimal-radio-tv-room_modal_map').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-tv-hall_modal_map').iCheck('uncheck');

    });

    $('#minimal-radio-tv-hall_modal_map').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-tv-room_modal_map').iCheck('uncheck');

    });


    $('#minimal-radio-internet-cable_modal_map').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-internet-wireless_modal_map').iCheck('uncheck');

    });

    $('#minimal-radio-internet-wireless_modal_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-internet-cable_modal_map').iCheck('uncheck');

    });

    $('#minimal-radio-wc-room_modal_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-wc-common_modal_map').iCheck('uncheck');
        $('#minimal-radio-wc-flats_modal_map').iCheck('uncheck');

    });

    $('#minimal-radio-wc-common_modal_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-wc-room_modal_map').iCheck('uncheck');
        $('#minimal-radio-wc-flats_modal_map').iCheck('uncheck');

    });

    $('#minimal-radio-wc-flats_modal_map').on('ifClicked', function (event) {
        // alert('Well done, Sir');
        $('#minimal-radio-wc-room_modal_map').iCheck('uncheck');
        $('#minimal-radio-wc-common_modal_map').iCheck('uncheck');

    });


    $('#minimal-radio-kitchenette-room_modal_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-kitchenette-flats_modal_map').iCheck('uncheck');



    });


    $('#minimal-radio-kitchenette-flats_modal_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-kitchenette-room_modal_map').iCheck('uncheck');



    });



    $('#minimal-radio-bed-bunk_modal_map').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-bed-normal_modal_map').iCheck('uncheck');

    });


    $('#minimal-radio-bed-normal_modal_map').on('ifClicked', function (event) {
        // alert('Well done, Sir');
        $('#minimal-radio-bed-bunk_modal_map').iCheck('uncheck');

    });


    $('#minimal-radio-tv-room_modal_responsive').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-tv-hall_modal_responsive').iCheck('uncheck');

    });

    $('#minimal-radio-tv-hall_modal_responsive').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-tv-room_modal_responsive').iCheck('uncheck');

    });


    $('#minimal-radio-internet-cable_modal_responsive').on('ifClicked', function (event) {

        //  alert('Well done, Sir');
        $('#minimal-radio-internet-wireless_modal_responsive').iCheck('uncheck');

    });

    $('#minimal-radio-internet-wireless_modal_responsive').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-internet-cable_modal_responsive').iCheck('uncheck');

    });

    $('#minimal-radio-wc-room_modal_responsive').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-wc-common_modal_responsive').iCheck('uncheck');
        $('#minimal-radio-wc-flats_modal_responsive').iCheck('uncheck');

    });

    $('#minimal-radio-wc-common_modal_responsive').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-wc-room_modal_responsive').iCheck('uncheck');
        $('#minimal-radio-wc-flats_modal_responsive').iCheck('uncheck');

    });

    $('#minimal-radio-wc-flats_modal_responsive').on('ifClicked', function (event) {
        // alert('Well done, Sir');
        $('#minimal-radio-wc-room_modal_responsive').iCheck('uncheck');
        $('#minimal-radio-wc-common_modal_responsive').iCheck('uncheck');

    });


    $('#minimal-radio-kitchenette-room_modal_responsive').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-kitchenette-flats_modal_responsive').iCheck('uncheck');



    });


    $('#minimal-radio-kitchenette-flats_modal_responsive').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-kitchenette-room_modal_responsive').iCheck('uncheck');



    });



    $('#minimal-radio-bed-bunk_modal_responsive').on('ifClicked', function (event) {
        //  alert('Well done, Sir');
        $('#minimal-radio-bed-normal_modal_responsive').iCheck('uncheck');

    });


    $('#minimal-radio-bed-normal_modal_responsive').on('ifClicked', function (event) {
        // alert('Well done, Sir');
        $('#minimal-radio-bed-bunk_modal_responsive').iCheck('uncheck');

    });







    


   
});
