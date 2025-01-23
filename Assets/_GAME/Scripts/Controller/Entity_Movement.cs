using System.Collections;
using UnityEngine;

public class Entity_Movement : MonoBehaviour
{
    private MovementSO data;
    private Rigidbody rb;
    private Vector2 m_InMove;
    private Coroutine m_C_Move;
    public float accelerationTime = 0.1f; // Acceleration time in seconds

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(MovementSO _data, Rigidbody _rb)
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
        while (true)
        {
            if (m_InMove != Vector2.zero)
            {
                Vector3 targetVelocity = (transform.forward * m_InMove.y) + (transform.right * m_InMove.x);
                targetVelocity = targetVelocity.normalized * data.speed;

                Vector3 currentVelocity = rb.linearVelocity;
                Vector3 velocityChange = targetVelocity - currentVelocity;

                rb.AddForce(velocityChange * data.acceleration, ForceMode.Acceleration);
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
