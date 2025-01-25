using System;
using UnityEngine;

public class Entity_Collisions : MonoBehaviour
{
    public event Action<Collision> OnEnter;
    public event Action OnExit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
            OnEnter?.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnExit?.Invoke();
    }
}