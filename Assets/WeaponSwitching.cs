using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selected = 0;
    private Animator animator;
    public static int danyo = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previous = selected;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            if (selected >= transform.childCount - 1)
                selected = 0;
            else
                selected++;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            if (selected <= 0)
                selected = transform.childCount - 1;
            else
                selected--;
        }
        if(previous != selected){
            SelectWeapon();
        }

        if(selected == 0){
            danyo = 20;
        }

        if(selected == 1){
            danyo = 12;
        }
        
        if(selected == 2){
            danyo = 60;
        }
    }
    void SelectWeapon(){
        int i = 0;
        foreach (Transform weapon in transform){
            if (i == selected){
                weapon.gameObject.SetActive(true);
                PlayerMove.player = weapon.gameObject;
                PlayerMove.animator = weapon.gameObject.GetComponent<Animator>();
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
