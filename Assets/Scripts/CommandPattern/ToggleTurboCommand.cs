using StatePattern;
using UnityEngine;

namespace CommandPattern
{
    public class ToggleTurboCommand : Command
    {
        private BikeController _bikeController;

        public ToggleTurboCommand(BikeController controller)
        {
            _bikeController = controller;
        }

    


        public override void Execute()
        {
            _bikeController.ToggleTurbo();
        }
        
    }
}