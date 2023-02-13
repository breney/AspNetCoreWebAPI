namespace SmartSchool.WebAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime) 
        {
            int age = DateTime.UtcNow.Year - dateTime.Year;

            if (age < 0) age = 0;

            return age;
        } 

    }
}
