using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

using UnityEngine.UI;

public class Medic_Kit_Health_Controller : MonoBehaviour
{
    private Rigidbody _rb;

    public int Ispolsov_Obj = 50;

    public _Player_Health Med_Sc;
    public PickUpWeapon SC_Apteka;
    public KeyCode _Med = KeyCode.F;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        

        if(Input.GetKeyDown(_Med) && SC_Apteka.currentWeapon.name == "apteka")
        {
            //Debug.Log("Test1");
            if((Med_Sc.playerHP + Ispolsov_Obj) < 100f){
                Med_Sc.playerHP += Ispolsov_Obj;
                Debug.Log("Test3");
            }
            else{Med_Sc.playerHP=100;}
            Destroy(gameObject);
			
        }
    }
 
}
