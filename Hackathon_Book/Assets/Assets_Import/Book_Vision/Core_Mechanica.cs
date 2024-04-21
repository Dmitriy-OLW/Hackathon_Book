using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Mechanica : MonoBehaviour
{
    private KeyCode world_0 = KeyCode.Mouse0;
    private KeyCode world_1 = KeyCode.Mouse1;
    //public KeyCode world_2 = KeyCode.F;
    public GameObject[] Mask_Vid_World;
    void Start()
    {
        Mask_Vid_World[0] = GameObject.Find("Mask0");
        Mask_Vid_World[1] = GameObject.Find("Mask1");
        Debug.Log("Test1");
        //Mask_Vid_World[2] = GameObject.Find(Mask2);
        foreach(GameObject _mask in Mask_Vid_World){Deactivate_Activate_World(_mask, false);}
        Debug.Log("Test2");
    }

    void Update()
    {
        if(Input.GetKeyDown(world_0)){
            Debug.Log("Test3");
           mask_on_off(Mask_Vid_World, 0);
        }
        if(Input.GetKeyDown(world_1)){
           mask_on_off(Mask_Vid_World, 1);
        }
        // if(Input.GetKeyDown(world_2)){
        //    mask_on_off(Mask_Vid_World, 2);
        // }
    }
    void mask_on_off(GameObject[] Masks, int Nomer)
    {
        Debug.Log("Test4");
        foreach(GameObject _mask in Masks){Deactivate_Activate_World(_mask, false);}
        Deactivate_Activate_World(Masks[Nomer], true);
        Debug.Log("Tes5");
    }
    void Deactivate_Activate_World(GameObject Objects, bool b)
    {
        Objects.SetActive(b);
    }
}
