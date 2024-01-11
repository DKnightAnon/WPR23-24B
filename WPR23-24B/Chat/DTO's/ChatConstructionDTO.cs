using WPR23_24B.Chat.Models;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Models.Authenticatie.DTOs;


namespace WPR23_24B.Chat.DTO_s
{





    /// <summary>
    /// DTO Model class to be used for inserting a new <see cref="ChatRoom"/> into the database, including two <see cref="Gebruiker"/>s .
    /// </summary>
    public class ChatConstructionDTO
    {



        public ChatRoom ChatRoom { get; set; }

        public GebruikerDTO Ervaringsdeskundige {  get; set; }
        
        public GebruikerDTO Bedrijf_ContactPersoon { get; set; }





    }
}
