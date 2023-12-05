namespace ShopAPI.Helpers
{
    public static class FormatDate
    {
        public static string StringifyDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
