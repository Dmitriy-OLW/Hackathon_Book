using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    private Rigidbody _rb;
    public Player_Health _HS;
    public KeyCode Hell = KeyCode.Z;
    private bool isAttack = false; //разрешение на атаку

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Hell) && isAttack == true)
        {
            //Debug.Log("123457890-");
            _HS.Health -= 30f;
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player"){ //игрок в поле удра, можно атокавать
            //Debug.Log("Atack_Good"); 
            isAttack = true;
        }
        else{isAttack = false;}
   
    }
}
