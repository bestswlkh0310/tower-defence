using TowerDefence.Activitys;
using TowerDefence.Views;

namespace TowerDefence
{
    public class GameActivity: Activity
    {
        public override void Start()
        {
            RegisterView(new View(xPos: 0, yPos: 0, text: "GameStart!"));
        }

        public override void Update()
        {
            
        }

        public override void Destroy()
        {
            
        }
    }
}