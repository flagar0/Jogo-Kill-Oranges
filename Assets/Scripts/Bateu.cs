using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateu : MonoBehaviour
{
    public Material quebrado;
    public Material normal;
    bool batido = false;
    private void OnCollisionEnter(Collision other) {
        if(batido == false && other.gameObject.tag == "Player") {
        
        if( other.gameObject.GetComponent<Mover>().pts >0){
            other.gameObject.GetComponent<Mover>().pts--;
        }
        GetComponent<MeshRenderer>().material = quebrado; //Muda o mesh render para outro
        batido = true;
        }
        
    }

    public void OnCollisionExit(Collision other) {
        StartCoroutine(waiter());
        
    }
    IEnumerator waiter(){
        yield return new WaitForSeconds(1); //wait
        GetComponent<MeshRenderer>().material = normal; //volta ao normal
        batido = false;
    }
}
