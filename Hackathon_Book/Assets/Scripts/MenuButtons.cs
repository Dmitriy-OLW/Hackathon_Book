using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    [SerializeField] GameObject Main_Cam;
    [SerializeField] GameObject Nast_Cam;

    [SerializeField] GameObject Main_Canv;
    [SerializeField] GameObject Nast_Canv;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }


    public void ToNastr()
    {
        Main_Canv.SetActive(false);
        Main_Cam.SetActive(false);

        Nast_Canv.SetActive(true);
        Nast_Cam.SetActive(true);
    }

    public void FromNastr()
    {
        Nast_Canv.SetActive(false);
        Nast_Cam.SetActive(false);

        Main_Canv.SetActive(true);
        Main_Cam.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
