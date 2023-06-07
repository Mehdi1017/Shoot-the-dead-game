using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject newZombie;
    public int xPos;
    public int zPos;
    public static int enemyCount; 

    public static List<GameObject> listazombies = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }




    public Vector3 RandomPoint(float radio){

        Vector3 randomDireccion = Random.insideUnitSphere * radio;
        randomDireccion += transform.position;
        NavMeshHit hit;
        Vector3 finalPos = Vector3.zero;

        if (NavMesh.SamplePosition(randomDireccion, out hit, radio, 1)){
            finalPos = hit.position;
        }
        return finalPos;
    }




    IEnumerator EnemyDrop(){

        for(int i = 0; i < ControlRondas.numZombies; i++){
            Vector3 pos = RandomPoint(80);
            newZombie = Instantiate(enemy, pos, Quaternion.identity);
            newZombie.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

    }




}
