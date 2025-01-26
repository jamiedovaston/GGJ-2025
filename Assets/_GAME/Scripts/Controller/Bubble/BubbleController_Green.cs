using UnityEngine;

public class BubbleController_Green : BubbleController
{
    public float m_ExplosionForce = 200.0f;

    public override void Initialise()
    {
        base.Initialise();
        BubbleGunController.OnBubbleStop += StopMovement;
    }

    protected override void BubbleCollisionsEnter(Collision collision)
    {
        StopMovement();

        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if(rb.linearVelocity.y <= 0.0f)
                rb.AddExplosionForce(m_ExplosionForce, transform.position, 3.0f, m_ExplosionForce);
        }
    }
}
