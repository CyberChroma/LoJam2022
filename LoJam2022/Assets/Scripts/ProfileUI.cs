using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour
{
    public float moveSpeed;
    public float scaleSpeed;

    public RectTransform[] profiles;
    public Transform[] positions;
    private int playerNum = 0;
    public Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        targets =  (Transform[])positions.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        profiles[0].transform.position = Vector3.Lerp(profiles[0].transform.position, targets[0].position, moveSpeed * Time.deltaTime);
        profiles[1].transform.position = Vector3.Lerp(profiles[1].transform.position, targets[1].position, moveSpeed * Time.deltaTime);
        profiles[2].transform.position = Vector3.Lerp(profiles[2].transform.position, targets[2].position, moveSpeed * Time.deltaTime);
        profiles[3].transform.position = Vector3.Lerp(profiles[3].transform.position, targets[3].position, moveSpeed * Time.deltaTime);
        
        for(int i = 0; i < 4; i++) {
            if (i == playerNum) {
                profiles[i].sizeDelta = Vector2.Lerp(profiles[i].sizeDelta, Vector3.one * 300, moveSpeed * Time.deltaTime);
            } else {
                profiles[i].sizeDelta = Vector2.Lerp(profiles[i].sizeDelta, Vector3.one * 100, moveSpeed * Time.deltaTime);
            }
        }
    }

    public void Change() {
        playerNum++;
        if (playerNum >= 4) {
            playerNum = 0;
        }

        switch (playerNum) {
            case 0:
                targets[0] = positions[0];
                targets[1] = positions[1];
                targets[2] = positions[2];
                targets[3] = positions[3];
                break;
            case 1:
                targets[0] = positions[3];
                targets[1] = positions[0];
                targets[2] = positions[1];
                targets[3] = positions[2];
                break;
            case 2:
                targets[0] = positions[2];
                targets[1] = positions[3];
                targets[2] = positions[0];
                targets[3] = positions[1];
                break;
            case 3:
                targets[0] = positions[1];
                targets[1] = positions[2];
                targets[2] = positions[3];
                targets[3] = positions[0];
                break;
        }
    }
}
