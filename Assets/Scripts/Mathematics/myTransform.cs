using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class myTransform : MonoBehaviour
{
    public myMatrix4x4[] Position =  new myMatrix4x4[] { myMatrix4x4.Identity, myMatrix4x4.Identity, myMatrix4x4.Identity };
    public myVector3[] Rotation = new myVector3[] { myVector3.Zero, myVector3.Zero, myVector3.Zero };
    public myMatrix4x4[] Scale = new myMatrix4x4[] { myMatrix4x4.Identity, myMatrix4x4.Identity, myMatrix4x4.Identity };

    myVector3[] ModelSpaceVertices;
    //public float tester = 12.4f;
    // Start is called before the first frame update
    void Awake()
    {
        //Mesh filter is a component that stores information about the current mesh
        Mesh MF = GetComponent<MeshFilter>().sharedMesh;

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        ModelSpaceVertices = myVector3.ToMyVector3(MF.vertices);

        //Position = myVector3.ToMyVector3(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Position[0] == Position[1] && Rotation[0] == Rotation[1] && Scale[0] == Scale[1])) //Checks if the transform of the gameObject has changed since the last update
        {
            //Calculates the difference between the previous transform and the new transform and manipulates the gameObject by this difference
            Position[2] = Position[0] - Position[1];
            Rotation[2] = Rotation[0] - Rotation[1];
            //Scale[2] = Scale[0] - Scale[1];

            //Mesh filter is a component that stores information about the current mesh
            Mesh MF = GetComponent<MeshFilter>().sharedMesh;

            //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
            ModelSpaceVertices = myVector3.ToMyVector3(MF.vertices);

            //Define a new array with the correct size
            myVector3[] transformedVertices = new myVector3[ModelSpaceVertices.Length];

            //Create our rotation matrix (Rotation.z, Rotation.y, Rotation.x)
            //Roll
            myMatrix4x4 rollMatrix = new myMatrix4x4(
                new myVector3(Mathf.Cos(Rotation[2].z), Mathf.Sin(Rotation[2].z), 0),
                new myVector3(-Mathf.Sin(Rotation[2].z), Mathf.Cos(Rotation[2].z), 0),
                new myVector3(0, 0, 1),
                myVector3.Zero);
            //Pitch
            myMatrix4x4 pitchMatrix = new myMatrix4x4(
                new myVector3(1, 0, 0),
                new myVector3(0, Mathf.Cos(Rotation[2].y), Mathf.Sin(Rotation[2].y)),
                new myVector3(0, -Mathf.Sin(Rotation[2].y), Mathf.Cos(Rotation[2].y)),
                myVector3.Zero);
            //Yaw
            myMatrix4x4 yawMatrix = new myMatrix4x4(
                new myVector3(Mathf.Cos(Rotation[2].x), 0, -Mathf.Sin(Rotation[2].x)),
                new myVector3(0, 1, 0),
                new myVector3(Mathf.Sin(Rotation[2].x), 0, Mathf.Cos(Rotation[2].x)),
                myVector3.Zero);

            myMatrix4x4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix); //Calculates the entire rotation in one step

            myMatrix4x4 transformMatrix = Position[2] * (rotationMatrix * Scale[0]);

            //Transform each individual vertex
            for (int i = 0; i < transformedVertices.Length; i++)
            { transformedVertices[i] = (transformMatrix * ModelSpaceVertices[i]).ToMyVector3(); }

            //Mesh filter is a component that stores information about the current mesh
            /*MeshFilter*/
            MF = GetComponent<MeshFilter>().sharedMesh;

            //Assign our new vertices
            MF.vertices = myVector3.ToUnityVector3(transformedVertices);

            //These final steps are sometimes necessary to make the mesh look correct
            MF.RecalculateNormals();
            MF.RecalculateBounds();

            //Updates stored previous transform of the gameObject
            Position[1] = Position[0];
            Rotation[1] = Rotation[0];
            Scale[1] = Scale[0];
        }
    }
}

/// <summary>
/// Creates the custom editor elements for myTransform
/// WARNING: Custom Editor is the 'old' method for modifying the script variables directly
/// It cannot handle multi-object editing, undo, and Prefab overrides
/// </summary>
[CustomEditor(typeof(myTransform))]
[CanEditMultipleObjects]
public class myTransformEditor : Editor
{
    /*SerializedProperty positionProp;
    SerializedProperty rotationProp;
    SerializedProperty scaleProp;
    SerializedProperty testerProp;*/

