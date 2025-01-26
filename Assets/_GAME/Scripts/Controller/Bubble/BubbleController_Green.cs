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

        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (Vector3.Dot(collision.contacts[0].normal, Vector3.zero) <= 0.4)
            {
                rb.AddExplosionForce(m_ExplosionForce, transform.position, 3.0f, m_ExplosionForce);
                //Debug.Log("bounce");
            }
        }
        else
        {
            StopMovement();

        }
    }
}
