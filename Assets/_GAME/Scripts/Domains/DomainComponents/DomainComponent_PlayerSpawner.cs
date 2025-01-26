using UnityEngine;

public class DomainComponent_PlayerSpawner : DomainComponent, IPlayerSpawnable
{
    [SerializeField] private Transform location;

    public Vector3 GetSpawnLocation()
    {
        return location.position;
    }
}
