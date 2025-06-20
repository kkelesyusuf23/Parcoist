using Parcoist.UI.Entities;

public class Adress
{
    public int AdressID { get; set; }
    public string Title { get; set; }

    public int CityID { get; set; }
    public City City { get; set; }

    public int DistrictID { get; set; }
    public District District { get; set; }


    public string Street { get; set; }
    public string Neighbourhood { get; set; }
    public string AddressText { get; set; }

    public int CustomerID { get; set; }
    public Customer Customer { get; set; }

    public bool PostalCode { get; set; }
    public string RecipientName { get; set; }
    public bool IsDefault { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
