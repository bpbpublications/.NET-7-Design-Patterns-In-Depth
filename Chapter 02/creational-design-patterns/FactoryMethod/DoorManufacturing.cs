using System;


public abstract class Door
{
    public abstract void Design();
    public abstract void Build();
    public abstract void Coloring();
}
public class WoodenDoor : Door
{
    public override void Design()
    {
        Console.WriteLine("Wooden door design done");
    }
    public override void Build()
    {
        Console.WriteLine("Wooden door build done");
    }
    public override void Coloring()
    {
        Console.WriteLine("Wooden door coloring done");
    }
}

public abstract class DoorManufacturer
{
    public void CreateDoor()
    {
        Door door = this.GetDoor();
        door.Design();
        door.Build();
        door.Coloring();
        Console.WriteLine("Your door is ready!");
    }

    public abstract Door GetDoor();
}
public class Carpenter : DoorManufacturer
{
    public override Door GetDoor()
    {
        return new WoodenDoor();
    }
}
public class StarndardDoorManufacturer<T> : DoorManufacturer where T : Door, new()
{
    public override Door GetDoor()
    {
        return new T();
    }
}
