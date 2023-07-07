

var authorBooks = Registry.BookFinder().GetAuthorBooks(1);

foreach (var authorBook in authorBooks)
    Console.WriteLine(authorBook.Title);

Console.WriteLine("################");
Registry.InitializeStub();
var authorBooksFromStub = ((BookFinderStub)Registry.BookFinder()).GetAuthorBooks(1);
foreach (var authorBook in authorBooksFromStub)
    Console.WriteLine(authorBook.Title);
Console.ReadLine();
