namespace TalentInsights.Application.Models.Response
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public DateTime TimeStamp { get; } = DateTimeOffset.UtcNow.DateTime;
        public T Data { get; set; }

        public string Cliente { get; set; }

        /*public Z OtroGeneric<Z>(Z data)
        {
            return data;
        }*/
    }
}
