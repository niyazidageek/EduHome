(function ($) {
"use strict";  

/*------------------------------------
    Global Search
--------------------------------------*/

let input = document.getElementById("global-search");

let matches = document.getElementById("matches");

    input.addEventListener('keyup', () => {
    $('#matches').empty();
    let filteredInput = input.value.trim();

    if (filteredInput == "") {
        let div = document.createElement('div');
        div.style.textAlign = "start";
        div.innerHTML = "Nothing to search";
        
        $('#matches').append(div);
    }
    else {
        fetch(`https://localhost:5001/Search/GetGlobalSearchResult?input=${filteredInput}`)
            .then((response) => { return response.text(); })
            .then((result) => {
                
                $('#matches').html(result);
            });
    }   
});

/*------------------------------------
    Courses Search 
--------------------------------------*/

    let coursesInput = document.getElementById("courses-search")

    if (coursesInput != null) {
        let coursesMatches = document.getElementById("courses-matches")

        coursesInput.addEventListener('keyup', () => {
            $('#courses-matches').empty();
            let filteredInput = coursesInput.value.trim();

            if (filteredInput == "") {
                $('#courses-matches').empty();
            }
            else {
                fetch(`https://localhost:5001/Search/GetCoursesSearchResult?input=${filteredInput}`)
                    .then((response) => { return response.text(); })
                    .then((result) => {

                        $('#courses-matches').html(result);
                    });
            }
        });
    }
/*------------------------------------
    Courses Search
--------------------------------------*/

    let detailInput = document.getElementById("detail-search")

    if (detailInput != null) {
        let detailMatches = document.getElementById("detail-matches")

        detailInput.addEventListener('keyup', () => {
            $('#detail-matches').empty();
            let filteredInput = detailInput.value.trim();

            if (filteredInput == "") {
                $('#detail-matches').empty();
            }
            else {
                fetch(`https://localhost:5001/Search/GetGlobalSearchResult?input=${filteredInput}`)
                    .then((response) => { return response.text(); })
                    .then((result) => {

                        $('#detail-matches').html(result);
                    });
            }
        });
    }


/*------------------------------------
	Sticky Menu 
--------------------------------------*/
 var windows = $(window);
    var stick = $(".header-sticky");
	windows.on('scroll',function() {    
		var scroll = windows.scrollTop();
		if (scroll < 5) {
			stick.removeClass("sticky");
		}else{
			stick.addClass("sticky");
		}
	});  
/*------------------------------------
	jQuery MeanMenu 
--------------------------------------*/
	$('.main-menu nav').meanmenu({
		meanScreenWidth: "767",
		meanMenuContainer: '.mobile-menu'
	});
    
    
    /* last  2 li child add class */
    $('ul.menu>li').slice(-2).addClass('last-elements');
/*------------------------------------
	Owl Carousel
--------------------------------------*/
    $('.slider-owl').owlCarousel({
        loop:true,
        nav:true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 2500,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });

    $('.partner-owl').owlCarousel({
        loop:true,
        nav:true,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });  

    $('.testimonial-owl').owlCarousel({
        loop:true,
        nav:true,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });
/*------------------------------------
	Video Player
--------------------------------------*/
    $('.video-popup').magnificPopup({
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        zoom: {
            enabled: true,
        }
    });
    
    $('.image-popup').magnificPopup({
        type: 'image',
        gallery:{
            enabled:true
        }
    }); 
/*----------------------------
    Wow js active
------------------------------ */
    new WOW().init();
/*------------------------------------
	Scrollup
--------------------------------------*/
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });
/*------------------------------------
	Nicescroll
--------------------------------------*/
     $('body').scrollspy({ 
            target: '.navbar-collapse',
            offset: 95
        });
$(".notice-left").niceScroll({
            cursorcolor: "#EC1C23",
            cursorborder: "0px solid #fff",
            autohidemode: false,
            
        });

})(jQuery);	