using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Perehod : MonoBehaviour
{
    public GameObject _del;
    public Image bg;
    public KeyCode nach = KeyCode.Alpha9;
    public KeyCode kone = KeyCode.Alpha8;
    public Book_Vision_Mechanica _SC_prverka;
    public bool _is_good;

 
    void Start()
    {

        bg = GetComponent<Image>();
        bg.color = new Color(1f, 1f, 1f, 0f);
        _is_good = false;
    }
    void Update()
    {
        
        if(_SC_prverka.active_perhod == true)
        {
            //_SC_prverka.active_perhod = false;
            Debug.Log("1234567890");
            
            StartCoroutine(c_Alpha_ON(1.0f, 0.5f));
            _SC_prverka.active_perhod = false;
            }
        //_is_good = !_is_good;
                        
        
        /*if (Input.GetKeyDown(nach))
        {
            StartCoroutine(c_Alpha(1.0f, 0.5f));
        }
            
 
        if (Input.GetKeyDown(kone))
        {
            StartCoroutine(c_Alpha(0.0f, 0.5f));
        }*/
            
    }
 
    IEnumerator c_Alpha_ON(float value, float time)
    {
        float k = 0.0f;
        Color c0 = bg.color;
        Color c1 = c0;
        c1.a = value;
 
        while ((k += Time.deltaTime) <= time)
        {
            bg.color = Color.Lerp(c0, c1, k / time);
 
            yield return null;
        }
 
        bg.color = c1;
        _is_good = true;
        _del.SetActive(true);
        bg.color = new Color(1f, 1f, 1f, 0f);
    }
    
    
}