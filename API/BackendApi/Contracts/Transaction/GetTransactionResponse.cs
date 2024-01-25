namespace BackendApi.Contracts.Transaction
{
    public class GetTransactionResponse
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int Income { get; set; }
        public int Expenses { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoriesId { get; set; }
    }
}
