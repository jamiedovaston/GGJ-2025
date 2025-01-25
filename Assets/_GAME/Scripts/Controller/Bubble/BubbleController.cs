using System;
using UnityEngine;

public abstract class BubbleController : MonoBehaviour
{
    Rigidbody m_RB;

    private Entity_Collisions m_Collisions;

    public virtual void Initialise()
    {
        m_RB = GetComponent<Rigidbody>();

        Debug.Log("Initialise bubble!");
        m_Collisions = gameObject.AddComponent<Entity_Collisions>();

        m_Collisions.OnEnter += BubbleCollisionsEnter;
    }

    protected virtual void BubbleCollisionsEnter(Collision collision)
    {
        Debug.Log("Collision!");
        m_RB.isKinematic = true;
    }
}
