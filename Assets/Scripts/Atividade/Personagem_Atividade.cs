using UnityEngine;

public class Personagem_Atividade : MonoBehaviour
{
    public float velocidade = 5; //Dita a velocidade do jogador.
    public float velocidade_max = 5; //Dita a velocidade máxima que o jogador pode alcançar.
    public float pulo_forca = 300; //A força do pulo do jogador.
    Rigidbody2D rb; //Física do jogador. NÃO ESQUECER DE COLOCAR 2D EM PROJETOS 2D!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! (tinha esquecido)
    bool pular = true; // Dita se o jogador pode pular ou não.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal") * velocidade;
        bool pulo = Input.GetAxisRaw("Jump") > 0;

        rb.AddForce(new Vector2(movimento, 0));

        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidade_max, velocidade_max);

        if (pular && pulo)
        {
            rb.AddForce(new Vector2(0, pulo_forca));
            pular = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Chao") == true || collision.gameObject.name.Contains("Bloco") == true || collision.gameObject.name.Contains("Horizontal") == true || collision.gameObject.name.Contains("Vertical") == true)
        {
            pular = true;
        }
    }
}
