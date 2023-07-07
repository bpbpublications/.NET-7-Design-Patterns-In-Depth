public class Customer
{
    public int CustomerId { get; private set; }
    public string Name { get; private set; }
    public string MobileNumber { get; private set; }
    public Customer(int customerId, string name)
    {
        if (customerId <= 0)
            throw new ArgumentException("شناسه مشتری نامعتبر است");
        CustomerId = customerId;

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("نام مشتری الزامی است");
        Name = name;
    }
    public Customer(int customerId, string name, string mobileNumber) : this(customerId, name)
    {
        if (string.IsNullOrWhiteSpace(mobileNumber))
            throw new ArgumentException("ورود شماره تلفن همراه الزامی است");
        if (mobileNumber.Length > 11 && mobileNumber.Length < 10)
            throw new ArgumentException("شماره تلفن همراه حداکثر بایستی 11 و حداقل 10 رقم باشد");
        if (int.TryParse(mobileNumber, out _))
            throw new ArgumentException("شماره تلفن همراه بایستی فقط شامل اعداد باشد");
        MobileNumber = mobileNumber;
    }
    public string GetMobileNumber()
    {
        if (string.IsNullOrWhiteSpace(MobileNumber))
            return string.Empty;
        string maskedMobileNumber;
        if (MobileNumber.Length == 10)
            maskedMobileNumber = "0" + MobileNumber;
        else
            maskedMobileNumber = MobileNumber;

        maskedMobileNumber = string.Concat(maskedMobileNumber.AsSpan()[..4], "***", maskedMobileNumber.AsSpan(7, 4));

        return maskedMobileNumber;
    }
}