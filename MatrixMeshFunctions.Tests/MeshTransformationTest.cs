using MatrixMeshMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MatrixMeshFunctions.Tests;

public class MeshTransformationTest
{
    [Fact]
    public void MeshTransformationMeshToPointCloudTest()
    {
        // given
        var mesh = Shapes.Quad;

        // when
        var transformed = MeshTransformations.ConvertMeshToPointCloud(mesh);

        // expect
        Assert.Equal(new MeshPointCloud()
        {
            Points = new List<Vector2Data>
            {
                new Vector2Data { X=0, Y=0 },
                new Vector2Data { X=1, Y=0 },
                new Vector2Data { X=0, Y=1 },
                new Vector2Data { X=1, Y=1 },
            }
        }, transformed);
    }

    [Fact]
    public void MeshTransformationPointCloudToMeshTest()
    {
        // given
        var mesh = new MeshPointCloud()
        {
            Points = new List<Vector2Data>
            {
                new Vector2Data { X=0, Y=0 },
                new Vector2Data { X=1, Y=0 },
                new Vector2Data { X=0, Y=1 },
                new Vector2Data { X=1, Y=1 },
            }
        };

        // when
        var transformed = MeshTransformations.ConvertPointCloudToMesh(mesh);

        // expect
        Assert.Equal(Shapes.Quad, transformed);
    }
}
