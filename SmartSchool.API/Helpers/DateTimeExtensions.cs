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

        public static DateTime GetDateBirthByAge(this int age)
        {
            if(age < 0) age = 0;

            return DateTime.Now.AddYears(-age);
        }

    }
}
