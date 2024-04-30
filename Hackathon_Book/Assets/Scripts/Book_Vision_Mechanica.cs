using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Vision_Mechanica : MonoBehaviour
{
    public KeyCode world_0 = KeyCode.Keypad1;
    public KeyCode world_1 = KeyCode.Keypad2;
    //public KeyCode world_2 = KeyCode.Keypad3;
    public GameObject[] Mask_Vid_World;
    public GameObject[] Worlds;
    public bool active_perhod;
    public bool you_can = true;
    public bool nacali = false;
    public bool mir_is = false;

    public GameObject[] models;

     public GameObject audiis;
    void Start()
    {
        active_perhod = false;
        Deactivate_Activate_World(Worlds[1], false);
        Mask_Vid_World[0] = GameObject.Find("Mask0");
        Mask_Vid_World[1] = GameObject.Find("Mask1");
        //Mask_Vid_World[2] = GameObject.Find("Mask2");
        foreach(GameObject _mask in Mask_Vid_World){Deactivate_Activate_World(_mask, false);}
    }

    void Update()
    {
        if(Input.GetKeyDown(world_0) && you_can == true){
            active_perhod = true;
            mir_is = !mir_is;
        }
        if(nacali == true && mir_is == false){
            mask_on_off(Mask_Vid_World, 0);
            Deactivate_Activate_World(Worlds[0], true);
            Deactivate_Activate_World(Worlds[1], false);
            foreach(GameObject telo in models){Deactivate_Activate_World(telo, true);}
            audiis.SetActive(true);
            nacali = false;
        }
        if(nacali == true && mir_is == true){
           mask_on_off(Mask_Vid_World, 1);
           Deactivate_Activate_World(Worlds[1], true);
           Deactivate_Activate_World(Worlds[0], false);
           foreach(GameObject telo in models){Deactivate_Activate_World(telo, false);}
           audiis.SetActive(false);
           nacali = false;
        }
        //  if(Input.GetKeyDown(world_2)){
        //    mask_on_off(Mask_Vid_World, 2);
        //    active_perhod = true;
        //  }
    }
    public void mask_on_off(GameObject[] Masks, int Nomer)
    {
        foreach(GameObject _mask in Masks){Deactivate_Activate_World(_mask, false);}
        Deactivate_Activate_World(Masks[Nomer], true);
    }
    public void Deactivate_Activate_World(GameObject Objects, bool b)
    {
        Objects.SetActive(b);
    }
}
