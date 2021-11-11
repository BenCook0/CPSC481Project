using System.Windows.Controls;
using NewCPSC481.Data;

namespace NewCPSC481
{
    /// <summary>
    /// Interaction logic for WorkoutUserControl.xaml
    /// </summary>
    public partial class WorkoutUserControl : UserControl
    {
        private Workout workout;

        public WorkoutUserControl()
        {
            InitializeComponent();
        }

        public void SetWorkout(Workout workout)
        {
            this.workout = workout;
            ExerciseGrid.ItemsSource = workout.Exercises;
        }
    }
}
