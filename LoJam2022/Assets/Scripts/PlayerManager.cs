using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ProfileUI profileUI;
    [SerializeField] public GameObject[] PlayersArray;
    [SerializeField] private Queue<GameObject> PlayersQueue = new Queue<GameObject>();

    void Start()
    {
        PlayersQueue.Enqueue(PlayersArray[0]);
        for(int i = 1; i < PlayersArray.Length; i++)
        {
            SwitchEnables(PlayersArray[i], false);
            PlayersQueue.Enqueue(PlayersArray[i]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchEnables(PlayersQueue.Peek(), false);
            profileUI.Change();
            GameObject popped = PlayersQueue.Dequeue();
            PlayersQueue.Enqueue(popped);
            SwitchEnables(PlayersQueue.Peek(), true);
        }
    }

    private void SwitchEnables(GameObject player, bool boolean)
    {
        player.GetComponent<PlayerMove>().enabled = boolean;
        player.GetComponent<PlayerThrow>().enabled = boolean;
        player.GetComponent<Rigidbody>().detectCollisions = boolean;
        player.transform.Find("CameraPivot").GetComponent<PlayerCamera>().enabled = boolean;
        player.transform.Find("CameraPivot").Find("Main Camera").gameObject.SetActive(boolean);
    }
   
}
