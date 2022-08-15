var url_base = "https://localhost:7146/api";


function confirmar(event) {
    let isExecuted = confirm("¿Deseas borrar esta cita?");
    if (!isExecuted) {
        event.preventDefault();
    }
}
function cerrar(event) {
    let isExecuted = confirm("¿Desea cerrar la sesión?");
    if (!isExecuted) {
        event.preventDefault();
    }
}

var form_registerUser = document.getElementById("form_registerUser");

if (form_registerUser != null) {
    var input_Name = document.getElementById("Name");
    var input_UserId = document.getElementById("UserId");
    var input_Birthday = document.getElementById("Birthday");
    var input_Payment_method = document.getElementById("Payment_method");

    var btn_registerUser = document.getElementById("btn_registerUser");

    btn_registerUser.disabled = true;

    input_Name.addEventListener('keyup', () => {
        check_registerUser();
    });
    input_UserId.addEventListener('keyup', () => {
        check_registerUser();
    });
    input_Birthday.addEventListener('keyup', () => {
        check_registerUser();
    });
    input_Birthday.addEventListener('change', () => {
        check_registerUser();
    });
    input_Payment_method.addEventListener('keyup', () => {
        check_registerUser();
    });
}

function check_registerUser(){
    var input_Name = document.getElementById("Name");
    var input_UserId = document.getElementById("UserId");
    var input_Birthday = document.getElementById("Birthday");
    var input_Payment_method = document.getElementById("Payment_method");

    var btn_registerUser = document.getElementById("btn_registerUser");

    if (input_Name.value == "" || input_UserId.value == "" || input_Birthday.value == "" || input_Payment_method.value == "") {
        btn_registerUser.disabled = true;
    } else {
        btn_registerUser.disabled = false;
    }
}

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
    input_Specialty.disabled = true;

    input_Appointment_date.addEventListener("change", () => {

        var dateSelected = new Date(input_Appointment_date.value);
        var dayOfWeek = dateSelected.getDay();
        var dateNow = new Date();

        if (dayOfWeek == 5 || dayOfWeek == 6) {
            alert("El horario es de lunes a viernes de 8 am a 11am y de 1 pm a 4pm");
            btn_appointment.disabled = true;
            input_Hour.disabled = true;
            input_Specialty.disabled = true;
        } else {
            input_Specialty.disabled = false;
            var difDays = (dateSelected.getTime() - dateNow.getTime()) / (1000 * 60 * 60 * 24);

            if (difDays < -1) {
                alert("Solo puede seleccionar una fecha para su cita de mañana en adelante.");
                btn_appointment.disabled = true;
                input_Hour.disabled = true;
                input_Specialty.disabled = true;
            }
            if (difDays > 22) {
                alert("Solo puede agendar citas hasta 22 días a partir de la fecha actual.");
                btn_appointment.disabled = true;
                input_Hour.disabled = true;
                input_Specialty.disabled = true;
            }
        }
        if (input_Appointment_date.value == "") {
            btn_appointment.disabled = true;
            input_Hour.disabled = true;
            input_Specialty.disabled = true;
        }
    });

    input_Specialty.addEventListener("change", () => {
        if (input_Appointment_date.value != "") {
            checkAgendaAvailability();
        } else {
            btn_appointment.disabled = true;
            input_Hour.disabled = true;
            input_Specialty.disabled = true;
        }
        console.log(input_Appointment_date.value);
    });

    btn_appointment.addEventListener("mouseover", () => {

         //checkAgendaAvailability();
        if (input_Appointment_date.value == "") {
            btn_appointment.disabled = true;
            input_Hour.disabled = true;
            input_Specialty.disabled = true;
        }
        
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