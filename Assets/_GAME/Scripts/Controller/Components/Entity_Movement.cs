using System.Collections;
using UnityEngine;

public class Entity_Movement : MonoBehaviour
{
    private EntitySO data;
    private Rigidbody rb;
    private Vector2 m_InMove;
    private Coroutine m_C_Move;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(EntitySO _data, Rigidbody _rb)
    {
        data = _data;
        rb = _rb;
    }

    public void SetInMove(Vector2 _inMove)
    {
        if (m_InMove != _inMove)
        {
            m_InMove = _inMove;
        }

        if (m_C_Move == null)
        {
            m_C_Move = StartCoroutine(C_Move());
        }
    }

    private IEnumerator C_Move()
    {
        bool isGrounded;
        float time = 1.0f;
        while (time >= 0.0f)
        {
            isGrounded = GetComponent<Entity_Jump>().IsGrounded;
            time -= Time.fixedDeltaTime;

            if (m_InMove != Vector2.zero)
            {
                time = 1.0f;
                Vector3 targetVelocity = (transform.forward * m_InMove.y) + (transform.right * m_InMove.x);
                targetVelocity = targetVelocity.normalized * data.speed;

                Vector3 currentVelocity = rb.linearVelocity;
                Vector3 velocityChange = targetVelocity - new Vector3(currentVelocity.x, 0, currentVelocity.z);

                rb.AddForce(velocityChange * data.acceleration * (isGrounded? 1 : data.airControl), ForceMode.Acceleration);
            }
            else
            {
                Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                Vector3 newHorizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, 5.0f * Time.fixedDeltaTime);
                rb.linearVelocity = new Vector3(newHorizontalVelocity.x, rb.linearVelocity.y, newHorizontalVelocity.z);
            }
            yield return new WaitForFixedUpdate();
        }

        m_C_Move = null;
    }
}
