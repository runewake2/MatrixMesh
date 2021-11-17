using Xunit;

namespace MatrixMeshMath.Tests;

public class Vector2Test
{
    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0)]
    [InlineData(1, 1, 1, 1, 2, 2)]
    [InlineData(1, 0, 0, 0, 1, 0)]
    [InlineData(0, 1, 0, 0, 0, 1)]
    [InlineData(0, 0, 1, 0, 1, 0)]
    [InlineData(0, 0, 0, 1, 0, 1)]
    public void Vector2AdditionTest(
        float leftX, float leftY,
        float rightX, float rightY,
        float resultX, float resultY)
    {
        // given
        var left = new Vector2(leftX, leftY);
        var right = new Vector2(rightX, rightY);

        // when
        var result = left + right;

        // expect
        Assert.Equal(new Vector2(resultX, resultY), result);
    }

    [Theory]
    [InlineData(1, 1, 0, 0, 0, 0)]
    [InlineData(0, 0, 1, 1, 0, 0)]
    [InlineData(1, 1, 1, 1, 1, 1)]
    public void Vector2MultiplicationTest(
        float leftX, float leftY,
        float rightX, float rightY,
        float resultX, float resultY)
    {
        // given
        var left = new Vector2(leftX, leftY);
        var right = new Vector2(rightX, rightY);

        // when
        var result = left * right;

        // expect
        Assert.Equal(new Vector2(resultX, resultY), result);
    }
}