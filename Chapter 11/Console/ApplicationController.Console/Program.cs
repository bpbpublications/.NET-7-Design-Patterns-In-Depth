
FrontController controller = new();
controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=1&date=20220101#return"));
Console.WriteLine("+++++++++++++++++++++++++++++");
controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=2&date=20220101#return"));
Console.WriteLine("+++++++++++++++++++++++++++++");
controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=1&date=20220101#damage"));
Console.WriteLine("+++++++++++++++++++++++++++++");
controller.ReceiveRequest(new Uri("http://abc.com/leasing?model=bmw&state=2&date=20220101#damage"));

Console.ReadLine();