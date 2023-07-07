using System.Xml.Xsl;

public class FirstStepAuthor
{
    public void FirstStepTransformer()
    {
        var myXslTrans = new XslCompiledTransform();
        myXslTrans.Load(@"TwoStepView\firststep-style.xslt");
        myXslTrans.Transform(@"TwoStepView\input.xml", @"TwoStepView\logical.xml");
    }
}
public class SecondStepAuthor
{
    public void SecondStepTransformer()
    {
        var myXslTrans = new XslCompiledTransform();
        myXslTrans.Load(@"TwoStepView\secondstep-style.xslt");
        myXslTrans.Transform(@"TwoStepView\logical.xml", @"TwoStepView\output.html");
    }
}