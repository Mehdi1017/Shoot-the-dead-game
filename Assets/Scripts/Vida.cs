using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida = 100;

    public static Collider colliderZombie;


    void OnTriggerEnter(Collider other){
        for(int i = 0; i < GenerateEnemies.enemyCount; i++){
            colliderZombie = GenerateEnemies.listazombies[i].GetComponent<Collider>();
            if(other == colliderZombie){
                //if(GenerateEnemies.listazombies[i] == "Normal"/"Especial") Esto para cuando tengamos muchos zombies
                vida -= 5;
            }

            if(vida <= 0){
                 
                 //CANVAS DE "HAS MUERTO"

                 //Destroy(gameObject, 5); Destruir el jugador despues de 5s

                 //Canvas de reiniciar partida o menu principal
            }
        }
    }
}
