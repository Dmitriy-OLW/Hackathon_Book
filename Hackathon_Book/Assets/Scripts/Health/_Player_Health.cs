using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class _Player_Health : MonoBehaviour
{

    public int playerHP;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;
    //public Book_Vision_Mechanica _SC_;
    
    //public KeyCode fff = KeyCode.Alpha9;
    

    void Start()
    {
        isGameOver = false;
        playerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(fff)) playerHP-=10;
        playerHPText.text = "Здоровья осталось: " + playerHP;
        if(playerHP <= 0)
        {
            Debug.Log("Dead");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Radiation")
        {
            Debug.Log("Radiation");
            playerHP = -10;
        }
    }
            

}

