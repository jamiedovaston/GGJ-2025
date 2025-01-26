using System;
using UnityEngine;

public abstract class BubbleController : MonoBehaviour
{
    protected Rigidbody m_RB;

    public virtual void Initialise()
    {
        m_RB = GetComponent<Rigidbody>();

        Debug.Log("Initialise bubble!");
    }
}

