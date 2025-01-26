using UnityEngine;

[CreateAssetMenu(menuName = "JD/Character/Entity_Movement", fileName = "movement_NAME")]
public class EntitySO : ScriptableObject
{
    [SerializeField] private float _acceleration;
    public float acceleration { get { return _acceleration; } }

    [SerializeField] private float _speed;
    public float speed { get { return _speed; } }

    [SerializeField] private float _airControl;
    public float airControl { get { return _airControl; } }

    [SerializeField] private float _ySensitivity;
    public float ySensitivity { get { return _ySensitivity; } }

    [SerializeField] private float _xSensitivity;
    public float xSensitivity { get { return _xSensitivity; } }

    [SerializeField] private float _xMin;
    public float xMin { get { return _xMin; } }

    [SerializeField] private float _xMax;
    public float xMax { get { return _xMax; } }

    [SerializeField] private float _jumpForce;
    public float jumpForce { get { return _jumpForce; } }

    public static EntitySO player = null;

    public static EntitySO GetPlayerEntityData()
    {
        if(player == null)
        {
            player = Resources.Load<EntitySO>("Entities/Player/Data/entity_player");
        }

        return player;
    }
}