using UnityEngine;

[CreateAssetMenu(menuName = "JD/Scene/Levels", fileName = "scene_level_NAME")]
public class LevelDataSO : SceneDataSO
{
    [SerializeField] private string _levelName;
    public string levelName { get { return _levelName; } }

    [SerializeField] private int _bubbleCount;
    public int bubbleCount { get { return _bubbleCount; } }
}

public abstract class JDDataAssets<T> : ScriptableObject where T : class
{

}
