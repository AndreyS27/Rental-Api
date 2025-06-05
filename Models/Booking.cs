using System.ComponentModel.DataAnnotations.Schema;

[Table("bookings")]
public class Booking
{
    public int id { get; set; }
    public int apartmentid { get; set; }
    public int userid { get; set; }
    public DateTime startdate { get; set; }
    public DateTime enddate { get; set; }
}