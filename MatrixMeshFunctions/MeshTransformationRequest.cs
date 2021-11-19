using MatrixMeshMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMeshFunctions;

public static class MeshTransformations
{
    public static Mesh ConvertPointCloudToMesh(MeshPointCloud mesh)
    {
        return new Mesh(mesh.Points.Select(vec => new Vector2(vec.X, vec.Y)).ToList());
    }

    public static MeshPointCloud ConvertMeshToPointCloud(Mesh mesh)
    {
        return new MeshPointCloud()
        {
            Points = mesh.Points.Select(vec => new Vector2Data() { X = vec.X, Y = vec.Y }).ToList()
        };
    }
}

public class MeshTransformationRequest
{
    public MeshPointCloud Mesh { get; set; }
    public TransformationOperation[] Transformations { get; set; }
}

public class MeshPointCloud
{
    public IEnumerable<Vector2Data> Points { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is MeshPointCloud mesh)
        {
            return this.Points.SequenceEqual(mesh.Points);
        }
        return base.Equals(obj);
    }
}

public class Vector2Data
{
    public float X { get; set; }
    public float Y { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Vector2Data vector)
        {
            return this.X == vector.X && this.Y == vector.Y;
        }
        return base.Equals(obj);
    }
}

public class TransformationOperation
{
    public string Type { get; set; }
    public Dictionary<string, object> Arguments { get; set; }
}