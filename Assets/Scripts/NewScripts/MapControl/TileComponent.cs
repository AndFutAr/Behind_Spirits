using UnityEngine;

namespace NewScripts.MapControl
{
    public class TileComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] tilePrefabs;
        
        private int IDx, IDy;
        [SerializeField] private int curIndexModel, lastIndexModel;

        public int X_ID => IDx;
        public int Y_ID => IDy; 
        public int CurIndexModel() => curIndexModel; 
        public int LastIndexModel() => lastIndexModel;
        public void CurIndexModel(int value, bool isLast)
        {
            if (!isLast) lastIndexModel = curIndexModel;
            curIndexModel = value;
            tilePrefabs[curIndexModel].SetActive(true);
            for (int i = 0; i < tilePrefabs.Length; i++)
            {
                if (i != curIndexModel)
                    tilePrefabs[i].SetActive(false);
            }
        }
        public void SetModel() => lastIndexModel = curIndexModel;
        public void SetupTile(int x, int y, int model)
        {
            IDx = x;
            IDy = y;
            curIndexModel = model;
            lastIndexModel = model;
        }
    }
}