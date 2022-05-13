using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    public bool recalculateBounds = false; //Allows bounds to be recalculated from editor (may remove later)
    public bool isStatic = true; //If an object is static, it searches the list of other objects that are marked as not static
    public collisionController collisionList; //Used to store a reference to the collision controller of the scene
    List<AABB> colliders = new List<AABB>(); //List of all colliders to check for
    //Bounds of AABB
    private AABB self;
    private myVector3 minExtent;
    private myVector3 maxExtent;

    //Public properties for ease of use
    public float Top { get { return maxExtent.y; } }
    public float Bottom { get { return minExtent.y; } }
    public float Left { get { return minExtent.x; } }
    public float Right { get { return maxExtent.x; } }
    public float Front { get { return maxExtent.z; } }
    public float Back { get { return minExtent.z; } }

    //public AABB(myVector3 min, myVector3 max) //Class constructor
    //{ minExtent = min; maxExtent = max; }

    public void calculateBounds() //Uses the vertices of the object's mesh to determine the bounds of the object and stores the result in min and max extent
    {
        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //We get a copy of all the vertices (this is NOT efficient, but for the sake of understanding we're doing it like this)
        myVector3[] ModelSpaceVertices = myVector3.ToMyVector3(MF.mesh.vertices);

        minExtent = myVector3.ToMyVector3(gameObject.transform.position); //Obtains object's centre as starting values for min and max extent to ensure vertices are outside of these starting values
        maxExtent = myVector3.ToMyVector3(gameObject.transform.position);

        /*if (gameObject.name == "Floor")
        {
            Debug.Log("Floor:\n" +
                        "MinExt: " + minExtent.x + ", " + minExtent.y + ", " + minExtent.z + "\n" +
                        "MaxExt: " + maxExtent.x + ", " + maxExtent.y + ", " + maxExtent.z);
        }*/
        myVector3 objPos = myVector3.ToMyVector3(gameObject.transform.position);
        myVector3 objScale = myVector3.ToMyVector3(gameObject.transform.lossyScale);
        foreach (myVector3 vertex in ModelSpaceVertices) //Cycles through each vertex of the object's mesh to find the objects bounds
        {
            vertex.x *= objScale.x;
            vertex.y *= objScale.y;
            vertex.z *= objScale.z;
            vertex.x += objPos.x; //* objScale.x;
            vertex.y += objPos.y; //* objScale.y;
            vertex.z += objPos.z; //* objScale.z;
            if (vertex.x < minExtent.x) { minExtent.x = vertex.x;}
            if (vertex.x > maxExtent.x) { maxExtent.x = vertex.x;}
            if (vertex.y < minExtent.y) { minExtent.y = vertex.y;}
            if (vertex.y > maxExtent.y) { maxExtent.y = vertex.y;}
            if (vertex.z < minExtent.z) { minExtent.z = vertex.z;}
            if (vertex.z > maxExtent.z) { maxExtent.z = vertex.z;}
            if (gameObject.name == "Floor")
            {
                Debug.Log("Floor:\n" +
                            "Vertex: " + vertex.x + ", " + vertex.y + ", " + vertex.z + "\n" +
                            "MinExt: " + minExtent.x + ", " + minExtent.y + ", " + minExtent.z + "\n" +
                            "MaxExt: " + maxExtent.x + ", " + maxExtent.y + ", " + maxExtent.z);
            }
        }
        self = this;
        return;
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

    public static myVector3 IntersectsAdjustment(AABB _self, AABB collider)
    {
        myVector3 Adjuster = myVector3.Zero;
        if (!(collider.Left > _self.Right)) { Adjuster.x += collider.Left - _self.Right; }
        if (!(collider.Right < _self.Left)) { Adjuster.x += collider.Right - _self.Left; }
        if (!(collider.Bottom > _self.Top)) { Adjuster.y += 1.25f*(_self.Top - collider.Bottom); } //Multiplier used here due to sinking that can be caused by gravity
        else if (!(collider.Top < _self.Bottom)) { Adjuster.y += _self.Bottom - collider.Top; }
        if (!(collider.Back > _self.Front)) { Adjuster.z += collider.Back - _self.Front; }
        if (!(collider.Front < _self.Back)) { Adjuster.z += collider.Front - _self.Back; }
        //Debug.Log("Floor Top: " + _self.Top + "\nPlayer Bottom: " + collider.Bottom + "\nAdjustment: " + Adjuster.y);
        return Adjuster;                  
    }

    public void Position(myVector3 change) //Used when a dynamic object is moved, applies the change in move to the AABB so that the bounds don't need to be recalculated
    { minExtent += change; maxExtent += change; }

    // Start is called before the first frame update
    void Start()
    {
        calculateBounds(); //Determines gameObjects AABB bounds and stores them in minExtent and maxExtent
        if (isStatic) { collisionList.staticColliders.add(self); } //Stores a reference to the AABB in the scene's collisionController under the static category
        else { collisionList.dynamicColliders.add(self); } //Stores a reference to the AABB in the scene's collisionController under the dynamic category
        colliders.AddRange(collisionList.dynamicColliders.axisAligned); //Obtains a reference to all dynamic AABB's in the scene
        //Removes own AABB from list of AABBs to prevent detecting a collision with itself
        AABB _collider = null;
        foreach (AABB collider in colliders)
        { if (collider.minExtent == self.minExtent && collider.maxExtent == self.maxExtent) { _collider = collider; } }
        colliders.Remove(_collider);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (recalculateBounds) { calculateBounds(); recalculateBounds = false; } //If the bounds of the AABB need to be recalculated, recalculates the bounds and unflags the need to recalculate
        foreach (AABB collider in colliders) //For each dynamic ABBA collider in the collider list...
        {
            //Debug.Log(collider.gameObject.name + gameObject.name);
            //Debug.Log(self.Top + ", " + self.Bottom);
            if (Intersects(self, collider)) //If the collider intersects the gameObject then...
            {
                myVector3 change = IntersectsAdjustment(self, collider); //Calculates how far the collider has entered
                //Debug.Log("collision: " + change.x + ", " + change.y + ", " + change.z);
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
                    //Debug.Log("Force: " + colVelocity.x + ", " + colVelocity.y + ", " + colVelocity.z);
                    colRigidBody.Velocity -= colVelocity; //Imparts the reactionary velocity onto the collider
                }
                //if (collider.gameObject.GetComponent<myPlayerController>() != null && change.y != 0); //If the collider has the player controller script and the change is on the y-axis...
                //{ collider.gameObject.GetComponent<myPlayerController>().isFalling = false; Debug.Log("Hi"); } //Updates the player controller script to log that the player is on solid ground
            }
        }
    }
}
