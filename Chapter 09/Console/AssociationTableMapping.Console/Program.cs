using AssociationTableMapping;

var objBook1 = new Book()
{
    BookId = 1,
    Title = "Design Patterns in .NET",
    PublishDate = new DateOnly(2021, 10, 01)
};
var objBook2 = new Book()
{
    BookId = 2,
    Title = "Programming in C#",
    PublishDate = new DateOnly(2022, 05, 01)
};
var objAuthor1 = new Author()
{
    AuthorId = 1001,
    FirstName = "Vahid",
    LastName = "Farahmandian"
};
var objAuthor2 = new Author()
{
    AuthorId = 1002,
    FirstName = "David",
    LastName = "Brown"
};

objBook1.Authors.Add(objAuthor1);
objBook2.Authors.Add(objAuthor1);
objBook2.Authors.Add(objAuthor2);

Console.ReadLine();