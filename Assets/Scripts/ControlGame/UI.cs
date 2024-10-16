using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _pointSetka;
    [SerializeField] private GameObject _buildBut, _buildMenu;
    [SerializeField] private GameObject _butControl, _sideMenu, _planMenu;
    [SerializeField] private GameObject _butPlan, _butBuild;
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

    void Update()
    {
        if(!Player.isStep)
        {
            Start();
        }
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
    
    public void Plun()
    {
        _sideMenu.SetActive(false);
        _butControl.SetActive(false);
        _planMenu.SetActive(true);
        _butBuild.SetActive(true);
        _butPlan.SetActive(false);
    }

    public void StartBuilding()
    {
        if (Player.isStep)
        {
            _pointSetka.SetActive(true);

            _buildBut.SetActive(false);
            _buildMenu.SetActive(true);

            _butControl.SetActive(true);
            _sideMenu.SetActive(false);
            _planMenu.SetActive(false);

            _butBuild.SetActive(false);
            _butPlan.SetActive(true);
        }
    }
    public void CloseBuild()
    {
        _pointSetka.SetActive(false);

        _buildBut.SetActive(true);
        _buildMenu.SetActive(false);
    }
}
