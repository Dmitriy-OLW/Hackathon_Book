using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeRotate : MonoBehaviour
{
    Transform[] Pipes;
    GameObject[] Pipes20 = new GameObject[68];
    int[] Pipe_vals = new int[68];
    public Camera Cam;
    public float distance = 15f;


    private void Start()
    {
        Pipes=this.gameObject.GetComponentsInChildren<Transform>(false);
       
        int j = 0;
        for (int i=Pipes.Length-1; i>=0; i--)
        {
            if (!Pipes[i].name.Contains("S"))
            {
                Pipes20[j] = Pipes[i].gameObject;
                j++;
            }
        }

        int a = 0;
        
        foreach (GameObject pipe in Pipes20)
        {
            Pipe_vals[a] =System.Convert.ToInt32( pipe.transform.rotation.z);
        }

        Shuffle();

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Check();
        }
    }


    void Check ()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            
            if (hit.transform.tag == "Pipe")
            {
                Debug.Log("Rot");
                hit.transform.eulerAngles += new Vector3(0, 0, 90);
            }

            int i = 0;
            bool flag = true;
            foreach (GameObject pipe in Pipes20)
            {
                if (pipe.transform.eulerAngles.z != Pipe_vals[i])
                { flag = false; break; }
                else
                    i++;
            }
            if (flag == true)
            {
                Debug.Log("WIN");
            }
        }
    }


    void Shuffle()
    {
        
        int[] ang = new int[] { 90, 270, 180, 0 };
        foreach (GameObject pipe in Pipes20)
        {
            int a = Random.Range(0, 4);
            Vector3 newRotation = new Vector3(0, 0, ang[a]);
            pipe.transform.eulerAngles = newRotation;
        }
    }

}
