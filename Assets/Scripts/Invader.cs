using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    [SerializeField]
    float cadencia = 1.5f;

    float tempoQuePassou = 0f;

    void Update()
    {
        if(tag == "Destrutivel")
        {
            tempoQuePassou += Time.deltaTime;
            if (tempoQuePassou >= cadencia)
            {
                Instantiate(fire, transform.position, transform.rotation);
                tempoQuePassou = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Destrutivel")
        {
            if (collision.gameObject.tag == "ProjectilAmigo")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        } else
        {
            Destroy(collision.gameObject);
        }
    }
}
