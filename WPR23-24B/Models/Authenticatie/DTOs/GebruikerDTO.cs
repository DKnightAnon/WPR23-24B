namespace WPR23_24B.Models.Authenticatie.DTOs
{
    public class GebruikerDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            if(UserName == "") { UserName = "UserName was an empty string!"; }
            if (Id == "") { UserName = "Id was an empty string!"; }
            return new string($"{UserName ?? "UserName field is empty!"}|{Id ?? "Id field is empty!"}");
        }
    }
}
