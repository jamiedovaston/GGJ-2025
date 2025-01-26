using UnityEngine;

public class BubbleController_Blue : BubbleController
{
    public override void Initialise()
    {
        base.Initialise();
    }

    protected override void BubbleCollisionsEnter(Collision collision)
    {
        StopMovement();
    }
}
