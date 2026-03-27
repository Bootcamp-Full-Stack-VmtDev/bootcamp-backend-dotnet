using LaboratorioUdemy.Shared.Helpers;
using System.Text.Json.Serialization;

namespace LaboratorioUdemy.Application.Models.Responses
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; } = DateTimeHelper.UtcNow();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Data { get; set; }
    }

    public class PagedResponse<T>
    {
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; } = DateTimeHelper.UtcNow();
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<T> Data { get; set; }
    }

}

