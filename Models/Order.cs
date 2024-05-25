namespace FinalProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
