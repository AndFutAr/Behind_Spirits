using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _pointSetka;
    [SerializeField] private GameObject _buildBut, _buildMenu;
    [SerializeField] private GameObject _butControl, _sideMenu;
    [SerializeField] private GameObject _mainMenu, _conMenu;
    [SerializeField] private GameObject _sidePro, _sideSoc;

    void Start()
    {
        _pointSetka.SetActive(false);

        _buildBut.SetActive(true);
        _buildMenu.SetActive(false);

        _butControl.SetActive(true);
        _sideMenu.SetActive(false);
        _mainMenu.SetActive(false);
        _conMenu.SetActive(false);
    }

    public void OpenMain()
    {
        _mainMenu.SetActive(true);
        _conMenu.SetActive(false);
    }
    public void OpenCon()
    {
        _conMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }
    public void OpenSide()
    {
        _butControl.SetActive(false);
        _sideMenu.SetActive(true);
        _sidePro.SetActive(false);
        _sideSoc.SetActive(false);
    }
    public void OpenSidePro()
    {
        _sidePro.SetActive(true);
        _sideSoc.SetActive(false);
    }
    public void OpenSideSoc()
    {
        _sideSoc.SetActive(true);
        _sidePro.SetActive(false);
    }
    public void Close()
    {
        _butControl.SetActive(true);
        _sideMenu.SetActive(false);
        _mainMenu.SetActive(false);
        _conMenu.SetActive(false);
    }


    public void StartBuilding()
    {
        _pointSetka.SetActive(true);

        _buildBut.SetActive(false);
        _buildMenu.SetActive(true);
    }
    public void CloseBuild()
    {
        _pointSetka.SetActive(false);

        _buildBut.SetActive(true);
        _buildMenu.SetActive(false);
    }
}
