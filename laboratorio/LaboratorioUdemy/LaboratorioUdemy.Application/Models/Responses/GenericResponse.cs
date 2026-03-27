using LaboratorioUdemy.Shared.Helpers;

namespace LaboratorioUdemy.Application.Models.Responses
{
    public class GenericResponse<T>
    {
        public string Message { get; set; } = null!;
        public DateTime TimeStamp { get; set; } = DateTimeHelper.UtcNow();
        public T? Data { get; set; }
    }

    public class PagedResponse<T>
    {
        public string Message { get; set; } = null!;
        public DateTime TimeStamp { get; set; } = DateTimeHelper.UtcNow();
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<T> Data { get; set; } = new();
    }

}

