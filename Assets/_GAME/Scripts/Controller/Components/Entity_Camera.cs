using UnityEngine;
using Unity.Cinemachine;

public class Entity_Camera : MonoBehaviour
{
    private CinemachineCamera m_Camera;

    public void Init(EntitySO _data, CinemachineCamera _camera)
    {
        m_Camera = _camera;
    }

    public Transform GetParent() => m_Camera.transform.parent;
}