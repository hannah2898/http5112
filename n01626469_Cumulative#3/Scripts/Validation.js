function validateForm() {
    var teacherFname = document.getElementById('TeacherFname').value;
    var teacherLname = document.getElementById('TeacherLname').value;
    var employeeNumber = document.getElementById('EmployeeNumber').value;
    var hireDate = document.getElementById('HireDate').value;
    var salary = document.getElementById('Salary').value;

    if (!teacherFname || !teacherLname || !employeeNumber || !hireDate || !salary) {
        alert('All fields must be filled out.');
        return false;
    }

    

    return true;
}