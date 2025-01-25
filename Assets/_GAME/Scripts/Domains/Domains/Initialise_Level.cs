using UnityEngine;

public class Initialise_Level : InitialiseDomain
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
        EntityController instance = Instantiate(Resources.Load<GameObject>("Entities/Player/Player"),
            _playerSpawner.GetSpawnLocation(), Quaternion.identity).GetComponent<EntityController>();

        instance.Init(EntitySO.GetPlayerEntityData());
    }
}
