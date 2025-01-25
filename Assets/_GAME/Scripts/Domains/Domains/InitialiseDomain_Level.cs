using System;
using UnityEngine;

public class InitialiseDomain_Level : InitialiseDomain
{
    SceneDataSO m_Data;

    private IPlayerSpawnable _playerSpawner;

    public override void Initialise(SceneDataSO data)
    {
        m_Data = data;

        _playerSpawner = GetComponent<IPlayerSpawnable>();

        Level_Start();
    }

    public void Level_Start()
    {
        Player player = Instantiate(Resources.Load<GameObject>("Entities/Player/Player"),
            _playerSpawner.GetSpawnLocation(), Quaternion.identity).GetComponent<Player>();

        player.Initialise(EntitySO.GetPlayerEntityData());
    }
}
