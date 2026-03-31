namespace LaboratorioUdemy.WebApi.Extensions
{
    public static class StringExtension
    {
        public static string ToUpperCreadorPorMi(this string str)
        {
            /*var parserd = new StringBuilder();

            foreach (var item in str.Split())
            {
                parsed.Append(item.ToUpper());
            }

            return parsed.ToString();*/
            return str.ToUpper();
        }
    }
}
