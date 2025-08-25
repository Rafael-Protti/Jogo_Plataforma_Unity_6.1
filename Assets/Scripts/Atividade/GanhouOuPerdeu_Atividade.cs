using UnityEngine;

public class GanhouOuPerdeu_Atividade : MonoBehaviour
{
    Vector2 posicao_inicial;
    float caiu = -1.5f;
    float ganhou = 105;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicao_inicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= caiu)
        {
            Debug.Log("Você caiu e perdeu todas as suas moedas!");
            ColetarMoedas_Atividade.moedas = 0;
            Debug.Log("Você caiu e perdeu todas as suas moedas!");
            transform.position = posicao_inicial;
        }

        if (transform.position.x >= ganhou)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("Parabéns! Você ganhou!");
            Debug.Log("Você conseguiu coletar " + ColetarMoedas_Atividade.moedas + " moedas!");
        }
    }
}
