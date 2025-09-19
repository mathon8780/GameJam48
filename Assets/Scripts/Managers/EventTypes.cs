namespace Managers
{
    public class EventTypes
    {
    }

    public class HpChanged
    {
        public float CurrentHP;
        public float MaxHP;

        public HpChanged(float currentHP, float maxHP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }
    }


    public struct CalmnessChanged
    {
        public float CurrentCalmness;

        public CalmnessChanged(float currentCalmness)
        {
            CurrentCalmness = currentCalmness;
        }
    }
}