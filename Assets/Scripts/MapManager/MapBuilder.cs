using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapBuilder : MonoBehaviour, IDropHandler
{
    private GameObject _targetTile, _targetPrefab;
    private bool _tileType;
    [SerializeField] private GameObject _tile0Prefab, _tile1Prefab;

    private GameObject? _targetStructure;
    static public GameObject? _structPrefab;
    [SerializeField] private Transform _theColony, _theLocation;

    [SerializeField] private Camera _cam;

    void Start()
    {
        for(int i = -5; i <= 5; i++)
        {
            for(int j = -5; j <= 5; j++)
            {
                _tileType = false;
                if((i == -1 || i == 0 || i == 1) && (j == -1 || j == 0 || j == 1))
                {
                    _tileType = true;
                }

                if (_tileType)
                {
                    _targetPrefab = _tile1Prefab;
                }
                else
                {
                    _targetPrefab = _tile0Prefab;
                }
                _targetTile = Instantiate(_targetPrefab, new Vector3(i, 0, j), Quaternion.identity);
                _targetTile.transform.SetParent(_theLocation);

                if (_tileType)
                {
                    _targetTile.transform.tag = "pointRd";
                }
                else
                {
                    _targetTile.transform.tag = "pointDisRd";
                }
            }
        }
        _structPrefab = null;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit HallHit;
            Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(HallRay, out HallHit))
            {
                if (HallHit.transform.tag == "pointRd")
                {
                    if (_structPrefab != null)
                    {
                        _targetStructure = Instantiate(_structPrefab, new Vector3(HallHit.transform.position.x, 1.5f, HallHit.transform.position.z), Quaternion.identity);
                        _targetStructure.transform.SetParent(_theColony);
                        _structPrefab = null;
                    }
                }
            }
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        CardScreen Card = eventData.pointerDrag.GetComponent<CardScreen>();
        if (Card)
        {
            Card._defaultParent = transform;
        }
    }
}
