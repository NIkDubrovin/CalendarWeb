// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const exampleModal = document.getElementById('exampleModal')
if (exampleModal) {
    exampleModal.addEventListener('show.bs.modal', event => {
        // Button that triggered the modal
        const button = event.relatedTarget
        // Extract info from data-bs-* attributes
        const recipient = button.getAttribute('data-bs-whatever')
        // If necessary, you could initiate an Ajax request here
        // and then do the updating in a callback.

        // Update the modal's content.
        const modalTitle = exampleModal.querySelector('.modal-title')
        const modalBodyInput = exampleModal.querySelector('.modal-body input')

        modalTitle.textContent = `New message to ${recipient}`
        modalBodyInput.value = recipient
    })
}

//const colorPickerInput = document.getElementById("color-picker-input");
//const colorPickerIcon = document.getElementById("color-picker-icon");

//colorPickerIcon.addEventListener("click", function () {
//    colorPickerInput.click();
//});

//colorPickerInput.addEventListener("input", function () {
//    // Get selected color value
//    let selectedColor = colorPickerInput.value;
//    console.log("Selected color: " + selectedColor);
//});

// Convert RGB to hex
function rgbToHex(rgb) {
    // Extract the RGB values
    const values = rgb.match(/^rgb\((\d+),\s*(\d+),\s*(\d+)\)$/);

    // Convert each RGB value to its hex representation and concatenate
    return ((1 << 24) + (parseInt(values[1]) << 16) + (parseInt(values[2]) << 8) + parseInt(values[3])).toString(16).slice(1);
}

document.addEventListener('DOMContentLoaded', function () {
    const buttons = document.querySelectorAll('.color-button');
    const colorInput = document.getElementById('color-input');

    buttons.forEach((button, index) => {
       
        button.addEventListener('click', function () {
            buttons.forEach((button, index) => {
                button.style.border = 0;
            });

            let bgColor = this.style.backgroundColor;
            colorInput.value = rgbToHex(bgColor);
            this.style.border = "5px solid black";
            this.classList.add('active')
        });
    });
});
