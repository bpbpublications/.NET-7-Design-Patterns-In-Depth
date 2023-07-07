
PersonMapper mapper = new();
string metadata = mapper.GetMetadata();
Console.WriteLine(metadata);
object result = mapper.Find(1);

Console.ReadLine();