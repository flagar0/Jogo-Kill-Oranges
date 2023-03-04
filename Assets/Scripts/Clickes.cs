using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickes : MonoBehaviour
{
    
    public void Reiniciar(){
        SceneManager.LoadScene("Rua");
    }
    public void Sair(){
        Application.Quit();
    }
}
