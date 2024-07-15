// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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

