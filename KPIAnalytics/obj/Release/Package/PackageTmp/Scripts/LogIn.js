$(function () {
    localStorage.setItem("chkYes", "1");
    $('#password').on('change,mousedown, mouseleave, focus', function () {
        //var EmployeeId = $('#bootstrap-duallistbox-selected-list_employeeList').val();
        $('#error-display').hide();
    })

    $('#username').on('change,mousedown, mouseleave, focus', function () {
        //var EmployeeId = $('#bootstrap-duallistbox-selected-list_employeeList').val();
        $('#error-display').hide();
    })

});