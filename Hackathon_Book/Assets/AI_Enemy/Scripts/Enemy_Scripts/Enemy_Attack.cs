using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public _Player_Health _HS;
    public Enemy_Liminal _EAS;
    public int yron = 20;
    private bool Anti_Double = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Telo_Player_Health")
        {
            
            if(_EAS.anim_is_good == true && Anti_Double == false)
            {
                Debug.Log("Atack");
                Anti_Double = true;
                _HS.playerHP -= yron;
            }
            else{Anti_Double = false;}
        }
    }
}
