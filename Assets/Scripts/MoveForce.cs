using UnityEngine;
using UnityEngine.Rendering;

public class MoveForce : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidademax = 5;
    public float forcaPulo  = 5;
    public float tempoPulo = 2;
    Rigidbody2D rb;
    bool podepular = true; //isGrounded
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimento = Input.GetAxisRaw("Horizontal") * velocidade;
        bool pulo = Input.GetAxisRaw("Jump") > 0;
        rb.AddForce(new Vector2(movimento, 0));

        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidademax, velocidademax);

        if (pulo && podepular)
        {
            rb.AddForce(new Vector2(0, forcaPulo));
            podepular = false;
            Invoke("ResetaPulo", tempoPulo);
        }

        /*if (rb.linearVelocity.x >= velocidademax)
        {
            rb.linearVelocityX = velocidademax;
        }
        if (rb.linearVelocity.x <= -velocidademax)
        {
            rb.linearVelocityX = -velocidademax;
        }*/
    }

    void ResetaPulo()
    {
        podepular = true;
    }
}
