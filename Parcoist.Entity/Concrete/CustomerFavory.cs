namespace Parcoist.UI.Entities
{
    public class CustomerFavory
    {
        public int CustomerFavoryID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public DateTime AddedDate { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
