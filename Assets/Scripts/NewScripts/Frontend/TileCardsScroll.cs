using NewScripts.MapControl;
using UnityEngine;

namespace NewScripts.Frontend
{
    public class TileCardsScroll : MonoBehaviour
    {
        public BuildCamera buildCamera;
        
        [SerializeField] private GameObject YourCardContainer, AnotherCardContainer;
        [SerializeField] private GameObject[] tileCards;
        [SerializeField] private int curTileCardId, lastIndex = 5;

        void Start()
        {
            buildCamera.SetCurrentTile(5);
        }

        void Update()
        {
            if (curTileCardId >= 0 && curTileCardId <= tileCards.Length - 1)
            {
                curTileCardId -= (int)(Input.GetAxis("Mouse ScrollWheel") * 10);

                for (int i = 0; i < tileCards.Length; i++)
                {
                    tileCards[i].transform.localScale = Vector3.one;
                    tileCards[i].transform.SetParent(AnotherCardContainer.transform);
                }
                if (curTileCardId >= 0 && curTileCardId <= tileCards.Length - 1)
                {
                    tileCards[curTileCardId].transform.SetParent(YourCardContainer.transform);
                    tileCards[curTileCardId].transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                }
            }
            if (curTileCardId < 0) curTileCardId = 0;
            else if (curTileCardId > tileCards.Length - 1)
                curTileCardId = tileCards.Length - 1;
            
            if (curTileCardId != lastIndex)
                buildCamera.SetCurrentTile(curTileCardId);
            lastIndex = curTileCardId;
        }
    }
}