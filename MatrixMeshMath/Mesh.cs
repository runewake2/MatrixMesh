using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMeshMath
{
    public class Mesh
    {
        public IEnumerable<Vector2> Points { get; init; }

        public Mesh(IEnumerable<Vector2> points)
        {
            this.Points = new List<Vector2>(points);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Mesh mesh)
            {
                return this.Points.SequenceEqual(mesh.Points);
            }
            return base.Equals(obj);
        }

        public Mesh Scale(Vector2 scale)
        {
            var results = new List<Vector2>();
            foreach(var point in Points)
            {
                results.Add(point * scale);
            }
            return new Mesh(results);
        }

        public Mesh Translation(Vector2 translation)
        {
            var results = new List<Vector2>();
            foreach (var point in Points)
            {
                results.Add(point + translation);
            }
            return new Mesh(results);
        }


        // The rotation of the mesh in radians
        public Mesh Rotate(float rotation)
        {
            var rotationMatrix = Matrix2x2.RotationMatrix(rotation);
            var results = new List<Vector2>();
            foreach (var point in Points)
            {
                results.Add(Matrix2x2.Rotate(rotationMatrix, point));
            }
            return new Mesh(results);
        }
    }
}
