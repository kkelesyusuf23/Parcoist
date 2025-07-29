namespace Parcoist.UI.Entities
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public string PlateCode { get; set; }

        public List<Adress> Adresses { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
