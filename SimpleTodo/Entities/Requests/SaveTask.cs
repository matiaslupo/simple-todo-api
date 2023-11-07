using System.ComponentModel.DataAnnotations;

namespace SimpleTodo.Entities.Requests;

public class SaveTask
{
    [MinLength(10, ErrorMessage = "Must be atleast 10 characters long.")]
    [MaxLength(25, ErrorMessage = "Cannot be more than 25 characters long.")]
    public string Description { get; set; } = string.Empty;
}
