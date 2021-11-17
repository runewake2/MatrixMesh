
namespace MatrixMeshMath.Tests;

using System;
using Xunit;

public class MeshTest
{
    [Fact]
    public void MeshScaleTest()
    {
        // given
        var mesh = Shapes.CenteredQuad;
        var scale = new Vector2(2, 2);

        // when
        var result = mesh.Scale(scale);

        // expect
        Assert.Equal(new Mesh(new Vector2[]
        {
            new Vector2(-1f,-1f),
            new Vector2(1f,-1f),
            new Vector2(-1f,1f),
            new Vector2(1f,1f),
        }), result);
    }

    [Fact]
    public void MeshTranslationTest()
    {
        // given
        var mesh = Shapes.CenteredQuad;
        var translation = new Vector2(0.5f, 0.5f);

        // when
        var result = mesh.Translation(translation);

        // expect
        Assert.Equal(Shapes.Quad, result);
    }

    [Fact]
    public void MeshRotationTest()
    {
        // given
        var mesh = Shapes.Quad;

        // when
        var result = mesh.Rotate(MathF.PI);

        // expect
        Assert.Equal(new Mesh(new Vector2[] {
                new Vector2(0, 0),
                new Vector2(-1,0),
                new Vector2(0,-1),
                new Vector2(-1,-1),
            }), result);
    }

    [Fact]
    public void MeshEqualInPointOrderTest()
    {
        // given
        var mesh = Shapes.CenteredQuad;

        // expect: Meshes with points in different sequence order to not be equal
        Assert.NotEqual(new Mesh(new Vector2[] {
                new Vector2(0.5f,0.5f),
                new Vector2(0.5f,-0.5f),
                new Vector2(-0.5f,0.5f),
                new Vector2(-0.5f,-0.5f),
            }), mesh);
    }
}
