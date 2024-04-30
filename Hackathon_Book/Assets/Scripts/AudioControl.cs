using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;

public class AudioControl : MonoBehaviour
{
    public GameObject[] Mask_Vid_World;

    public AudioSource samolyot1;
    public AudioSource samolyot2;
    public AudioSource pojarka;

    public AudioSource raciya;

    float timer1;

    private void Start()
    {
        Mask_Vid_World[0] = GameObject.Find("Mask0");
        Mask_Vid_World[1] = GameObject.Find("Mask1");
        timer1 =  0f;
    }


    private void Update()
    {
        timer1 += Time.deltaTime;
        if (Convert.ToInt32(timer1)!=0 && Convert.ToInt32(timer1) % 30 == 0)
        {
            samolyot1.Play();
        }
        if (Convert.ToInt32(timer1) != 0 && Convert.ToInt32(timer1) % 46 == 0)
        { samolyot2.Play();}

        if (Convert.ToInt32(timer1) != 0 && Convert.ToInt32(timer1) %34==0)
        {
            pojarka.Play();
        }

        if (Convert.ToInt32(timer1) != 0 && Convert.ToInt32(timer1) % 12 == 0)
        { raciya.Play();}
    }





}
