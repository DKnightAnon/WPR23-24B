﻿using WPR23_24B.Models.Authenticatie;

namespace WPR23_24B.Chat.Models
{
    public class ChatDeelnemer
    {

        public Gebruiker Deelnemer { get; set; }
        public ChatRoom Gesprek { get; set; }
    }
}