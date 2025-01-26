using UnityEngine;

public class BubbleController_Red : BubbleController
{
    public override void Initialise()
    {
        base.Initialise();
    }

    protected override void BubbleCollisionsEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PhysicsObject"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}