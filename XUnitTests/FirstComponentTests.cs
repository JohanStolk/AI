namespace XUnitTests;

public class FirstComponentTests
{
    [Fact]
    public void ValidateEmail_ValidEmail_ReturnsTrue()
    {
        // Arrange
        string email = "test@example.com";

        // Act
        bool result = FirstComponent.ValidateEmail(email);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ValidateEmail_InvalidEmail_ReturnsFalse()
    {
        // Arrange
        string email = "invalid-email";

        // Act
        bool result = FirstComponent.ValidateEmail(email);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void ValidateEmail_EmptyEmail_ReturnsFalse()
    {
        // Arrange
        string email = "";

        // Act
        bool result = FirstComponent.ValidateEmail(email);

        // Assert
        result.Should().BeFalse();
    }

}
