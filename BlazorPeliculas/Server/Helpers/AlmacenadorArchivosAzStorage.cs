using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Helpers
{
    public class AlmacenadorArchivosAzStorage : IAlmacenadorDeArchivos
    {
        //private readonly string connectionString;

        //public AlmacenadorArchivosAzStorage(IConfiguration configuration)
        //{
        //    connectionString = configuration.GetConnectionString("AzureStorage");
        //}

        //public async Task<string> EditarArchivo(byte[] contenido, string extension,
        //    string nombreContenedor, string rutaArchivoActual)
        //{
        //    if (!string.IsNullOrEmpty(rutaArchivoActual))
        //    {
        //        await EliminarArchivo(rutaArchivoActual, nombreContenedor);
        //    }

        //    return await GuardarArchivo(contenido, extension, nombreContenedor);
        //}

        //public async Task EliminarArchivo(string ruta, string nombreContenedor)
        //{
        //    var cuenta = CloudStorageAccount.Parse(connectionString);
        //    var servicioCliente = cuenta.CreateCloudBlobClient();
        //    var contenedor = servicioCliente.GetContainerReference(nombreContenedor);

        //    var blobName = Path.GetFileName(ruta);
        //    var blob = contenedor.GetBlobReference(blobName);
        //    await blob.DeleteIfExistsAsync();
        //}

        //public async Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        //{
        //    var cuenta = CloudStorageAccount.Parse(connectionString);
        //    var servicioCliente = cuenta.CreateCloudBlobClient();
        //    var contenedor = servicioCliente.GetContainerReference(nombreContenedor);
        //    await contenedor.CreateIfNotExistsAsync();
        //    await contenedor.SetPermissionsAsync(new BlobContainerPermissions
        //    {
        //        PublicAccess = BlobContainerPublicAccessType.Blob
        //    });

        //    var nombreArchivo = $"{Guid.NewGuid()}.{extension}";
        //    var blob = contenedor.GetBlockBlobReference(nombreArchivo);
        //    await blob.UploadFromByteArrayAsync(contenido, 0, contenido.Length);
        //    blob.Properties.ContentType = "image/jpg";
        //    await blob.SetPropertiesAsync();
        //    return blob.Uri.ToString();
        //}

        //Task<string> IAlmacenadorDeArchivos.EditarArchivo(byte[] contenido, string extension, string nombreContenedor, string rutaArchivoActual)
        //{
        //    throw new System.NotImplementedException();
        //}

        //Task IAlmacenadorDeArchivos.EliminarArchivo(string ruta, string nombreContenedor)
        //{
        //    throw new System.NotImplementedException();
        //}

        //Task<string> IAlmacenadorDeArchivos.GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
