using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MatrixMeshMath;
using System.Linq;

namespace MatrixMeshFunctions;

public static class MeshTransformationFunction
{
    [FunctionName("MeshTransformationFunction")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<MeshTransformationRequest>(requestBody);

        // Convert to Mesh and Transformations
        var mesh = MeshTransformations.ConvertPointCloudToMesh(data.Mesh);

        // Execute Transformations
        var transformedMesh = TransformationController.Transform(mesh, data.Transformations);

        // Convert from Mesh to Mesh Point Cloud
        var convertedMesh = MeshTransformations.ConvertMeshToPointCloud(transformedMesh);
            
        return new OkObjectResult(convertedMesh);
        //return new OkObjectResult(responseMessage);
    }
}