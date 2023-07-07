public interface IRecruitmentCommand
{
    void Execute();
    void Undo();
}
public class CreateEmailCommand : IRecruitmentCommand
{
    EmployeeManager _employeeManager;
    public CreateEmailCommand(EmployeeManager employeeManager) => _employeeManager = employeeManager;
    public void Execute() => _employeeManager.CreateEmailAccount();
    public void Undo() => _employeeManager.UndoCreateEmailAccount();
}
public class DesignIdentityCardCommand : IRecruitmentCommand
{
    EmployeeManager _employeeManager;
    public DesignIdentityCardCommand(EmployeeManager employeeManager) => _employeeManager = employeeManager;
    public void Execute() => _employeeManager.DesignIdentityCard();
    public void Undo() => _employeeManager.UndoDesignIdentityCard();
}
public class DesignVisitingCardCommand : IRecruitmentCommand
{
    EmployeeManager _employeeManager;
    public DesignVisitingCardCommand(EmployeeManager employeeManager) => _employeeManager = employeeManager;
    public void Execute() => _employeeManager.DesignVisitingCard();
    public void Undo() => _employeeManager.UndoDesignVisitingCard();
}
public class EmployeeManager
{
    public EmployeeManager(int employeeId) { }
    public void CreateEmailAccount() { }
    public void UndoCreateEmailAccount() { }
    public void DesignIdentityCard() { }
    public void UndoDesignIdentityCard() { }
    public void DesignVisitingCard() { }
    public void UndoDesignVisitingCard() { }
}

public class Recruitment
{
    public System.Collections.Generic.List<IRecruitmentCommand> Commands { get; set; } = new System.Collections.Generic.List<IRecruitmentCommand>();
    public void Invoke()
    {
        try
        {
            foreach (var command in Commands)
                command.Execute();
        }
        catch
        {
            foreach (var command in Commands)
                command.Undo();
        }
    }
}