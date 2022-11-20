
var ajax = {

    get: function (url, parameters) {
        $.get(url, parameters);
    },

    post: function (url, parameters) {
        $.post(url, parameters);
    },

    load: function (element, url, parameters, callback) {
        $(element).load(url, parameters, callback);
    },
};

 function Modal(title, partialUrl, partialParams, buttonHTMLs) {

    $("#messageBoxTitle")[0].innerText = title;
    ajax.load($("#messageBoxBody"), partialUrl, partialParams);

    if (buttonHTMLs) {
        var innerHtml = "";
        for (var item in buttonHTMLs) {
            innerHtml += item;
        }
        $("#messageBoxButtons")[0].innerHTML = innerHtml;
    }
    $("#messageBox").fadeTo(300, 1);
}

$("#messageBox .close").click(function () {
    $("#messageBox").hide();
});