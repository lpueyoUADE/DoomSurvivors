using System;

public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2(float value)
    {
        this.x = value;
        this.y = value;
    }

    public static bool operator == (Vector2 a, Vector2 b)
    {
        return a.x == b.x && a.y == b.y;
    } 

    public static bool operator != (Vector2 a, Vector2 b)
    {
        return !(a == b);
    }

	public static Vector2 Zero => new Vector2(0, 0);

    public static Vector2 Distance (Vector2 a, Vector2 b)
    {
        var newX = a.x - b.x;
        var newY = a.y - b.y;

        newX = Math.Abs(newX);
        newY = Math.Abs(newY);
        return new Vector2(newX, newY);
    }
}