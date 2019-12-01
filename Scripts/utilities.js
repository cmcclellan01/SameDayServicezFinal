


function LoadData(userDiv, controller, method) {
    $('body').loading('start');
    var $userDiv = $('.' + userDiv + '');   
    var url = '/' + controller + '/' + method;   
    $userDiv.empty();
    var ret = $.get(url, function (data) {        
        $userDiv.replaceWith('<div class="' + userDiv + '">' + data + '</div>');       
    });
    $('body').loading('stop');
    return ret;    
}

function validateDec(key) {
    //getting key code of pressed key
    var keycode = (key.which) ? key.which : key.keyCode;
    //comparing pressed keycodes
    if (!(keycode === 8 || keycode === 46) && (keycode < 48 || keycode > 57)) {
        return false;
    }
    else {
        var parts = key.srcElement.value.split('.');
        if (parts.length > 1 && keycode === 46)
            return false;
        return true;
    }
}

(function ($) {
    $.fn.currencyFormat = function () {
        this.each(function (i) {
            $(this).change(function (e) {
                if (isNaN(parseFloat(this.value))) return;
                this.value = parseFloat(this.value).toFixed(2);
            });
        });
        return this; //for chaining
    }
})(jQuery);

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};

$.fn.disable = function () {
    return this.each(function () {
        if (typeof this.disabled !== "undefined") this.disabled = true;
    });
};

$.fn.enable = function () {
    return this.each(function () {
        if (typeof this.disabled !== "undefined") this.disabled = false;
    });
};

