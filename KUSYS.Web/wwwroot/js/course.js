var Course = {

    LoadSelectedCourses: function (studentId) {
        ajax.load($("#pvSelectedCourses"), "/Course/SelectedCourseManagePartial", { 'studentId': studentId });
    },

    LoadSelectableCourses: function (studentId) {
        ajax.load($("#pvSelectableCourses"), "/Course/SelectableCourseManagePartial", { 'studentId': studentId });
    },

    AddSelectableCourse: function (studentId, courseId) {
        ajax.post("/Course/AddSelectableCourse", { 'studentId': studentId, 'courseId': courseId }, function (response) {
            Course.LoadSelectableCourses(studentId);
            Course.LoadSelectedCourses(studentId);
        });
    },

    RemoveSelectedCourse: function (studentId, courseId) {
        ajax.post("/Course/RemoveSelectedCourse", { 'studentId': studentId, 'courseId': courseId }, function (response) {
            Course.LoadSelectableCourses(studentId);
            Course.LoadSelectedCourses(studentId);
        });
    }

};

