using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NewScripts.MapControl
{
    public class BuildCamera : MonoBehaviour
    {
        [SerializeField] private GameObject selectedTile;
        [SerializeField] private int currentTileID;

        public void SetCurrentTile(int tileId)
        {
            currentTileID = tileId;
            if (selectedTile != null && selectedTile.gameObject.layer == LayerMask.NameToLayer("IgnoreTile"))
                selectedTile.gameObject.layer = LayerMask.NameToLayer("Tile");
        }

        [SerializeField] private List<GameObject> UsedTiles = new List<GameObject>();
        
        void Update()
        {
            RaycastHit HallHit;
            Ray HallRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(HallRay, out HallHit))
            {
                foreach (GameObject myTile in UsedTiles.ToList())
                {
                    if (myTile != HallHit.transform.gameObject && 
                        HallHit.transform.gameObject.layer == LayerMask.NameToLayer("IgnoreTile"))
                    {
                        TileComponent tileComp = myTile.GetComponent<TileComponent>();
                        tileComp.CurIndexModel(tileComp.LastIndexModel(), true);
                        myTile.gameObject.layer = LayerMask.NameToLayer("Tile");
                        UsedTiles.Remove(myTile);
                    }
                }
                if (HallHit.transform.gameObject.layer == LayerMask.NameToLayer("Tile"))
                {
                    TileComponent tileComp = HallHit.transform.gameObject.GetComponent<TileComponent>();
                    tileComp.CurIndexModel(currentTileID, true);
                    selectedTile = HallHit.transform.gameObject;
                    HallHit.transform.transform.gameObject.layer = LayerMask.NameToLayer("IgnoreTile");
                    if (!UsedTiles.Contains(HallHit.transform.gameObject))
                        UsedTiles.Add(HallHit.transform.gameObject);
                }
                if (HallHit.transform.gameObject.layer == LayerMask.NameToLayer("IgnoreTile"))
                {
                    if (Input.GetMouseButton(0))
                        HallHit.transform.GetComponent<TileComponent>().SetModel();
                }
            }
        }
    }
}