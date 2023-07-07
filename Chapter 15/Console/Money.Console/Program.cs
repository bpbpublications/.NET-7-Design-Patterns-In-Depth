
Money first = new(2, 50, Currency.Dollar);
Console.WriteLine("NEW");
Console.WriteLine(first.Amount);
Console.WriteLine(first.Fraction);

Money second = new(3, 60, Currency.Dollar);
first.Add(second);
Console.WriteLine("ADD");
Console.WriteLine(first.Amount);
Console.WriteLine(first.Fraction);

first.Subtract(new Money(10, 5, Currency.Dollar));
Console.WriteLine("SUBTRACT");
Console.WriteLine(first.Amount);
Console.WriteLine(first.Fraction);

first.Multiply(1.5);
Console.WriteLine("MULTIPLY");
Console.WriteLine(first.Amount);
Console.WriteLine(first.Fraction);

Console.WriteLine(first.Equals(second));
Console.WriteLine(first == second);
Console.WriteLine(first != second);
Console.WriteLine(first > second);
Console.WriteLine(first < second);
Console.WriteLine(first >= second);
Console.WriteLine(first <= second);

Console.ReadLine();