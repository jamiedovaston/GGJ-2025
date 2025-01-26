using UnityEngine;

public class BubbleController_Blue : BubbleController
{
    public override void Initialise()
    {
        base.Initialise();
        BubbleGunController.OnBubbleStop += StopMovement;
    }

    protected override void BubbleCollisionsEnter(Collision collision)
    {
        StopMovement();
    }
}
