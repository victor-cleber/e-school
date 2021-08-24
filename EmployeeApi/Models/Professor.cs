using System;

namespace EmployeeApi.Models
{
    public class Professor : Employee
    {
        public string ProfessorId { get; set; }

        public bool IsStaff {get; set;}
    }
}
