/*=========================================================================================
    File Name: app-ecommerce.js
    Description: Ecommerce pages js
    ----------------------------------------------------------------------------------------
    Item Name: Vuexy  - Vuejs, HTML & Laravel Admin Dashboard Template
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

'use strict';

$(function () {
  // RTL Support
  var direction = 'ltr';
  if ($('html').data('textdirection') == 'rtl') {
    direction = 'rtl';
  }

  var sidebarShop = $('.sidebar-shop'),
    btnCart = $('.btn-cart'),
    overlay = $('.body-content-overlay'),
    sidebarToggler = $('.shop-sidebar-toggler'),
    gridViewBtn = $('.grid-view-btn'),
    listViewBtn = $('.list-view-btn'),
    priceSlider = document.getElementById('price-slider'),
    ecommerceProducts = $('#ecommerce-products'),
    sortingDropdown = $('.dropdown-sort .dropdown-item'),
    sortingText = $('.dropdown-toggle .active-sorting'),
    wishlist = $('.btn-wishlist'),
    checkout = '/Product/Ecommerce_checkout';

  if ($('body').attr('data-framework') === 'laravel') {
    var url = $('body').attr('data-asset-path');
    checkout = url + 'app/ecommerce/checkout';
  }

  // On sorting dropdown change
  if (sortingDropdown.length) {
    sortingDropdown.on('click', function () {
      var $this = $(this);
      var selectedLang = $this.text();
      sortingText.text(selectedLang);
    });
  }

  // Show sidebar
  if (sidebarToggler.length) {
    sidebarToggler.on('click', function () {
      sidebarShop.toggleClass('show');
      overlay.toggleClass('show');
      $('body').addClass('modal-open');
    });
  }

  // Overlay Click
  if (overlay.length) {
    overlay.on('click', function (e) {
      sidebarShop.removeClass('show');
      overlay.removeClass('show');
      $('body').removeClass('modal-open');
    });
  }

  // Init Price slider
  if (typeof priceSlider !== undefined && priceSlider !== null) {
    noUiSlider.create(priceSlider, {
      start: [1500, 3500],
      direction: direction,
      connect: true,
      tooltips: [true, true],
      format: wNumb({
        decimals: 0
      }),
      range: {
        min: 51,
        max: 5000
      }
    });
  }

  // Grid View
  if (gridViewBtn.length) {
    gridViewBtn.on('click', function () {
      ecommerceProducts.removeClass('list-view').addClass('grid-view');
      listViewBtn.removeClass('active');
      gridViewBtn.addClass('active');
    });
  }

  // List View
  if (listViewBtn.length) {
    listViewBtn.on('click', function () {
      ecommerceProducts.removeClass('grid-view').addClass('list-view');
      gridViewBtn.removeClass('active');
      listViewBtn.addClass('active');
    });
    }

    ///////////////////////////////////////////////
    // Code by Vo Van Tung
    if ($(".quantityt").length) {
        $(".quantityt").on("click", function (e) {
            var btn = $(this);
            var id = btn.data("id");
            var countert = btn.find('.countert').val().toString();

 
            $.ajax({
                url: "/Product/Quantity",
                data: { id: id, countert: countert},
                ddataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.ret) {
                        toastr['success']('', 'Đã thêm một sản phẩm vào giỏ hàng', {
                            closeButton: true,
                            tapToDismiss: false,
                            rtl: direction
                        });

                    } else {

                        toastr['success']('', 'Thêm sản phẩm vào giỏ hàng không thành công!', {
                            closeButton: true,
                            tapToDismiss: false,
                            rtl: direction
                        });

                    };
                }

            });


        })
    }
    ///////////////////////////////////////////////



    

  // On cart & view cart btn click to cart
  if (btnCart.length) {
      btnCart.on('click', function (e) {

          var btn = $(this);
          var id = btn.data("id");
          var addToCart = btn.find('.add-to-cart');
      if (addToCart.length > 0) {
        e.preventDefault();
        }

          /*Code by Vo Van Tung*/
          if (!btn.hasClass("view")) {
              btn.addClass("view");

              $.ajax({
                  url: "/Product/Ecom_cart",
                  data: { id: id },
                  ddataType: "json",
                  type: "POST",
                  success: function (response) {
                      if (response.ret) {

                          addToCart.text('View In Cart').removeClass('add-to-cart').addClass('view-in-cart');
                          btn.attr('href', checkout);
                          toastr['success']('', 'Added Item In Your Cart 🛒', {
                              closeButton: true,
                              tapToDismiss: false,
                              rtl: direction
                          });

                      } else {

                          toastr['success']('', 'Thêm sản phẩm không thành công!', {
                              closeButton: true,
                              tapToDismiss: false,
                              rtl: direction
                          });

                      };
                  }

              });

          };
  
     
        /*Kết  thúc  code add*/
    
    });
  }

  // For Wishlist Icon
  if (wishlist.length) {
    wishlist.on('click', function () {
      var $this = $(this);
      $this.find('svg').toggleClass('text-danger');
      if ($this.find('svg').hasClass('text-danger')) {
        toastr['success']('', 'Added to wishlist ❤️', {
          closeButton: true,
          tapToDismiss: false,
          rtl: direction
        });
      }
    });
  }
});

// on window resize hide sidebar
$(window).on('resize', function () {
  if ($(window).outerWidth() >= 991) {
    $('.sidebar-shop').removeClass('show');
    $('.body-content-overlay').removeClass('show');
  }
});
