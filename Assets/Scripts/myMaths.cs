using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myMaths
{
    /// <summary>
    /// Adds together two myVector4s
    /// </summary>
    /// <param name="a">A myVector4 Parameter</param>
    /// <param name="b">A myVector4 Parameter</param>
    /// <returns>The total of the inputted myVector4s</returns>
    public static myVector4 AddVector(myVector4 a, myVector4 b)
    {
        myVector4 rv = myVector4.Zero; //An empty Return Vector used to store the result of the inputted myVector4s
        //Adds each parameter of the myVector4s together and stores the result in the Return Vector
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;
        rv.z = a.z + b.z;
        rv.w = a.w + b.w;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Adds together two myVector3s<br/>WARNING: Legacy Feature. Use + operator instead
    /// </summary>
    /// <param name="a">A myVector3 Parameter</param>
    /// <param name="b">A myVector3 Parameter</param>
    /// <returns>The total of the inputted myVector3s</returns>
    public static myVector3 AddVector(myVector3 a, myVector3 b)
    {
        myVector3 rv = myVector3.Zero; //An empty Return Vector used to store the result of the inputted myVector3s
        //Adds each parameter of the myVector3s together and stores the result in the Return Vector
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;
        rv.z = a.z + b.z;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Adds together two myVector2s
    /// </summary>
    /// <param name="a">A myVector2 Parameter</param>
    /// <param name="b">A myVector2 Parameter</param>
    /// <returns>The total of the inputted myVector2s</returns>
    public static myVector2 AddVector(myVector2 a, myVector2 b)
    {
        myVector2 rv = myVector2.Zero; //An empty Return Vector used to store the result of the inputted myVector2s
        //Adds each parameter of the myVector2s together and stores the result in the Return Vector
        rv.x = a.x + b.x;
        rv.y = a.y + b.y;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Subtracts two myVector4s
    /// </summary>
    /// <param name="startVector4">A myVector4 Parameter</param>
    /// <param name="subVector4">A myVector4 Parameter</param>
    /// <returns>The subtracted total of the inputted myVector4s</returns>
    public static myVector4 SubVector(myVector4 startVector4, myVector4 subVector4)
    {
        myVector4 rv = myVector4.Zero; //An empty Return Vector used to store the result of the inputted myVector4s
        //Subtracts each parameter of the myVector4s together and stores the result in the Return Vector
        rv.x = startVector4.x - subVector4.x;
        rv.y = startVector4.y - subVector4.y;
        rv.z = startVector4.z - subVector4.z;
        rv.w = startVector4.w - subVector4.w;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Subtracts two myVector3s
    /// </summary>
    /// <param name="startVector3">A myVector3 Parameter</param>
    /// <param name="subVector3">A myVector3 Parameter</param>
    /// <returns>The subtracted total of the inputted myVector3s</returns>
    public static myVector3 SubVector(myVector3 startVector3, myVector3 subVector3)
    {
        myVector3 rv = myVector3.Zero; //An empty Return Vector used to store the result of the inputted myVector3s
        //Subtracts each parameter of the myVector3s together and stores the result in the Return Vector
        rv.x = startVector3.x - subVector3.x;
        rv.y = startVector3.y - subVector3.y;
        rv.z = startVector3.z - subVector3.z;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Subtracts two myVector2s
    /// </summary>
    /// <param name="startVector2">A myVector2 Parameter</param>
    /// <param name="subVector2">A myVector2 Parameter</param>
    /// <returns>The subtracted total of the inputted myVector2s</returns>
    public static myVector2 SubVector(myVector2 startVector2, myVector2 subVector2)
    {
        myVector2 rv = myVector2.Zero; //An empty Return Vector used to store the result of the inputted myVector2s
        //Subtracts each parameter of the myVector2s together and stores the result in the Return Vector
        rv.x = startVector2.x - subVector2.x;
        rv.y = startVector2.y - subVector2.y;

        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Scales the inputted myVector4 by the inputted scalar
    /// </summary>
    /// <param name="startVector4">A myVector4 Parameter</param>
    /// <param name="Scalar">Value used to scale the myVector4 Parameter</param>
    /// <returns>The scaled myVector4</returns>
    public static myVector4 ScaleVector(myVector4 startVector4, float Scalar)
    {
        myVector4 rv = new myVector4(startVector4.x * Scalar, startVector4.y * Scalar, startVector4.z * Scalar, startVector4.w * Scalar); //Scales the myVector4 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Scales the inputted myVector3 by the inputted scalar<br/>WARNING: Legacy Feature. Use * operator instead
    /// </summary>
    /// <param name="startVector3">A myVector3 Parameter</param>
    /// <param name="Scalar">Value used to scale the myVector3 Parameter</param>
    /// <returns>The scaled myVector3</returns>
    public static myVector3 ScaleVector(myVector3 startVector3, float Scalar)
    {
        myVector3 rv = new myVector3(startVector3.x * Scalar, startVector3.y * Scalar, startVector3.z * Scalar); //Scales the myVector3 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Scales the inputted myVector2 by the inputted scalar
    /// </summary>
    /// <param name="startVector2">A myVector2 Parameter</param>
    /// <param name="Scalar">Value used to scale the myVector2 Parameter</param>
    /// <returns>The scaled myVector2</returns>
    public static myVector2 ScaleVector(myVector2 startVector2, float Scalar)
    {
        myVector2 rv = new myVector2(startVector2.x * Scalar, startVector2.y * Scalar); //Scales the myVector2 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Divides the inputted myVector4 by the inputted divisor
    /// </summary>
    /// <param name="startVector4">A myVector4 Parameter</param>
    /// <param name="Divisor">Value used to divide the myVector4 Parameter</param>
    /// <returns>The divided myVector4</returns>
    public static myVector4 DivideVector(myVector4 startVector4, float Divisor)
    {
        myVector4 rv = new myVector4(startVector4.x / Divisor, startVector4.y / Divisor, startVector4.z / Divisor, startVector4.w / Divisor); //Divides the myVector4 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Divides the inputted myVector3 by the inputted divisor
    /// </summary>
    /// <param name="startVector3">A myVector3 Parameter</param>
    /// <param name="Divisor">Value used to divide the myVector3 Parameter</param>
    /// <returns>The divided myVector3</returns>
    public static myVector3 DivideVector(myVector3 startVector3, float Divisor)
    {
        myVector3 rv = new myVector3(startVector3.x / Divisor, startVector3.y / Divisor, startVector3.z / Divisor); //Divides the myVector3 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Divides the inputted myVector2 by the inputted divisor
    /// </summary>
    /// <param name="startVector2">A myVector2 Parameter</param>
    /// <param name="Divisor">Value used to divide the myVector2 Parameter</param>
    /// <returns>The divided myVector2</returns>
    public static myVector2 DivideVector(myVector2 startVector2, float Divisor)
    {
        myVector2 rv = new myVector2(startVector2.x / Divisor, startVector2.y / Divisor); //Divides the myVector2 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Calcuates the dot product of two myVector4s
    /// </summary>
    /// <param name="a">A myVector4 Parameter</param>
    /// <param name="b">A myVector4 Parameter</param>
    /// <param name="Normalise">Normalise the myVector4s</param>
    /// <returns>The dot product of the two myVector4s</returns>
    public static float VectorDotProduct(myVector4 a, myVector4 b, bool Normalise = false)
    {
        if (Normalise) //If myVector4s should be normalised then...
        {
            //Normalises the myVector4s
            a = a.NormaliseVector();
            b = b.NormaliseVector();
        }
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w)); //Returns the myVector4 Dot Product
    }

    /// <summary>
    /// Calcuates the dot product of two myVector3s
    /// </summary>
    /// <param name="a">A myVector3 Parameter</param>
    /// <param name="b">A myVector3 Parameter</param>
    /// <param name="Normalise">Normalise the myVector3s</param>
    /// <returns>The dot product of the two myVector3s</returns>
    public static float VectorDotProduct(myVector3 a, myVector3 b, bool Normalise = false)
    {
        if (Normalise) //If myVector3s should be normalised then...
        {
            //Normalises the myVector3s
            a = a.NormaliseVector();
            b = b.NormaliseVector();
        }
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z)); //Returns the myVector3 Dot Product
    }

    /// <summary>
    /// Calcuates the dot product of two myVector2s
    /// </summary>
    /// <param name="a">A myVector2 Parameter</param>
    /// <param name="b">A myVector2 Parameter</param>
    /// <param name="Normalise">Normalise the myVector2s</param>
    /// <returns>The dot product of the two myVector2s</returns>
    public static float VectorDotProduct(myVector2 a, myVector2 b, bool Normalise = false)
    {
        if (Normalise) //If myVector2s should be normalised then...
        {
            //Normalises the myVector2s
            a = a.NormaliseVector();
            b = b.NormaliseVector();
        }
        return ((a.x * b.x) + (a.y * b.y)); //Returns the myVector2 Dot Product
    }

    /// <summary>
    /// Performs one step a of vector lerp to smoothly adjust the position of an actor in vector4 space
    /// </summary>
    /// <param name="a">A myVector4 parameter</param>
    /// <param name="b">A myVector4 parameter</param>
    /// <param name="Time">Used to make lerp smooth over multiple frames</param>
    /// <returns>The next myVector4 position of the actor</returns>
    public static myVector4 VectorLerp(myVector4 a, myVector4 b, float Time)
    {
        return AddVector(ScaleVector(a, (1.0f - Time)), ScaleVector(b, Time));
    }

    /// <summary>
    /// Performs one step a of vector lerp to smoothly adjust the position of an actor in vector3 space
    /// </summary>
    /// <param name="a">A myVector3 parameter</param>
    /// <param name="b">A myVector3 parameter</param>
    /// <param name="Time">Used to make lerp smooth over multiple frames</param>
    /// <returns>The next myVector3 position of the actor</returns>
    public static myVector3 VectorLerp(myVector3 a, myVector3 b, float Time)
    {
        return AddVector(ScaleVector(a, (1.0f - Time)), ScaleVector(b, Time));
    }

    /// <summary>
    /// Performs one step a of vector lerp to smoothly adjust the position of an actor in vector2 space
    /// </summary>
    /// <param name="a">A myVector2 parameter</param>
    /// <param name="b">A myVector2 parameter</param>
    /// <param name="Time">Used to make lerp smooth over multiple frames</param>
    /// <returns>The next myVector2 position of the actor</returns>
    public static myVector2 VectorLerp(myVector2 a, myVector2 b, float Time)
    {
        return AddVector(ScaleVector(a, (1.0f - Time)), ScaleVector(b, Time));
    }

    /// <summary>
    /// Converts an Euler angle into a directional myVector3
    /// </summary>
    /// <param name="Euler">A myVector3 parameter storing an Euler angle</param>
    /// <returns>A directional myVector3</returns>
    public static myVector3 EulerToVector(myVector3 Euler)
    {
        myVector3 rv = myVector3.Zero;

        rv.x = Mathf.Cos(Euler.y) * Mathf.Sin(Euler.x);
        rv.y = Mathf.Sin(Euler.x);
        rv.z = Mathf.Cos(Euler.x) * Mathf.Cos(Euler.y);

        return rv;
    }

    public static myVector3 LinearInterpretation(myVector3 a, myVector3 b, float t)
    {
        return AddVector(ScaleVector(a, (1 - t)), ScaleVector(b, t));
    }

    /// <summary>
    /// Converts a myVector2 variable into an angle in radians
    /// </summary>
    /// <param name="a">A myVector2 parameter</param>
    /// <returns></returns>
    public static float VectorToRadians(myVector2 a)
    {
        float rv = Mathf.Atan(a.y / a.x); //Calculates the myVector2's angle using the formula tan^-1(y/x)
        return rv;
    }

    /// <summary>
    /// Converts an angle in radians into a myVector2 variable
    /// </summary>
    /// <param name="r">Angle in Radians</param>
    /// <returns>A myVector2 variable</returns>
    public static myVector2 RadiansToVector(float r)
    {
        myVector2 rv = new myVector2(Mathf.Cos(r), Mathf.Sin(r)); //Converts the angle into a unit length vector
        return rv;

    }
}

public class myMatrix4x4
{
    public float[,] values;
    public myMatrix4x4(myVector4 column1, myVector4 column2, myVector4 column3, myVector4 column4)
    {
        values = new float[4, 4];
        //Column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;
        //Column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;
        //Column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;
        //Column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }
    public myMatrix4x4(myVector3 column1, myVector3 column2, myVector3 column3, myVector3 column4)
    {
        values = new float[4, 4];
        //Column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0.0f;
        //Column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0.0f;
        //Column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0.0f;
        //Column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1.0f;
    }
    public static myVector4 operator *(myMatrix4x4 lhs, myVector4 rhs)
    {
        myVector4 rv = myVector4.Zero;
        //Scales the myMatrix4x4 by the myVector4
        rv.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * rhs.w;
        rv.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * rhs.w;
        rv.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * rhs.w;
        rv.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * rhs.w;
        return rv;
    }
    public static myVector4 operator *(myMatrix4x4 lhs, myVector3 rhs)
    {
        myVector4 rv = myVector4.Zero;
        //Scales the myMatrix4x4 by the myVector3
        rv.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * 1;
        rv.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * 1;
        rv.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * 1;
        rv.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * 1;
        return rv;
    }
    /*public static myVector3 operator *(myMatrix4x4 lhs, myVector3 rhs)
    {
        myVector3 rv = myVector3.Zero;
        //Scales the myMatrix4x4 by the myVector3
        rv.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * 1;
        rv.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * 1;
        rv.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * 1;
        return rv;
    }*/
}