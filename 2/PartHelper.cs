namespace _2;

public static class PartHelper
{
    public static bool LevelHasError(ref bool allIncrease, int current, int next, int i)
    {
        var count = current - next;
        var currentIncrease = count < 0;
        var wihtinThreshold = Math.Abs(count) >= 1 && Math.Abs(count) <= 3;

        if (i == 0)
        {
            allIncrease = currentIncrease;
        }

        return (currentIncrease != allIncrease) || !wihtinThreshold;
    }
}
