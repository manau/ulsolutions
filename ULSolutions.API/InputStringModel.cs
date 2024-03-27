using System.ComponentModel.DataAnnotations;
namespace ULSolutions.API;

public class InputStringModel
{
    public InputStringModel()
    {
        InputString = ""; 
    }

    [Required]
    [StringLength(50)]
    [RegularExpression("^[0-9+-/*]+$")]
    public string InputString { get; set; }
}
