(function (window, undefined) {
  'use strict';

  /*
  NOTE:
  ------
  PLACE HERE YOUR OWN JAVASCRIPT CODE IF NEEDED
  WE WILL RELEASE FUTURE UPDATES SO IN ORDER TO NOT OVERWRITE YOUR JAVASCRIPT CODE PLEASE CONSIDER WRITING YOUR SCRIPT HERE.  */

    window.addEventListener("scroll", function (event) {
        var scroll = this.scrollY;

        if (window.innerWidth > 1198) {
            if (scroll > 62) {

                $('.kkkk').addClass("vvt1");
                $('.kkk').addClass("vvt");

                $('body').removeClass("navbar-static");
             


            } else {
                $('body').addClass("navbar-static");
             
                $('.kkk').removeClass("vvt");
                $('.kkkk').removeClass("vvt1");
            }

        }
      
       
    });

})(window);


