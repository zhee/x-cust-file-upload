(function ($) {
    $.fn.loadPage = function (options, callback) {
        options = $.extend({
            showLoader: true,
            callback: function () { }
        }, options);
               
        $.ajax({
            url: options.url,
            type: "post",
            data: null,
            beforeSend: function () {
                if (options.showLoader == true) {
                    console.log("Show loader");
                }
                else {
                    console.log("Hide loader");
                }
            },
            success: function (data) {
                $(".section-body").html(data);
            },
            error: function (xhr, ajaxOptions, error) {
                console.log(xhr.responseText);
            }
        });
    }
})(jQuery);

(function ($) {
    $.fn.GetUniqueIndentifier = function (baseUrl) {
        baseUrl = $.extend({
            baseUrl: ""
        }, baseUrl);

        var url = baseUrl + "/Home/GetUniqueIdentifier/";
        var value = null;

        $.ajax({
            url: url,
            type: "post",
            data: null,
            beforeSend: function () {
            },
            success: function (data) {
                value = data;
            },
            error: function (xhr, ajaxOptions, error) {
                value = null;
            },
            complete: function () {
                return value;
            }
        });
    }
})(jQuery);