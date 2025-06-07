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


        [UseProjection]
        public IQueryable<Apartment> GetFilteredApartments(
                [Service] AppDbContext context,
                ApartmentFilter filter)
        {
            var query = context.Apartments.Include(a => a.Owner).AsQueryable();

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(a => a.pricepernight < filter.MaxPrice.Value);
            }

            return query;
        }
    }
}