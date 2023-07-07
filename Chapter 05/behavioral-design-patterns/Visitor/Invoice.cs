using System.Collections.Generic;
using System.Linq;

public class Invoice
{
    private readonly ILoyalityVisitor visitor;
    public Invoice(ILoyalityVisitor visitor) => this.visitor = visitor;
    public List<IInvoiceItems> Items { get; set; } = new List<IInvoiceItems>();
    public double Calculate() => Items.Sum(x => x.Accept(visitor));
}
public interface IInvoiceItems
{
    public double Cost { get; set; }
    double Accept(ILoyalityVisitor visitor);
}
public class Food : IInvoiceItems
{
    public double Cost { get; set; }
    public double Accept(ILoyalityVisitor visitor) => visitor.VisitFoods(this);
}
public class Cosmetics : IInvoiceItems
{
    public double Cost { get; set; }
    public double Accept(ILoyalityVisitor visitor) => visitor.VisitCosmetics(this);
}
public class HomeAppliances : IInvoiceItems
{
    public double Cost { get; set; }
    public double Accept(ILoyalityVisitor visitor) => visitor.VisitHomeAppliances(this);
}
public interface ILoyalityVisitor
{
    double VisitFoods(Food item);
    double VisitCosmetics(Cosmetics item);
    double VisitHomeAppliances(HomeAppliances item);
}
public class GoldenUsersVisitor : ILoyalityVisitor
{
    public double VisitCosmetics(Cosmetics item) => item.Cost * 0.9;
    public double VisitFoods(Food item) => item.Cost * 0.8;
    public double VisitHomeAppliances(HomeAppliances item) => item.Cost * 0.9;
}
public class SilverUsersVisitor : ILoyalityVisitor
{
    public double VisitCosmetics(Cosmetics item) => item.Cost * 0.95;
    public double VisitFoods(Food item) => item.Cost * 0.9;
    public double VisitHomeAppliances(HomeAppliances item) => item.Cost * 0.95;
}