$(document).ready(function () {

    var today = new Date().toISOString().split('T')[0];
    $('#startDate').val(today);
    $('#endDate').val(today);
    $('#dateRange').hide();
    console.log($('#startDate').val());
    console.log($('#endDate').val());

    Build_Dropdown('doctorsSelect', 'choose Doctor', 'DropDowns/GetDcotors');

   
})

$('#searchButton').click(function () {
    var doctorId = $('#doctorsSelect').val();
    var fromDate = $('#startDate').val();
    var toDate = $('#endDate').val();

    if (doctorId && fromDate && toDate) {
        $.ajax({
            url: '/Doctors/GetAppointmentsByDocIdDuringPeriod',
            type: 'GET',
            data: {
                docId: doctorId,
                from: fromDate,
                to: toDate
            },
            success: function (response) {
                $('#appointments-table tbody').empty();

                if (response.length > 0) {
                    response.forEach(function (appointment) {
                        var row = '<tr>' +
                            '<td>' + appointment.doctorName + '</td>' +
                            '<td>' + appointment.patientName + '</td>' +
                            '<td>' + new Date(appointment.patientBD).toLocaleDateString() + '</td>' +
                            '<td>' + new Date(appointment.date).toLocaleDateString() + '</td>' +
                            '<td>' + appointment.from + '</td>' +
                            '<td>' + appointment.to + '</td>' +
                            '</tr>';
                        $('#appointments-table tbody').append(row);
                    });
                    $('#dateRange').show();
                } else {
                    $('#appointments-table tbody').append('<tr><td colspan="6" class="text-center">No Appointments</td></tr>');
                    $('#dateRange').show();
                }
            },
            error: function () {
                Swal.fire({
                    title: 'Error!',
                    text: 'Error while getting appointments',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            }
        });
    }
});





function Build_Dropdown(id, text, url) {
    //parentElement = $("#" + id);
    var parentElement = $(`#${id}`);
    parentElement.empty();
    parentElement.append('<option selected value="" > Loading... </option>');

    $.ajax({
        url: '/' + url,
        type: "GET",
        success: function (response) {

            parentElement.empty();
            parentElement.append('<option value="" > - ' + text + ' - </option>');
            for (var i = 0; i < response.length; i++) {
                parentElement.append('<option value="' + response[i].id + '" > ' + response[i].name + '</option>');
            }

            var docId = getQueryStringParameter('id');
            if (docId) {
                console.log('Value of paramName:', docId);
                parentElement.val(docId).change(); 
                $('#searchButton').click();
            }
           /* $("#" + id).select2();*/
            $("#" + id).trigger("change");

        },
        error: function (response) {
            swal({
                title: 'Error!',
                text: 'Error while getting data',
                icon: 'error',
                confirmButtonText: 'OK'
            });
        }
    });

    
}


$('#doctorsSelect').change(function () {
    $('#dateRange').hide();
    $('#appointments-table tbody').empty();
});


function getQueryStringParameter(name) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(name);
}



function getCurrentDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    return yyyy + '-' + mm + '-' + dd;
}






