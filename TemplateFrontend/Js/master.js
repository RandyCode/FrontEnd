
function createDialog(url, parameters) {
    $.get(url, parameters, function (data) {
        for (i = 0; i < $(data).length; i++) {
            var item = $(data)[i];
            if ($(item).hasClass("modal")) {
                modal = $(item);
                $(modal).appendTo('#dialog_content');
                $(modal).modal({
                    keyboard: true,
                    show: true,
                    backdrop: 'static'
                })
            }
        }
    }, "html");
}


function alertInfo(selector, msg) {
    var alert = "<div id='alertDiv' class='alert alert-danger alert-dismissible fade in' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><strong>"+msg+"</strong></div>"
    $(selector).append(alert);
    setTimeout(function () {
        $("#alertDiv").fadeOut("slow", function () { $("#alertDiv").remove(); });
    }, 1500);
}

