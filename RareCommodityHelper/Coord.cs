public class Coords {
    public float X = 0.0f;
    public float Y = 0.0f;
    public float Z = 0.0f;

    public static Coords operator -(Coords a, Coords b)
    {
        Coords ret = new Coords();
        ret.X = a.X - b.X;
        ret.Y = a.Y - b.Y;
        ret.Z = a.Z - b.Z;
        return ret;
    }

    public static Coords operator +(Coords a, Coords b)
    {
        Coords ret = new Coords();
        ret.X = a.X + b.X;
        ret.Y = a.Y + b.Y;
        ret.Z = a.Z + b.Z;
        return ret;
    }

    public static Coords operator /(Coords a, float b)
    {
        Coords ret = new Coords();
        ret.X = a.X / b;
        ret.Y = a.Y / b;
        ret.Z = a.Z / b;
        return ret;
    }

    public static Coords operator *(Coords a, float b)
    {
        Coords ret = new Coords();
        ret.X = a.X * b;
        ret.Y = a.Y * b;
        ret.Z = a.Z * b;
        return ret;
    }

    public float Magnitude()
    {
        return (float)System.Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
    }

    public Coords Normal()
    {
        Coords ret = new Coords();
        float mag = Magnitude();
        ret.X = X / mag;
        ret.Y = Y / mag;
        ret.Z = Z / mag;
        return ret;
    }

    public float Distance(Coords other)
    {
        return (float)System.Math.Sqrt(DistanceSquared(other));
    }

    public float DistanceSquared(Coords other)
    {
        float xDiff = this.X - other.X,
              yDiff = this.Y - other.Y,
              zDiff = this.Z - other.Z;
        return (xDiff * xDiff) + (yDiff * yDiff) + (zDiff * zDiff);
    }
}
