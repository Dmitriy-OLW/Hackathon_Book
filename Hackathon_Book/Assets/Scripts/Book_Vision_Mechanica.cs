using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Vision_Mechanica : MonoBehaviour
{
    public KeyCode world_0 = KeyCode.Keypad1;
    public KeyCode world_1 = KeyCode.Keypad2;
    public KeyCode world_2 = KeyCode.Keypad3;
    public GameObject[] Mask_Vid_World;
    public bool active_perhod;
    void Start()
    {
        active_perhod = false;
        Mask_Vid_World[0] = GameObject.Find("Mask0");
        Mask_Vid_World[1] = GameObject.Find("Mask1");
        Mask_Vid_World[2] = GameObject.Find("Mask2");
        foreach(GameObject _mask in Mask_Vid_World){Deactivate_Activate_World(_mask, false);}
    }

    void Update()
    {
        if(Input.GetKeyDown(world_0)){
            active_perhod = true;
            mask_on_off(Mask_Vid_World, 0);
        }
        if(Input.GetKeyDown(world_1)){
           mask_on_off(Mask_Vid_World, 1);
           active_perhod = true;
        }
         if(Input.GetKeyDown(world_2)){
           mask_on_off(Mask_Vid_World, 2);
           active_perhod = true;
         }
    }
    void mask_on_off(GameObject[] Masks, int Nomer)
    {
        foreach(GameObject _mask in Masks){Deactivate_Activate_World(_mask, false);}
        Deactivate_Activate_World(Masks[Nomer], true);
    }
    void Deactivate_Activate_World(GameObject Objects, bool b)
    {
        Objects.SetActive(b);
    }
}
