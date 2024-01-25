namespace BackendApi.Contracts.Budget
{
    public class CreateBudgetRequest
    {
        public DateTime StartsDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsersId { get; set; }
        public decimal Size { get; set; }
    }
}
