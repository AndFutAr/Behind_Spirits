using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScreen : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Camera _cam;
    Vector3 OffSet, StartPos;
    public Transform _defaultParent;

    private int _needStep = -1;
    [SerializeField] private string _name;
    [SerializeField] private Text _nameText;
    [SerializeField] private int _count;
    [SerializeField] private Text _countText;
    [SerializeField] private int _matForCard, _ideasForCard = 0;
    [SerializeField] private int _formalCount;
    [SerializeField] private bool _isOpened;

    [SerializeField] private GameObject _structure;
    [SerializeField] private int _structType = 0;
    [SerializeField] private int _structBuff = 0;
    [SerializeField] private GameObject _lockItem;

    private float x, y;
    private Vector3 StartScale;

    void Start()
    {
        StartPos = transform.position;
        StartScale = transform.localScale;
        x = transform.localScale.x;
        y = transform.localScale.y;
    }
    void Update()
    {
        _nameText.text = _name;
        _countText.text = _count.ToString();

        if (Player.isStep)
        {
            if (Player._thisStep == _needStep)
            {
                _count = _formalCount;
                _needStep = -1;
            }
        }
        if (_isOpened)
        {
            _lockItem.SetActive(false);
        }
        else
        {
            _lockItem.SetActive(true);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_isOpened)
        {
            OffSet = transform.position - _cam.ScreenToWorldPoint(eventData.position);
            _defaultParent = transform.parent;
            transform.SetParent(_defaultParent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_isOpened)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            newPosition.z = 0;
            transform.position = newPosition;
            x = 0.3f;
            y = 0.3f;
            gameObject.transform.localScale = new Vector3(x, y, transform.localScale.z);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isOpened)
        {
            RaycastHit HallHit;
            Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(HallRay, out HallHit) && HallHit.transform.tag == "pointRd" && _count > 0 && SelectPoint._selectedPoint != HallHit.transform)
            {
                MapBuilder._structPrefab = _structure;
                MapBuilder.StructType = _structType;
                MapBuilder.StructBuff = _structBuff;
                _count -= 1;
                _formalCount -= 1;
            }
            transform.localScale = StartScale;
            transform.SetParent(_defaultParent);
            transform.position = StartPos;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void PlusCount()
    {
        if (Player._materialPerStep >= _matForCard && _isOpened)
        {
            _formalCount++;
            Player._materialPerStep -= _matForCard;
            _needStep = Player._thisStep + 1;
        }
    }
    public void OpenCard()
    {
        if(!_isOpened)
        {
            _isOpened = true;
            Player._ideasPerStep -= _ideasForCard;
        }
    }
}
