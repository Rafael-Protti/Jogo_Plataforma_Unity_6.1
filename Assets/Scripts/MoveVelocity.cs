using UnityEngine;

public class MoveVelocity : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal") * velocidade;
        rb.linearVelocity = new Vector2 (movimento, 0);
    }
}
