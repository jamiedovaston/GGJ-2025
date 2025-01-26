using UnityEngine;

public class Entity_Jump : MonoBehaviour
{
    private EntitySO m_Data;
    private Tool_Collisions m_Collisions;
    private Rigidbody rb;
    public bool IsGrounded { get => isGrounded; }
    private bool isGrounded;

    public void Init(EntitySO _data, Tool_Collisions _collisions, Rigidbody _rb)
    {
        m_Data = _data;
        m_Collisions = _collisions;
        rb = _rb;

        m_Collisions.OnEnter += CollisionEnter;
        m_Collisions.OnExit += CollisionExit;
    }

    private void CollisionExit()
    {
        isGrounded = false;
    }

    private void CollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
            if (angle < 45.0f)
            {
                isGrounded = true;
            }
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * m_Data.jumpForce, ForceMode.Impulse);
            isGrounded = false;
            SoundManager.PlaySound(SoundType.JUMP);
        }
    }
}
