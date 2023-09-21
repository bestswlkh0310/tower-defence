using System.Collections.Generic;
using TowerDefence.Views;

namespace TowerDefence
{
    public abstract class Tower
    {
        public string name;
        public List<View> views; // 7 * 3
    }
}