$(document).ready(function () {
    $('#RoleTbl > tbody  > tr').each(function () {
        var ctr = 1;
        $(this).find('td').each(function () {
            $(this).css("background-color", "");
            $(this).find('div').css("display", "none");
            ctr = ctr + 1;
        });
    });
    localStorage['x'] = null;
    $.ajax({
        type: 'GET',
        url: '/RoleDetails/Get', // Calling json method
        dataType: 'json',
        success: function (details) {
            var input = "";
            jQuery.each(details, function (index, item) {
                //alert(item.IsAllowed); 
                if (item.IsAllowed) {
                    input = checked;
                } else {
                    input = unchecked;
                }
                if (item.BelongsTo == 0) {
                    //$("#t0").append('<li>' + '<span><i class="icon-folder-open"></i>' + item.Name + ' </span>' + input + '' + GetChildren(item.Id) + '</li>');
                    // $("#t0").append('<li><span><i class="icon-folder-open"></i>gfhfgh</span></li>');
                    $("#t0").html($('#f').html());
                }


                function GetChildren(moduleid) {
                    var ul = "";
                    jQuery.each(details, function (index, detail) {
                        if (detail.BelongsTo == moduleid) {
                            ul += '<li>' + '<span><i class="icon-folder-open"></i>' + detail.Name + ' </span>' + input + '</li> ';
                        }
                    });
                    return '<ul>' + ul + '</ul>'
                }

            });
        },
        error: function (ex) {
            alert('Failed to retrieve daasdsadta.' + ex);
        }
    });
});
function asdasd() {
    alert("asd");
    $("#partialViewDiv").load('/RoleDetails/_Modules', function (html) { });
}

