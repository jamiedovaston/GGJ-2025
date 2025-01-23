using UnityEngine;

[CreateAssetMenu(menuName = "JD/Character/Entity_Movement", fileName = "movement_NAME")]
public class MovementSO : ScriptableObject
{
    [SerializeField] private float _acceleration;
    public float acceleration { get { return _acceleration; } }

    [SerializeField] private float _speed;
    public float speed { get { return _speed; } }

}