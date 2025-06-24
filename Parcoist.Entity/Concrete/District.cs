namespace Parcoist.UI.Entities
{
    public class District
    {
        public int DistrictID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }

        public City City { get; set; }
        public List<Adress> Adresses { get; set; }
    }

}
