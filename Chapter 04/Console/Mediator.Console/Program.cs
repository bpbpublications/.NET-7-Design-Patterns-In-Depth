using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IChatroom room = new Chatroom();
            IParticipant p1 = new Participant("vahid", room);
            IParticipant p2 = new Participant("ali", room);
            IParticipant p3 = new Participant("reza", room);
            room.Login(p1);
            room.Login(p2);
            room.Login(p3);

            IParticipant sender = room.GetParticipant("vahid");
            IParticipant receiver = room.GetParticipant("ali");
            sender.Send(receiver.Name, "hello");

            room.Logout(p1);
            room.Logout(p2);
            room.Logout(p3);
            Console.Read();
        }
    }
}