function changeRole(e) {
    // location.href = '/UserMaintenance/set/' + $('#RoleId').val();
    // $('#ModulesTbl > tbody').html('Retrieving data');
    // alert($(e).parent().html()) ;
    $('#RoleTbl > tbody  > tr').each(function () {
        var ctr = 1;
        $(this).find('td').each(function () {
            $(this).css("background-color", "");
            $(this).find('div').css("display", "none");
            ctr = ctr + 1;
        });
    });
    $(e).css("background-color", "#147bae");
    $(e).parent().find('div').css("display", "");
    $.ajax({
        type: 'POST',
        url: '/UserRights/Fetch/' + $('#RoleId').val(), // Calling json method
        dataType: 'json',
        success: function (data) {
            if (data.result == "false") {
                $('#ModulesTbl > tbody').html('');
                $('#ModulesTbl').DataTable().destroy();
                $('#ModulesTbl > tbody').html('');
                $('#ModulesTbl').DataTable().draw();
                $(e).parent().find('div').css("display", "none");
            } else {
                var row = "";
            // alert('');
            for (i = 0; i < data.id.length; i++) {
                var is = '';
                var is2 = ''; 
                if (data.isallowed[i] == 'True') { 
                    is2 = ' <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></td> ';
                } else { 
                    is2 = '</td> ';
                } if (data.isallowed2[i] == 'True') {

                    is = ' checked'; 
                } else {
                    is = ''; 
                }

                

                var name = ""; 
                row += '<tr>' +
                    '<td width="0%" style="display:none;">' + data.id[i] + '</td>' + 
                    '<td width="60%" >' + data.name[i] + '</td>' +
                    '<td  width="20%">' + is2 +
                    '<td  width="20%" class="pull-right"><div class="checkbox" style="padding:0px;margin:0px"> <label> <input type="checkbox" value="" onclick="change(this)"' + is +
                    '> <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>' +
                                  '</label> </div></td></tr>';
                //alert("");
            }
            $('#ModulesTbl').DataTable().destroy();
            $('#ModulesTbl > tbody').html(row);
            $('#ModulesTbl').DataTable().draw();
            $(e).parent().find('div').css("display", "none");
            }
            
        },
        error: function (ex) {
            alert('Failed to retrieve daasdsadta.' + ex);
        }
    });

}
function change(id) {
    var mode;
    if ($(id).prop('checked') == true) {
        mode = 0;
    } else {
        mode = 1;
    }
    if (localStorage[$(id).data('id')] == '1') {
        localStorage[$(id).data('bt')] = "1";
        ChangeParent($(id).data('id'), mode, $(id).data('bt'));
        localStorage[$(id).data('id')] = 'null';
    } else if (localStorage[$(id).data('bt')] == '2') {
        localStorage[$(id).data('id')] = "2";
        ChangeChildren($(id).data('id'), mode, $(id).data('bt'), id);
        localStorage[$(id).data('bt')] = 'null';
    } else {
        localStorage[$(id).data('id')] = "2";
        localStorage[$(id).data('bt')] = "1";
        ChangeParent($(id).data('id'), mode, $(id).data('bt'));
        ChangeChildren($(id).data('id'), mode, $(id).data('bt'), id);
        localStorage[$(id).data('bt')] = 'null';
        localStorage[$(id).data('id')] = 'null';
    }
}
function Save() {
    var Ids = []; 
    var Namess = [];
    var Statuses = [];
    var issave = [];
    $('#ModulesTbl > tbody  > tr').each(function () {
        var ctr = 1;
        var defaultstatus = false; 
        $(this).find('td').each(function () { 
            switch (ctr) {
                case 1:
                    Ids.push($(this).html());
                    break; 
                case 2:
                    var index = ($(this).html()).lastIndexOf('</span>') + 7;
                    var len = ($(this).html()).length;
                    Namess.push($(this).html().substring(index, len));
                    //.substring(1, 4)
                    break;
                case 3:
                    if ($(this).html() == "") {
                        defaultstatus = false;
                    } else {
                        defaultstatus = true;
                    }
                    break;
                default:
                    var $checkbox = $(this).find('div > label');
                    var inner = $(this).html();
                    var cf = $(this).find('input');
                    var thisstatus = false; 
                    if (cf.prop('checked') == false) {
                        Statuses.push(false);
                        thisstatus = false;
                    } else {
                        Statuses.push(true);
                        thisstatus = true;
                    } 
                    if (thisstatus == defaultstatus) {
                        issave.push(false)
                    } else {
                        issave.push(true) 
                    }
                     

            }
            ctr = ctr + 1;
        });
         

    });
    $.ajax({
        type: 'POST',
        url: '/UserRights/SaveDetails', // Calling json method
        dataType: 'json',
        data: { id: Ids, names: Namess, status: Statuses, saveflag: issave, userid: $('#RoleId').val() },
        success: function (data) {
            
            alert("Changes Saved!");
        },
        error: function (ex) {
            alert('Failed to save changes.' + ex);
        }
    });
}
function ChangeParent(parentid, mode, bt, trigger) {
    $('#ModulesTbl > tbody  > tr').each(function () {
        var ctr = 1; var bool = false; var bool1 = false; var b = false;
        var id;
        $(this).find('td').each(function () {
            switch (ctr) {
                case 1:
                    id = $(this).html();
                    if (bt == $(this).html()) {
                        bool1 = true; b = $(this).html();
                    }
                    break;
                case 4:
                    if (bool1) {
                        var $checkbox = $(this).find('div > label');
                        var inner = $(this).html();
                        var cf = $(this).find('input');
                        if (mode == 1) {
                            if (cf.prop('checked') == true) {
                                //$checkbox.click();
                            }
                        } else {
                            if (cf.prop('checked') == false) {
                                $checkbox.click();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            ctr = ctr + 1;
        });
    });



}
function ChangeChildren(parentid, mode, bt, id) {

    $('#ModulesTbl > tbody  > tr').each(function () {
        var up1 = 0;
        var ctr = 1; var bool = false;
        var id;
        $(this).find('td').each(function () {
            switch (ctr) {
                case 1:
                    id = $(this).html();
                    break;
                case 2:
                    if (parentid == $(this).html()) {
                        bool = true;
                    }
                    break;
                case 4:
                    if (bool) {
                        var $checkbox = $(this).find('div > label');
                        var inner = $(this).html();
                        var cf = $(this).find('input');
                        if (mode == 1) {
                            if (cf.prop('checked') == true) {
                                $checkbox.click();
                            }
                        } else {
                            if (cf.prop('checked') == false) {
                                $checkbox.click();
                            }
                        }
                    }


                    break;
                default:
                    break;
            }
            ctr = ctr + 1;
        });
    });



}
