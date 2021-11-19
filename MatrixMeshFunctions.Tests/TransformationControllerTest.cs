using MatrixMeshMath;
using System;
using System.Collections.Generic;
using Xunit;

namespace MatrixMeshFunctions.Tests;

public class TransformationControllerTest
{
    [Fact]
    public void RotateTransformFailsWhenArgumentsAreEmptyTest()
    {
        // given
        var function = new RotateFunction();
        var mesh = Shapes.CenteredQuad;
        var arguments = new Dictionary<string, object>() {};

        // when
        Assert.Throws<KeyNotFoundException>(() => function.Transform(mesh, arguments));
    }

    [Fact]
    public void RotateTransformFailsWhenRotationNotProvidedTest()
    {
        // given
        var function = new RotateFunction();
        var mesh = Shapes.CenteredQuad;
        var arguments = new Dictionary<string, object>()
        {
            { "x", 10.0f }
        };

        // when
        Assert.Throws<KeyNotFoundException>(() => function.Transform(mesh, arguments));
    }

    [Fact]
    public void RotateTransformSucceedsWhenRotationProvidedTest()
    {
        // given
        var function = new RotateFunction();
        var mesh = Shapes.Quad;
        var arguments = new Dictionary<string, object>()
        {
            { "rotation", MathF.PI }
        };

        // when
        var result = function.Transform(mesh, arguments);

        // expect
        Assert.Equal(new Mesh(new Vector2[] {
                new Vector2(0, 0),
                new Vector2(-1,0),
                new Vector2(0,-1),
                new Vector2(-1,-1),
            }), result);
    }
}