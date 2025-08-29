namespace Parcoist.Entity.Concrete
{
    public class Logo
    {
        public int LogoID { get; set; }
        public string LogoImage { get; set; }
        public string LogoTitle { get; set; }
        public string LogoLink { get; set; }
        //public DateTime LogoDate { get; set; }
        public bool LogoStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
