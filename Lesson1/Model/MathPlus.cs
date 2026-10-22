namespace Lesson1.Model;

public class MathPlus(int a, int b)
{
    public int A { get; set; } = a;
    public int B { get; set; } = b;

    public int Plus()
    {
        return A + B;
    }
}
