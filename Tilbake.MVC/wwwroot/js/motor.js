//  Motor Attributes
const motorForm = document.getElementById('motorModal');
const regNumber = document.getElementById('RegNumber');
const engineNumber = document.getElementById('EngineNumber');
const chassisNumber = document.getElementById('ChassisNumber');
const motorbtnAdd = document.getElementById('btnAddMotor');

motorForm.addEventListener('submit', (e) => {
  e.preventDefault();

  validateMotorInputs();
});

motorbtnAdd.addEventListener('click', (e) => {
  e.preventDefault();

  validateMotorInputs();
});

function validateMotorInputs() {
  //  Trim to remove whitespaces
  const regNumberValue = regNumber.value.trim();
  const engineNumberValue = engineNumber.value.trim();
  const chassisNumberValue = chassisNumber.value.trim();

  if (regNumberValue === '') {
    setErrorFor(regNumber, 'Registration Number cannot be blank');
  } else {
    setSuccessFor(regNumber);
  }
}

function setErrorFor(input, message) {
  const formControl = input.parentElement;
  const small = formControl.querySelector('small');
  formControl.className = 'form-control error';
  small.innerText = message;
}

function setSuccessFor(input) {
  const formControl = input.parentElement;
  formControl.className = 'form-control success';
}

function isEmail(email) {
  return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
    email
  );
}
