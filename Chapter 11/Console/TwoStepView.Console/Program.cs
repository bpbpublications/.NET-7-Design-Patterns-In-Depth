
FirstStepAuthor firstStep = new();
firstStep.FirstStepTransformer();

Console.WriteLine(File.ReadAllText("TwoStepView\\logical.xml"));
Console.WriteLine("####");
SecondStepAuthor secondStep = new();
secondStep.SecondStepTransformer();

Console.WriteLine(File.ReadAllText("TwoStepView\\output.html"));

Console.ReadLine();