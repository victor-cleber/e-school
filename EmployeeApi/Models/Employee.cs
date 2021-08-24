using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeApi.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
