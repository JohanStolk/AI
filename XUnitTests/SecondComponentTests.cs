namespace XUnitTests;

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public Address Address { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
}


public class SecondComponentTests
{
    [Fact]
    public void TestGetNestedPropertyValue()
    {
        // Arrange
        Address address = new()
        {
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };
        Person person = new()
        {
            Name = "John Doe",
            Age = 42,
            Address = address
        };
        string propertyPath = "Address.City";

        // Act
        object? result = SecondComponent.GetNestedPropertyValue(person, propertyPath);

        // Assert
        result.Should().Be("Anytown");
    }

    [Fact]
    public void TestGetNestedPropertyValue_NullObject()
    {
        // Arrange
        Person? person = null;
        string propertyPath = "Address.City";

        // Act
        object? result = SecondComponent.GetNestedPropertyValue(person, propertyPath);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void TestGetNestedPropertyValue_NullProperty()
    {
        // Arrange
        Address address = new()
        {
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };
        Person person = new()
        {
            Name = "John Doe",
            Age = 42,
            Address = address
        };
        string propertyPath = "Address.Country";

        // Act
        object? result = SecondComponent.GetNestedPropertyValue(person, propertyPath);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void TestGetNestedPropertyValue_EmptyPropertyPath()
    {
        // Arrange
        Address address = new()
        {
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };
        Person person = new()
        {
            Name = "John Doe",
            Age = 42,
            Address = address
        };
        string propertyPath = "";

        // Act
        object? result = SecondComponent.GetNestedPropertyValue(person, propertyPath);

        // Assert
        result.Should().Be(person);
    }

    [Fact]
    public void TestGetNestedPropertyValue_NestedList()
    {
        // Arrange
        Address address1 = new()
        {
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };
        Address address2 = new()
        {
            Street = "456 Oak St",
            City = "Othertown",
            State = "CA",
            Zip = "67890"
        };
        Person person = new()
        {
            Name = "John Doe",
            Age = 42,
            Addresses = new List<Address> { address1, address2 }
        };
        string propertyPath = "Addresses[1].City";

        // Act
        object? result = SecondComponent.GetNestedPropertyValue(person, propertyPath);

        // Assert
        result.Should().Be("Othertown");
    }
}
