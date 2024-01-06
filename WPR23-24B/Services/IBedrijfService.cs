using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Services
{
    public interface IBedrijfService
    {
        Bedrijf GetBedrijfById(int bedrijfId);
        IEnumerable<Bedrijf> GetAllBedrijven();

        // TODO: 
        // Verdere implementatie van de interface 
    }
}