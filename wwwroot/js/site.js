/*
$(document).ready(function () {
    // Tarih seçildiğinde müsait saatleri getir
    $('#AppointmentDate').change(function () {
        var selectedDate = $(this).val();
        if (selectedDate) {
            $.get('/Appointment/CheckAvailability', { date: selectedDate }, function (response) {
                var timeSelect = $('#timeSlots');
                timeSelect.empty();
                timeSelect.append($('<option>', {
                    value: '',
                    text: 'Saat seçiniz'
                }));

                if (response.available) {
                    response.slots.forEach(function (slot) {
                        timeSelect.append($('<option>', {
                            value: slot,
                            text: slot
                        }));
                    });
                } else {
                    timeSelect.append($('<option>', {
                        value: '',
                        text: response.message
                    }));
                }
            });
        }
    });

    // Form validasyonu
    $('form').submit(function (e) {
        var timeSlot = $('#timeSlots').val();
        if (!timeSlot) {
            e.preventDefault();
            alert('Lütfen uygun bir saat seçiniz.');
        }
    });
});
*/