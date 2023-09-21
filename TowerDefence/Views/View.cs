using System;

namespace TowerDefence.Views
{
    public class View
    {
        private int xPos;
        private int yPos;
        private string text;

        public View(int xPos, int yPos, string text)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.text = text;
        }
        
        public void PrintView()
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(text);
        }
    }
}