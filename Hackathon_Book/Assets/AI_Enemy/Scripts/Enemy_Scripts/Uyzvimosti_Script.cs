using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uyzvimosti_Script : MonoBehaviour
{
        
    public Enemy_Health _EH;
 
    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Krit_Damage");
        if(other.gameObject.tag == "Katana"){ 
            _EH.enemy_Health -= 20;
        }
        if(other.gameObject.tag == "Axe"){ 
            _EH.enemy_Health -= 25;
        }
        if(other.gameObject.tag == "Matcheta"){ 
            _EH.enemy_Health -= 15;
        }
        if(other.gameObject.tag == "Crowbar"){ 
            _EH.enemy_Health -= 10; 
        }
        if(other.gameObject.tag == "Pipe"){ 
            _EH.enemy_Health -= 5;
        }
    }
}
