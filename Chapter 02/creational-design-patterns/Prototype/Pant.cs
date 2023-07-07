using System.Linq;

public class Cloth
{
    public string Color { get; set; }
}
public class PantRegistry
{
    public PantRegistry() => Pants = new System.Collections.Generic.List<IPant>();
    public System.Collections.Generic.List<IPant> Pants { get; private set; }
    public void Add(IPant obj) => Pants.Add(obj);
    public IPant GetByColor(string color) => Pants.OrderBy(x => System.Guid.NewGuid()).FirstOrDefault(x => x.ClothInfo.Color == color).DeepClone();
    public IPant GetByType(System.Type type) => Pants.OrderBy(x => System.Guid.NewGuid()).FirstOrDefault(x => x.GetType() == type).DeepClone();
}
public interface IPant
{
    public int Price { get; set; }
    public Cloth ClothInfo { get; set; }
    IPant Clone();
    IPant DeepClone();
}
public class FabricPant : IPant
{
    public int Price { get; set; }
    public Cloth ClothInfo { get; set; }

    public IPant Clone() => this.MemberwiseClone() as IPant;

    public IPant DeepClone()
    {
        FabricPant pant = this.MemberwiseClone() as FabricPant;
        pant.ClothInfo = new Cloth() { Color = this.ClothInfo.Color };
        return pant;
    }

    public override string ToString() => $"Hash: {this.GetHashCode()}, Type: {this.GetType().Name} Color: {this.ClothInfo.Color}, Price: {this.Price}";

}
public class CottonPant : IPant
{
    public int Price { get; set; }
    public Cloth ClothInfo { get; set; }

    public IPant Clone() => this.MemberwiseClone() as IPant;
    public IPant DeepClone()
    {
        CottonPant pant = this.MemberwiseClone() as CottonPant;
        pant.ClothInfo = new Cloth() { Color = this.ClothInfo.Color };
        return pant;
    }

    public override string ToString() => $"Hash: {this.GetHashCode()}, Type: {this.GetType().Name} Color: {this.ClothInfo.Color}, Price: {this.Price}";

}
public class JeanPant : IPant
{
    public int Price { get; set; }
    public Cloth ClothInfo { get; set; }
    public IPant Clone() => this.MemberwiseClone() as IPant;
    public IPant DeepClone()
    {
        JeanPant pant = this.MemberwiseClone() as JeanPant;
        pant.ClothInfo = new Cloth() { Color = this.ClothInfo.Color };
        return pant;
    }

    public override string ToString() => $"Hash: {this.GetHashCode()}, Type: {this.GetType().Name} Color: {this.ClothInfo.Color}, Price: {this.Price}";

}