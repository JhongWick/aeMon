$(function () {

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        //e.preventDefault();
        $("#MyModalContent").load(this.href, function () {

            $("#MyModal").modal({
                //backdrop: 'static',
                keyboard: false
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {

    $('form', dialog).submit(function () {
        //$.validator.unobtrusive.parse($('form'));
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $("#MyModal").modal('hide');
                    toastr.success(result.message);
                    table.draw();
                    //location.reload();
                }
                else {
                    $("#MyModal").modal('show');
                    //$("#MyModalContent").html(result);
                    toastr.error(result.ErrorMessage);
                    bindForm(dialog);
                }
            }
            ,
            error: function (xml, message, text) {
                toastr.error("Msg: " + message + ", Text: " + text);
            }
        });
        return false;
    });
}