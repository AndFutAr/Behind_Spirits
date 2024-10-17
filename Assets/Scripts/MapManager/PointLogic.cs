using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    static public bool isChop = false;
    /*private int StructureType;
    private int StructureBuff;*/

    private int CountPlace = 0, FoodPerStep = 0, MaterialPerStep = 0, IdeaCount = 10;
    private bool CheckForest = false;
    private int FactorForFood = 1, FactorForMat = 1, FactorForIdea = 1, FactorForAll = 1;
    private int ForestCount = 0, n = 1;
    private int _chanceTile;

    [SerializeField] private GameObject _tilePrefab0;
    [SerializeField] private GameObject[] _tile1Prefabs = new GameObject[4];

    void Start()
    {
        NumStructI = gameObject.transform.position.x + 5;
        NumStructJ = gameObject.transform.position.z + 5;
        _pointPosI = (int)NumStructI / 1;
        _pointPosJ = (int)NumStructJ / 1;
        _chanceTile = Random.Range(0, 3);

        if ((_pointPosI == 4 || _pointPosI == 5 || _pointPosI == 6) && (_pointPosJ == 4 || _pointPosJ == 5 || _pointPosJ == 6))
        {
            isReady = true;
        }
        else
        {
            isReady = false;
        }
        //_structure = Instantiate(_structureMesh, gameObject.transform.position, Quaternion.identity);
        //_structure.transform.SetParent(this.transform);
        GetIdea = 1;

        if (isReady && !isStruct)
        {
            for (int i = 0; i < 4; i++)
            {
                _tile1Prefabs[i].SetActive(false);
            }
            _tilePrefab0.SetActive(true);

            transform.tag = "pointRd";
        }
        else if (!isReady)
        {
            for (int i = 0; i < 4; i++)
            {
                _tile1Prefabs[i].SetActive(false);
            }
            _tilePrefab0.SetActive(false);
            _tile1Prefabs[_chanceTile].SetActive(true);
            transform.tag = "pointDisRd";
        }
    }
    void Update()
    {
        if (transform.tag == "pointRd")
        {
            isReady = true;
            for (int i = 0; i < 4; i++)
            {
                _tile1Prefabs[i].SetActive(false);
            }
            _tilePrefab0.SetActive(true);
        }
        else if (transform.tag == "pointDisRd")
        {
            isReady = false;
            for (int i = 0; i < 4; i++)
            {
                _tile1Prefabs[i].SetActive(false);
            }
            _tilePrefab0.SetActive(false);
            _tile1Prefabs[_chanceTile].SetActive(true);
        }

        if (isReady && !isStruct)
        {
            transform.tag = "pointRd";
        }
        else if (!isReady)
        {
            transform.tag = "pointDisRd";
        }
        else if (isReady && isStruct)
        {
            transform.tag = "pointSt";
        }

        if (SelectPoint._selectedPoint == this.transform)
        {
            isSelected = true;
            SelectPoint.StructText = StructureText;
            isReady = SelectPoint.isRd;
            isStruct = SelectPoint.isStr;
            if (isReady)
            {
                transform.tag = "pointRd";
            }
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
                    if (Player._thisStep == _needStep && Player._countPeople < Player._foodPerStep)
                    {
                        Player._countPeople++;
                        _needStep = -1;
                    }
                }
            }
            else if (StructureText == "Lesopilka")
            {
                if (GetMat == 1)
                {
                    GetMat = 0;
                    MaterialPerStep *= (FactorForMat * FactorForAll);
                    Player._materialPerStep += 3 * FactorForMat * FactorForAll;
                }
            }
            else if (StructureText == "Labas")
            {
                if (GetFood == 1)
                {
                    GetFood = 0;
                    FoodPerStep *= (FactorForFood * FactorForAll);
                    Player._foodPerStep += (3 * FactorForFood * FactorForAll + ForestCount);
                }
            }
            else if (StructureText == "Koster")
            {
                if (GetIdea == 1)
                {
                    IdeaCount = 10;
                    Player._ideasPerStep += IdeaCount * FactorForIdea * FactorForAll;
                    GetIdea = 0;
                }
            }
        }
        else if (!Player.isStep)
        {
            _needStep = Player._thisStep + 1;
            if (StructureText == "Lesopilka")
            {
                GetMat = 1;
            }
            else if (StructureText == "Labas")
            {
                GetFood = 1;
            }
            IdeaCount = 10;
            CheckForest = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
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
                //GetStruct = 0;
            }
            if (collision.transform.tag == "StructSide")
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("PlaceLive"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Arhiv";
                        isStruct = true;
                    }
                    if (StructureText == "Chum")
                    {
                        CountPlace += 1;
                        Player._placeForLive += 1;
                    }

                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Food"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Kiparis";
                        isStruct = true;
                    }
                    FactorForFood = 2;
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Material"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Sklad";
                        isStruct = true;
                    }
                    FactorForMat = 2;
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Ideas"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Gharovnya";
                        isStruct = true;
                    }
                    FactorForIdea = 2;
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("All1"))
                {
                    FactorForAll = 2;

                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Besedka";
                        isStruct = true;
                    }
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Spirits"))
                {
                    if (collision.transform.position.x == gameObject.transform.position.x && collision.transform.position.z == gameObject.transform.position.z)
                    {
                        StructureText = "Totem";
                        isStruct = true;
                    }
                }
                //GetStruct = 0;
            }
            if (collision.transform.tag == "StructCon")
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
                //GetStruct = 0;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "pointDisRd")
        {
            if (StructureText == "Lesopilka" && (collision.transform.position.x == transform.position.x || collision.transform.position.z == transform.position.z))
            {
                collision.transform.tag = "pointRd";
                ForestCount += 1;
                Player._materialPerStep += 2;
                Player._repOfSpirits -= 2;
            }
            else if (StructureText == "Labas" && n == 1)
            {
                n = 0;
                ForestCount = 1;
                Player._repOfSpirits -= 2;
            }
        }
        else if (collision.transform.tag != "pointStr" && CheckForest == false)
        {
            if (StructureText == "Koster")
            {
                CheckForest = true;
                IdeaCount -= 1;
            }
        }
        if (collision.transform.tag == "pointRd" && isSelected == true && isChop == false)
        {
            if (!isReady)
            {
                isChop = true;

            }
        }
        if(collision.collider.tag == "Totem")
        {
            if(StructureText == "Shaman")
            {
                Invocation.factorShaman = 2;
            }
        }
    }
}
