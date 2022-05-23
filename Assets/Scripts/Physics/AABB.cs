using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    public bool recalculateBounds = false; //Allows bounds to be recalculated from editor (may remove later)
    public bool isStatic = true; //If an object is static, it searches the list of other objects that are marked as not static
    public collisionController collisionList; //Used to store a reference to the collision controller of the scene
    private List<AABB> colliders = new List<AABB>(); //List of all colliders to check for
    //Bounds of AABB
    private myVector3 minExtent; //Min extent of the AABB (Bottom/Left/Back)
    private myVector3 maxExtent; //Max extent of the AABB (Top/Right/Front)

    //Public properties for ease of use
    public float Top { get { return maxExtent.y; } }
    public float Bottom { get { return minExtent.y; } }
    public float Left { get { return minExtent.x; } }
    public float Right { get { return maxExtent.x; } }
    public float Front { get { return maxExtent.z; } }
    public float Back { get { return minExtent.z; } }

    public void calculateBounds() //Uses the vertices of the object's mesh to determine the bounds of the object and stores the result in min and max extent
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        myVector3[] ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);

        //Obtains object's centre as starting values for min and max extent to ensure vertices are outside of these starting values
        minExtent = myVector3.ToMyVector3(gameObject.transform.position);
        maxExtent = myVector3.ToMyVector3(gameObject.transform.position);

        //Obtains objects position and scale to account for vertices being in local position
        myVector3 objPos = myVector3.ToMyVector3(gameObject.transform.position); 
        myVector3 objScale = myVector3.ToMyVector3(gameObject.transform.lossyScale);
        foreach (myVector3 vertex in ModelSpaceVertices) //Cycles through each vertex of the object's mesh to find the objects bounds
        {
            //Adjusts vertex position by scale to account for any scaling done to the mesh
            vertex.x *= objScale.x;
            vertex.y *= objScale.y;
            vertex.z *= objScale.z;
            //Adjusts vertex position by gameObject position to account for gameObject position
            vertex.x += objPos.x;
            vertex.y += objPos.y;
            vertex.z += objPos.z;
            //Checks each axis of vertex to determine if that axis is greater than a stored max axis or less than a stored min axis
            if (vertex.x < minExtent.x) { minExtent.x = vertex.x;} //Left
            if (vertex.x > maxExtent.x) { maxExtent.x = vertex.x;} //Right
            if (vertex.y < minExtent.y) { minExtent.y = vertex.y;} //Bottom
            if (vertex.y > maxExtent.y) { maxExtent.y = vertex.y;} //Top
            if (vertex.z < minExtent.z) { minExtent.z = vertex.z;} //Back
            if (vertex.z > maxExtent.z) { maxExtent.z = vertex.z;} //Front
        }
        return; //Returns code execution to caller
    }

    public static bool Intersects(AABB _self, AABB collider) //Determines if two AABB's are colliding and returns to the result to the caller
    {
        return !(collider.Left > _self.Right
            || collider.Right < _self.Left
            || collider.Top < _self.Bottom
            || collider.Bottom > _self.Top
            || collider.Back > _self.Front
            || collider.Front < _self.Back);
    }

    public static myVector3 IntersectsAdjustment(AABB _self, AABB collider) //Determines adjustment needed to stop two AABBs colliding
    {
        myVector3 Adjuster = myVector3.Zero; //Used to store adjustment of each axis
        if (collider.Left > _self.Right) { Adjuster.x += _self.Right - collider.Left; }
        if (collider.Right < _self.Left) { Adjuster.x += _self.Left - collider.Right; }
        if (!(collider.Bottom > _self.Top)) { Adjuster.y += 1.25f*(_self.Top - collider.Bottom); } //Multiplier used here due to sinking that can be caused by gravity
        else if (!(collider.Top < _self.Bottom)) { Adjuster.y += _self.Bottom - collider.Top; }
        if (collider.Back > _self.Front) { Adjuster.z += _self.Front - collider.Back; }
        if (collider.Front < _self.Back) { Adjuster.z += _self.Back - collider.Front; }
        return Adjuster; //Returns adjustment myVector3 to caller
    }

    public void Position(myVector3 change) //Used when a dynamic object is moved, applies the change in position to the AABB so that the bounds don't need to be recalculated
    { minExtent += change; maxExtent += change; }

    public void buildCollisions() //Build list of collisions to check for
    {
        colliders.AddRange(collisionList.dynamicColliders.axisAligned); //Obtains a reference to all dynamic AABB's in the scene
        //Old removal system for own collider...
        //Removes own AABB from list of AABBs to prevent detecting a collision with itself
        //AABB _collider = null; //A null AABB reference
        //foreach (AABB collider in colliders) //For each collider in the collisions list...
        //{ if (collider.minExtent == this.minExtent && collider.maxExtent == this.maxExtent) { _collider = collider; } } //If collider is own collider, then store a reference to own collider
        //colliders.Remove(_collider); //Remove own collider from collisions list

        colliders.Remove(this); //Remove own collider from collisions list
    }

    // Start is called before the first frame update
    void Start()
    {
        calculateBounds(); //Determines gameObjects AABB bounds and stores them in minExtent and maxExtent
        if (isStatic) { collisionList.staticColliders.add(this); } //Stores a reference to the AABB in the scene's collisionController under the static category
        else { collisionList.dynamicColliders.add(this); } //Stores a reference to the AABB in the scene's collisionController under the dynamic category
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (recalculateBounds) { calculateBounds(); recalculateBounds = false; } //If the bounds of the AABB need to be recalculated, recalculates the bounds and unflags the need to recalculate
        foreach (AABB collider in colliders) //For each dynamic ABBA collider in the collider list...
        {
            if (Intersects(this, collider)) //If the collider intersects the gameObject then...
            {
                myVector3 change = IntersectsAdjustment(this, collider); //Calculates how far the collider has entered
                collider.GetComponent<myTransform>().Position += change; //Adjusts the colliders position to make it exit the ABBA of the gameObject
                collider.Position(change); //Updates the collider's ABBA to it's new position
                myRigidBody colRigidBody = collider.gameObject.GetComponent<myRigidBody>(); //Obtains the collider's rigid body component
                if (colRigidBody != null) //If the collider does have a rigid body then...
                {
                    myVector3 colVelocity = myVector3.Zero; //Creates an empty myVector3 velocity that will impart an equal but opposite force on the collider
                    //Determines which faces of the collider collided with the gameObject and stores the reactionary velocity to those impact points
                    if (change.x != 0) { colVelocity.x = colRigidBody.Velocity.x * Mathf.Sign(change.x); } //x-axis (Right/Left)
                    if (change.y != 0) { colVelocity.y = colRigidBody.Velocity.y * Mathf.Sign(change.y); } //y-axis (Top/Bottom)
                    if (change.z != 0) { colVelocity.z = colRigidBody.Velocity.z * Mathf.Sign(change.z); } //z-axis (Front/Back)
                    if (collider.gameObject.GetComponent<myPlayerController>() != null) //If collider is the player gameObject and y velocity is less than true jump height then ignore y velocity change
                    { if (colVelocity.y > 0 && colVelocity.y <= (collider.gameObject.GetComponent<myPlayerController>().jumpHeight * -20.0f * colRigidBody.Gravity)) { colVelocity.y = 0; } }
                    colRigidBody.Velocity -= colVelocity; //Imparts the reactionary velocity onto the collider
                }
            }
        }
    }
}