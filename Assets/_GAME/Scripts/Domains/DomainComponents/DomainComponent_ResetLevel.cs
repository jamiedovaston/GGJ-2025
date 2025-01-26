using UnityEngine;
using UnityEngine.SceneManagement;

public class DomainComponent_ResetLevel : DomainComponent_ChangeLevel
{
    protected override async void CollisionChangeLevel(Collision collision)
    {
        Debug.Log("Collision!");

        if(collision.gameObject.CompareTag("Player"))
            await SceneToolManager.ChangeScene(SceneDataSO.GetLevelByBuildIndex(SceneManager.GetActiveScene().buildIndex).name);
    }
}
