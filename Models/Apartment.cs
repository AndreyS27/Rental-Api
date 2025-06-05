using System.ComponentModel.DataAnnotations.Schema;

[Table("apartments")]
public class Apartment
{
    public int id { get; set; }
    public string address { get; set; }
    public decimal pricepernight { get; set; }
    public int ownerid { get; set; }
    public User Owner { get; set; }
}