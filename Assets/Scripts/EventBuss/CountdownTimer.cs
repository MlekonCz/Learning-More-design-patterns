using System;
using System.Collections;
using UnityEngine;

namespace EventBuss
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float _duration = 3f;

        private void OnEnable()
        {
            RaceEventBuss.Subscribe(RaceEventType.CountDown,StartTimer);
        }
        private void OnDisable()
        {
         RaceEventBuss.UnSubscribe(RaceEventType.CountDown, StartTimer);   
        }
        private void StartTimer()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            _currentTime = _duration;
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }
            RaceEventBuss.Publish(RaceEventType.Start);
        }

        private void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(
                new Rect(125,0,100,20),"COUNTDOWN: " + _currentTime);
        }
    }
}