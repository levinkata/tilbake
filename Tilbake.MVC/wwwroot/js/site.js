// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//  jQuery
$('#RegNumber, #EngineNumber, #ChassisNumber').keyup(function () {
    $(this).val($(this).val().toUpperCase());
});

$("#MotorMakeId").change(function (e) {
    e.preventDefault();

    var selectedMotorMakeId = $("#MotorMakeId option:selected").val();

    $.ajax({
        url: '@(Url.Action("GetMotorModels", "MotorModels"))',
        traditional: true,
        dataType: "JSON",
        type: 'GET',
        data: { motorMakeId: selectedMotorMakeId },
        error: function () {
            alert("An error occurred.");
        },
        success: function (models) {

            $("#MotorModelId").empty();   // clear before appending new list
            $.each(models, function (index, model) {
                $('#MotorModelId').append($('<option></option>').val(model.id).html(model.name));
            });
        }
    });
});

$('#AddressCountryId').change(function () {
    var selectedCountryId = $('#AddressCountryId option:selected').val();

    if (selectedCountryId != null && selectedCountryId != '') {
        $.ajax({
            url: '@(Url.Action("GetCities", "Cities"))',
            traditional: true,
            dataType: 'json',
            type: 'GET',
            data: { countryId: selectedCountryId },
            error: function () {
                alert("An error occurred.");
            },
            success: function (cities) {

                $('#AddressCityId').empty();   // clear before appending new list
                $.each(cities, function (index, city) {
                    $('#AddressCityId').append($('<option></option>').val(city.id).html(city.name));
                });
            }
        });
    }
});

//  JavaScript
//  Motor Attributes
//const motorForm = document.getElementById('motorModal');
//const regNumber = document.getElementById('RegNumber');
//const engineNumber = document.getElementById('EngineNumber');
//const chassisNumber = document.getElementById('ChassisNumber');
//const motorbtnAdd = document.getElementById('btnAddMotor');

//motorForm.addEventListener('submit', (e) => {
//    e.preventDefault();

//    validateMotorInputs();
//});

//motorbtnAdd.addEventListener('click', (e) => {
//    e.preventDefault();

//    validateMotorInputs();
//});

//function validateMotorInputs() {
//    //  Trim to remove whitespaces
//    const regNumberValue = regNumber.value.trim();
//    const engineNumberValue = engineNumber.value.trim();
//    const chassisNumberValue = chassisNumber.value.trim();

//    if (regNumberValue === '') {
//        setErrorFor(regNumber, 'Registration Number cannot be blank');
//    } else {
//        setSuccessFor(regNumber);
//    }

//    if (engineNumberValue === '') {
//        setErrorFor(engineNumber, 'Engine Number cannot be blank');
//    } else {
//        setSuccessFor(engineNumber);
//    }

//    if (chassisNumberValue === '') {
//        setErrorFor(chassisNumber, 'Chassis Number cannot be blank');
//    } else {
//        setSuccessFor(chassisNumber);
//    }
//}

//function setErrorFor(input, message) {
//    const formControl = input.parentElement;
//    const small = formControl.querySelector('small');
//    formControl.className = 'form-control error';
//    small.innerText = message;
//}

//function setSuccessFor(input) {
//    const formControl = input.parentElement;
//    formControl.className = 'form-control success';
//}

//function isEmail(email) {
//    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
//        email
//    );
//}
