namespace Parcoist.UI.Entities
{
    public class OrderBrandStatus
    {
        public int OrderBrandStatusID { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        public int TotalSales { get; set; }
        public int AvgOrderValue { get; set; }
    }

}
