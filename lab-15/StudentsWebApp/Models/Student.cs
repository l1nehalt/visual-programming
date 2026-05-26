using System.ComponentModel.DataAnnotations;

namespace StudentsWebApp.Models;

public class Student
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(100)] public string Name { get; set; }

    [Required] [DataType(DataType.Date)] public DateTime Birthdate { get; set; }

    public string? PhotoPath { get; set; }

    [StringLength(20)]
    [Required(ErrorMessage = "Введите номер телефона")]
    [RegularExpression(@"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$",
        ErrorMessage = "Номер телефона должен быть в формате +7(xxx)xxx-xx-xx")]
    public string Phone { get; set; }
}