using System;

public interface ITikcetState
{
    void Process(TicketContext context);
}
public class AssignState : ITikcetState
{
    public void Process(TicketContext context)
    {
        Console.WriteLine("Ticket Assigned");
        context.State = new DoingState();
    }
}
public class DoingState : ITikcetState
{
    public void Process(TicketContext context)
    {
        Console.WriteLine("Ticket Done");
        context.State = new ApprovalState();
    }
}
public class ApprovalState : ITikcetState
{
    public void Process(TicketContext context)
    {
        Console.WriteLine("Ticket Approved");
        context.State = new ClosingState();
    }
}
public class ClosingState : ITikcetState
{
    public void Process(TicketContext context)
    {
        Console.WriteLine("Ticket Closed");
        context.State = new AssignState();
    }
}
public class TicketContext
{
    public ITikcetState State { get; set; }
    public TicketContext(ITikcetState state) => this.State = state;
    public void Process() => State.Process(this);
}
