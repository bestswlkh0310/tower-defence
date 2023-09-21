using TowerDefence.Service;

namespace TowerDefence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LifeCycleService lifeCycleService = LifeCycleService.Instance();
            lifeCycleService.SetActivity(new MainActivity());
        }
    }
}