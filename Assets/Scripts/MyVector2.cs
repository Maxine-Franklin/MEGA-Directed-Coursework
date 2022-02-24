using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector2
{
    public float x, y;

    static MyVector2 Zero = new MyVector2(0, 0);

    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Adds together two MyVector2s
    /// </summary>
    /// <param name="a">A MyVector2 Parameter</param>
    /// <param name="b">A MyVector2 Parameter</param>
    /// <returns>The total of the inputted MyVector2s</returns>
    public static MyVector2 AddVector(MyVector2 a, MyVector2 b)
    {
        MyVector2 rv = Zero; //An empty Return Vector used to store the result of the inputted MyVector2s
        //Adds each parameter of the MyVector2s together and stores the result in the Return Vector
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Subtracts two MyVector2s
    /// </summary>
    /// <param name="startVector2">A MyVector2 Parameter</param>
    /// <param name="subVector2">A MyVector2 Parameter</param>
    /// <returns>The subtracted total of the inputted MyVector2s</returns>
    public static MyVector2 SubVector(MyVector2 startVector2, MyVector2 subVector2)
    {
        MyVector2 rv = Zero; //An empty Return Vector used to store the result of the inputted MyVector2s
        //Subtracts each parameter of the MyVector2s together and stores the result in the Return Vector
        rv.x = startVector2.x - subVector2.x;
        rv.y = startVector2.y - subVector2.y;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Scales the inputted MyVector2 by the inputted scalar
    /// </summary>
    /// <param name="startVector2">A MyVector2 Parameter</param>
    /// <param name="Scalar">Value used to scale the MyVector2 Parameter</param>
    /// <returns>The scaled MyVector2</returns>
    public static MyVector2 ScaleVector(MyVector2 startVector2, float Scalar)
    {
        MyVector2 rv = new MyVector2(startVector2.x * Scalar, startVector2.y * Scalar); //Scales the MyVector2 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Divides the inputted MyVector2 by the inputted divisor
    /// </summary>
    /// <param name="startVector2">A MyVector2 Parameter</param>
    /// <param name="Divisor">Value used to divide the MyVector2 Parameter</param>
    /// <returns>The divided MyVector2</returns>
    public static MyVector2 DivideVector(MyVector2 startVector2, float Divisor)
    {
        MyVector2 rv = new MyVector2(startVector2.x / Divisor, startVector2.y / Divisor); //Divides the MyVector2 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Converts a MyVector2 variable into an angle in radians
    /// </summary>
    /// <param name="a">A MyVector2 Parameter</param>
    /// <returns>The radians represting the MyVector2's angle</returns>
    public static float VectorToRadians(MyVector2 a)
    {
        float rv = Mathf.Atan(a.y / a.x); //Calculates the MyVector2's angle using the formula tan^-1(y/x)
        return rv;
    }

    /// <summary>
    /// Converts an angle in radians into a MyVector2 variable
    /// </summary>
    /// <param name="r">Angle in Radians</param>
    /// <returns>A MyVector2 variable</returns>
    public static MyVector2 RadiansToVector(float r)
    {
        MyVector2 rv = new MyVector2(Mathf.Cos(r), Mathf.Sin(r)); //Converts the angle into a unit length vector
        return rv;

    }

    /// <summary>
    /// Calcuates the dot product of two MyVector2s
    /// </summary>
    /// <param name="a">A MyVector2 Parameter</param>
    /// <param name="b">A MyVector2 Parameter</param>
    /// <param name="Normalise">Normalise the MyVector2s</param>
    /// <returns>The dot product of the two MyVector2s</returns>
    public static float VectorDotProduct(MyVector2 a, MyVector2 b, bool Normalise = false)
    {
        if (Normalise) //If MyVector2s should be normalised then...
        {
            //Normalises the MyVector2s
            a = a.NormaliseVector();
            b = b.NormaliseVector();
        }
        return ((a.x * b.x) + (a.y * b.y)); //Returns the MyVector2 Dot Product
    }

    /// <summary>
    /// Normalises the MyVector2
    /// </summary>
    /// <returns>The normalised resulted of the MyVector2</returns>
    public MyVector2 NormaliseVector()
    {
        MyVector2 rv = new MyVector2(x, y);
        rv = MyVector2.DivideVector(rv, rv.Length()); //Calculates the normalised MyVector2 by performing the calculation of: vector.normalised = vector / vector.length
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Returns the squared length of the MyVector2
    /// <param name="a">A MyVector2 Parameter</param>
    /// </summary>
    public float LengthSqaured()
    {
        float LenSquared = (x * x + y * y);
        return LenSquared;
    }



    /// <summary>
    /// Returns the length of the MyVector2
    /// </summary>
    public float Length()
    {
        float Len = Mathf.Sqrt(x * x + y * y); //Calculates the length of the MyVector2
        return Len; //Returns the result to the caller
    }

    /// <summary>
    /// Converts the MyVector2 variable to a MyVector3 variable
    /// </summary>
    /// <returns>A MyVector3 variable</returns>
    public MyVector3 ToMyVector3()
    {
        MyVector3 rv = new MyVector3(x, y, 0);
        return rv;
    }

    /// <summary>
    /// Converts the MyVector2 variable to a Unity Vector2 variable
    /// </summary>
    /// <returns>A Unity Vector2 variable</returns>
    public Vector2 ToUnityVector2()
    {
        Vector2 uv = new Vector2(x, y);
        return uv;
    }
}