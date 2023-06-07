using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public int runSpeed = 7;
    public int RotationSpeed = 1000;
    private bool shoot = false;
    static public bool aim = false;
    public static GameObject player;
    private Camera camera;
    public  int vida;
    public static int vidalocal;
    public static bool atacado = false;
    public static int restarvida=0;
    private float DamageTime = 0f;

    public GameObject danyo;

    public Text vidaText;


    public static Animator animator;

    private float x, y;
    Vector3 m_Movement;

    void Start ()
    {
        
        vidalocal = 100;
        player = GameObject.FindWithTag("Player");
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        camera = GetComponentInChildren<Camera>();
        camera.transform.eulerAngles = new Vector3(0, 0, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        


    }
    // Update is called once per frame
    void Update()
    {
        
        if (atacado){
            danyo.SetActive(true);
            if(Time.time > DamageTime){
                danyo.SetActive(false);
                atacado = false;
                DamageTime += Time.time + 1f;
            }
        }
        else{
             danyo.SetActive(false);
        }
        
            
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        float rotateX = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotateX * Time.deltaTime * RotationSpeed, 0);

        float rotateY = -Input.GetAxis("Mouse Y") * RotationSpeed;
        float rotacion = player.transform.localEulerAngles.x;

        if((rotateY > 0 && (rotacion < 80 || (360.0f > rotacion && rotacion > 310.0f)))){ //Mirar hacia abajo

            player.transform.Rotate(rotateY * Time.deltaTime, 0, 0);
            camera.transform.Rotate(rotateY * Time.deltaTime, 0, 0);
        }

        if((rotateY < 0 && (rotacion < 100 || (360.0f > rotacion && rotacion > 320.0f)))){ //Mirar hacia arriba

            player.transform.Rotate(rotateY * Time.deltaTime, 0, 0);
            camera.transform.Rotate(rotateY * Time.deltaTime, 0, 0);
        }

        
        transform.Translate(x * Time.deltaTime * runSpeed, 0, 0);
      
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);



        bool down = Input.GetKeyDown(KeyCode.Space);
        bool up = Input.GetKeyUp(KeyCode.Space);

        if (!PauseMenu.GameIsPaused)
        {
            if(!aim && !shoot){
                if (Input.GetKeyDown(KeyCode.LeftShift)){
                animator.SetBool("isRunning", true);
                runSpeed = 20;
            }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", false);
                runSpeed = 7;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetBool("isAmming", true);
                aim = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                animator.SetBool("isAmming", false);
                aim = false;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetBool("isShooting", true);
                shoot = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("isShooting", false);
                shoot = false;
            }

        }
        vida -= restarvida;
        restarvida = 0;
        vidalocal = vida;

        vidaText.text = vida.ToString();

    }
  
    public static int getVida()
    {
        return vidalocal;
    }
    
}



