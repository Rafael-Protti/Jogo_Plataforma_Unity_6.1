using UnityEngine;

public class ColetarMoedas_Atividade : MonoBehaviour
{
    public static int moedas = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Colete todas as moedas e chegue no fim da fase para ganhar.");
        Debug.Log("Você têm " + moedas + " moedas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Moeda") == true)
        {
            Destroy(collision.gameObject);
            moedas++;
            Debug.Log("Você têm " + moedas + " moedas");
        }
    }
}
