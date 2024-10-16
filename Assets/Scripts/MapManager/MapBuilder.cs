using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapBuilder : MonoBehaviour, IDropHandler
{
    private GameObject _targetTile;
    [SerializeField] private GameObject _tilePrefab;

    private GameObject? _targetStructure;
    static public GameObject? _structPrefab;
    static public int StructType;
    static public int StructBuff;
    [SerializeField] private Transform _theColony, _theLocation;

    [SerializeField] private Camera _cam;

    void Start()
    {
        for (int i = -5; i <= 5; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                _targetTile = Instantiate(_tilePrefab, new Vector3(i, 0.01f, j), Quaternion.identity);
                _targetTile.transform.SetParent(_theLocation);
            }
        }
        _structPrefab = null;
    }
    void Update()
    {
        if (Player.isStep)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit HallHit;
                Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(HallRay, out HallHit))
                {
                    if (HallHit.transform.tag == "pointRd" && HallHit.transform != SelectPoint._selectedPoint)
                    {
                        if (_structPrefab != null)
                        {
                            _targetStructure = Instantiate(_structPrefab, new Vector3(HallHit.transform.position.x, 1.65f, HallHit.transform.position.z), Quaternion.identity);
                            _targetStructure.transform.SetParent(_theColony);
                            switch (StructType)
                            {
                                case 1: _targetStructure.transform.tag = "StructMain"; break;
                                case 2: _targetStructure.transform.tag = "StructSide"; break;
                                case 3: _targetStructure.transform.tag = "StructCon"; break;
                            }
                            switch (StructBuff)
                            {
                                case 1: _targetStructure.layer = LayerMask.NameToLayer("PlaceLive"); break;
                                case 2: _targetStructure.layer = LayerMask.NameToLayer("Food"); break;
                                case 3: _targetStructure.layer = LayerMask.NameToLayer("Material"); break;
                                case 4: _targetStructure.layer = LayerMask.NameToLayer("Ideas"); break;
                                case 5: _targetStructure.layer = LayerMask.NameToLayer("All1"); break;
                                case 7: _targetStructure.layer = LayerMask.NameToLayer("Population"); break;
                                case 8: _targetStructure.layer = LayerMask.NameToLayer("Spirits"); break;
                            }

                            _structPrefab = null;
                            HallHit.transform.tag = "pointSt";
                        }
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
