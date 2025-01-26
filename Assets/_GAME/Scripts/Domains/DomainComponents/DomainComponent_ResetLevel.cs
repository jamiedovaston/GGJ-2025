using UnityEngine;
using UnityEngine.SceneManagement;

public class DomainComponent_ResetLevel : DomainComponent_ChangeLevel
{
    protected override void CollisionChangeLevel(Collision collision)
    {
        OnSceneLoad?.Invoke(SceneDataSO.GetLevelByBuildIndex(SceneManager.GetActiveScene().buildIndex).name);
    }
}
