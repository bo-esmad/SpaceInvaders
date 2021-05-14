using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    [SerializeField]
    float cadencia = 1.5f;

    [SerializeField]
    float intervaloDaCadencia = 1f;

    float tempoQuePassou = 0f;

    [SerializeField]
    int vidasDosIndestrutiveis = 10;

    float tempoDeDisparo = 0;




    void Start()
    {
        NovoTempoDeDisparo();
    }


    void NovoTempoDeDisparo()
    {
        tempoDeDisparo = Random.Range(cadencia - intervaloDaCadencia, cadencia + intervaloDaCadencia);
    }

    void Update()
    {
        if(tag == "Destrutivel")
        {
            tempoQuePassou += Time.deltaTime;
            if (tempoQuePassou >= tempoDeDisparo)
            {
                Instantiate(fire, transform.position, transform.rotation);
                tempoQuePassou = 0f;
                NovoTempoDeDisparo();
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
            vidasDosIndestrutiveis--;
            if(vidasDosIndestrutiveis == 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
