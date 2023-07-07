using System;
using System.Collections.Generic;
using System.Text;
public interface IMenuComponent
{
    public string Text { get; set; }
    public string Url { get; set; }
    string Print();
}
public class Menu : IMenuComponent
{
    public string Text { get; set; }
    public string Url { get; set; }
    public List<IMenuComponent> Children { get; set; }
    public string Print()
    {
        StringBuilder sb = new();
        sb.Append($"Root: {Text}");
        sb.Append(Environment.NewLine);
        foreach (var child in Children)
        {
            sb.Append($"Parent: {Text}, Child: {child.Print()}");
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }
}
public class MenuItem : IMenuComponent
{
    public string Text { get; set; }
    public string Url { get; set; }
    public string Print() => $"{Text}";
}
