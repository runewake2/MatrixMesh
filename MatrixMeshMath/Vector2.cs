namespace MatrixMeshMath;

public class Vector2
{
    private const float floatingPrecision = 0.00001f;

    public float X { get; init; }
    public float Y { get; init; }

    public Vector2(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector2 vector)
        {
            return Math.Abs(vector.X - this.X) < floatingPrecision && Math.Abs(vector.Y - this.Y) < floatingPrecision;
        }
        return base.Equals(obj);
    }



    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X + right.X, left.Y + right.Y);
    }

    public static Vector2 operator *(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X * right.X, left.Y * right.Y);
    }
}