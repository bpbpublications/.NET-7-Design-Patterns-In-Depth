using System.Data;

public class DbManager
{
    protected DataTable dt;
    protected DbManager(DataSet ds, string tableName)
    {
        if (ds.Tables.Count == 0)
        {
            DataTable employees = new DataTable("employees");
            employees.Columns.Add("Id", typeof(int));
            employees.Columns.Add("Position", typeof(string));

            employees.Rows.Add(1, "CEO");
            employees.Rows.Add(2, "CTO");

            ds.Tables.Add(employees);
        }
        dt = ds.Tables[tableName];
    }
}
public class RollCall : DbManager
{
    public RollCall(DataSet ds) : base(ds, "rollcalls") { }
    public double GetWorkingHoursSummary(int employeeId)
    {
        if (employeeId == 1) return 100;
        else throw new ArgumentException("Employee not found.");
    }
}
public class Employee : DbManager
{
    public Employee(DataSet ds) : base(ds, "employees") { }

    public DataRow this[int employeeId] => dt.Select($"Id = {employeeId}")[0];

    public double CalculateWorkingHours(int employeeId)
    {
        var employee = this[employeeId];
        var workingHours = new RollCall(dt.DataSet).GetWorkingHoursSummary(employeeId);
        if (employee["Position"] == "CEO")
            workingHours *= 1.2;
        return workingHours;
    }
}