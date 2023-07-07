public interface IMapper
{
    DomainObject Find(int id);
    void Insert(DomainObject obj);
    void Update(DomainObject obj);
    void Delete(DomainObject obj);
}
public class LockingMapper : IMapper
{
    private readonly IMapper _mapper;
    public LockingMapper(IMapper mapper) => _mapper = mapper;
    public DomainObject Find(int id)
    {
        //Acquire lock
        return _mapper.Find(id);
    }
    public void Delete(DomainObject obj) => _mapper.Delete(obj);

    public void Insert(DomainObject obj) => _mapper.Insert(obj);

    public void Update(DomainObject obj) => _mapper.Update(obj);
}