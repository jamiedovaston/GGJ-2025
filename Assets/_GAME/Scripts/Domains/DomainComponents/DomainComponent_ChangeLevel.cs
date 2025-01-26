using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class DomainComponent_ChangeLevel : MonoBehaviour
{
    private Tool_Collisions m_Collisions;

    private void OnEnable()
    {
        m_Collisions.OnEnter += CollisionChangeLevel;
    }

    private void OnDisable()
    {
        m_Collisions.OnEnter -= CollisionChangeLevel;
    }

    private void Awake()
    {
        m_Collisions = gameObject.AddComponent<Tool_Collisions>();
    }

    protected abstract void CollisionChangeLevel(Collision collision);
}

