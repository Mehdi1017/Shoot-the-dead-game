using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparar : MonoBehaviour
{

    public int capacidadCargador;
    public int cantidadBalas;
    public int cantidadTotalBalas;
    public Text cantidadBalasTexto;
    public Text cantidadTotalBalasTexto;
    public string animacion;

    public GameObject mira1;
    public GameObject mira2;


    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce = 150000f; //Velocidad de las balas
    public float shotRate = 0.38f;   //Cooldown disparos
    public static Collider colliderBala;

    private float shotRateTime = 0; //Tiempo que pasa desde que disparas

    private AudioSource disparo;

    public AudioClip disparoSonido;

    public AudioClip recargaArma;


    void Start(){
        disparo = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] vectorAnimacion = PlayerMove.animator.GetCurrentAnimatorClipInfo(0);
        if(vectorAnimacion.Length > 0)
            animacion = vectorAnimacion[0].clip.name;
        if(Input.GetKey(KeyCode.Mouse0) && !animacion.Contains("Reload")){
            
            if(Time.time > shotRateTime){

                if(cantidadBalas > 0){

                    GameObject newBullet;

                    newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                    cantidadBalas -= 1;

                    colliderBala = newBullet.GetComponent<Collider>();

                    shotRateTime = Time.time + shotRate;

                    disparo.PlayOneShot(disparoSonido);
                    
                    Destroy(newBullet, 4);
                }
                else{
                    //Cancelar animator disparar
                    if(recargar()){
                        PlayerMove.animator.SetTrigger("noAmmo");
                    }   
                
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){ //Cada arma tendra su cargador
            if(recargar())
                disparo.PlayOneShot(recargaArma);
                PlayerMove.animator.SetBool("reload", true);
		}
		if (Input.GetKeyUp(KeyCode.R))
            PlayerMove.animator.SetBool("reload", false);

        if(PlayerMove.aim == true){
            mira1.SetActive(false);
            mira2.SetActive(false);
        }
        else{
            mira1.SetActive(true);
            mira2.SetActive(true);
        }

        cantidadBalasTexto.text = cantidadBalas.ToString();
        cantidadTotalBalasTexto.text = cantidadTotalBalas.ToString();
    }

    bool recargar(){
        if(cantidadTotalBalas > 0){
            cantidadTotalBalas -= capacidadCargador - cantidadBalas;
            cantidadBalas += capacidadCargador - cantidadBalas;
            return true;
        }
        return false;

    }


}
