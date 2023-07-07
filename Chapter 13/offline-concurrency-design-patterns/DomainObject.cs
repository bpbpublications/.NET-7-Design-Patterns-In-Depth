public class DomainObject : BaseEntity
{
    public DomainObject(Version version) : base(version)
    {
    }
    public int Id { get; set; }
    public DomainObject Parent { get; set; }
}