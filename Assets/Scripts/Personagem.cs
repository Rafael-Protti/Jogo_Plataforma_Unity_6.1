using JetBrains.Rider.Unity.Editor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidadeMax = 5;
    public float puloForca = 10;
    public Transform groundCheck;
    public float rayCastDistancia = 0.6f;
    bool puloDisponivel = true;
    Rigidbody2D rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>(); //transform. é redundante aqui.
    }
    void Update()
    {
        //lógica do movimento
        float horizontal = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;

        Vector2 movimento = new Vector2(horizontal, 0);
        
        rb.linearVelocity += movimento;
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidadeMax, velocidadeMax);

        //if (movimento.x == 0)
        //{
        //    rb.linearVelocityX = 0;
        //}

        //lógica do pulo

        //Forma 3 de fazer o pulo: Raycast

        puloDisponivel = Physics2D.Raycast(transform.position, Vector2.down, rayCastDistancia, LayerMask.GetMask("Ground"));

        //Forma 2 de fazer o pulo: verificando sobreposição de colisões.
        /*puloDisponivel = Physics2D.OverlapBox(groundCheck.position, groundCheck.GetComponent<BoxCollider2D>().bounds.size, 0, LayerMask.GetMask("Ground"));*/

        bool pulo = Input.GetButtonDown("Jump");

        if (pulo && puloDisponivel)
        {
            rb.AddForce(new Vector2(0, puloForca), ForceMode2D.Impulse);
            puloDisponivel = false;
        }

    }
    /*private void OnCollisionEnter2D(Collision2D collision) //Forma 1 de fazer o pulo: COLISÕES
    {
        //if (collision.gameObject.layer == 6)
        //if (collision.gameObject.layer == LayerMask.GetMask("Ground"))
        if (collision.gameObject.layer == Constraints.layerGround) //Esse e os dois modos acima funcionam iguais.
        {
            puloDisponivel = true;    
        }
        //para colisões com sólidos
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //para coleta de itens 
    }*/
}
