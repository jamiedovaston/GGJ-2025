using System;
using UnityEngine;

public abstract class BubbleController : MonoBehaviour
{
    private Entity_Collisions m_Collisions;
    protected Rigidbody m_RB;

    public virtual void Initialise()
    {
        m_RB = GetComponent<Rigidbody>();

        m_Collisions = gameObject.AddComponent<Entity_Collisions>();

        m_Collisions.OnEnter += BubbleCollisionsEnter;

        BubbleGunController.OnBubbleStop += StopMovement;
        Debug.Log("Initialise bubble!");
    }

    public void StopMovement()
    {
        if (!m_RB.isKinematic)
            m_RB.isKinematic = true;
    }

    protected abstract void BubbleCollisionsEnter(Collision collision);
}

