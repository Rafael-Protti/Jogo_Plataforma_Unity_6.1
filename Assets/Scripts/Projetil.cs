using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Vector3 direcao;
    public float velocidade = 10;

    private void Start()
    {
        Destroy(transform.gameObject, 5);
    }
    void Update()
    {
        transform.position += direcao * velocidade * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Moeda"))
        {
            Destroy(transform.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
