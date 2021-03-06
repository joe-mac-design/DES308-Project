using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
Script provided by Turbo Makes Games on Youtube: https://www.youtube.com/c/TurboMakesGames
*/

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public TMP_Text _timeCounter;
    public TMP_Text _endTimeCounter;

    private TimeSpan _timePlaying;
    private bool _timerGoing;

    private float _elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _timeCounter.text = "Time: 00:00.00";
        _timerGoing = true;
        TimerController.instance.BeginTimer();
    }

    public void BeginTimer()
    {
        _timerGoing = true;
        _elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        _timerGoing = false;
        _endTimeCounter.text = "Time: " + _timePlaying.ToString("mm':'ss'.'ff");
    }

    private IEnumerator UpdateTimer()
    {
        while (_timerGoing)
        {
            _elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            string _timePlayingStr = "Time: " + _timePlaying.ToString("mm':'ss'.'ff");
            _timeCounter.text = _timePlayingStr;

            yield return null;
        }
    }

}
