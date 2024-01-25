namespace BackendApi.Contracts.Budget
{
    public class GetBudgetResponse
    {
        public int Id { get; set; }
        public DateTime StartsDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsersId { get; set; }
        public decimal Size { get; set; }
    }
}
