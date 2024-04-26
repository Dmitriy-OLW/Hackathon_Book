using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public KeyCode _PickUp = KeyCode.Keypad1;
    public KeyCode _Drop = KeyCode.Keypad2;
    public KeyCode _Slot1 = KeyCode.Keypad3;
    public KeyCode _Slot2 = KeyCode.Keypad4;
    public KeyCode _Slot3 = KeyCode.Keypad5;
    public KeyCode _Slot4 = KeyCode.Keypad6;

    public GameObject camera;
    public float distance = 15f;
    GameObject currentWeapon;
    bool canPickUp = false;

    public GameObject[] Predmets;
    public int vebor_predmets = 0;

    public GameObject _Nule_invent;
   
    private void Start() {
        for(int i = 0; i<4; i++)
        {
            Predmets[i] = _Nule_invent;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(_PickUp)) PickUp();
        if (Input.GetKeyDown(_Drop)) Drop();
        if (Input.GetKeyDown(_Slot1)) {vebor_predmets = 0;inventory();}
        if (Input.GetKeyDown(_Slot2)) {vebor_predmets = 1;inventory();}
        if (Input.GetKeyDown(_Slot3)) {vebor_predmets = 2;inventory();}
        if (Input.GetKeyDown(_Slot4)) {vebor_predmets = 3;inventory();}
    }

    void inventory()
    {
        foreach(GameObject _prednet in Predmets){Deactivate_Activate(_prednet, false);}
        Deactivate_Activate(Predmets[vebor_predmets], true);
    }

    void PickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Predmets")
            {
                //if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                //currentWeapon.GetComponent<Rigidbody>().useGravity = false;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
                canPickUp = true;
                Predmets[vebor_predmets] = currentWeapon;
            }
        }

        
    }

    void Drop()
    {
        try{
            currentWeapon.transform.parent = null;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<Collider>().isTrigger = false;
            canPickUp = false;
            currentWeapon = null;
            Predmets[vebor_predmets] = _Nule_invent;
        }
        catch{Debug.Log("fail");}
        
        
    }
    void Deactivate_Activate(GameObject Objects, bool b)
    {
        Objects.SetActive(b);
    }
}

