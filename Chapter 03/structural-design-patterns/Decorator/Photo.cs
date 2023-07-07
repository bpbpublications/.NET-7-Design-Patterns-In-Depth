using System.Drawing;

public interface IPhoto
{
    Bitmap GetPhoto();
}
public class Photo : IPhoto
{
    private readonly string filename;
    public Photo(string filename) => this.filename = filename;
    public Bitmap GetPhoto() => new(filename);
}
public abstract class PhotoDecoratorBase : IPhoto
{
    private readonly IPhoto _photo;
    public PhotoDecoratorBase(IPhoto photo) => _photo = photo;
    public virtual Bitmap GetPhoto() => _photo.GetPhoto();
}
public class WatermarkDecorator : PhotoDecoratorBase
{
    private readonly string text;
    public WatermarkDecorator(IPhoto photo, string text) : base(photo) => this.text = text;
    public override Bitmap GetPhoto()
    {
        var photo = base.GetPhoto();
        Graphics g = Graphics.FromImage(photo);
        g.DrawString(text, new Font("B Nazanin", 18), Brushes.Black, photo.Width / 2, photo.Height / 2);
        g.Save();
        return photo;
    }
}
public class BlackWhiteDecorator : PhotoDecoratorBase
{
    public BlackWhiteDecorator(IPhoto photo) : base(photo) { }
    public override Bitmap GetPhoto()
    {
        var photo = base.GetPhoto();
        /*
         * Convert photo to black and white here
         */
        return photo;
    }
}