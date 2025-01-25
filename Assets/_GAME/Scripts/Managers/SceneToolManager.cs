using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneToolManager
{
    public static async Task ChangeScene(string _id)
    {
        SceneDataSO scene = Resources.Load<SceneDataSO>($"Levels/{_id}");

        if (scene == null)
        {
            Debug.LogError($"Scene with ID '{_id}' not found in 'Levels' resources.");
            return;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(scene.buildIndex);

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        InitialiseScene(scene);

        Debug.Log($"Scene '{scene.buildIndex}' loaded successfully.");

    }

    public static void InitialiseScene(SceneDataSO data)
    {
        InitialiseDomain util = GameObject.FindAnyObjectByType<InitialiseDomain>();
        util.Initialise(data);
    }
}
