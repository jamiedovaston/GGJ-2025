using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Collisions : MonoBehaviour
{
    public Action<Collision> OnEnter;
    public Action OnExit;

    private HashSet<Collider> activeCollisions = new HashSet<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Debug.Log("Collision!");
            activeCollisions.Add(collision.collider);
            OnEnter?.Invoke(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            activeCollisions.Remove(collision.collider);
            if (activeCollisions.Count == 0)
            {
                OnExit?.Invoke();
            }
        }
    }
}
