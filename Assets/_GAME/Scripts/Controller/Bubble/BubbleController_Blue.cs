using UnityEngine;

public class BubbleController_Blue : BubbleController
{
    private Entity_Collisions m_Collisions;

    public override void Initialise()
    {
        base.Initialise();

        m_Collisions = gameObject.AddComponent<Entity_Collisions>();

        m_Collisions.OnEnter += BubbleCollisionsEnter;
    }

    private void BubbleCollisionsEnter(Collision collision)
    {
        m_RB.isKinematic = true;
    }
}
