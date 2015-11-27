document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM loaded and ready to go!");

    loadCourses();
});

function loadCourses() {
    CourseModule.getCourses(setupCoursesTable);
    //EnrollmentModule.getEnrollments(setupCoursesTable);
}

function setupCoursesTable(coursesList) {
    //CourseList is returned from the getCourses.
    var controller = document.body.getAttribute("data-controller");
    var courseTable = document.getElementById("coursesList");
    console.log(coursesList);

    for (i = 0; i < coursesList.length; i++) {
        var row = document.createElement("tr");

        var lastNameCol = document.createElement("td");
        //inner HTML is between tags.
        lastNameCol.innerHTML = coursesList[i].CourseID;
        row.appendChild(lastNameCol);

        var firstNameCol = document.createElement("td");
        //inner HTML is between tags.
        firstNameCol.innerHTML = coursesList[i].Title;
        row.appendChild(firstNameCol);

        // Create edit and delete buttons
        var editcol = document.createElement('td');
        var editbtn = document.createElement('button');
        editbtn.class = "btn btn-primary btn-xs";
        editbtn.innerHTML = "Edit";

        // You can set your own attributes to elements. This is pretty handy
        // for idenitfying them without using the id tag, or keeping context
        // between different pages (see the 'detail' page event handler down)
        editbtn.setAttribute("data-id", coursesList[i].CourseID);
        editbtn.setAttribute("data-btntype", "edit");
        editbtn.setAttribute("data-title", "Edit");
        editbtn.setAttribute("data-toggle", "modal");
        editbtn.setAttribute("data-target","#edit")

        editcol.appendChild(editbtn);
        row.appendChild(editcol);

        var deletecol = document.createElement('td');
        var deletebtn = document.createElement('button');
        deletebtn.className = "btn btn-default";
        deletebtn.innerHTML = "Delete";
        deletebtn.setAttribute("data-id", coursesList[i].CourseID);
        deletebtn.setAttribute("data-btntype", "delete");

        deletecol.appendChild(deletebtn);
        row.appendChild(deletecol);

        courseTable.appendChild(row);
    }

    // Event delegation
    courseTable.addEventListener('click', function (e) {
        var target = e.target;

        // Bubble up to tbody - need to bubble the event up because the click occurs in 
        // the td cells but the data-id attribute is in the row (for going to more detail page)
        while (target.nodeName.toLowerCase() !== "tbody") {

            // For all these cases we use the data-id stored in either the cell or the row to keep context
            // between seperate pages

            // Edit
            if (target.getAttribute("data-btntype") === "edit") {
              window.location.href = 'edit.html' + '?id=' + target.getAttribute("data-id");
              return;
            }
                // Delete
              if (target.getAttribute("data-btntype") === "delete") {
                CourseModule.deleteCourse(target.getAttribute("data-id"), function () {
                    window.location.reload(true);
                });
                return;

                // Detail - this is true if clicked anywhere within the row
            } else if (target.nodeName.toLowerCase() === "tr") {
                window.location.href = 'detail.html' + '?type=' + controller + '&id=' + target.getAttribute("data-id");
                return;
            }

            // Keep bubbling the event up through the DOM
            target = target.parentNode;
        }
    });


}