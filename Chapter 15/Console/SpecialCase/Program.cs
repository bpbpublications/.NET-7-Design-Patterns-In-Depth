var searchResult = new AuthorRepository().Find(3);
if (searchResult is AuthorNotFound)
{
    Console.WriteLine("Author not found!");
}
else
{
    Console.WriteLine(searchResult.LastName);
}

Console.ReadLine();