



// If submit button is click check if the values are correct if not hightlight inputs that are not. 


//Check if all the questions have a selected option 
//Check if all the inputs are selected and valid with Regular Expressions

// Erros for empty inputs 
const INPUT_ERRORS = ['Required', 'Name is invalid', 'Phone number is invalid'];

//Erros for dropdowns 
const DROPDOWN_ERRORS = ['Required'];

//Regex for Inputs
const NAME_REGEXP = /[A-Za-z]{2,17}/;
const PHONE_REGEXP = /[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/;

//Select all HTML tags needed. 
const FORM_INPUT_NAMES = document.querySelectorAll(".form-input  input:not(.number)");
const FORM_INPUT_PHONE = document.querySelector(".number");
const FORM_DROPDOWNS = document.querySelectorAll(".form-dropdown-group select");
const FORM_BTN = document.querySelector(".container input[type=submit]" );


FORM_BTN.addEventListener('click', (e) => {
    checkFormInputs();
    checkFormDropdowns();
    e.preventDefault();
})

function checkFormDropdowns() {
    FORM_DROPDOWNS.forEach(dropdown => {
        if (parseInt(dropdown.value) >= 0)
            createError(dropdown, DROPDOWN_ERRORS[0]);
    });
}
function checkFormInputs() {
    FORM_INPUT_NAMES.forEach(input => {

        // Checks if the first and last name are not empty
        // And Valid 
        let = formvalue = input.value; 
        if (input.value === "") {
            createError(input, INPUT_ERRORS[0]);
        }
        else if (!formvalue.match(NAME_REGEXP)) {
            createError(input, INPUT_ERRORS[1]); 
        }
    })

    // Checks if the phone field is empty or valid
    if (FORM_INPUT_PHONE.value === "") {
        createError(FORM_INPUT_PHONE, INPUT_ERRORS[0]);
        
    }
    else if (!FORM_INPUT_PHONE.value.match(PHONE_REGEXP)) {
        createError(FORM_INPUT_PHONE, INPUT_ERRORS[2]);
        
    }

}

// Appends error depending on the error list 
function createError(input,errorValue) {
       
    //Creates ul and li element and appends error class
    let ul = document.createElement('ul');
    ul.classList.add('error-list')
    input.classList.add('error-outline');
    let li = document.createElement('li');

    //Adds error outline to Errors and appends to field
    li.innerText = errorValue;
    ul.appendChild(li);
    input.parentElement.appendChild(ul);
};

function removeError(input) {

    FORM_INPUT_PHONE.parentElement.lastChild.remove(); 
}