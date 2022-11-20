var Student = {

    LoadStudents: function () {
        ajax.load($("#pvStudents"), "/Student/StudentsPartial");
    },

    GetStudentCoursesPopUp: function (studentName, studentId) {
        Modal(studentName, '/Course/StudentCoursePartial', { 'studentId': studentId });
    },

    GetCourseManager: function (studentId) {
        ajax.get('/Course/CourseManager', { 'studentId': studentId });
    },
};

