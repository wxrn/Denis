namespace BackendApi.Contracts.Operation
{
    public class CreateOperationRequest
    {
        public int UsersId { get; set; }
        public string Type { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public decimal Sums { get; set; }
        public string Comment { get; set; } = null!;
        public int CategoriesId { get; set; }
    } 
}
