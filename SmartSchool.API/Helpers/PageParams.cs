namespace SmartSchool.WebAPI.Helpers
{
    public class PageParams
    {
        private const int MaxPageSize = 50;

        private int defaultPageSize = 10;

        public int PageNumber { get; set; }
        
        public int PageSize 
        { 
            get { return defaultPageSize; } 
            set { defaultPageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
        }
    }
}
