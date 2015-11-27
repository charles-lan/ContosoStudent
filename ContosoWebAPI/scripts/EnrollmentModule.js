var EnrollmentModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        getEnrollments: function (callback) {

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "/api/enrollments",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        },

        addEnrollments: function (enrollment, callback) {
            xhttp.open("POST", "/api/Enrollment", true);
            xhttp.setRequestHeader("Content-type", "application/json")
            xhttp.send(JSON.stringify(enrollment));
        },

    }
}());