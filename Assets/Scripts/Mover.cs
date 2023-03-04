using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{

    public GameObject resticios;
    int vida = 4;
    public Texture Q1, Q2, Q3;
    public Text texto;
    Rigidbody carro;
    public int pts;
    [SerializeField] GameObject chao;
    public Slider barraBoost;
    public AudioSource batida, explosao;
    bool boost = false; // variavel pra ver o boost
    public Image seta;

    // Start is called before the first frame update
    void Start()
    {

        ///translate.Transform()
        carro = GetComponent<Rigidbody>();
        pts = 0;
    }


    // Update is called once per frame
    void Update()
    {

        //AndaCarro();
        //Debug.Log(carro.rotation);

        Velocimetro();

        texto.text = "Pontos: " + pts.ToString();
        if (pts >= 5 && pts < 10)
        {
            chao.GetComponent<CriaLaranja>().velocidade = 2f;
        }
        else if (pts >= 10)
        {
            chao.GetComponent<CriaLaranja>().velocidade = 1f;
        }
        else
        {
            chao.GetComponent<CriaLaranja>().velocidade = 4f;
        }


        if (Input.GetKey("r"))
        { //Reinicia fase
            SceneManager.LoadScene("Rua");
        }

        if (Input.GetKeyDown("left shift") && barraBoost.value > 0)
        { //Reinicia fase
            if (barraBoost.value == 0)
            {
                this.gameObject.GetComponent<PrometeoCarController>().accelerationMultiplier = 3;
                boost = false;
            }
            else
            {
                boost = true;
            }

        }
        else if (Input.GetKeyUp("left shift"))
        {
            boost = false;
        }
        if (barraBoost.value == 0)
        {
            this.gameObject.GetComponent<PrometeoCarController>().accelerationMultiplier = 3;
            boost = false;
        }

        if (boost == true)
        {
            barraBoost.value = barraBoost.value - 2;
            this.gameObject.GetComponent<PrometeoCarController>().accelerationMultiplier = 5;
        }
        else if (barraBoost.value < 2000)
        {
            barraBoost.value++;
            this.gameObject.GetComponent<PrometeoCarController>().accelerationMultiplier = 3;
        }


        //DEBUG
        if (Input.GetKey("l"))
        {
            //vida--;
        }
    }


    void Velocimetro()
    {
        float speed;
        speed = this.GetComponent<PrometeoCarController>().carSpeed;
        //Debug.Log(speed);
        if (speed > 0)
        {
            seta.rectTransform.rotation = Quaternion.Euler(0, 0, -((256 * speed) / 80));
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "Arvore" || other.gameObject.tag == "Muro") && this.GetComponent<PrometeoCarController>().carSpeed > 10)
        {
            vida--;
            switch (vida)
            {
                case 3:
                    this.GetComponent<Renderer>().material.SetTexture("_MainTex", Q1);
                    break;
                case 2:
                    this.GetComponent<Renderer>().material.SetTexture("_MainTex", Q2);
                    break;
                case 1:
                    this.GetComponent<Renderer>().material.SetTexture("_MainTex", Q3);
                    break;
                case 0:
                    Destroy(this.gameObject);
                    Instantiate(resticios, this.transform.position, Quaternion.identity);
                    explosao.Play();

                    break;
            }
            batida.Play();
            if (other.gameObject.tag == "Arvore" && pts > 0)
            {
                pts--;
            }


        }
    }



}
