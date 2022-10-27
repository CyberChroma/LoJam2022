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
    public bool converting = false;


    void Start()
    {
    }

    void Update()
    {
    }

    public void BloodToCancer()
    {
        StopAllCoroutines();
        StartCoroutine(WaitToConvertToCancer());
    }

    public void CancerToBlood()
    {
        StopAllCoroutines();
        StartCoroutine(WaitToConvertToBlood());
    }

    IEnumerator WaitToConvertToCancer()
    {
        converting = true;

        GetComponent<CellNavMesh>().StopMoving();

        yield return new WaitForSeconds(3);

        GetComponent<CellNavMesh>().enabled = false;
        GetComponent<CancerNavMesh>().enabled = true;

        tag = "Cancerous";
        bloodType = BloodType.CancerousCell;

        transform.Find("Blood").gameObject.SetActive(false);
        transform.Find("Cancer").gameObject.SetActive(true);
        converting = false;
    }

    IEnumerator WaitToConvertToBlood()
    {
        converting = true;

        yield return new WaitForSeconds(1);

        GetComponent<CellNavMesh>().enabled = true;
        GetComponent<CancerNavMesh>().enabled = false;

        tag = "Blood Cell";
        bloodType = BloodType.BloodCell;

        transform.Find("Blood").gameObject.SetActive(true);
        transform.Find("Cancer").gameObject.SetActive(false);
        converting = false;
    }
}
