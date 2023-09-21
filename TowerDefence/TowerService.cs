namespace TowerDefence
{
    public class TowerService
    {
        private static TowerService _instance;

        public static TowerService Instance()
        {
            if (_instance == null)
            {
                _instance = new TowerService();
            }
            return _instance;
        }

        private Tower[] _towerList = { null, null, null, null, null, null, null, null};

        public string RegisterTower(int idx, Tower tower)
        {
            if (_towerList[idx] == null)
            {
                _towerList[idx] = tower;
                return "register success";
            }
            {
                return "can't register this tower";
            }
        }

        public string UpgradeTower(Profile profile, Tower tower)
        {
            return "todo: implementation";
        }
    }
}