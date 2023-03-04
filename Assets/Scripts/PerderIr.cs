using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PerderIr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Morreu",5f);
    }

    void Morreu(){
        SceneManager.LoadScene("GameOver");
    }
}
