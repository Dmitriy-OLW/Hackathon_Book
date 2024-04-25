using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    
    public float  Health;
    public Image Hell_Barr;
    public Image[] Obvodka_Barr;
    //public Image Dead_Barr;
    [SerializeField]
    private float a = 0f;
    [SerializeField]
    private float rgb = 1f;

    [SerializeField]
    private GameObject Menu_Objects_Dead;
    [SerializeField]
    private GameObject[] Enemy_All;



    void Awake()
    {
        Health = 100f;
    }
    void Start()
    {
        //Dead_Barr.color = new Color(0f, 0f, 0f, 0f);
        Deactivate_Activate(Menu_Objects_Dead, false);
    }
    void Update() 
    { 
        if(Health <= 0f)
        {
            //Dead_Barr.color = new Color(0.6698113f, 0.2243236f, 0.2243236f, 0.09803922f);
            Deactivate_Activate(Menu_Objects_Dead, true);
            foreach(GameObject Object in Enemy_All){Deactivate_Activate(Object, false);}
            
        }
        else if(Health == 100f)
        {
           a = 0f;
           rgb = 1f;
        }
        else if(Health < 100f && Health >= 50f)
        {
           a = (100-Health)/50;
           rgb = 1f;
        }
        else if(Health < 50f && Health > 0f)
        {
           a = 1f;
           rgb = Health/50f;
        }
        
        Hell_Barr.color = new Color (rgb, rgb, rgb, a);
        foreach(Image OB in Obvodka_Barr){OB.color = new Color (rgb, rgb, rgb, a);;}
    }

    

    void Deactivate_Activate(GameObject Objects, bool b)
    {
        Objects.SetActive(b);
    }

}
