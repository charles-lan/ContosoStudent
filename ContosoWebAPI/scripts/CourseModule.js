var CourseModule = (function () {
    // Return anything that you want to expose outside the closure
    return {
        getCourses: function (callback) {

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "/api/courses",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        },

        deleteCourse: function (courseid, callback) {
            $.ajax({
                type: "DELETE",
                dataType: "json",
                url: "/api/courses/" + courseid,
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            })

        },

        addCourse: function (course, callback) {
             
            $.ajax({
                url : "/api/Courses/",
                type: "POST",
                data : course,
                success: function(data, textStatus, jqXHR)
                {
                    callback();
                }
            });
        },

        editCourse: function (courseID, course, callback) {            
                $.ajax({
                    url : "/api/Courses/" + studentid,
                    type: "PUT",
                    data : student,
                    success: function(data, textStatus, jqXHR)
                    {
                        callback();
                    }
                });
        },

        getCourseById: function (courseid, callback) {

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "/api/Courses/" + courseid,
                success: function (data) {
                    callback(data);
                }
            });
        }
    }

   


    
}());
