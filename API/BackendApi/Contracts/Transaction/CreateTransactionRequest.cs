namespace BackendApi.Contracts.Transaction
{
    public class CreateTransactionRequest
    {
        public int UsersId { get; set; }
        public int Income { get; set; }
        public int Expenses { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoriesId { get; set; }
    }
}
