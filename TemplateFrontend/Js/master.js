function createDialog(url, parameters) {
    $.get(url, parameters, function (data) {
        for (i = 0; i < $(data).length; i++) {
            var item = $(data)[i];
  
            if ($(item).hasClass("modal")) {
                modal = $(item);
                //console.log($(modal));
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