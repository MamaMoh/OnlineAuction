const prevBtns = document.querySelectorAll(".btn-prev");
const nextBtns = document.querySelectorAll(".btn-next");
const progress = document.getElementById("progress");
const formSteps = document.querySelectorAll(".form-step");
const progressSteps = document.querySelectorAll(".progress-step");

let formStepsNum = 0;
function Validatetextonly(element) {
    var check = 1;
        console.log("check"+element);
    var regName = /^[a-zA-Z\-]+$/;
    ;
        var name = document.getElementById(element).value;
       

            if (regName.test(name)) {

                document.getElementById(element + 'err').innerHTML = ''
                check = 0;
               
            }

            else {
                document.getElementById(element + 'err').innerHTML = 'Please insert valid input'
                document.getElementById(element).focus();
               
            }
        
    return check;
}
function ValidatePhone(element) {
    var check = 1;
    var regName = /^[+]*[(]{0,1}[0-9]{1,3}[)]{0,1}[-\s\./0-9]*$/g;
    ;
    var name = document.getElementById(element).value;

        if (regName.test(name)) {

            document.getElementById(element + 'err').innerHTML = ''
            check = 0;

        }

        else {
            document.getElementById(element + 'err').innerHTML = 'Please insert valid input'
            document.getElementById(element).focus();

        }

    return check;
}

function Validateempty(element) {
    var check = 1;
    var name = document.getElementById(element).value;
    if (name == '' || name ==null) {
        document.getElementById(element + 'err').innerHTML = 'Please fill the field';
        document.getElementById(element).focus();
    }

    else {

        check = 0;

    }
    return check;
    }
    

function Validatebtn(btn) {
    console.log("button clicked"+btn);
    if (btn == 'btn1') {

        var res = Validateempty('ProductName');
        return res;

    }
    if (btn == 'btn2') {
        var res = Validateempty('FirstName') + Validateempty('LastName') + Validateempty('CompanyName') + Validateempty('PhoneNumber') + ValidatePhone('PhoneNumber');
        console.log("hehe" + res);
        return res;

    }

}
nextBtns.forEach((btn) => {
  btn.addEventListener("click", () => {
        if (Validatebtn(btn.id)!=0) {
            console.log("error occur");
        } else {
    formStepsNum++;
    updateFormSteps();
    updateProgressbar();
        }
  });
});

prevBtns.forEach((btn) => {
  btn.addEventListener("click", () => {
    formStepsNum--;
    updateFormSteps();
    updateProgressbar();
  });
});

function updateFormSteps() {
  formSteps.forEach((formStep) => {
    formStep.classList.contains("form-step-active") &&
      formStep.classList.remove("form-step-active");
  });

  formSteps[formStepsNum].classList.add("form-step-active");
}

function updateProgressbar() {
  progressSteps.forEach((progressStep, idx) => {
    if (idx < formStepsNum + 1) {
      progressStep.classList.add("progress-step-active");
    } else {
      progressStep.classList.remove("progress-step-active");
    }
  });

  const progressActive = document.querySelectorAll(".progress-step-active");

  progress.style.width =
    ((progressActive.length - 1) / (progressSteps.length - 1)) * 100 + "%";
}
