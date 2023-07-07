using System;
using System.Collections.Generic;

public interface IChatroom
{
    void Login(IParticipant participant);
    void Send(string from, string to, string message);
    void Logout(IParticipant participant);
    IParticipant GetParticipant(string name);
}
public class Chatroom : IChatroom
{
    Dictionary<string, IParticipant> participants = new();
    public void Login(IParticipant participant)
    {
        if (!participants.ContainsKey(participant.Name))
            participants.Add(participant.Name, participant);
    }

    public void Logout(IParticipant participant)
    {
        if (participants.ContainsKey(participant.Name))
            participants.Remove(participant.Name);
    }

    public void Send(string from, string to, string message)
    {
        IParticipant receiver = participants[to];
        if (receiver != null)
            receiver.Receive(from, message);
        else
            throw new Exception("Invalid participant");
    }

    public IParticipant GetParticipant(string name) => participants.ContainsKey(name) ? participants[name] : null;
}
public interface IParticipant
{
    public string Name { get; set; }
    void Send(string to, string message);
    void Receive(string from, string message);
}
public class Participant : IParticipant
{
    private readonly IChatroom room;
    public string Name { get; set; }
    public Participant(string name, IChatroom room)
    {
        this.Name = name;
        this.room = room;
    }
    public void Receive(string from, string message) => Console.WriteLine($"Sender: {from}, To: {Name},  Message: {message}");
    public void Send(string to, string message) => room.Send(Name, to, message);
}