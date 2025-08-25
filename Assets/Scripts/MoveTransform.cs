using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    public float velocidade = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal") * Time.deltaTime * velocidade;
        //float pulo = Input.GetAxisRaw("Vertical") * Time.deltaTime * velocidade;
        transform.position += new Vector3(movimento, 0);
    }
}
    