document.addEventListener("DOMContentLoaded", function () {
    setupStudentSubmit();
    setupReturn();
});

function setupStudentSubmit() {

    //Creating student from form parameters

    var form = document.forms.create;
    // Need to add our own custom event for form submission
    form.onsubmit = function (e) {
        // ... and prevent the default action from occuring
        e.preventDefault();

        //Creating student from form parameters
        var newCourse = {
            // Access the data in the fields with .value 
            CourseID: document.getElementById("courseIDinput").value,
            Title: document.getElementById("Title").value,
        }

        // Take me back home when done!
        CourseModule.addCourse(newCourse, function () {
            window.location.href = "index.html";
        });
    }

};

// Add event listener, cancel button will take you back to home page
function setupReturn() {
    document.getElementById('btncancel').addEventListener('click', function () {
        window.location.href = "index.html";
    });
}