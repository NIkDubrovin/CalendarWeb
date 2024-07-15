const uri = 'api/event';

document.addEventListener('DOMContentLoaded', function () {
    const buttons = document.querySelectorAll('.color-button');
    const colorsInputs = document.querySelectorAll('.color-input');

    buttons.forEach((button, index) => {
        button.addEventListener('click', function () {
            buttons.forEach((button, index) => {
                button.style.border = 0;
            });

            colorsInputs.forEach((input, index) => {
                let bgColor = this.style.backgroundColor;
                input.value = rgbToHex(bgColor);
            });

            this.style.border = "5px solid black";
            this.classList.add('active')
        });
    });

    const updateLinks = document.querySelectorAll('.event-update-link');
    const deleteLinks = document.querySelectorAll('.event-delete-link');

    updateLinks.forEach((button, index) => {
        button.addEventListener('click', function () {
            displayEditForm(this.id)
        });
    });

    deleteLinks.forEach((button, index) => {
        button.addEventListener('click', function () {
            document.getElementById('deleteButton').id = this.id;
            $('#deleteEventModal').modal('show');
        });
    });
});

function getEvents() {
    fetch(uri)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addEvent() {
    const TitleTextBox = document.getElementById('create-title');
    const DateInput = document.getElementById('create-date');
    const ColorInput = document.getElementById('edit-color-input');

    const item = {
        title: TitleTextBox.value,
        date: DateInput.value,
        color: ColorInput.value
    };

    console.log(JSON.stringify(item))

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
    .then(response => {
        if (response.ok) {
           window.location.reload();

            $('#successToast .toast-body').text('Event created!');
            var myToastEl = document.getElementById('successToast')
            var myToast = bootstrap.Toast.getOrCreateInstance(myToastEl)
            if (myToast != null)
            myToast.show()

            $('#createEventModal').modal('hide');
        }
    })
    .then(data => console.log(data))
        .catch(error => {
            console.error('Unable to add item.', error)
            window.location.reload();
        $('#errorToast .toast-body').text('Event isnt created!');
        var myToastEl = document.getElementById('errorToast')
        var myToast = bootstrap.Toast.getInstance(myToastEl)
        if (myToast != null)
            myToast.show()

       $('#createEventModal').modal('hide');
     });
}

function deleteEvent(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                window.location.reload();

                $('#successToast .toast-body').text('Event created!');
                var myToastEl = document.getElementById('successToast')
                var myToast = bootstrap.Toast.getOrCreateInstance(myToastEl)
                if (myToast != null)
                    myToast.show()

                $('#deleteEventModal').modal('hide');
            }
        })
        .catch(error => {
            console.error('Unable to add item.', error)
            window.location.reload();
            $('#errorToast .toast-body').text('Event isnt created!');
            var myToastEl = document.getElementById('errorToast')
            var myToast = bootstrap.Toast.getInstance(myToastEl)
            if (myToast != null)
                myToast.show()

            $('#deleteEventModal').modal('hide');
        });
}

function Event(id, title, date, color) {
    this.id = id;
    this.title = title;
    this.date = date;
    this.color = color;
}

function displayEditForm(id) {
    fetch(`${uri}/${id}`)
    .then(response => response.json())
     .then(data => {
        $('#editEventModal').modal('show');
        const IdTextBox = document.getElementById('edit-id');
        const TitleTextBox = document.getElementById('edit-title');
        const DateInput = document.getElementById('edit-date');
        const ColorInput = document.getElementById('edit-color-input');
        const event = new Event(data.id, data.title, data.date, data.color);

        IdTextBox.value = event.id;
        TitleTextBox.value = event.title;
        DateInput.value = event.date;
        ColorInput.value = event.color;

         const buttons = document.querySelectorAll('.color-button');

         buttons.forEach((button, index) => {
             button.style.border = 0;
             let hexColor = rgbToHex(button.style.backgroundColor);
             if (hexColor.toUpperCase() == ColorInput.value.toUpperCase()) {
                 button.style.border = "5px solid black";
                 button.classList.add('active')
             }
         });
    })
    .catch(error => console.error('Unable to get items.', error));
}

function editEvent() {
    const IdTextBox = document.getElementById('edit-id');
    const TitleTextBox = document.getElementById('edit-title');
    const DateInput = document.getElementById('edit-date');
    const ColorInput = document.getElementById('edit-color-input');

    const item = {
        id: IdTextBox.value,
        title: TitleTextBox.value,
        date: DateInput.value,
        color: ColorInput.value
    };

    fetch(`${uri}/${IdTextBox.value}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
    .then(response => {
        if (response.ok) {
            window.location.reload();
            $('#successToast .toast-body').text('Event updated!');
            var myToastEl = document.getElementById('successToast')
            var myToast = bootstrap.Toast.getOrCreateInstance(myToastEl)
            if (myToast != null)
                myToast.show()

            $('#editEventModal').modal('hide');
        } else {
            console.log(response.json())
        }
    })
        .catch(error => {
            window.location.reload();
            console.error('Unable to update item.', error)
        $('#errorToast .toast-body').text('Event isnt created!');
        var myToastEl = document.getElementById('errorToast')
        var myToast = bootstrap.Toast.getInstance(myToastEl)
        if (myToast != null)
            myToast.show()

        $('#editEventModal').modal('hide');
        
    });
}
