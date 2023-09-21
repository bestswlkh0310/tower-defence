using System;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Activitys;
using TowerDefence.Views;

namespace TowerDefence
{
    public class GameActivity: Activity
    {
        public override void Start()
        {
            InitBackGround();
            InitGrid();
            InitUI();
        }

        public override void Update()
        {
            InputKey();

            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    break;
                case ConsoleKey.RightArrow:
                    break;
                case ConsoleKey.UpArrow:
                    break;
                case ConsoleKey.DownArrow:
                    break;
            }
            
            ObserveEvent(e =>
            {
                
                return e;
            });
        }
        
        private ConsoleKeyInfo cki;

        private void InputKey()
        {
            Task.Factory.StartNew(() =>
            {
                cki = Console.ReadKey(true);
            });
        }
        
        public override void Destroy()
        {
            
        }

        private void InitBackGround()
        {
            View line1 = new View(xPos: 0, yPos: 0, text: new String('\u25a0', Constant.Width));
            View line2 = new View(xPos: 0, yPos: Constant.Height - 1, text: new String('\u25a0', Constant.Width));
            RegisterAllView(line1, line2);
        }

        private void InitGrid()
        {
            for (int i = 0; i < Constant.Height / Constant.TowerSize - 1; i++)
            {
                String rowText = new String('\u2500', Constant.Width);
                for (int j = Constant.TowerSize * 2; j < Constant.Width; j += Constant.TowerSize * 2)
                {
                    rowText = rowText.ReplaceAt(j, '\u254B');
                }
                View line1 = new View(xPos: 0, yPos: Constant.TowerSize * (i + 1), text: rowText);
                RegisterAllView(line1);
            }

            for (int i = 1; i < Constant.Height - 1; i++)
            {
                if (i % Constant.TowerSize == 0)
                {
                    continue;
                }
                String colText = new String(' ', Constant.Width);
                for (int j = Constant.TowerSize * 2; j < Constant.Width; j += Constant.TowerSize * 2)
                {
                    colText = colText.ReplaceAt(j, '\u2503');
                }

                View line1 = new View(xPos: 0, yPos: i, text: colText);
                RegisterView(line1);
            }
        }

        private void InitUI()
        {
            
        }
    }
}