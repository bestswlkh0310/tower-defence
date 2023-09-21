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
            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(xPos + i, yPos);
                if (text[i] != ' ')
                {
                    Console.Write(text[i]);
                }
            }
        }
    }
}