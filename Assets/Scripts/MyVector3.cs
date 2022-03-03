using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3
{
    public float x, y, z;

    static MyVector3 Zero = new MyVector3(0, 0, 0);

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    /// <summary>
    /// Adds together two MyVector3s
    /// </summary>
    /// <param name="a">A MyVector3 Parameter</param>
    /// <param name="b">A MyVector3 Parameter</param>
    /// <returns>The total of the inputted MyVector3s</returns>
    public static MyVector3 AddVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 rv = Zero; //An empty Return Vector used to store the result of the inputted MyVector3s
        //Adds each parameter of the MyVector3s together and stores the result in the Return Vector
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;
        rv.z = a.z + b.z;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Subtracts two MyVector3s
    /// </summary>
    /// <param name="startVector3">A MyVector3 Parameter</param>
    /// <param name="subVector3">A MyVector3 Parameter</param>
    /// <returns>The subtracted total of the inputted MyVector3s</returns>
    public static MyVector3 SubVector(MyVector3 startVector3, MyVector3 subVector3)
    {
        MyVector3 rv = Zero; //An empty Return Vector used to store the result of the inputted MyVector3s
        //Subtracts each parameter of the MyVector3s together and stores the result in the Return Vector
        rv.x = startVector3.x - subVector3.x;
        rv.y = startVector3.y - subVector3.y;
        rv.z = startVector3.z - subVector3.z;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Scales the inputted MyVector3 by the inputted scalar
    /// </summary>
    /// <param name="startVector3">A MyVector3 Parameter</param>
    /// <param name="Scalar">Value used to scale the MyVector3 Parameter</param>
    /// <returns>The scaled MyVector3</returns>
    public static MyVector3 ScaleVector(MyVector3 startVector3, float Scalar)
    {
        MyVector3 rv = new MyVector3(startVector3.x * Scalar, startVector3.y * Scalar, startVector3.z * Scalar); //Scales the MyVector3 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Divides the inputted MyVector3 by the inputted divisor
    /// </summary>
    /// <param name="startVector3">A MyVector3 Parameter</param>
    /// <param name="Divisor">Value used to divide the MyVector3 Parameter</param>
    /// <returns>The divided MyVector3</returns>
    public static MyVector3 DivideVector(MyVector3 startVector3, float Divisor)
    {
        MyVector3 rv = new MyVector3(startVector3.x / Divisor, startVector3.y / Divisor, startVector3.z / Divisor); //Divides the MyVector3 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Converts an Euler angle into a directional MyVector3
    /// </summary>
    /// <param name="Euler">A MyVector3 parameter storing an Euler angle</param>
    /// <returns>A directional MyVector3</returns>
    public static MyVector3 EulerToVector(MyVector3 Euler)
    {
        MyVector3 rv = MyVector3.Zero;

        rv.x = Mathf.Cos(Euler.y) * Mathf.Sin(Euler.x);
        rv.y = Mathf.Sin(Euler.x);
        rv.z = Mathf.Cos(Euler.x) * Mathf.Cos(Euler.y);

        return rv;
    }

    /// <summary>
    /// Calcuates the dot product of two MyVector3s
    /// </summary>
    /// <param name="a">A MyVector3 Parameter</param>
    /// <param name="b">A MyVector3 Parameter</param>
    /// <param name="Normalise">Normalise the MyVector3s</param>
    /// <returns>The dot product of the two MyVector3s</returns>
    public static float VectorDotProduct(MyVector3 a, MyVector3 b, bool Normalise = false)
    {
        if (Normalise) //If MyVector3s should be normalised then...
        {
            //Normalises the MyVector3s
            a = a.NormaliseVector();
            b = b.NormaliseVector();
        }
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z)); //Returns the MyVector3 Dot Product
    }

    public static MyVector3 LinearInterpretation(MyVector3 a, MyVector3 b, float t)
    {
        return AddVector(ScaleVector(a, (1 - t)), ScaleVector(b, t));
    }

    public static Vector3 ToUnityVector3(MyVector3 a)
    {
        Vector3 uv = new Vector3(a.x, a.y, a.z);
        return uv;
    }

    /// <summary>
    /// Normalises the MyVector3
    /// </summary>
    /// <returns>The normalised resulted of the MyVector3</returns>
    public MyVector3 NormaliseVector()
    {
        MyVector3 rv = new MyVector3(x, y, z);
        rv = MyVector3.DivideVector(rv, rv.Length()); //Calculates the normalised MyVector3 by performing the calculation of: vector.normalised = vector / vector.length
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Returns the squared length of the MyVector3
    /// <param name="a">A MyVector3 Parameter</param>
    /// </summary>
    public float LengthSqaured()
    {
        float LenSquared = (x * x + y * y + z * z);
        return LenSquared;
    }



    /// <summary>
    /// Returns the length of the MyVector3
    /// </summary>
    public float Length()
    {
        float Len = Mathf.Sqrt(x * x + y * y + z * z); //Calculates the length of the MyVector3
        return Len; //Returns the result to the caller
    }

    /// <summary>
    /// Converts the MyVector3 variable to a Unity Vector3 variable
    /// </summary>
    /// <returns>A Unity Vector3 variable</returns>
    public Vector3 ToUnityVector3()
    {
        Vector3 uv = new Vector3(x, y, z);
        return uv;
    }
}