using NewCPSC481.Data;

namespace NewCPSC481
{
    public delegate void GoalCreatedEventHandler(Goal newGoal);
    public delegate void GoalPopupClosedEventHandler();

    public static class Events
    {
        public static event GoalCreatedEventHandler UserGoalCreated;
        public static event GoalPopupClosedEventHandler CloseGoalControl;

        public static void RaiseGoalCreated(Goal goal)
        {
            UserGoalCreated?.Invoke(goal);
        }

        public static void RaiseCloseGoalPopup()
        {
            CloseGoalControl?.Invoke();
        }
    }
}
