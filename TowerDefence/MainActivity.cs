using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TowerDefence.Activitys;
using TowerDefence.Views;

namespace TowerDefence
{
    public class MainActivity: Activity
    {
        struct State
        {
            public int ind;
        }

        private State state;
        
        enum MainEvent
        {
            ClickLeft = 0,
            ClickRight = 1,
            Enter = 2
        }
        
        private ConsoleKeyInfo cki;

        private View ind1 = new View(xPos: Constant.Width / 2 - 9, yPos: Constant.Height / 2 + 1,
            text: " ");

        private View ind2 = new View(xPos: Constant.Width / 2 + 6, yPos: Constant.Height / 2 + 1,
            text: " ");

        public override void Start()
        {
            InitButtons();
            InitBackGroundView();
            InitIndicator();
        }

        public override void Update()
        {
            InputKey();

            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    PushEvent((int)MainEvent.ClickLeft);
                    break;
                case ConsoleKey.RightArrow:
                    PushEvent((int)MainEvent.ClickRight);
                    break;
                case ConsoleKey.Enter:
                    PushEvent((int)MainEvent.Enter);
                    break;
            }

            ind1.text = state.ind == 0 ? "---" : "   ";
            ind2.text = state.ind == 1 ? "---" : "   ";
            
            ObserveEvent(i =>
            {
                switch (i)
                {
                    case (int)MainEvent.ClickLeft:
                        state.ind = 0;
                        break;
                    case (int)MainEvent.ClickRight:
                        state.ind = 1;
                        break;
                    case (int)MainEvent.Enter:
                        if (state.ind == 0)
                        {
                            LifeCycleService lifeCycleService = LifeCycleService.Instance();
                            lifeCycleService.SetActivity(new GameActivity());
                        } else if (state.ind == 1)
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                return i;
            });
        }

        private void InputKey()
        {
            Task.Factory.StartNew(() =>
            {
                cki = Console.ReadKey(true);
            });
        }

        public override void Destroy()
        { }

        private void InitButtons()
        {
            View start = new View(xPos: Constant.Width / 2 - 10, yPos: Constant.Height / 2, text: "start");
            View exit = new View(xPos: Constant.Width / 2 + 6, yPos: Constant.Height / 2, text: "exit");
            RegisterAllView(start, exit);
        }
        
        private void InitBackGroundView()
        {
            View title = new View(xPos: Constant.Width / 2 - 7, yPos: Constant.Height / 2 - 2, "Tower Defence!!");
            View alert = new View(xPos: Constant.Width / 2 - 7, Constant.Height / 2 + 2, text: "Enter to start");
            View line1 = new View(xPos: 0, yPos: 0, text: new String('\u25a0', Constant.Width));
            View line2 = new View(xPos: 0, yPos: Constant.Height - 1, text: new String('\u25a0', Constant.Width));
            RegisterAllView(line1, line2, title, alert);
            for (int i = 1; i < Constant.Height - 1; i++)
            {
                RegisterView(new View(xPos: 0, yPos: i, "\u25a0"));
                RegisterView(new View(xPos: Constant.Width - 1, yPos: i, "\u25a0"));
            }
        }

        private void InitIndicator()
        {
            RegisterView(ind1);
            RegisterView(ind2);
        }
        
    }
}