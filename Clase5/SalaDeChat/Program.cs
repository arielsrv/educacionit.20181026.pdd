using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Participant Juan = new Participant("Juan");
            Participant Maria = new Participant("Maria");

            ChatRoom chatRoom = new ChatRoom();
            chatRoom.Register(Juan);
            chatRoom.Register(Maria);

            Juan.Send("Hola, ¿cómo estás", "Maria");
            Maria.Send("Todo bien y vos?", "Juan");
        }
    }

    class ChatRoom
    {
        Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public void Register(Participant participant)
        {
            participant.SetChatRoom(this);
            participants.Add(participant.GetName(), participant);
        }

        public void Send(string from, string to, string message)
        {
            Participant participant = participants[to];

            participant.Receive(from, message);
        }
    }

    class Participant
    {
        private string name;
        private ChatRoom chatRoom;       

        public Participant(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
        
        public void SetChatRoom(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
        }

        public void Send(string message, string to)
        {
            chatRoom.Send(this.name, to, message);
        }

        public void Receive(string from, string message)
        {
            Console.WriteLine($"{from} says: {message}");
        }
    }
}
