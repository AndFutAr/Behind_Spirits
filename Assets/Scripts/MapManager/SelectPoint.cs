using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPoint : MonoBehaviour
{
    static public Transform _selectedPoint = null;
    [SerializeField] private GameObject _ParamMenu;
    [SerializeField] private Text _selectText, _structText, _structTypeText;

    static public bool isRd, isStr;
    public int _ChopCell = 0;
    static public string StructText;

    [SerializeField] private Camera _cam;

    void Start()
    {
        _ParamMenu.SetActive(false);
    }
    void Update()
    {
        if (!Player.isStep)
        {
            _selectedPoint = null;
        }
        if (Player.isStep)
        {
            if (Input.GetMouseButtonUp(1))
            {
                RaycastHit HallHit;
                Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(HallRay, out HallHit))
                {
                    if ((HallHit.transform.tag == "pointRd" || HallHit.transform.tag == "pointDisRd" || HallHit.transform.tag == "pointSt") && _selectedPoint == null)
                    {
                        _selectedPoint = HallHit.transform;
                        _selectedPoint.position = new Vector3(_selectedPoint.position.x, 0.1f, _selectedPoint.position.z);

                        _ParamMenu.SetActive(true);
                        if (_selectedPoint.tag == "pointSt")
                        {
                            isRd = true;
                            isStr = true;
                        }
                        else if (_selectedPoint.tag == "pointRd")
                        {
                            isRd = true;
                            isStr = false;
                        }
                        else if (_selectedPoint.tag == "pointDisRd")
                        {
                            isRd = false;
                            isStr = false;
                        }
                    }
                    else if (_selectedPoint != null)
                    {
                        _selectedPoint.position = new Vector3(_selectedPoint.position.x, 0, _selectedPoint.position.z);
                        _selectedPoint = null;
                        _ParamMenu.SetActive(false);
                    }
                }
            }
        }
        if (_selectedPoint != null && _selectedPoint.tag == "pointSt")
        {
            isRd = true;
            isStr = true;
        }
        _selectText.text = isRd.ToString();
        _structText.text = isStr.ToString();
        _structTypeText.text = StructText;

    }
    public void ChopForest()
    {
        if (_selectedPoint != null && _ChopCell < Player._countPeople / 2 && Player._countPeople > 0)
        {
            isRd = true;
            isStr = false;
            _ChopCell++;
            Player._repOfSpirits -= 2;
        }
    }
}
