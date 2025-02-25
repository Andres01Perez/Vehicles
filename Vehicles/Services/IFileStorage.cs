﻿namespace Vehicles.Services
{
    public interface IFileStorage
    {
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contentType);
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> GuardarArchivo(string contenedor, IFormFile foto);
    }
}
