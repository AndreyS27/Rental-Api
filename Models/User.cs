using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}