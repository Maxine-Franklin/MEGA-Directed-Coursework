using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMatrix4x4
{
    public MyMatrix4x4(Vector4 Column1, Vector4 Column2, Vector4 Column3, Vector4 Column4);
    public MyMatrix4x4(MyVector3 Column1, Vector4 Column2, MyVector3 Column3, MyVector3 Column4);
    public float[,] Values;
    public static Vector4 operator *(MyMatrix4x4 matrix, Vector4 vec);
}
