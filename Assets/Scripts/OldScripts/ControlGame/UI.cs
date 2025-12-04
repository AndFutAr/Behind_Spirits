using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _pointSetka;
    [SerializeField] private GameObject _buildMenu, _mainMenu, _sideMenu;

    [SerializeField] private GameObject _invocControl0, _invocControl1;
    [SerializeField] private GameObject StudyOkno;

    void Start()
    {
        _pointSetka.SetActive(false);
        _buildMenu.SetActive(false);
        _sideMenu.SetActive(false);
        _mainMenu.SetActive(false);

        _invocControl0.SetActive(false);
        _invocControl1.SetActive(false);
    }

    void Update()
    {
        if (!Player.isStep)
        {
            Start();
        }
    }
    public void OpenMain()
    {
        _mainMenu.SetActive(true);
        _sideMenu.SetActive(false);
    }
    public void OpenSide()
    {
        _sideMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void StartBuilding()
    {
        if (Player.isStep)
        {
            _pointSetka.SetActive(true);
            _buildMenu.SetActive(true);
            _mainMenu.SetActive(true);
            _sideMenu.SetActive(false);
        }
    }
    public void CloseBuild()
    {
        _pointSetka.SetActive(false);
        _buildMenu.SetActive(false);
    }


    public void OpenInvocPeople()
    {
        _invocControl0.SetActive(true);
        _invocControl1.SetActive(false);
    }
    public void OpenInvocSpirits()
    {
        _invocControl0.SetActive(false);
        _invocControl1.SetActive(true);
    }

    public void Game()
    {
        StudyOkno.SetActive(false);
    }
}
