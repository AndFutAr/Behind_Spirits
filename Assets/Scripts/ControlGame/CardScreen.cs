using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScreen : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Camera _cam;
    Vector3 OffSet, StartPos;
    public Transform _defaultParent;

    [SerializeField] private string _name;
    [SerializeField] private Text _nameText;
    [SerializeField] private int _count;
    [SerializeField] private Text _countText;
    public GameObject _structure;

    void Start()
    {
        StartPos = transform.position;
    }
    void Update()
    {
        _nameText.text = _name;
        _countText.text = _count.ToString();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        OffSet = transform.position - _cam.ScreenToWorldPoint(eventData.position);
        _defaultParent = transform.parent;
        transform.SetParent(_defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        newPosition.z = 0;
        transform.position = newPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit HallHit;
        Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(HallRay, out HallHit) && HallHit.transform.tag == "pointRd" && _count > 0)
        {
            MapBuilder._structPrefab = _structure;
            _count -= 1;
        }
        transform.SetParent(_defaultParent);
        transform.position = StartPos;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
