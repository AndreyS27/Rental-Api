public class UserInputType : InputObjectType<UserInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserInput> descriptor)
    {
        descriptor.Field(u => u.Name).Type<StringType>();
        descriptor.Field(u => u.Email).Type<StringType>();
    }
}


public class UserInput
{
    public string Name { get; set; }
    public string Email { get; set; }
}