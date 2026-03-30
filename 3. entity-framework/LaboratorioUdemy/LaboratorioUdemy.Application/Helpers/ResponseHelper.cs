using LaboratorioUdemy.Application.Models.Responses;

namespace LaboratorioUdemy.Application.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud realizada correctamente")
        {
            var response = new GenericResponse<T>
            {
                Data = data,
                Message = message,
            };

            return response;
        }

        public static PagedResponse<T> CreatePaged<T>(List<T> data, int total, int limit, int offset, string message = "Solicitud realizada correctamente")
        {
            var response = new PagedResponse<T>
            {
                Data = data,
                Total = total,
                Limit = limit,
                Offset = offset,
                Message = message
            };

            return response;
        }
    }
}
