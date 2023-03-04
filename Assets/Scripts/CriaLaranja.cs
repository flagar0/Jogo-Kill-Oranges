using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaLaranja : MonoBehaviour
{
    public GameObject laranja;
    bool criando = false;
    public float velocidade = 4f;
    public LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        if (criando == false)
        {
            criando = true;
            Invoke("criaLaranja", velocidade);
        }
    }

    void criaLaranja()
    {
        float x = Random.Range(80, 266);
        float z = Random.Range(240, 450);
        Instantiate(laranja, new Vector3(x, -103, z), Quaternion.identity);
        criando = false;
    }
}
