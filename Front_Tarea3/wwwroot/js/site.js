var url_base = "https://localhost:7146/api";

var form_appointment = document.getElementById("create_appointment");

if (form_appointment != null) {

    var input_Appointment_date = document.getElementById("Appointment_date");
    var input_id = document.getElementById("id");
    var input_token = document.getElementById("item");

    var input_Specialty = document.getElementById("Specialty");
    var input_Hour = document.getElementById("hour");
    var btn_appointment = document.getElementById("btn_appointment");

    btn_appointment.disabled = true;
    input_Hour.disabled = true;

    input_Specialty.addEventListener("change", () => {
        checkAgendaAvailability(); 
    });

    btn_appointment.addEventListener("mouseover", () => {

         //checkAgendaAvailability();
        
    });

    function checkAgendaAvailability() {
        if (input_Specialty.value == "") {
            btn_appointment.disabled = true;
        }

        const request = fetch(url_base + "/Agenda/agendaAvability/" + input_id.value + "/" + input_Specialty.value, {
            method: 'get',
            headers: new Headers({
                'Authorization': 'Bearer ' + input_token.value
            })
        }
        );
        if (request) {
            request.then(
                response => response.json())
                .then(function (data) {
                    console.log(data);
                    if (data.data) {
                        alert("Ya cuenta con una cita agendada activa con esta especialidad");
                        btn_appointment.disabled = true;
                        input_Hour.innerHTML = "";
                        return true;
                    } else {
                        btn_appointment.disabled = false;
                        input_Hour.disabled = false;
                        checkAgendaAvailabilityByHour();   
                        return false;
                    }
                });
        }
    }

    function checkAgendaAvailabilityByHour() {
        var appointment = {
            Id: 0,
            Appointment_date: input_Appointment_date.value
        }

        const request = fetch(url_base + "/Appointment/appointmentsListBydateUser/" + input_Specialty.value + "/" + input_id.value, {
            method: 'post',
            headers: new Headers({
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + input_token.value,
                'Content-Type': 'application/json; charset=utf-8'
            }),
            body: JSON.stringify(appointment)
        }
        );
        console.log(request);
        if (request) {
            request.then(
                response => response.json())
                .then(function (data) {
                    console.log(data);
                    if (data.data) {
                        input_Hour.innerHTML = "";
                        var hours = data.data.split(',');
                        var options = ``;
                        if (hours[0] < 2) {
                            options += `<option value="8">8 am</option>`;
                        }
                        if (hours[1] < 2) {
                            options += `<option value="9">9 am</option>`;
                        }
                        if (hours[2] < 2) {
                            options += `<option value="10">10 am</option>`;
                        }
                        if (hours[3] < 2) {
                            options += `<option value="11">11 am</option>`;
                        }
                        if (hours[4] < 2) {
                            options += `<option value="1">1 pm</option>`;
                        }
                        if (hours[5] < 2) {
                            options += `<option value="2">2 pm</option>`;
                        }
                        if (hours[6] < 2) {
                            options += `<option value="3">3 pm</option>`;
                        }
                        if (hours[7] < 2) {
                            options += `<option value="4">4 pm</option>`;
                        }
                        input_Hour.innerHTML = options;
                        btn_appointment.disabled = false;
                        input_Hour.disabled = false;
                    } else {
                        btn_appointment.disabled = true;
                        input_Hour.disabled = true;
                    }
                    if (data.data == null) {
           
                            var options = `<option value="8">8 am</option>` + `<option value="9">9 am</option>` + `<option value="10">10 am</option>` + `<option value="11">11 am</option>` + `<option value="1">1 pm</option>` + `<option value="2">2 pm</option>` + `<option value="3">3 pm</option>` + `<option value="4">4 pm</option>`;
                            input_Hour.innerHTML = options;
                            btn_appointment.disabled = false;
                            input_Hour.disabled = false;

                    }
                });
        }
    }
}