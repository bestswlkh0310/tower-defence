using System;

namespace TowerDefence.Views
{
    public class View
    {
        public int xPos;
        public int yPos;
        public string text;

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