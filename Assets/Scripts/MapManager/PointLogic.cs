using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class PointLogic : MonoBehaviour
{
    private double NumStructI = 0.0, NumStructJ = 0.0;
    public int _pointPosI, _pointPosJ;
    public bool isReady = false, isStruct = false, isSelected = false;

    private string StructureText = "-";

    [SerializeField] private GameObject _structure;
    private GameObject _structureMesh;
    private int _needStep = -1, GetFood = 0, GetMat = 0, GetStruct = 1, GetIdea = 1;
    /*private int StructureType;
    private int StructureBuff;*/

    public int CountPlace = 0, FoodPerStep = 0, MaterialPerStep = 0;
    private int FactorForFood = 1, FactorForMat = 1, FactorForIdea = 1, FactorForAll = 1;

    [SerializeField] private GameObject _tilePrefab0, _tilePrefab1;

    void Start()
    {
        NumStructI = gameObject.transform.position.x + 5;
        NumStructJ = gameObject.transform.position.z + 5;
        _pointPosI = (int)NumStructI / 1;
        _pointPosJ = (int)NumStructJ / 1;

        if((_pointPosI == 4 || _pointPosI == 5 || _pointPosI == 6) && (_pointPosJ == 4 || _pointPosJ == 5 || _pointPosJ == 6))
        {
            isReady = true;
            _structureMesh = _tilePrefab1;
        }
        else
        {
            isReady = false;
            _structureMesh = _tilePrefab0;
        }
        //_structure = Instantiate(_structureMesh, gameObject.transform.position, Quaternion.identity);
        //_structure.transform.SetParent(this.transform);
        GetIdea = 1;
    }
    void Update()
    {
        if (isReady && !isStruct)
        {
            _structureMesh = _tilePrefab1;
            _tilePrefab1.SetActive(true);
            _tilePrefab0.SetActive(false);
            transform.tag = "pointRd";
        }
        else if (!isReady)
        {
            _tilePrefab1.SetActive(false);
            _tilePrefab0.SetActive(true);
            _structureMesh = _tilePrefab0;
            transform.tag = "pointDisRd";
        }
        else if (isReady && isStruct)
        {
            _structureMesh = _tilePrefab1;
            transform.tag = "pointSt";
        }

        if (SelectPoint._selectedPoint == this.transform)
        {
            isSelected = true;
            SelectPoint.StructText = StructureText;
            isReady = SelectPoint.isRd;
            isStruct = SelectPoint.isStr;
        }
        else
        {
            isSelected = false;
        }

        if (Player.isStep)
        {
            if (StructureText == "Chum")
            {
                CountPlace = 2;
                if (Player._placeForLive == 2)
                {
                    Player._countPeople = 2;
                }
                else if (Player._placeForLive > 2)
                {
                    if (Player._thisStep == _needStep)
                    {
                        Player._countPeople = Player._placeForLive;
                        _needStep = -1;
                    }
                }
            }
            else if (StructureText == "Lesopilka")
            {
                if(GetMat == 1)
                {
                    GetMat = 0;
                    MaterialPerStep *= (FactorForMat * FactorForAll);
                    Player._materialPerStep += MaterialPerStep;
                }
            }
            else if (StructureText == "Labas")
            {
                if(GetFood == 1)
                {
                    GetFood = 0;
                    FoodPerStep *= (FactorForFood * FactorForAll);
                    Player._foodPerStep += FoodPerStep;
                }
            }
            else if(StructureText == "Koster")
            {
                if(GetIdea == 1)
                {
                    Player._ideasPerStep += 2 * FactorForIdea * FactorForAll;
                    GetIdea = 0;
                }
            }
        }
        else if(!Player.isStep)
        {
            if (StructureText == "Lesopilka")
            {
                GetMat = 1;
            }
            else if (StructureText == "Labas")
            {
                GetFood = 1;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (GetStruct == 1)
        {
            if (collision.collider.tag == "StructMain")
            {
                isStruct = true;
                if (collision.gameObject.layer == LayerMask.NameToLayer("PlaceLive"))
                {
                    Player._placeForLive += 2;
                    StructureText = "Chum";
                    _needStep = Player._thisStep + 1;
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Food"))
                {
                    StructureText = "Labas";
                    FoodPerStep = 2;
                    GetFood = 1;
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Material"))
                {
                    StructureText = "Lesopilka";
                    MaterialPerStep = 3;
                    GetMat = 1;
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Ideas"))
                {
                    StructureText = "Koster";
                }
                GetStruct = 0;
            }
            else if (collision.transform.tag == "StructSide")
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("PlaceLive"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Arhiv";
                        isStruct = true;
                    }
                    CountPlace += 1;
                    Player._placeForLive += 1;

                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Food"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Kiparis";
                        isStruct = true;
                    }
                    FactorForFood = 2;
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Material"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Sklad";
                        isStruct = true;
                    }
                    FactorForMat = 2;
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Ideas"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Gharovnya";
                        isStruct = true;
                    }
                    FactorForIdea = 2;
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("All1"))
                {
                    FactorForAll = 2;

                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Besedka";
                        isStruct = true;
                    }
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Spirits"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Totem";
                        isStruct = true;
                    }
                }
                GetStruct = 0;
            }
            else if (collision.transform.tag == "StructCon")
            {
                isStruct = true;
                if (collision.gameObject.layer == LayerMask.NameToLayer("Population"))
                {
                    StructureText = "Vozhd";
                }
                else if (collision.gameObject.layer == LayerMask.NameToLayer("Spirits"))
                {
                    StructureText = "Shaman";
                }
                GetStruct = 0;
            }
        }
    }
}
