using System.Collections;
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

    private float randRotationX = 0;
    private float randRotationY = 0;
    private float randRotationZ = 0;

    [SerializeField] private CellManager cellManager;

    void Start()
    {
        cellManager.GetComponent<CellManager>();

        transform.Find("Blood").rotation = Random.rotation;
        transform.Find("Cancer").rotation = Random.rotation;
        randRotationX = Random.Range(0f, 180f);
        randRotationY = Random.Range(0f, 180f);
        randRotationZ = Random.Range(0f, 180f);
    }

    void Update()
    {
        float xValue = (float)(0.5 * Mathf.Sin(randRotationX) + 0.5);
        float yValue = (float)(0.5 * Mathf.Cos(randRotationY) + 0.5);
        float zValue = (float)(0.5 * Mathf.Cos(randRotationZ) + 0.5);
        if (bloodType == BloodType.BloodCell)
        {
            transform.Find("Blood").Rotate(new Vector3(xValue, yValue, zValue));
        } else
        {
            transform.Find("Cancer").Rotate(new Vector3(xValue, yValue, zValue));
        }
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

        cellManager.NumOfBlood--;
        cellManager.NumOfCancer++;

        tag = "Cancerous";
        bloodType = BloodType.CancerousCell;

        transform.Find("Blood").gameObject.SetActive(false);
        transform.Find("Cancer").gameObject.SetActive(true);
        converting = false;
    }

    IEnumerator WaitToConvertToBlood()
    {
        converting = true;

        yield return new WaitForSeconds(0.1f);

        GetComponent<CellNavMesh>().enabled = true;
        GetComponent<CancerNavMesh>().enabled = false;

        cellManager.NumOfBlood++;
        cellManager.NumOfCancer--;

        tag = "Blood Cell";
        bloodType = BloodType.BloodCell;

        transform.Find("Blood").gameObject.SetActive(true);
        transform.Find("Cancer").gameObject.SetActive(false);
        converting = false;
        gameObject.GetComponent<CellNavMesh>().targetAquired = false;
    }
}
