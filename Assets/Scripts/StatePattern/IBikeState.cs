namespace StatePattern
{
    public interface IBikeState
    {
        void Handle(BikeController bikeController);
    }
}