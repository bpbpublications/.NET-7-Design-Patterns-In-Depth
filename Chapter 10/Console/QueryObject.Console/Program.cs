
QueryObject qb = new QueryObject();
qb.Criterias.Add(Criteria.GreaterThan(nameof(Person.Age), 33));
var result = qb.Execute();
Console.ReadLine();