using System;
using EventBuss;
using UnityEngine;

namespace StatePattern
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }
    public class BikeController : MonoBehaviour
    {
        public float maxSpeed = 2f;
        public float turnDistance = 2f;

        private string _status;
        
        public float CurrentSpeed { get; set; }
    
        public Direction CurrentTurnDirection {
            get; private set;
        }

        private IBikeState _startState, _stopState, _turnState;

        private BikeStateContext _bikeStateContext;

        private void OnEnable()
        {
            RaceEventBuss.Subscribe(RaceEventType.Start,StartBike);
            RaceEventBuss.Subscribe(RaceEventType.Stop,StopBike);
        }

        private void OnDisable()
        {
            RaceEventBuss.UnSubscribe(RaceEventType.Start,StartBike);
            RaceEventBuss.UnSubscribe(RaceEventType.Stop,StopBike);
        }

        private void Start()
        {
            _bikeStateContext = new BikeStateContext(this);
            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();
        
            _bikeStateContext.Transition(_stopState);
        }

        public void StartBike()
        {
            _status = "Started";
            _bikeStateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _status = "Stopped";
            _bikeStateContext.Transition(_stopState);
        }

        public void Turn(Direction direction)
        {
            CurrentTurnDirection = direction;
            _bikeStateContext.Transition(_turnState);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10,60,200,20), "BIKE STATUS: " + _status);
        }

        public void ToggleTurbo()
        {
            
        }
    }
}