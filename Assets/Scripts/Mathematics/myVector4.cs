using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myVector4
{
    public float x, y, z, w; //The myVector4 values

    //public static myVector4 Zero = new myVector4(0, 0, 0, 0); //Creates an empty myVector4 parameter

    public static myVector4 Zero //Replacement for myVector4.Zero
    { get { return new myVector4(0, 0, 0, 0); } }

    public myVector4(float x, float y, float z, float w) //The myVector4 constructor
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Less Than
    /// </summary>
    /// <param name="a">A myVector4 parameter</param>
    /// <param name="b">A myVector4 parameter</param>
    /// <returns>If a is less than b returns true, else returns false</returns>
    public static bool operator <(myVector4 a, myVector4 b)
    { if (a.x < b.x && a.y < b.y && a.z < b.z && a.w < b.w) { return true; } else { return false; } }

    /// <summary>
    /// Less Than or Equal To
    /// </summary>
    /// <param name="a">A myVector4 parameter</param>
    /// <param name="b">A myVector4 parameter</param>
    /// <returns>If a is less than or equal to b returns true, else returns false</returns>
    public static bool operator <=(myVector4 a, myVector4 b)
    { if (a.x <= b.x && a.y <= b.y && a.z <= b.z && a.w <= b.w) { return true; } else { return false; } }

    /// <summary>
    /// Greater Than
    /// </summary>
    /// <param name="a">A myVector4 parameter</param>
    /// <param name="b">A myVector4 parameter</param>
    /// <returns>If a is greater than b returns true, else returns false</returns>
    public static bool operator >(myVector4 a, myVector4 b)
    { if (a.x > b.x && a.y > b.y && a.z > b.z && a.w > b.w) { return true; } else { return false; } }

    /// <summary>
    /// Greater Than or Equal To
    /// </summary>
    /// <param name="a">A myVector4 parameter</param>
    /// <param name="b">A myVector4 parameter</param>
    /// <returns>If a is greater than or equal to b returns true, else returns false</returns>
    public static bool operator >=(myVector4 a, myVector4 b)
    { if (a.x >= b.x && a.y >= b.y && a.z >= b.z && a.w >= b.w) { return true; } else { return false; } }

    /// <summary>
    /// Normalises the myVector4
    /// </summary>
    /// <returns>The normalised resulted of the myVector4</returns>
    public myVector4 NormaliseVector()
    {
        myVector4 rv = new myVector4(x, y, z, w);
        rv = myMaths.DivideVector(rv, rv.Length()); //Calculates the normalised myVector4 by performing the calculation of: vector.normalised = vector / vector.length
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Returns the squared length of the myVector4
    /// <param name="a">A myVector4 Parameter</param>
    /// </summary>
    public float LengthSqaured()
    {
        float LenSquared = (x * x + y * y + z * z + w * w);
        return LenSquared;
    }

    /// <summary>
    /// Returns the length of the myVector4
    /// </summary>
    public float Length()
    {
        float Len = Mathf.Sqrt(x * x + y * y + z * z + w * w); //Calculates the length of the myVector4
        return Len; //Returns the result to the caller
    }

    public myVector3 ToMyVector3()
    {
        return new myVector3(x, y, z);
    }

    public static Vector4 ToUnityVector4(myVector4 a)
    {
        Vector4 uv = new Vector4(a.x, a.y, a.z, a.w);
        return uv;
    }
}
