using MatrixMeshMath;
using System;
using System.Collections.Generic;

namespace MatrixMeshFunctions;

internal static class TransformationController
{
    private static Dictionary<string, ITransformationFunction> transformationFunctions = new Dictionary<string, ITransformationFunction>()
    {
        { "translate", new TranslateFunction() },
        { "rotate", new RotateFunction() },
        { "scale", new ScaleFunction() }
    };

    internal static Mesh Transform(Mesh mesh, TransformationOperation[] transformations)
    {
        var transformedMesh = mesh;
        foreach (var transformation in transformations)
        {
            ITransformationFunction func;
            if (transformationFunctions.TryGetValue(transformation.Type, out func))
            {
                transformedMesh = func.Transform(transformedMesh, transformation.Arguments);
            }
        }
        return transformedMesh;
    }
}

internal interface ITransformationFunction
{
    Mesh Transform(Mesh mesh, Dictionary<string, object> arguments);
}

public class TranslateFunction : ITransformationFunction
{
    public Mesh Transform(Mesh mesh, Dictionary<string, object> arguments)
    {
        // TODO sam: add type safety checks on dynamic arguments
        float x = 0, y = 0;
        if (arguments.ContainsKey("x"))
        {
            x = Convert.ToSingle(arguments["x"]);
        }
        if (arguments.ContainsKey("y"))
        {
            y = Convert.ToSingle(arguments["y"]);
        }
        var translation = new Vector2(x, y);
        return mesh.Translation(translation);
    }
}

public class RotateFunction : ITransformationFunction
{
    public Mesh Transform(Mesh mesh, Dictionary<string, object> arguments)
    {
        var rotation = (float)arguments["rotation"];
        return mesh.Rotate(rotation);
    }
}

public class ScaleFunction : ITransformationFunction
{
    public Mesh Transform(Mesh mesh, Dictionary<string, object> arguments)
    {
        var scale = new Vector2((float)arguments["x"], (float)arguments["y"]);
        return mesh.Scale(scale);
    }
}