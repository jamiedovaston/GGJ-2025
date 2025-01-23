using UnityEngine.InputSystem;
using UnityEngine;
using System;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody))]
public class EntityController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private MovementSO m_MovementData;

    private Input_Movement m_Input;
    private Entity_Movement m_Movement;

    private void Awake()
    {
        // temp
        Init();
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody>();

        m_Input = new Input_Movement();

        m_Movement = gameObject.AddComponent<Entity_Movement>();
        m_Movement.Init(m_MovementData, rb);

        m_Input.Enable();
        m_Input.Player.Move.performed += Input_MovePerformed;
        m_Input.Player.Move.canceled += Input_MoveCanceled;
    }

    private void Input_MovePerformed(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();

        if(m_Movement != null && m_Movement.isActiveAndEnabled)
        {
            m_Movement.SetInMove(axis);
        }
    }

    private void Input_MoveCanceled(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();

        if (m_Movement != null && m_Movement.isActiveAndEnabled)
        {
            m_Movement.SetInMove(axis);
        }
    }
}
