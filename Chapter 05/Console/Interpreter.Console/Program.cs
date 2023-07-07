using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string query = "Select SomeMethod, OtherMethod From Config";
            SqlContext context = new() { Namespace = "Sample" };
            var expressionParts = Regex.Split(query, " From ", RegexOptions.IgnoreCase).Select(x => x.Trim()).ToArray();
            LiteralExpression methodExpression = new(expressionParts[0][6..]);
            LiteralExpression classExpression = new(expressionParts[1]);
            SelectExpression selectExpression = new(methodExpression);
            FromExpression fromExpression = new(classExpression);
            QueryExpression queryExpression = new(selectExpression, fromExpression);
            Console.WriteLine(queryExpression.Interpret(context));
            Console.Read();
        }
    }
}
