using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace StudentApi.Models
{
  [Table("tb_student")]
  public partial class Student
  {
    #region "Properties"
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name", TypeName = "varchar")]
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    [Column("student_id", TypeName = "varchar")]
    [Required]
    [MaxLength(8)]
    public string StudentId { get; set; }

    [Column("grades", TypeName = "text")]
    [Required]
    public List<double> Grades { get; set; }

    #endregion

    #region Methods 

    #endregion
  }
}
