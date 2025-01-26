using UnityEngine;

public class DomainComponent_NextLevel : DomainComponent_ChangeLevel
{
    [SerializeField] private string m_ID;

    protected override async void CollisionChangeLevel(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            await SceneToolManager.ChangeScene(m_ID);
    }
}

