using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TowerDefence.Activitys;
using TowerDefence.Views;

namespace TowerDefence
{
    public class MainActivity: Activity
    {
        enum MainEvent
        {
            ClickLeft = 0,
            ClickRight = 1
        }
        
        private ConsoleKeyInfo cki;

        public override void Start()
        {
            View line1 = new View(xPos: 0, yPos: 0, text: "------------------");
            View line2 = new View(xPos: 0, yPos: 10, text: "------------------");
            RegisterAllView(line1, line2);
        }

        public override void Update()
        {
            Task.Factory.StartNew(() =>
            {
                cki = Console.ReadKey(true);
            });

            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    PushEvent((int)MainEvent.ClickLeft);
                    break;
            }
            ObserveEvent(i =>
            {
                switch (i)
                {
                    case (int)MainEvent.ClickLeft:
                        RegisterView(new View(xPos: 3, yPos: 5, text: "new"));
                        break;
                }
                return i;
            });
        }

        public override void Destroy()
        {
            
        }

    }
}