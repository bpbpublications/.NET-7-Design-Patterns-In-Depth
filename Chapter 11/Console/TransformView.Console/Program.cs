
using TransformView;

AuthorTransformer transformer = new AuthorTransformer();
var result = transformer.Transform(new DatabaseGateway().GetAuthors());
Console.WriteLine(result);
Console.ReadLine();