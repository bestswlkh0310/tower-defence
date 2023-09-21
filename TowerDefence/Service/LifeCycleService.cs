using System;
using TowerDefence.Activitys;

namespace TowerDefence
{
    public class LifeCycleService
    {
        private static LifeCycleService _instance;

        private static ILifeCycle _currentActivity;

        public static LifeCycleService Instance()
        {
            if (_instance == null)
            {
                _instance = new LifeCycleService();
            }

            return _instance;
        }

        private LifeCycleService() { }

        public void SetActivity(Activity activity)
        {
            _currentActivity = activity;
            _currentActivity.Start();
            InitPrintView();
            while (!activity.IsDie)
            {
                activity.PrintView();
                _currentActivity.Update();
            }
            _currentActivity.Destroy();
        }

        public void InitPrintView()
        {
            for (int i = 0; i < Constant.Height; i++)
            {
                Console.WriteLine("");
            }
        }
    }
}