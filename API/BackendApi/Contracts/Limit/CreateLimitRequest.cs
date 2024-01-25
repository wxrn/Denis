namespace BackendApi.Contracts.Limit
{
    public class CreateLimitRequest
    {
        public int Type { get; set; }
        public int UsersId { get; set; }
        public string Names { get; set; } = null!;
        public decimal StartingBalance { get; set; }
        public DateTime DateOpened { get; set; }
        public int CategoriesId { get; set; }
    }
}
