using TMPro;
using UnityEngine;

public class GanhouOuPerdeu_Atividade : MonoBehaviour
{
    public int vida = 10;
    int vidamax;
    TextMeshProUGUI textoVida;
    TextMeshProUGUI textoGP;
    Vector2 posicao_inicial;
    float caiu = -1.5f;
    float ganhou = 105;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidamax = vida;
        textoVida = GameObject.Find("Text (TMP) 2").transform.GetComponent<TextMeshProUGUI>();
        textoGP = GameObject.Find("Text (TMP) 3").transform.GetComponent <TextMeshProUGUI>();
        posicao_inicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
            textoGP.text = "<color=red>Você PERDEU!!!!!!!";
        }
        if (vida > vidamax * 0.5)
        {
            textoVida.text = "<color=black> Vida: <color=green>" + vida + "</color>"; 
        }

        if (vida <= vidamax * 0.5 && vida > vidamax * 0.3)
        {
            textoVida.text = "<color=black> Vida: <color=yellow>" + vida + "</color>";
        }

        if (vida <= vidamax * 0.3)
        {
            textoVida.text = "<color=black> Vida: <color=red>" + vida + "</color>";
        }

        if (transform.position.y <= caiu)
        {
            Debug.Log("Você caiu e perdeu todas as suas moedas!");
            ColetarMoedas_Atividade.moedas = 0;
            Debug.Log("Você caiu e perdeu todas as suas moedas!");
            transform.position = posicao_inicial;
            vida--;
        }

        if (transform.position.x >= ganhou)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
            Debug.Log("Parabéns! Você ganhou!");
            Debug.Log("Você conseguiu coletar " + ColetarMoedas_Atividade.moedas + " moedas!");
            textoGP.text = "<color=green>Você ganhou!!!!!!!"; 
        }
    }
}
