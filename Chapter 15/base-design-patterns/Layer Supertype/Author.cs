namespace LayerSupertype
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
    }
}
