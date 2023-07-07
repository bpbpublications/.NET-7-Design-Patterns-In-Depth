public class CellPhone
{
    public string CameraResolution { get; set; }
    public string MonitorSize { get; set; }
    public string BodyMaterial { get; set; }
    public string OSName { get; set; }
}
public interface ICellPhoneBuilder
{
    public CellPhone Phone { get; }
    void BuildMonitor();
    void BuildBody();
    void BuildCamera();
    void PrepareOS();
}

public class Apple : ICellPhoneBuilder
{
    public CellPhone Phone { get; private set; }
    public Apple() => Phone = new CellPhone();
    public void BuildBody() => Phone.BodyMaterial = "Titanium";
    public void BuildCamera() => Phone.CameraResolution = "10 MP";
    public void BuildMonitor() => Phone.MonitorSize = "10 Inch";
    public void PrepareOS() => Phone.OSName = "iOS";
}
public class Samsung : ICellPhoneBuilder
{
    public CellPhone Phone { get; private set; }
    public Samsung() => Phone = new CellPhone();
    public void BuildBody() => Phone.BodyMaterial = "Aluminum";
    public void BuildCamera() => Phone.CameraResolution = "12 MP";
    public void BuildMonitor() => Phone.MonitorSize = "9.8 Inch";
    public void PrepareOS() => Phone.OSName = "Android 10";
}
public class CellPhoneDirector
{
    private ICellPhoneBuilder builder;
    public CellPhoneDirector(ICellPhoneBuilder builder) => this.builder = builder;

    public CellPhone Construct()
    {
        builder.BuildBody();
        builder.BuildMonitor();
        builder.BuildCamera();
        builder.PrepareOS();
        return builder.Phone;
    }
}