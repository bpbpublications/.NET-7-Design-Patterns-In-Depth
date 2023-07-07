public abstract class BaseEntity
{
    public Version Version { get; set; }
    protected BaseEntity(Version version) => this.Version = version;
}