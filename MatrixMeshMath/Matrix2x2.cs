using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMeshMath
{
    internal class Matrix2x2
    {
        private float[,] matrix = new float[2, 2];

        protected Matrix2x2(float r1, float r2, float r3, float r4)
        {
            /*
             * r1 r2    X
             * r3 r4    Y
             */

            matrix[0, 0] = r1;
            matrix[0, 1] = r2;
            matrix[1, 0] = r3;
            matrix[1, 1] = r4;
        }

        public static Matrix2x2 RotationMatrix(float rotation)
        {
            return new Matrix2x2(
                MathF.Cos(rotation), -MathF.Sin(rotation),
                MathF.Sin(rotation), MathF.Cos(rotation));
        }
        
        // rotation is the radians of rotation
        public static Vector2 Rotate(Matrix2x2 matrix, Vector2 point)
        {
            //var matrix = RotationMatrix(rotation).matrix;

            return new Vector2(
                matrix.matrix[0, 0] * point.X + matrix.matrix[0, 1] * point.X,
                matrix.matrix[1, 0] * point.Y + matrix.matrix[1, 1] * point.Y);
        }
    }
}
