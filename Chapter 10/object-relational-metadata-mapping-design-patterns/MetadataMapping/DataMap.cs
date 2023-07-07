using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
public class DataMap
{
    public Type DomainClass { get; set; }
    public string TableName { get; set; }
    public ICollection<ColumnMap> ColumnMaps { get; set; }
    public DataMap(Type domainClass, string tableName)
    {
        DomainClass = domainClass;
        TableName = tableName;
        ColumnMaps = new List<ColumnMap>();
    }
    public string? GetKeyColumn() => ColumnMaps.FirstOrDefault(x => x.IsKey)?.ColumnName;
    public string GetColumns()
    {
        StringBuilder sb = new();
        if (ColumnMaps.Any())
            sb.Append(ColumnMaps.First().ColumnName);
        foreach (var column in ColumnMaps.Skip(1))
        {
            sb.Append($",{column.ColumnName}");
        }
        return sb.ToString();
    }
}
public class ColumnMap
{
    public string ColumnName { get; }
    public string PropertyName { get; }
    public bool IsKey { get; }

    [JsonIgnore]
    public PropertyInfo Property { get; private set; }

    [JsonIgnore]
    public DataMap DataMap { get; }
    public ColumnMap(string columnName, string propertyName, DataMap dataMap, bool isKey = false)
    {
        DataMap = dataMap;
        ColumnName = columnName;
        PropertyName = propertyName;
        IsKey = isKey;
        Property = DataMap.DomainClass.GetProperty(PropertyName);
    }
    public void SetValue(object obj, object columnValue) => Property.SetValue(obj, columnValue);
    public object GetValue(object obj) => Property.GetValue(obj);
}
public abstract class Mapper<TKey>
{
    public DataMap DataMap { get; protected set; }
    public object Find(TKey key)
    {
        string query = $"" +
            $"SELECT {DataMap.GetColumns()} " +
            $"FROM {DataMap.TableName} " +
            $"WHERE {DataMap.GetKeyColumn()} = {key}";
        SqlConnection sqlConnection = new("Data Source = .;Initial Catalog=Test;Integrated Security = true");
        sqlConnection.Open();
        var reader = new SqlCommand(query, sqlConnection).ExecuteReader();
        reader.Read();
        var result = Load(reader);
        return result;
    }
    public object Load(IDataReader reader)
    {
        var obj = Activator.CreateInstance(DataMap.DomainClass);
        LoadProperties(reader, obj);
        return obj;
    }
    private void LoadProperties(IDataReader reader, object obj)
    {
        foreach (var item in DataMap.ColumnMaps)
        {
            item.SetValue(obj, reader[item.ColumnName]);
        }
    }
    public IDataReader FindByWhere(string where)
    {
        string query = $"" +
                        $"SELECT {DataMap.GetColumns()} " +
                        $"FROM {DataMap.TableName} " +
                        $"WHERE {where}";
        return new SqlCommand(query, DB.Connection).ExecuteReader();
    }
}
public class PersonMapper : Mapper<int>
{
    public PersonMapper() => LoadDataMap();
    protected void LoadDataMap()
    {
        DataMap = new DataMap(typeof(Person), "people");
        DataMap.ColumnMaps.Add(new("personId", nameof(Person.PersonId), DataMap, isKey: true));
        DataMap.ColumnMaps.Add(new("firstName", nameof(Person.FirstName), DataMap));
        DataMap.ColumnMaps.Add(new("lastName", nameof(Person.LastName), DataMap));
        DataMap.ColumnMaps.Add(new("age", nameof(Person.Age), DataMap));
    }
    public string GetMetadata()
    {
        return JsonConvert.SerializeObject(DataMap, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
    }
    public Person Get(int personId) => (Person)Find(personId);
}
public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
public class Car
{
    public int CarId { get; set; }
    public string Name { get; set; }
}