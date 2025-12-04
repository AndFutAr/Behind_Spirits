using UnityEngine;

namespace NewScripts.MapControl
{
    public class MapConstruct : MonoBehaviour
    {
        [SerializeField] private GameObject buildTile;
        [SerializeField] private int size;
        
        void Start()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    GameObject tile = Instantiate(buildTile, new Vector3(i * 2 - size + 1, 0, j * 2 - size + 1), Quaternion.identity);
                    tile.transform.GetComponent<TileComponent>().SetupTile(i, j, 5);
                }
            }
        }
    }
 }