using System;
using System.Collections.Generic;

public interface ITree
{
    void Draw(ITree tree);
}
public class TreeType : ITree
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public string Size { get; private set; }
    public TreeType(string name, string color, string size)
    {
        Name = name;
        Color = color;
        Size = size;
    }
    public void Draw(ITree tree)
    {
        var obj = (Tree)tree;
        Console.WriteLine($"TreeType:{GetHashCode()},{Name},Tree:{obj.GetHashCode()}({obj.Coord_X},{obj.Coord_Y})");
    }
}
public class Tree : ITree
{
    public int Coord_X { get; private set; }
    public int Coord_Y { get; private set; }
    public TreeType Type { get; }
    public Tree(TreeType type, int coord_x, int coord_y)
    {
        this.Coord_X = coord_x;
        this.Coord_Y = coord_y;
        this.Type = type;
    }
    public void Draw(ITree tree) => this.Type.Draw(this);
}
public class TreeFactory
{
    readonly Dictionary<string, TreeType> _cache = new();
    public TreeType this[string name, string color, string size]
    {
        get
        {
            TreeType tree;
            string key = $"{name}_{color}_{size}";
            if (_cache.ContainsKey(key))
                tree = _cache[key];
            else
            {
                tree = new TreeType(name, color, size);
                _cache.Add(key, tree);
            }
            return tree;
        }
    }
}