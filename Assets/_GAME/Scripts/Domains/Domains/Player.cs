using System;
using UnityEngine;

public class Player : Entity
{
    private Input_Player m_Input;

    [SerializeField] private EntityController m_EntityController;

    [SerializeField] private BubbleGunController m_BubbleGunController;

    internal void Initialise(EntitySO entitySO, Input_Player _input, int _ammo)
    {
        m_Input = _input;

        m_EntityController.Init(entitySO, m_Input);
        m_BubbleGunController.Init(m_Input, _ammo);
    }
}