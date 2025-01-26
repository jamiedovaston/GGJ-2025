using UnityEngine.InputSystem;
using UnityEngine;
using System;
using UnityEngine.Windows;
using Unity.Cinemachine;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody))]
public class EntityController : MonoBehaviour
{
    private Rigidbody m_RB;

    private EntitySO m_Data;

    private Input_Player m_Input;

    private Entity_Movement m_Movement;
    private Entity_Camera m_Camera;
    private Entity_Look m_Look;
    private Entity_Jump m_Jump;
    private Tool_Collisions m_Collisions;

    [SerializeField] private CinemachineCamera m_CinemachineVirtualCamera;

    public void Init(EntitySO _data, Input_Player _input)
    {
        m_RB = GetComponent<Rigidbody>();

        m_Input = _input;

        m_Data = _data;

        m_Movement = gameObject.AddComponent<Entity_Movement>();
        m_Look = gameObject.AddComponent<Entity_Look>();
        m_Camera = gameObject.AddComponent<Entity_Camera>();
        m_Jump = gameObject.AddComponent<Entity_Jump>();
        m_Collisions = gameObject.AddComponent<Tool_Collisions>();
        
        m_Movement.Init(m_Data, m_RB);
        m_Camera.Init(m_Data, m_CinemachineVirtualCamera);
        m_Look.Init(m_Data, m_Camera);
        m_Jump.Init(m_Data, m_Collisions, m_RB);

        m_Input.Enable();
        m_Input.Player.Move.performed += Input_MovePerformed;
        m_Input.Player.Move.canceled += Input_MoveCanceled;

        m_Input.Player.Look.performed += Input_LookPerformed;
        m_Input.Player.Look.canceled += Input_LookPerformed;

        m_Input.Player.Jump.performed += Input_JumpPerformed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnDisable()
    {
        m_Input.Player.Move.performed -= Input_MovePerformed;
        m_Input.Player.Move.canceled -= Input_MoveCanceled;

        m_Input.Player.Look.performed -= Input_LookPerformed;
        m_Input.Player.Look.performed -= Input_LookCanceled;

        m_Input.Player.Jump.performed -= Input_JumpPerformed;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
   
    private void Input_LookPerformed(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();

        if (m_Look != null && m_Look.isActiveAndEnabled)
        {
            m_Look.AdjustLook(axis);
        }
    }

    private void Input_LookCanceled(InputAction.CallbackContext context) { }

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

    private void Input_JumpPerformed(InputAction.CallbackContext context)
    {
        if(m_Jump != null && m_Jump.isActiveAndEnabled)
        {
            m_Jump.Jump();
        }
    }
}