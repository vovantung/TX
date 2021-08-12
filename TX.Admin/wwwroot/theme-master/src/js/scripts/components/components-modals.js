
(function (window, document, $) {
  'use strict';

  var onShowEvent = $('#onshow'),
    onShownEvent = $('#onshown'),
    onHideEvent = $('#onhide'),
    onHiddenEvent = $('#onhidden');

  // onShow event
  onShowEvent.on('show.bs.modal', function () {
    alert('onShow event fired.');
  });

  // onShown event
  onShownEvent.on('shown.bs.modal', function () {
    alert('onShown event fired.');
  });

  // onHide event
  onHideEvent.on('hide.bs.modal', function () {
    alert('onHide event fired.');
  });

  // onHidden event
  onHiddenEvent.on('hidden.bs.modal', function () {
    alert('onHidden event fired.');
  });
})(window, document, jQuery);
