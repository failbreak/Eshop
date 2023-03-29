namespace ServiceLayer
{
    public class FilterPage
    {


        public const int DefaultPageSize = 10;

        public int PageNum { get; set; }

        public int PageSize { get; set; } = DefaultPageSize;

        public int NumPages { get; private set; }

        public void SetupRestOfProducts<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
        }

    }
}