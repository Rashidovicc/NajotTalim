namespace NajotTalim.Domain.Configurations
{
    public class PaginationParams
    {
        private const int MaxSize = 50;
        private int pageSize;

        public int PageSize { get => pageSize; set => pageSize = value > MaxSize ? MaxSize : value; }
        public int PageIndex { get; set; }
    }
}
