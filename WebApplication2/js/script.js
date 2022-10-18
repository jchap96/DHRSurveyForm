



// If submit button is click check if the values are correct if not hightlight inputs that are not. 


//Check if all the questions have a selected option 
//Check if all the inputs are selected and valid with Regular Expressions

// Erros for empty inputs 
const INPUT_ERRORS = {
    'required': false, 'name is invalid or empty': false, 'phone number is invalid or empty': false
};

//Erros for dropdowns 
const DROPDOWN_ERRORS = { 'required': false };

//Regex for Inputs
const NAME_REGEXP = /[A-Za-z]{2,17}/;
const PHONE_REGEXP = /[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/;

//Select all HTML tags needed. 
const FORM_INPUT_NAMES = document.querySelectorAll(".form-input  input:not(.number)");
const FORM_INPUT_PHONE = document.querySelector(".number");
const FORM_DROPDOWNS = document.querySelectorAll(".form-dropdown-group select");
const FORM_BTN = document.querySelector(".form-content input[type=submit]");



FORM_BTN.addEventListener('click', (e) => {

    //Adds any erros if needed
    
    
    //Removes past errors so they are not appended again
    FORM_DROPDOWNS.forEach(dropdown => {
        if (dropdown.classList.contains('error-outline')) {
            dropdown.classList.remove('error-outline');
            dropdown.parentElement.lastChild.remove();
        }
    });
    FORM_INPUT_NAMES.forEach(input => removeErrorInputs(input));
    removeErrorInputs(FORM_INPUT_PHONE);

   
    checkFormInputs();
    checkFormDropdowns();
    if(checkError())
    e.preventDefault();
     
})

function checkFormDropdowns() {
    FORM_DROPDOWNS.forEach(dropdown => {
        if (parseInt(dropdown.value) === 0)
            createError(dropdown, 'required');
        else if (parseInt(dropdown.value) > 0 && dropdown.classList.contains('error-outline')) {
            dropdown.classList.remove('error-outline');
            dropdown.parentElement.lastChild.remove();
        }
    });
}
function checkFormInputs() {
    FORM_INPUT_NAMES.forEach(input => {

        // Checks if the first and last name are not empty
        // And Valid 
        let = formvalue = input.value; 
        if (input.value === "" || !formvalue.match(NAME_REGEXP)) {
            createError(input, 'name is invalid or empty');
        }
        else if (formvalue.match(NAME_REGEXP) && input.classList.contains('error-outline')) {
            input.classList.remove('error-outline');
            input.parentElement.lastChild.remove();
        }

    })

    // Checks if the phone field is empty or valid
    if (FORM_INPUT_PHONE.value === "" || !FORM_INPUT_PHONE.value.match(PHONE_REGEXP)) {
        createError(FORM_INPUT_PHONE, 'phone number is invalid or empty');
        
    }
    else if (FORM_INPUT_PHONE.value.match(NAME_REGEXP) && FORM_INPUT_PHONE.classList.contains('error-outline')) {
        FORM_INPUT_PHONE.classList.remove('error-outline');
        FORM_INPUT_PHONE.parentElement.lastChild.remove();
    }
}
// Appends error depending on the error list 
function createError(input,errorValue) {

 
    //if (input.classList.contains('error-outline'))
    //    return;


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
//To remove repeated errors 
function removeErrorInputs(input) {

    if (input.classList.contains('error-outline')) {
        input.classList.remove('error-outline');
        input.parentElement.lastChild.remove();
    } 
}
// Checks overall Erros in page 
function checkError() {
    let value; 
    const name = document.querySelectorAll(".form-input  input:not(.number)");
    const phone = document.querySelector(".number");
    const dropdowns = document.querySelectorAll(".form-dropdown-group select");
    name.forEach(input => {
        value = input.classList.contains('error-outline');
    });

    dropdowns.forEach(input => {
        value = input.classList.contains('error-outline');
    });
    console.log(phone)

    return value; 


}

