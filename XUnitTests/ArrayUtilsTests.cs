namespace XUnitTests;

public class ArrayUtilsTests
{
    [Fact]
    public void FindMax_ReturnsMaxValue_WhenArrayContainsIntegers()
    {
        // Arrange
        int[] arr = { 1, 5, 3, 2, 4 };

        // Act
        int max = ArrayUtils.FindMax(arr);

        // Assert
        max.Should().Be(5);
    }

    [Fact]
    public void FindMax_ReturnsMaxValue_WhenArrayContainsDoubles()
    {
        // Arrange
        double[] arr = { 1.0, 5.0, 3.0, 2.0, 4.0 };

        // Act
        double max = ArrayUtils.FindMax(arr);

        // Assert
        max.Should().Be(5.0);
    }

    [Fact]
    public void FindMax_ThrowsException_WhenArrayIsEmpty()
    {
        // Arrange
        int[] arr = Array.Empty<int>();

        // Act
        Action action = () => ArrayUtils.FindMax(arr);

        // Assert
        action.Should().Throw<IndexOutOfRangeException>().WithMessage("Index was outside the bounds of the array.");
    }
}
