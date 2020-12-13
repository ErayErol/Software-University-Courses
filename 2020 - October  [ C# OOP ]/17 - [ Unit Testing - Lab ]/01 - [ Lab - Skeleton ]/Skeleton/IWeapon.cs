namespace Skeleton
{
    public interface IWeapon
    {
        void Attack(ITarget target);

        int DurabilityPoints { get; set; }
    }
}
