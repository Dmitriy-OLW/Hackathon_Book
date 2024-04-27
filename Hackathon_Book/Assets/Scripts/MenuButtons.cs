using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public int sohran = 0;

    public int SceneType;
    [SerializeField] GameObject Main_Cam;
    [SerializeField] GameObject Nast_Cam;

    [SerializeField] GameObject Main_Canv;
    [SerializeField] GameObject Nast_Canv;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    private void Start() {
        Nast_Canv.SetActive(false);
        Nast_Cam.SetActive(false);
    }


    public void ToNastr()
    {
        Main_Canv.SetActive(false);
        Main_Cam.SetActive(false);

        Nast_Canv.SetActive(true);
        Nast_Cam.SetActive(true);
        sohran = 1;

        if (SceneType==1)
        {
            sohran = 1;
            //sohranenie timer
        }
    }

    public void FromNastr()
    {
        Nast_Canv.SetActive(false);
        Nast_Cam.SetActive(false);

        Main_Canv.SetActive(true);
        Main_Cam.SetActive(true);

        sohran = 2;

        if (SceneType==1)
        {
            sohran = 2;
            //timer start
        }

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void forMenu()
    {
        Debug.Log("Aga");
        SceneManager.LoadScene(0);
    }

}
