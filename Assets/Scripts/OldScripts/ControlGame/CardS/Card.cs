using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour/*, IBeginDragHandler, IDragHandler, IEndDragHandler*/
{
    [SerializeField] private Camera _cam;
    Vector3 OffSet, StartPos;
    public Transform _defaultParent;
    private int _needStep = -1;

    [SerializeField] private Text _nameText;
    [SerializeField] private Text _countText;
    [SerializeField] private GameObject _lockItem;

    private int _matForCard, _ideasForCard = 0;
    private int _formalCount;
    private bool _isOpened;

    private GameObject _structure;
    private int _structType = 0;
    private int _structBuff = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
