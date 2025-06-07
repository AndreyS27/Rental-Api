using HotChocolate.Types;

using HotChocolate.Types;

public class ApartmentFilterInputType : InputObjectType<ApartmentFilter>
{
    protected override void Configure(IInputObjectTypeDescriptor<ApartmentFilter> descriptor)
    {
        descriptor.Field(f => f.MaxPrice).Type<DecimalType>();
    }
}
