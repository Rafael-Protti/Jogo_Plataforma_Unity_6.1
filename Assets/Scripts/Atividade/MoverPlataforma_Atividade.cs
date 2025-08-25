using UnityEditor.Timeline;
using UnityEngine;

public class MoverPlataforma_Atividade : MonoBehaviour
{
    public float velocidade = 5;
    public float distancia = 2;
    Vector2 posicao_inicial;
    public bool vertical = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicao_inicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (vertical)
        {
            float novaPosicaoY = Mathf.PingPong(Time.time * velocidade, distancia);

            transform.position = new Vector2(posicao_inicial.x, posicao_inicial.y + novaPosicaoY);
        }

        else 
        {
            float novaPosicaoX = Mathf.PingPong(Time.time * velocidade, distancia);

            transform.position = new Vector2(posicao_inicial.x + novaPosicaoX, posicao_inicial.y);
        }  
    }
}
