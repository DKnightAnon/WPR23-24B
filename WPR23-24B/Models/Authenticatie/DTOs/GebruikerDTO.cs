namespace WPR23_24B.Models.Authenticatie.DTOs
{
    public class GebruikerDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return new string($"{UserName}");
        }
    }
}
