using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStructures : MonoBehaviour
{
    private GameObject? _targetStructure;
    private GameObject? _structPrefab;
    public GameObject[] _structures = new GameObject[15];
    [SerializeField] private Camera _cam;

    void Start()
    {
        _targetStructure = null;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit HallHit;
            Ray HallRay = _cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(HallRay, out HallHit))
            {
                if(HallHit.transform.tag == "point")
                {
                    if (_structPrefab != null)
                    {
                        _targetStructure = Instantiate(_structPrefab, HallHit.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
    public void 
}
