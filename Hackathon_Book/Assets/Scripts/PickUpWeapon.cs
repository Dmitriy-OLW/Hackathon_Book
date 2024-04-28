using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject currentWeapon;
    bool canPickUp = false;

    public GameObject[] Predmets;
    public GameObject[] Iventory_kostel;
    public int vebor_predmets = 0;

    public GameObject _Nule_invent;

    Ray MyRay;
    //считываем позицияю мышки это будет начальная точка луча
    //Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
    // Update is called once per frame
    public TextMeshProUGUI counterText;
    int book_counter=0;
   
    private void Start() {
        for(int i = 0; i<4; i++)
        {
            Predmets[i] = _Nule_invent;
        }
        foreach(GameObject _prednet in Iventory_kostel){Deactivate_Activate(_prednet, false);}
    }

    
    void Update()
    {
        if (Input.GetKeyDown(_PickUp)) PickUp();
        if (Input.GetKeyDown(_Drop)){ Drop(); inventory();}
        if (Input.GetKeyDown(_Slot1)) {vebor_predmets = 0;inventory();}
        if (Input.GetKeyDown(_Slot2)) {vebor_predmets = 1;inventory();}
        if (Input.GetKeyDown(_Slot3)) {vebor_predmets = 2;inventory();}
        if (Input.GetKeyDown(_Slot4)) {vebor_predmets = 3;inventory();}
    }

    void inventory()
    {
        foreach(GameObject _prednet in Predmets){Deactivate_Activate(_prednet, false);}
        foreach(GameObject _prednet in Iventory_kostel){Deactivate_Activate(_prednet, false);}
        for(int i = 0; i<Predmets.Length; i++)
        {
            if(Predmets[i].name == "apteka")
            {
                Deactivate_Activate(Iventory_kostel[i], true);
            }
            if(Predmets[i].name == "key")
            {
                Deactivate_Activate(Iventory_kostel[i+4], true);
            }
            if(Predmets[i].name == "truba")
            {
                Deactivate_Activate(Iventory_kostel[i+8], true);
            }
        }
        currentWeapon = Predmets[vebor_predmets];
        
        Deactivate_Activate(Predmets[vebor_predmets], true);
        Deactivate_Activate(Iventory_kostel[vebor_predmets], false);
        Deactivate_Activate(Iventory_kostel[vebor_predmets+4], false);
        Deactivate_Activate(Iventory_kostel[vebor_predmets+8], false);
    }

    void PickUp()
    {
        // MyRay=Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay(MyRay.origin, MyRay.direction*10,Color.yellow);
        // if(Physics.Raycast(MyRay, out hit))
        // {
        //     MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
        //     Debug.Log(filter.gameObject.name);
        // }

        RaycastHit hit;
        MyRay=Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(MyRay.origin, MyRay.direction*1,Color.yellow);
        
        //if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        if(Physics.Raycast(MyRay, out hit))
        {
            MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
            Debug.Log(filter.gameObject.name);
            if(filter.transform.tag == "Predmets" && hit.distance < 2f)
            {
                if (Predmets[vebor_predmets].gameObject.name != _Nule_invent.gameObject.name){Drop(); inventory();} 


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
            if (hit.transform.tag =="Book") //!!
            {
                Destroy(hit.transform.gameObject);
                book_counter++;
                counterText.text = book_counter+"/5";
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

