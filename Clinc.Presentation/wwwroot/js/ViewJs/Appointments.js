$(document).ready(function () {

   
    Build_Dropdown('DoctorId', 'choose Doctor', 'DropDowns/GetDcotors');
  
})





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


$('#DoctorId').change(function () {
    $('#Date').val(0).change();
    $('#appointmentTime').empty();
});

$('#Date').change(function () {
    var date = $(this).val();
    var doctorId = $('#DoctorId').val();

    if (doctorId && date) {
        $.ajax({
            url: 'DropDowns/GetFreeTimeSlots',
            type: 'GET',
            data: { docId: doctorId, date: date },
            success: function (response) {
                // Clear the current time slots
                $('#appointmentTime').empty();
                $('#appointmentTime').append('<option value="">Select a time slot</option>');

                if (response.length > 0) {

                   var i = 0;
                    response.forEach(function (slot) {

                        var fromTime = slot.from; 
                        var toTime = slot.to;  
                        
                        $('#appointmentTime').append('<option value="' + fromTime + '-' + toTime + '">' + fromTime + ' - ' + toTime + '</option>');
                    });
                } else {
                    $('#Date').empty();
                    Swal.fire({
                        title: 'Error!',
                        text: 'No available time slots for the selected date, choose another Date.',
                        icon: 'error',
                        confirmButtonText: 'OK'
                    });
                }
            },
            error: function () {

                Swal.fire({
                    title: 'Error!',
                    text: 'Error while retrieving data',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            }
        });
    }
});


$('#appointmentTime').change(function () {
    var selectedSlot = $(this).val();
    if (selectedSlot) {
        var times = selectedSlot.split('-');
        var fromTime = times[0];
        var toTime = times[1];
        $('#From').val(fromTime);
        $('#To').val(toTime);
        console.log($('#From').val());
        console.log($('#To').val());

    } else {
        $('#From').val('');
        $('#To').val('');
    }
});


$('form').submit(function (event) {
   event.preventDefault(); 

    var formData = {
        PatientName: $('#PatientName').val(),
        PatientBD: $('#PatientBD').val(),
        DoctorId: $('#DoctorId').val(),
        Date: $('#Date').val(),
        From: $('#From').val(),
        To: $('#To').val()
    };

    console.log($('#appForm').serialize());
    $.ajax({
        url: '/Appointments/CreateNewAppointment', 
        type: 'POST',
        data: $('#appForm').serialize(),
        content: 'application/json',
        success: function (response) {
            if (response.isSuccess) {
                Swal.fire({
                    title: 'Success!',
                    text: response.message,
                    icon: 'success',
                    confirmButtonText: 'OK'
                }).then(function () {
                    window.location.reload();
                });
            } else {
                Swal.fire({
                    title: 'Error!',
                    text: response.message,
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            }
        },
        error: function () {
            Swal.fire({
                title: 'Error!',
                text: 'Failed to create appointment.',
                icon: 'error',
                confirmButtonText: 'OK'
            });
        }
    });
});


