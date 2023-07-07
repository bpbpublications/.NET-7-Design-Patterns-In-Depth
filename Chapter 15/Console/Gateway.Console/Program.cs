var result = await WebAPIGateway.GetDataAsync("https://jsonplaceholder.typicode.com/posts");
Console.WriteLine(result);

Console.ReadLine();