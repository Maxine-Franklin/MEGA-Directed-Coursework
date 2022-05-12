using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionController : MonoBehaviour //Re-add Monobehaviour if switching to a grid system
{
    public Collider dynamicColliders = new Collider(new List<AABB>()); //Dynamic Colliders are colliders that move within the scene
    public Collider staticColliders = new Collider(new List<AABB>()); //Static Colliders are colliders that remain stationary (they do not need to check for collisions with other static colliders)

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
        //If collision grid system is added, check for if player is within the grid, or which grid the player is within and enable collisions for that grid (have an array of lists for grids) 
    }
}
