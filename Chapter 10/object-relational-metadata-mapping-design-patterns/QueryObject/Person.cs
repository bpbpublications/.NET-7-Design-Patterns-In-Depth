using System.Data;
using System.Text;

public class Criteria
{
    public string @Operator { get; set; }
    public string Property { get; set; }
    public object Value { get; set; }
    public Criteria(string @operator, string property, object value)
    {
        Operator = @operator;
        Property = property;
        Value = value;
    }
    public static Criteria GreaterThan(string property, int value) => new(" > ", property, value);
    public string GenerateTSQL(PersonMapper mapper)
    {
        var columnMap = mapper.DataMap.ColumnMaps.FirstOrDefault(x => x.PropertyName == Property);
        return $"{columnMap.ColumnName} {Operator} {Value}";
    }
}
public class QueryObject
{
    public ICollection<Criteria> Criterias { get; set; } = new List<Criteria>();
    private readonly PersonMapper mapper;
    public QueryObject() => mapper = new PersonMapper();
    public IDataReader Execute() => mapper.FindByWhere(GenerateWhereClause());
    public string GenerateWhereClause()
    {
        StringBuilder sb = new();
        foreach (var item in Criterias)
        {
            if (sb.Length > 0)
            {
                sb.Append(" AND ");
            }
            sb.Append(item.GenerateTSQL(mapper));
        }

        return sb.ToString();
    }
}