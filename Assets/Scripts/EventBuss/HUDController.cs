using System;
using UnityEngine;

namespace EventBuss
{
    public class HUDController : MonoBehaviour
    {
        private bool _isDisplayOn;

        private void OnEnable()
        {
            RaceEventBuss.Subscribe(RaceEventType.Start, DisplayHUD);
        } 
        private void OnDisable()
        {
            RaceEventBuss.UnSubscribe(RaceEventType.Start, DisplayHUD);
        }
        private void DisplayHUD()
        {
            _isDisplayOn = true;
        }

        private void OnGUI()
        {
            if (_isDisplayOn)
            {
                if (GUILayout.Button("Stop Race"))
                {
                    _isDisplayOn = false;
                    RaceEventBuss.Publish(RaceEventType.Stop);
                }
            }
        }
    }
}