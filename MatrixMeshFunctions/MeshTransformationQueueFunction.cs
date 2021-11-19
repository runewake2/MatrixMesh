using System;
using System.Linq;
using MatrixMeshMath;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatrixMeshFunctions
{
    public static class MeshTransformationQueueFunction
    {
        [FunctionName("MeshTransformationQueueFunction")]
        public static void Run([ServiceBusTrigger("matrix-transformation-requests")]string myQueueItem, ILogger log)
        {
            var data = JsonConvert.DeserializeObject<MeshTransformationRequest>(myQueueItem);

            // Convert to Mesh and Transformations
            var mesh = MeshTransformations.ConvertPointCloudToMesh(data.Mesh);

            // Execute Transformations
            var transformedMesh = TransformationController.Transform(mesh, data.Transformations);

            // Convert from Mesh to Mesh Point Cloud
            var convertedMesh = MeshTransformations.ConvertMeshToPointCloud(transformedMesh);

            log.LogInformation($"C# ServiceBus queue trigger function processed message: \n {JsonConvert.SerializeObject(convertedMesh)}");
        }
    }
}
