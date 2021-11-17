using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMeshMath
{
    public static class Shapes
    {
        public static Mesh Quad => new Mesh(new Vector2[] {
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(0,1),
                new Vector2(1,1),
            });

        public static Mesh CenteredQuad => new Mesh(new Vector2[] {
                new Vector2(-0.5f,-0.5f),
                new Vector2(0.5f,-0.5f),
                new Vector2(-0.5f,0.5f),
                new Vector2(0.5f,0.5f),
            });
    }
}
