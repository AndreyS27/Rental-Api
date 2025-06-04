using Microsoft.EntityFrameworkCore;

[ExtendObjectType("Query")]
public class ApartmentQuery
{
    [UseProjection]
    public IQueryable<Apartment> GetApartments([Service] AppDbContext context)
    {
        return context.Apartments.Include(a => a.Owner);
    }
}