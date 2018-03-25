namespace WinterWood.Web.ViewModel
{
    public class PageInvoices
    {
        const int MaxPageSize = 55;

        public int PageNumber { get; set; } = 1;

        public int pageSize { get; set; } = 12;

        public int PageSize
        {

            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Search { get; set; }

    }
}