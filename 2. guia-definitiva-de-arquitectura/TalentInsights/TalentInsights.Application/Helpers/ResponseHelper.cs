using TalentInsights.Application.Models.Response;

namespace TalentInsights.Application.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud realzada correctamente")
        {
            var response = new GenericResponse<T>();
            response.Message = message;
            response.Data = data;

            return response;

        }

    }
}
