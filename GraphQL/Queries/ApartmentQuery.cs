using Microsoft.EntityFrameworkCore;
using HotChocolate;

namespace RentalApi.GraphQL.Queries
{
    public class ApartmentQuery

    {
        [UseProjection]
        public IQueryable<Apartment> GetApartments([Service] AppDbContext context)
        {
            return context.Apartments.Include(a => a.Owner);
        }
    }
}