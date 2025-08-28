using JetBrains.Rider.Unity.Editor;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Personagem : MonoBehaviour
{
    Animator animator;
    Transform projetil;
    public float velocidade = 10;
    public float velocidadeMax = 5;
    public float puloForca = 10;
    public Transform groundCheck;
    public float rayCastDistancia = 0.6f;
    public bool ativadoProjetil = true;
    bool puloDisponivel = true;
    bool estaOlhandoDireita = true;
    Rigidbody2D rb;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>(); //transform. é redundante aqui.
        if (ativadoProjetil)
        {
            projetil = GameObject.Find("Kamehameha").transform;
        }
    }
    void Update()
    {

        //lógica do movimento
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 1)
        {
            transform.eulerAngles = new Vector2(0, 0);
            estaOlhandoDireita = true;
        }
        if (horizontal == -1)
        {
            transform.eulerAngles = new Vector2(0, 180);
            estaOlhandoDireita = false;
        }

        //if (movimento.x == 0)
        //{
        //    rb.linearVelocityX = 0;
        //}

        //lógica do tiro

        bool tiro = Input.GetKeyDown(KeyCode.R);
        if (tiro)
        {
            Transform instanciado = Instantiate(projetil);
            instanciado.position = transform.position;
            instanciado.GetComponent<Projetil>().enabled = true;
            if (estaOlhandoDireita == true)
            {
                instanciado.GetComponent<Projetil>().direcao = new Vector2(1, 0);
            }
            else
            {
                instanciado.GetComponent<Projetil>().direcao = new Vector2(-1, 0);
            }
        }

        horizontal = horizontal * velocidade * Time.deltaTime;

        Vector2 movimento = new Vector2(horizontal, 0);

        rb.linearVelocity += movimento;
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidadeMax, velocidadeMax);

        if (animator.GetBool("estaPulando") == false) //esse IF não é necessário para esse script
        {
            if (rb.linearVelocityX >= 3 || rb.linearVelocityX <= -3)
            {
                animator.SetBool("estaCorrendo", true);
            }
            else
            {
                animator.SetBool("estaCorrendo", false);
            }

            if (rb.linearVelocityX < 0.1f && rb.linearVelocityX > -0.1f)
            {
                animator.SetBool("estaAndando", false);
            }
            else
            {
                animator.SetBool("estaAndando", true);
            }
        }

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

        animator.SetBool("estaPulando", !puloDisponivel);

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
