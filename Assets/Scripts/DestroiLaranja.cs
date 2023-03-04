using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroiLaranja : MonoBehaviour
{
    bool destruindo = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && destruindo == false)
        {
            destruindo = true;

            this.GetComponent<AudioSource>().Play();
            this.GetComponent<ParticleSystem>().Play();
            other.gameObject.GetComponent<Mover>().pts++;

            Invoke("destrua", 3f); // espera 3 segundos e destroi
            //Abrir portao
            if (other.gameObject.GetComponent<Mover>().pts == 15)
            {
                GameObject portao = GameObject.Find("Pivot1");
                portao.GetComponent<Animator>().SetTrigger("Abrir");
            }

        }
    }

    void destrua()
    {
        //wait
        destruindo = false;
        Destroy(this.gameObject);
    }
}
