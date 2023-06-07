using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class ControlRondas : MonoBehaviour

{
    public static bool lose = false;
    public static bool win = false;

    public GameObject Won;
    public GameObject GameOver;
   


    public int rondaActual;
    private int totalRondas;
    public static int numZombies = 5;

    public GameObject enemy;
    private GameObject newZombie;
    public int enemyCount;
    public static int restaenemy = 0;
    

    public Text rondaAct;
    public Text rondaTot;

    private List<Vector3> spawnPoints = new List<Vector3>();
    

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints.Add(new Vector3 (56.9f, 0f, 6.6f));
        spawnPoints.Add(new Vector3 (40f, 0f, 30f));
        spawnPoints.Add(new Vector3 (-14f, 0f, 42f));
        spawnPoints.Add(new Vector3 (-50f, 0f, 56f));
        spawnPoints.Add(new Vector3 (-40f, 0f, -10f));
        spawnPoints.Add(new Vector3 (0f, 0f, -45f));
        spawnPoints.Add(new Vector3 (49.9f, 0f, 21.2f));
        spawnPoints.Add(new Vector3 (68.8f, 0f, 11f));
        spawnPoints.Add(new Vector3 (5.6f, 0f, -9.1f));
        spawnPoints.Add(new Vector3 (51.6f, 0, 41.6f));

        totalRondas = 15;
        
        rondaTot.text = totalRondas.ToString();
    }

    void Update(){

        enemyCount -= restaenemy;
        restaenemy = 0;

        rondaAct.text = rondaActual.ToString();
        
        SpawnRondas();

       

        if (PlayerMove.getVida() <= 0)
        {
            lose = true;
            Pause();
        }



    }
    void Pause()
    {
        Time.timeScale = 0f;

        if (lose) {
            GameOver.SetActive(true);

        }
        if (win)
        {
            Won.SetActive(true);

        }


    }
  



void SpawnRondas(){

        if(rondaActual > totalRondas){
            win = true;
            Pause();
        }



        if (enemyCount == 0 && rondaActual <= totalRondas){
            EnemyDrop();
            
            rondaActual++;
            rondaAct.text = rondaActual.ToString();
            numZombies += 3;
        }

    }

        
    void EnemyDrop(){

        for(int i = 0; i < numZombies; i++){
            int indice = (int) Mathf.Floor(Random.value*10);
            Vector3 pos = spawnPoints[indice];
            newZombie = Instantiate(enemy, pos, Quaternion.identity);
            newZombie.SetActive(true);
            enemyCount += 1;
        }

    }

}







