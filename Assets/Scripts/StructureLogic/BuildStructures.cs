using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildStructures : MonoBehaviour, IDropHandler
{
    private GameObject? _targetStructure;
    static public GameObject? _structPrefab;
    public GameObject[] _structures = new GameObject[15];
    [SerializeField] private Camera _cam;

    void Start()
    {
        _structPrefab = null;
    }
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit HallHit;
            Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(HallRay, out HallHit))
            {
                if(HallHit.transform.tag == "point")
                {
                    if (_structPrefab != null)
                    {
                        _targetStructure = Instantiate(_structPrefab, HallHit.transform.position, Quaternion.identity);
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
