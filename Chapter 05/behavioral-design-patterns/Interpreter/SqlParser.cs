using System;
using System.Linq;

namespace Sample
{
    public class Config
    {
        public void SomeMethod() => Console.WriteLine("I am SomeMethod");
        public void OtherMethod() => Console.WriteLine("I am OtherMethod");
    }
}

public class SqlContext
{
    public string Namespace { get; set; }
}
public interface ISqlExpression
{
    string Interpret(SqlContext context);
}
public class QueryExpression : ISqlExpression
{
    private readonly ISqlExpression selectExpression;
    private readonly ISqlExpression fromExpression;
    public QueryExpression(ISqlExpression selectExpression, ISqlExpression fromExpression)
    {
        this.selectExpression = selectExpression;
        this.fromExpression = fromExpression;
    }
    public string Interpret(SqlContext context)
    {
        var className = fromExpression.Interpret(context);
        var methods = selectExpression.Interpret(context);

        var targetType = this.GetType().Assembly.GetType($"{context.Namespace}.{className}");
        var targetObj = Activator.CreateInstance(targetType);
        var methodsList = targetType
            .GetMethods().Where(x => methods.Split(',').Select(c => c.Trim()).Contains(x.Name));
        foreach (var item in methodsList)
        {
            item.Invoke(targetObj, null);
        }
        return "Expression interpreted!";
    }
}
public class SelectExpression : ISqlExpression
{
    private readonly ISqlExpression expression;
    public SelectExpression(ISqlExpression expression) => this.expression = expression;
    public string Interpret(SqlContext context) => expression.Interpret(context);
}
public class FromExpression : ISqlExpression
{
    private readonly ISqlExpression expression;
    public FromExpression(ISqlExpression expression) => this.expression = expression;
    public string Interpret(SqlContext context) => expression.Interpret(context);
}
public class LiteralExpression : ISqlExpression
{
    private readonly string statement;
    public LiteralExpression(string statement) => this.statement = statement;
    public string Interpret(SqlContext context) => this.statement;
}
