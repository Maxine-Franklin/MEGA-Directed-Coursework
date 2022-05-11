using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class myVector3
{
    public float x, y, z; //The myVector3 values

    //public static myVector3 Zero = new myVector3(0, 0, 0); //Creates an empty myVector3 parameter

    public static myVector3 Zero //Replacement for myVector3.Zero
    { get { return new myVector3(0, 0, 0); } }

    public myVector3(float x, float y, float z) //The myVector3 constructor
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// Adds together two myVector3s
    /// </summary>
    /// <param name="a">A myVector3 Parameter</param>
    /// <param name="b">A myVector3 Parameter</param>
    /// <returns>The total of the inputted myVector3s</returns>
    public static myVector3 operator +(myVector3 a, myVector3 b) { return new myVector3(a.x + b.x, a.y + b.y, a.z + b.z); }

    /// <summary>
    /// Subtracts two myVector3s
    /// </summary>
    /// <param name="a">A myVector3 Parameter</param>
    /// <param name="b">A myVector3 Parameter</param>
    /// <returns>The total of the two subtracted myVector3s</returns>
    public static myVector3 operator -(myVector3 a, myVector3 b) { return new myVector3(a.x - b.x, a.y - b.y, a.z - b.z); }

    /// <summary>
    /// Scales the inputted myVector3 by the inputted scalar
    /// </summary>
    /// <param name="startVector3">A myVector3 Parameter</param>
    /// <param name="Scalar">Value used to scale the myVector3 Parameter</param>
    /// <returns>The scaled myVector3</returns>
    public static myVector3 operator *(myVector3 startVector3, float Scalar)
    {
        myVector3 rv = new myVector3(startVector3.x * Scalar, startVector3.y * Scalar, startVector3.z * Scalar); //Scales the myVector3 and stores the result in the Return Vector
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Divides the inputted myVector3 by the inputted scalar
    /// </summary>
    /// <param name="a">A myVector3 Parameter</param>
    /// <param name="Scalar">Value used to scale the myVector3 Parameter</param>
    /// <returns>The divided myVector3</returns>
    public static myVector3 operator /(myVector3 a, float Scalar)
    { return new myVector3(a.x / Scalar, a.y / Scalar, a.z / Scalar); }//Divides the myVector3 by the scalar and returns to resultant myVector3 to the caller

    /// <summary>
    /// Less Than
    /// </summary>
    /// <param name="a">A myVector3 parameter</param>
    /// <param name="b">A myVector3 parameter</param>
    /// <returns>If a is less than b returns true, else returns false</returns>
    public static bool operator <(myVector3 a, myVector3 b)
    { if (a.x < b.x && a.y < b.y && a.z < b.z) { return true; } else { return false; } }

    /// <summary>
    /// Less Than or Equal To
    /// </summary>
    /// <param name="a">A myVector3 parameter</param>
    /// <param name="b">A myVector3 parameter</param>
    /// <returns>If a is less than or equal to b returns true, else returns false</returns>
    public static bool operator <=(myVector3 a, myVector3 b)
    { if (a.x <= b.x && a.y <= b.y && a.z <= b.z) { return true; } else { return false; } }

    /// <summary>
    /// Greater Than
    /// </summary>
    /// <param name="a">A myVector3 parameter</param>
    /// <param name="b">A myVector3 parameter</param>
    /// <returns>If a is greater than b returns true, else returns false</returns>
    public static bool operator >(myVector3 a, myVector3 b)
    { if (a.x > b.x && a.y > b.y && a.z > b.z) { return true; } else { return false; } }

    /// <summary>
    /// Greater Than or Equal To
    /// </summary>
    /// <param name="a">A myVector3 parameter</param>
    /// <param name="b">A myVector3 parameter</param>
    /// <returns>If a is greater than or equal to b returns true, else returns false</returns>
    public static bool operator >=(myVector3 a, myVector3 b)
    { if (a.x >= b.x && a.y >= b.y && a.z >= b.z) { return true; } else { return false; } }

    public static myVector3 ToMyVector3(Vector3 a)
    {
        return new myVector3(a.x, a.y, a.z);
    }
    public static myVector3[] ToMyVector3(Vector3[] a)
    {
        myVector3[] rv = new myVector3[a.Length];
        for (int i = 0; i < a.Length; i++)
        { rv[i] = ToMyVector3(a[i]); }
        return rv;
    }

    public static Vector3 ToUnityVector3(myVector3 a)
    {
        Vector3 uv = new Vector3(a.x, a.y, a.z);
        return uv;
    }

    public static Vector3[] ToUnityVector3(myVector3[] a)
    {
        Vector3[] rv = new Vector3[a.Length];
        for (int i = 0; i < a.Length; i++)
        { rv[i] = ToUnityVector3(a[i]); }
        return rv;
    }

    /// <summary>
    /// Normalises the myVector3
    /// </summary>
    /// <returns>The normalised resulted of the myVector3</returns>
    public myVector3 NormaliseVector()
    {
        myVector3 rv = new myVector3(x, y, z);
        rv = myMaths.DivideVector(rv, rv.Length()); //Calculates the normalised myVector3 by performing the calculation of: vector.normalised = vector / vector.length
        return rv; //Returns the stored result in the Return Vector to the caller
    }

    /// <summary>
    /// Returns the squared length of the myVector3
    /// <param name="a">A myVector3 Parameter</param>
    /// </summary>
    public float LengthSqaured()
    {
        float LenSquared = (x * x + y * y + z * z);
        return LenSquared;
    }

    /// <summary>
    /// Returns the length of the myVector3
    /// </summary>
    public float Length()
    {
        float Len = Mathf.Sqrt(x * x + y * y + z * z); //Calculates the length of the myVector3
        return Len; //Returns the result to the caller
    }

    /// <summary>
    /// Converts the myVector3 variable to a Unity Vector3 variable
    /// </summary>
    /// <returns>A Unity Vector3 variable</returns>
    public Vector3 ToUnityVector3()
    {
        Vector3 uv = new Vector3(x, y, z);
        return uv;
    }
}

/*
/// <summary>
/// Creates the custom editor elements for myTransform_OLD
/// WARNING: Custom Editor is the 'old' method for modifying the script variables directly
/// It cannot handle multi-object editing, undo, and Prefab overrides
/// </summary>
[CustomEditor(typeof(myVector3))]
[CanEditMultipleObjects]
public class myVector3Editor : Editor
{
    SerializedProperty myVec;
    SerializedProperty x;
    SerializedProperty y;
    SerializedProperty z;
    void OnEnable()
    {
        //Setup the SerializedProperties
        //myVec = serializedObject.FindProperty("myVector3");
        x = serializedObject.FindProperty("x");
        y = serializedObject.FindProperty("y");
        z = serializedObject.FindProperty("z");
    }
    public override void OnInspectorGUI()
    {
        //Update the serializedProperty - always do this in the beginning of OnInspectorGUI
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        //EditorGUILayout.FloatField(myVec.FindPropertyRelative("x").floatValue);
        EditorGUILayout.FloatField(x.floatValue);
        EditorGUILayout.FloatField(y.floatValue);
        EditorGUILayout.FloatField(z.floatValue);
        EditorGUILayout.EndHorizontal();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}*/