using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public float enemy_Health;
    private Rigidbody _rb;
    [SerializeField]
    private GameObject Uyzvim_Obj;

    void Awake()
    {
        enemy_Health = 100f;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(enemy_Health <= 0f)
        {
            //_rb.AddForce(Vector3.up * 2f);
            Destroy(Uyzvim_Obj);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("_______Damage");
        if(other.gameObject.tag == "Katana"){ 
            enemy_Health -= 30;
        }
        if(other.gameObject.tag == "Axe"){ 
            enemy_Health -= 40;
        }
        if(other.gameObject.tag == "Matcheta"){ 
            enemy_Health -= 20;
        }
        if(other.gameObject.tag == "Crowbar"){ 
            enemy_Health -= 15; 
        }
        if(other.gameObject.tag == "Pipe"){ 
            enemy_Health -= 8;
        }
    }
}
