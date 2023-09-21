using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefence.Activitys;
using TowerDefence.Views;

namespace TowerDefence.Activitys
{
    public abstract class Activity: ILifeCycle
    {
        private Queue<int> _eventQueue = new Queue<int>();

        private List<View> _viewList = new List<View>();

        public Boolean IsDie = false;
        
        public void PushEvent(int e)
        {
            _eventQueue.Enqueue(e);
        }
        
        public void ObserveEvent(Func<int, int> observeFunc)
        {
            for (int i = 0; i < _eventQueue.Count; i++)
            {
                int e = _eventQueue.Dequeue();
                observeFunc(e);
            }
        }

        public abstract void Start();
        public abstract void Update();
        public abstract void Destroy();

        public void PrintView()
        {
            for (int i = 0; i < _viewList.Count; i++)
            {
                _viewList[i].PrintView();
            }
        }
        
        public void RegisterView(View view)
        {
            _viewList.Add(view);
        }

        public void RegisterAllView(params View[] views)
        {
            foreach (var view in views)
            {
                _viewList.Add(view);
            }
        }
    }
}