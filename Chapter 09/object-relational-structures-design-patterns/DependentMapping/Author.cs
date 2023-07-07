namespace DependentMapping;

public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<ContactInfo> ContactInfo { get; set; }

    public void UpdateAuthor(Author author)
    {
        this.FirstName = author.FirstName;
        this.LastName = author.LastName;
        UpdateContactInfo(author);
    }

    public void UpdateContactInfo(Author author)
    {
        RemoveAllContactInfo();
        foreach (var item in author.ContactInfo)
        {
            AddContactInfo(item);
        }
    }
    public void AddContactInfo(ContactInfo contactInfo) => ContactInfo.Add(contactInfo);
    public void RemoveContactInfo(ContactInfo contactInfo) => ContactInfo.Remove(contactInfo);
    public void RemoveAllContactInfo() => ContactInfo.Clear();
}
public class ContactInfo
{
    public ContactType ContactType { get; set; }
    public string Value { get; set; }
}
public enum ContactType : short
{
    HomePhone,
    MobilePhone,
    HomeAddress,
    WorkAddress
}
