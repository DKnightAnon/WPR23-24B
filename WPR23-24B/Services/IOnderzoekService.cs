using WPR23_24B.Models.Onderzoek;

namespace WPR23_24B.Services
{
    public interface IOnderzoekService
    {
        Onderzoek GetOnderzoekById(int onderzoekId);
        IEnumerable<Onderzoek> GetAllOnderzoeken();

        // TODO: 
        // Verdere implementatie van de interface 
    }
}