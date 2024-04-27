using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class Time_Contoler : MonoBehaviour
{
    public MenuButtons _SC_safe;
    public KeyCode _T = KeyCode.Alpha0;
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;
 
    private float _timeLeft = 0f;
    private float _Nachal_Time;
    private void Start() {
        StartTime();
    }
    private void Update() {
        if (Input.GetKeyDown(_T)) StartTime();
        if(_SC_safe.sohran == 2)
        {
            StartTime(); 
            _SC_safe.sohran = 0;
        }
    }
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }
 
    public void StartTime()
    {
        _Nachal_Time = time;
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        if(_Nachal_Time < _timeLeft){timerText.text = "Wave Begun";}
        if(_timeLeft <= 0)
        {
            timerText.text = "You Dead"; 
        }
        if(_SC_safe.sohran == 1)
        {
            time = _timeLeft;
            _timeLeft=0;
        }
        

        


    }

}
