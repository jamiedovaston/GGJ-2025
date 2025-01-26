using System;
using UnityEngine;

public abstract class BubbleController : MonoBehaviour
{
    private Tool_Collisions m_Collisions;
    protected Rigidbody m_RB;

    public virtual void Initialise()
    {
        m_RB = GetComponent<Rigidbody>();

        m_Collisions = gameObject.AddComponent<Tool_Collisions>();

        m_Collisions.OnEnter += BubbleCollisionsEnter;
        Debug.Log("Initialise bubble!");
    }

    public void StopMovement()
    {
        if (!m_RB.isKinematic)
            m_RB.isKinematic = true;
    }

    protected abstract void BubbleCollisionsEnter(Collision collision);
}

