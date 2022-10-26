using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BloodType
{
    BloodCell,
    CancerousCell
};

public class CellTypeManager : MonoBehaviour
{
    public BloodType bloodType;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void BloodToCancer()
    {
        GetComponent<CellNavMesh>().enabled = false;
        GetComponent<CancerNavMesh>().enabled = true;

        tag = "Cancerous";
        bloodType = BloodType.CancerousCell;

        transform.Find("Blood").gameObject.SetActive(false);
        transform.Find("Cancer").gameObject.SetActive(true);
    }

    public void CancerToBlood()
    {
        GetComponent<CellNavMesh>().enabled = true;
        GetComponent<CancerNavMesh>().enabled = false;

        tag = "Blood Cell";
        bloodType = BloodType.BloodCell;

        transform.Find("Blood").gameObject.SetActive(true);
        transform.Find("Cancer").gameObject.SetActive(false);
    }
}
