using NewCPSC481.Data;

namespace NewCPSC481
{
    public delegate void GoalCreatedEventHandler(Goal newGoal);

    public static class Events
    {
        public static event GoalCreatedEventHandler UserGoalCreated;

        public static void RaiseGoalCreated(Goal goal)
        {
            UserGoalCreated?.Invoke(goal);
        }
    }
}
