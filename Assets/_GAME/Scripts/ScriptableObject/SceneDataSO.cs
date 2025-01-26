using UnityEngine;

[CreateAssetMenu(menuName = "JD/Scene/Scene", fileName = "scene_NAME")]
public class SceneDataSO : JDDataAssets<SceneDataSO>
{
    [SerializeField] private int _buildIndex;
    public int buildIndex { get { return _buildIndex; } }

    public static SceneDataSO[] data = null;
    public static SceneDataSO GetLevelByBuildIndex(int index)
    {
        if(data == null)
        {
            data = Resources.LoadAll<SceneDataSO>("Scenes");
        }

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].buildIndex == index)
            {
                return data[i];
            }
        }

        Debug.LogError($"No scene found with build index : {index}");
        return null;
    }

    public static SceneDataSO GetLevelByID(string _id)
    {
        if (data == null)
        {
            data = Resources.LoadAll<SceneDataSO>("Scenes");
        }

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].name == _id)
            {
                return data[i];
            }
        }

        Debug.LogError($"No scene found with build index : {_id}");
        return null;
    }
}
