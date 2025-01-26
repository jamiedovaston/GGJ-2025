using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BubbleGunController : MonoBehaviour
{
    public static Action OnBubbleStop;

    Input_Player m_Input;
    BubbleDataSO[] m_BubbleData;
    [SerializeField] private Transform m_Barrel;
    [SerializeField] private TMP_Text m_BubbleText;
    [SerializeField] private TMP_Text m_AmmoText;

    private int m_Index;

    private int m_Ammo = 0;

    public void Init(Input_Player _input, int _ammo)
    {
        m_BubbleData = BubbleDataSO.GetBubbles();

        m_Input = _input;

        Debug.Log("Initialised Gun!");

        m_Ammo = _ammo;

        m_Input.Weapon.Toggle.performed += Input_TogglePerformed;
        m_Input.Weapon.Fire.performed += Input_FirePerformed;

        m_Input.Weapon.BubbleStop.performed += Input_BubbleStopPerformed;

        m_BubbleText.text = m_BubbleData[m_Index].Name;
        m_AmmoText.text = $"Ammo: {m_Ammo}";
    }

    private void OnDisable()
    {
        m_Input.Weapon.Toggle.performed -= Input_TogglePerformed;
        m_Input.Weapon.Fire.performed -= Input_FirePerformed;
        m_Input.Weapon.BubbleStop.performed -= Input_BubbleStopPerformed;
    }

    private void Input_FirePerformed(InputAction.CallbackContext context) => Fire();

    private void Input_TogglePerformed(InputAction.CallbackContext context) => Toggle();

    private void Input_BubbleStopPerformed(InputAction.CallbackContext context) => BubbleStop();

    private void BubbleStop()
    {
        OnBubbleStop?.Invoke();
    }

    public void Toggle()
    {
        if (m_Index + 1 >= m_BubbleData.Length) m_Index = 0;
        else m_Index++;

        //update gun, animate, etc.
        m_BubbleText.text = m_BubbleData[m_Index].Name;
    }

    public void Fire()
    {
        Debug.Log("Fire");
        if(m_Ammo > 0)
        {
            m_Ammo--;
            BubbleController bubble = Instantiate(m_BubbleData[m_Index].Prefab, m_Barrel.position, m_Barrel.rotation).GetComponent<BubbleController>();
            bubble.Initialise();
            bubble.GetComponent<Rigidbody>().AddForce(m_Barrel.forward * 5.0f, ForceMode.Impulse);
            m_AmmoText.text = $"Ammo: {m_Ammo}";
        }
    }
}