using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text municionText;
    public Text vidaText;


    public static GameManager Instance {get; private set;}

    public int gunAmmo = 10;

    public static int vida = 100;

    private void Awake(){

        Instance = this;
    }

    private void update(){

    municionText.text = gunAmmo.ToString();
    vidaText.text = vida.ToString();
    }   

}
