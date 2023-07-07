public class Publisher
{
    public string Title { get; set; }
    public List<Address> Addresses { get; set; } = new List<Address>();
}
public class Address
{
    public string City { get; private set; }
    public string MainStreet { get; private set; }
    public string SubStreet { get; private set; }
    public string Alley { get; private set; }
    public Address(string city, string mainStreet, string subStreet, string alley)
    {
        City = city;
        MainStreet = mainStreet;
        SubStreet = subStreet;
        Alley = alley;
    }

    public static bool operator ==(Address address1, Address address2) => address1.City == address2.City &&
            address1.MainStreet == address2.MainStreet &&
            address1.SubStreet == address2.SubStreet &&
            address1.Alley == address2.Alley;
    public static bool operator !=(Address address1, Address address2) => address1.City != address2.City ||
            address1.MainStreet != address2.MainStreet ||
            address1.SubStreet != address2.SubStreet ||
            address1.Alley != address2.Alley;
    public override int GetHashCode()
        => City.GetHashCode() ^
        MainStreet.GetHashCode() ^
        SubStreet.GetHashCode() ^
        Alley.GetHashCode();
}