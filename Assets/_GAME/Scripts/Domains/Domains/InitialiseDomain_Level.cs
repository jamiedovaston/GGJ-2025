using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitialiseDomain_Level : InitialiseDomain
{
    Input_Player m_Input;
    LevelDataSO m_Data;

    private IPlayerSpawnable _playerSpawner;

    private float m_RestartTimer;
    private const float RESTART_TIME = 3.0f;
    private bool m_Restarting = false;

    public override void Initialise(SceneDataSO data)
    {
        m_Data = data as LevelDataSO;
        m_Input = new Input_Player();

        _playerSpawner = GetComponent<IPlayerSpawnable>();

        Level_Start();
    }

    public void Level_Start()
    {
        Player player = Instantiate(Resources.Load<GameObject>("Entities/Player/Player"),
            _playerSpawner.GetSpawnLocation(), Quaternion.identity).GetComponent<Player>();

        player.Initialise(EntitySO.GetPlayerEntityData(), m_Input, m_Data.bubbleCount);

        m_Input.System.Restart.canceled += Input_CancelRestart;
    }

    private void Update()
    {
        if(m_Input.System.Restart.IsPressed())
        {
            m_RestartTimer -= Time.deltaTime;

            //update restart UI

            if (m_RestartTimer <= 0.0f && !m_Restarting)
            {
                m_Restarting = true;
                Level_Restart();
            }
        }
    }

    private void Input_CancelRestart(InputAction.CallbackContext context) => m_RestartTimer = RESTART_TIME;

    public async void Level_Restart()
    {
        m_Input.System.Restart.canceled -= Input_CancelRestart;
        await SceneToolManager.ChangeScene(m_Data.name);
    }
}
