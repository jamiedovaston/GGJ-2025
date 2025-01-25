using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleGunController : MonoBehaviour, IBubbleable
{
    Input_Player m_Input;

    BubbleDataSO[] m_BubbleData;

    [SerializeField] private Transform m_Barrel;

    private int m_Index;

    public void Init(Input_Player _input)
    {
        m_BubbleData = BubbleDataSO.GetBubbles();

        m_Input = _input;

        Debug.Log("Initialised Gun!");

        m_Input.Weapon.Toggle.performed += Input_TogglePerformed;
        m_Input.Weapon.Fire.performed += Input_FirePerformed;
    }

    private void OnDisable()
    {
        m_Input.Weapon.Toggle.performed -= Input_TogglePerformed;
        m_Input.Weapon.Fire.performed -= Input_FirePerformed;
    }

    private void Input_FirePerformed(InputAction.CallbackContext context) => Fire();

    private void Input_TogglePerformed(InputAction.CallbackContext context) => Toggle();

    public void Toggle()
    {
        if (m_Index + 1 >= m_BubbleData.Length) m_Index = 0;
        else m_Index++;

        //update gun, animate, etc.
    }

    public void Fire()
    {
        Debug.Log("Fire");
        BubbleController bubble = Instantiate(m_BubbleData[m_Index].Prefab, m_Barrel.position, m_Barrel.rotation).GetComponent<BubbleController>();
        bubble.Initialise();
        bubble.GetComponent<Rigidbody>().AddForce(m_Barrel.forward * 5.0f, ForceMode.Impulse);
    }
}