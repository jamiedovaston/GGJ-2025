using UnityEngine;

public class BubbleController_Red : BubbleController
{
    private Entity_Collisions m_Collisions;
    public float m_ExplosionForce = 200.0f;

    public override void Initialise()
    {
        base.Initialise();

        m_Collisions = gameObject.AddComponent<Entity_Collisions>();

        m_Collisions.OnEnter += BubbleCollisionsEnter;
    }

    private void BubbleCollisionsEnter(Collision collision)
    {
        if(!m_RB.isKinematic)
            m_RB.isKinematic = true;

        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player!");

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            rb.AddExplosionForce(m_ExplosionForce, transform.position, 3.0f, m_ExplosionForce);
        }
    }
}