   /* private void OnEnable()
    {
        //Setup the SerializedProperties
        positionProp = serializedObject.FindProperty("Position");
        rotationProp = serializedObject.FindProperty("Rotation");
        scaleProp = serializedObject.FindProperty("Scale");
        testerProp = serializedObject.FindProperty("tester");
    }*/
    public override void OnInspectorGUI()
    {
        //Update the serializedProperty - always do this in the beginning of OnInspectorGUI
        //serializedObject.Update();
        /*EditorGUILayout.BeginHorizontal();
        EditorGUILayout.FloatField(positionProp.FindPropertyRelative("x").floatValue);
        EditorGUILayout.FloatField(positionProp.FindPropertyRelative("y").floatValue);
        EditorGUILayout.FloatField(positionProp.FindPropertyRelative("z").floatValue);
        EditorGUILayout.EndHorizontal();*/

        myTransform myTrans = (myTransform)target;

        //Position
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Position", GUILayout.MinWidth(67.0f / 194.0f * Screen.width)); //Informs user that they are editing the position of the object
        EditorGUILayout.LabelField("X", GUILayout.Width(9.0f)); //Informs the user that they are editing the x coordinate of the object's position
        myTrans.Position[0].values[0, 3] = EditorGUILayout.FloatField(myTrans.Position[0].values[0, 3], GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's x position
        EditorGUILayout.LabelField("Y", GUILayout.Width(9.0f)); //Informs the user that they are editing the y coordinate of the object's position
        myTrans.Position[0].values[1, 3] = EditorGUILayout.FloatField(myTrans.Position[0].values[1, 3], GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's y position
        EditorGUILayout.LabelField("Z", GUILayout.Width(9.0f)); //Informs the user that they are editing the z coordinate of the object's position
        myTrans.Position[0].values[2, 3] = EditorGUILayout.FloatField(myTrans.Position[0].values[2, 3], GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's z position
        EditorGUILayout.EndHorizontal();
        //Rotation
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Rotation", GUILayout.MinWidth(67.0f / 194.0f * Screen.width)); //Informs user that they are editing the rotation of the object
        EditorGUILayout.LabelField("X", GUILayout.Width(9.0f)); //Informs the user that they are editing the x coordinate of the object's rotation
        myTrans.Rotation[0].x = EditorGUILayout.FloatField(myTrans.Rotation[0].x, GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's x rotation
        EditorGUILayout.LabelField("Y", GUILayout.Width(9.0f)); //Informs the user that they are editing the y coordinate of the object's rotation
        myTrans.Rotation[0].y = EditorGUILayout.FloatField(myTrans.Rotation[0].y, GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's y rotation
        EditorGUILayout.LabelField("Z", GUILayout.Width(9.0f)); //Informs the user that they are editing the z coordinate of the object's rotation
        myTrans.Rotation[0].z = EditorGUILayout.FloatField(myTrans.Rotation[0].z, GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's z rotation
        EditorGUILayout.EndHorizontal();
        //Scale
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Scale", GUILayout.MinWidth(67.0f / 194.0f * Screen.width)); //Informs user that they are editing the scale of the object
        EditorGUILayout.LabelField("X", GUILayout.Width(9.0f)); //Informs the user that they are editing the x coordinate of the object's scale
        myTrans.Scale[0].values[0, 0] = EditorGUILayout.FloatField(myTrans.Scale[0].values[0, 0], GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's x scale
        EditorGUILayout.LabelField("Y", GUILayout.Width(9.0f)); //Informs the user that they are editing the y coordinate of the object's scale
        myTrans.Scale[0].values[1, 1] = EditorGUILayout.FloatField(myTrans.Scale[0].values[1, 1], GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's y scale
        EditorGUILayout.LabelField("Z", GUILayout.Width(9.0f)); //Informs the user that they are editing the z coordinate of the object's scale
        myTrans.Scale[0].values[2, 2] = EditorGUILayout.FloatField(myTrans.Scale[0].values[2, 2], GUILayout.MinWidth(31.0f / 194.0f * Screen.width)); //Takes user input to update object's z scale
        EditorGUILayout.EndHorizontal();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        //serializedObject.ApplyModifiedProperties();

        //base.OnInspectorGUI();
    }
}