using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour {
    public float throwDelay = 2;
    public int curAmmo = 4;
    public bool canThrow = true;
    public GameObject whiteBloodCell;
    public Transform whiteCellParent;
    public Transform shootPoint;

    // Update is called once per frame
    void Update() {
        if (canThrow && Input.GetKeyDown(KeyCode.LeftShift)) {
            GameObject newCell = Instantiate(whiteBloodCell, shootPoint.position, shootPoint.rotation, whiteCellParent);
            newCell.GetComponent<WhiteBloodCell>().Throw(GetComponent<Collider>());
            StartCoroutine(WaitToThrow());
        }
    }

    IEnumerator WaitToThrow() {
        curAmmo--;
        canThrow = false;
        yield return new WaitForSeconds(throwDelay);
        if (curAmmo > 0) {
            canThrow = true;
        }
    }

    public void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("White Cell")) {
            Destroy(other.gameObject);
            curAmmo++;
            if (curAmmo == 1) {
                canThrow = true;
            }
        }
    }
}
