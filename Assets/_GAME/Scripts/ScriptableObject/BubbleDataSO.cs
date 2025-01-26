using UnityEngine;

[CreateAssetMenu(menuName = "JD/Bubbles/Bubble", fileName = "bubble_NAME")]
public class BubbleDataSO : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [SerializeField] private GameObject _prefab;
    public GameObject Prefab { get { return _prefab; } }

    [SerializeField] private Color _color;
    public Color Color { get { return _color; } }

    public static BubbleDataSO[] instance = null;

    public static BubbleDataSO[] GetBubbles()
    {
        if(instance == null)
        {
            instance = Resources.LoadAll<BubbleDataSO>("Bubbles");
        }

        return instance;
    }
}