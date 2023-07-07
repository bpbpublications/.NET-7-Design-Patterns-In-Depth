
public enum Currency
{
    Rial,
    Dollar
}
public class Money
{
    public int Amount { get; private set; }
    public int Fraction { get; private set; }
    public Currency Currency { get; private set; }
    public Money(int amount, int fraction, Currency currency)
    {
        Currency = currency;
        (int NewAmount, int NewFraction) = NormalizeValues(amount, fraction);
        Amount = NewAmount;
        Fraction = NewFraction;
    }
    private (int NewAmount, int NewFraction) NormalizeValues(int amount, int fraction) => NormalizeValues((double)amount, (double)fraction);
    private (int NewAmount, int NewFraction) NormalizeValues(double amount, double fraction)
    {
        if (Currency == Currency.Rial)
            fraction = 0;
        else if (Currency == Currency.Dollar)
        {
            double totalCents = amount * 100 + fraction;
            amount = totalCents / 100;
            fraction = totalCents % 100;
        }
        return ((int)amount, (int)fraction);
    }

    public void Add(Money other)
    {
        if (Currency == other.Currency)
        {
            int a = Amount + other.Amount;
            int f = Fraction + other.Fraction;
            (int NewAmount, int NewFraction) = NormalizeValues(a, f);
            Amount = NewAmount;
            Fraction = NewFraction;
        }
        else throw new Exception("Unequal currencies");
    }
    public void Subtract(Money other)
    {
        if (Currency == other.Currency)
        {
            int a = Amount - other.Amount;
            int f = Fraction - other.Fraction;
            (int NewAmount, int NewFraction) = NormalizeValues(a, f);
            Amount = NewAmount;
            Fraction = NewFraction;
        }
        else throw new Exception("Unequal currencies");
    }
    public void Multiply(double number)
    {
        number = Math.Round(number, 2);
        double a = Amount * number;
        double f = Math.Round(Fraction * number);
        (int NewAmount, int NewFraction) = NormalizeValues(a, f);
        Amount = NewAmount;
        Fraction = NewFraction;
    }


    public override bool Equals(object? other) => other is Money otherMoney && Equals(otherMoney);
    public bool Equals(Money other) => Currency.Equals(other.Currency) && Amount == other.Amount && Fraction == other.Fraction;
    public static bool operator ==(Money a, Money b) => a.Equals(b);
    public static bool operator !=(Money a, Money b) => !a.Equals(b);
    public static bool operator >(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            if (a.Amount > b.Amount) return true;
            else if (a.Amount == b.Amount && a.Fraction > b.Fraction) return true;
            else return false;
        }
        return false;
    }

    public static bool operator <(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            if (a.Amount < b.Amount) return true;
            else if (a.Amount == b.Amount && a.Fraction < b.Fraction) return true;
            else return false;
        }
        return false;
    }

    public static bool operator >=(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            if (a.Amount > b.Amount) return true;
            else if (a.Amount == b.Amount)
            {
                if (a.Fraction > b.Fraction || a.Fraction == b.Fraction) return true;
            }
            else return false;
        }
        return false;
    }

    public static bool operator <=(Money a, Money b)
    {
        if (a.Currency == b.Currency)
        {
            if (a.Amount < b.Amount) return true;
            else if (a.Amount == b.Amount)
            {
                if (a.Fraction < b.Fraction || a.Fraction == b.Fraction) return true;
            }
            else return false;
        }
        return false;
    }

    public override int GetHashCode()
        => Amount.GetHashCode() ^
        Fraction.GetHashCode() ^
        Currency.GetHashCode();
}