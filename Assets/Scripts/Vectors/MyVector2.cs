using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myVector2
{
    public float x, y;

    public static myVector2 Zero = new myVector2(0, 0);

    public myVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Less Than
    /// </summary>
    /// <param name="a">A myVector2 parameter</param>
    /// <param name="b">A myVector2 parameter</param>
    /// <returns>If a is less than b returns true, else returns false</returns>
    public static bool operator <(myVector2 a, myVector2 b)
    { if (a.x < b.x && a.y < b.y) { return true; } else { return false; } }

    /// <summary>
    /// Less Than or Equal To
    /// </summary>
    /// <param name="a">A myVector2 parameter</param>
    /// <param name="b">A myVector2 parameter</param>
    /// <returns>If a is less than or equal to b returns true, else returns false</returns>
    public static bool operator <=(myVector2 a, myVector2 b)
    { if (a.x <= b.x && a.y <= b.y) { return true; } else { return false; } }

    /// <summary>
    /// Greater Than
    /// </summary>
    /// <param name="a">A myVector2 parameter</param>
    /// <param name="b">A myVector2 parameter</param>
    /// <returns>If a is greater than b returns true, else returns false</returns>
    public static bool operator >(myVector2 a, myVector2 b)
    { if (a.x > b.x && a.y > b.y) { return true; } else { return false; } }

    /// <summary>
    /// Greater Than or Equal To
    /// </summary>
    /// <param name="a">A myVector2 parameter</param>
    /// <param name="b">A myVector2 parameter</param>
    /// <returns>If a is greater than or equal to b returns true, else returns false</returns>
    public static bool operator >=(myVector2 a, myVector2 b)
    { if (a.x >= b.x && a.y >= b.y) { return true; } else { return false; } }

    /// <summary>
    /// Normalises the myVector2
    /// </summary>
    /// <returns>The normalised resulted of the myVector2</returns>
    public myVector2 NormaliseVector()
    {
        myVector2 rv = new myVector2(x, y);
        rv = myMaths.DivideVector(rv, rv.Length()); //Calculates the normalised myVector2 by performing the calculation of: vector.normalised = vector / vector.length
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Returns the squared length of the myVector2
    /// <param name="a">A myVector2 Parameter</param>
    /// </summary>
    public float LengthSqaured()
    {
        float LenSquared = (x * x + y * y);
        return LenSquared;
    }

    /// <summary>
    /// Returns the length of the myVector2
    /// </summary>
    public float Length()
    {
        float Len = Mathf.Sqrt(x * x + y * y); //Calculates the length of the myVector2
        return Len; //Returns the result to the caller
    }

    /// <summary>
    /// Converts the myVector2 variable to a MyVector3 variable
    /// </summary>
    /// <returns>A MyVector3 variable</returns>
    public myVector3 ToMyVector3()
    {
        myVector3 rv = new myVector3(x, y, 0);
        return rv;
    }

    /// <summary>
    /// Converts the myVector2 variable to a Unity Vector2 variable
    /// </summary>
    /// <returns>A Unity Vector2 variable</returns>
    public Vector2 ToUnityVector2()
    {
        Vector2 uv = new Vector2(x, y);
        return uv;
    }
}