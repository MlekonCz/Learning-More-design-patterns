using System;
using StatePattern;
using UnityEngine;

namespace EventBuss
{
    public class ClientEventBus : MonoBehaviour
    {
        private bool _isButtonEnabled;

        private void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            _isButtonEnabled = true;
        }

        private void OnEnable()
        {
            RaceEventBuss.Subscribe(RaceEventType.Stop,Restart);
        }

        private void OnDisable()
        {
            RaceEventBuss.UnSubscribe(RaceEventType.Stop,Restart);
        }

        private void Restart()
        {
            _isButtonEnabled = true;
        }

        private void OnGUI()
        {
            if (_isButtonEnabled)
            {
                if (GUILayout.Button("Start CountDown"))
                {
                    _isButtonEnabled = false;
                    RaceEventBuss.Publish(RaceEventType.CountDown);
                }
                
                
            }
        }
    }
}