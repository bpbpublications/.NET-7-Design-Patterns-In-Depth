public class UnitOfWork
{
    List<DomainObject> modifiedObjects;
    public void Commit()
    {
        foreach (var item in modifiedObjects)
        {
            item.Parent?.Version.Increment();
        }
        foreach (var item in modifiedObjects)
        {
            //save changes to database
        }
    }
}