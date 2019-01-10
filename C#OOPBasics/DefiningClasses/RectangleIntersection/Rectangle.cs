public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;


    public string Id
    {
        get => id;
        set => id = value;
    }
    public double Width
    {
        get => width;
        set => width = value;
    }
    public double Height
    {
        get => height;
        set => height = value;
    }
    public double X
    {
        get => x;
        set => x = value;
    }
    public double Y
    {
        get => y;
        set => y = value;
    }

    public double X1
    {
        get => this.x + this.width;
    }
    public double Y1
    {
        get => this.y + this.height;
    }

    public bool CheckRectanglesForIntersect(Rectangle r)
    {
        bool isIntersect = 
            X <= r.X1 && 
            X1 >= r.X &&
            Y <= r.Y1 &&
            Y1 >= r.Y;

        return isIntersect;
    }
}