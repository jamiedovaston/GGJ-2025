using System;
using UnityEngine;

public class Player : Entity
{
    private Input_Player m_Input;

    [SerializeField] private EntityController m_EntityController;

    [SerializeField] private BubbleGunController m_BubbleGunController;

    internal void Initialise(EntitySO entitySO)
    {
        m_Input = new Input_Player();

        m_EntityController.Init(entitySO, m_Input);
        m_BubbleGunController.Init(m_Input);
    }
}