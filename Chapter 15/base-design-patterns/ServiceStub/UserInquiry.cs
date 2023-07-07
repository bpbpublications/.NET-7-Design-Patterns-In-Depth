public class UserInformation
{
    public string NationalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
}

public interface IInquiryService
{
    static IInquiryService InquiryService { get; set; }
    UserInformation Inquiry(string nationalCode);
}
public class InquiryService : IInquiryService
{
    public UserInformation Inquiry(string nationalCode) => throw new NotImplementedException();
}
public class InquiryServiceStub : IInquiryService
{
    public UserInformation Inquiry(string nationalCode)
    {
        return new UserInformation()
        {
            NationalCode = nationalCode,
            FirstName = "Vahid",
            LastName = "Farahmandian",
            DoB = new DateTime(1989, 09, 07)
        };
    }
}