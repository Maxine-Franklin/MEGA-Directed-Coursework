using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionController : MonoBehaviour //Re-add Monobehaviour if switching to a grid system
{
    public Collider dynamicColliders = new Collider(new List<AABB>()); //Dynamic Colliders are colliders that move within the scene
    public Collider staticColliders = new Collider(new List<AABB>()); //Static Colliders are colliders that remain stationary (they do not need to check for collisions with other static colliders)
    public bool buildColliders = true; //~Could be set to a 2D array later to enable and disables colliders in a grid system

    public struct Collider
    {
        public Collider(/*AABB[] _AABB*/List<AABB> _AABB) { _axisAligned = _AABB; } //Constructor for class
        private List<AABB> _axisAligned; //A list that all Axis Aligned Bounding Boxes in the collider's category
        public AABB[] axisAligned { get { return _axisAligned.ToArray(); } } //Used to obtain an array of all AABB colliders in the collider's category
        public void add(AABB var) { _axisAligned.Add(var); } //Used to add an AABB collider to the list of AABB colliders in the collider's category
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (buildColliders) //If collisions need to be built/rebuilt then...
        {
            foreach (AABB collider in staticColliders.axisAligned) //For each static AABB collider...
            { collider.buildCollisions(); } //Build collisions list
            foreach (AABB collider in dynamicColliders.axisAligned) //For each dynamic AABB collider...
            { collider.buildCollisions(); } //Build collisions list
            buildColliders = false; //Prevents collisions list constantly being built
        }
        //If collision grid system is added, check for if player is within the grid, or which grid the player is within and enable collisions for that grid (have an array of lists for grids) 
    }
}


//Note for PP, buildColliders is done in Fixed Updates as otherwise the collision lists stored in each collider may be incomplete leading to collisions not occuring