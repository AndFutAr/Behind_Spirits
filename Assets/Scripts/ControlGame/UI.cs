using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _pointSetka;
    [SerializeField] private GameObject _buildBut, _buildMenu;

    void Start()
    {
        _pointSetka.SetActive(false);

        _buildBut.SetActive(true);
        _buildMenu.SetActive(false);
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
