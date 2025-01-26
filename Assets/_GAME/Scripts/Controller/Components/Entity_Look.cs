using Unity.VisualScripting;
using UnityEngine;

public class Entity_Look : MonoBehaviour
{
    private EntitySO m_Data;
    private Entity_Camera m_Camera;

    private float rotationX;

    public void AdjustLook(Vector2 change)
    {
        rotationX += -change.y * m_Data.ySensitivity;
        rotationX = Mathf.Clamp(rotationX, -m_Data.xMax, m_Data.xMax);
        m_Camera.GetParent().localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, change.x * m_Data.xSensitivity, 0);
    }

    public void Init(EntitySO _data, Entity_Camera _camera)
    {
        m_Data = _data;
        m_Camera = _camera;
    }
}
