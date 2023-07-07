IInquiryService.InquiryService = new InquiryServiceStub();

var result = IInquiryService.InquiryService.Inquiry("2740076223");

Console.WriteLine($"{result.FirstName} {result.LastName} {result.NationalCode}");

Console.ReadLine();