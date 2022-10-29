using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    private int numOfPlayers = 0;
    [SerializeField] private PlayerManager playerManager;


    private void Start()
    {
        playerManager.GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if (GetWinCondition())
        {
            StartCoroutine(WaitForWinCondition());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            numOfPlayers++;
            Debug.Log("TESTING!!!Enter");
            Debug.Log(numOfPlayers);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            numOfPlayers--;
            Debug.Log("TESTING!!!Exit");
        }
    }

    private bool GetWinCondition()
    {
        if (numOfPlayers == playerManager.PlayersArray.Length)
        {
            return true;
        } else
        {
            return false;
        }
    }

    IEnumerator WaitForWinCondition()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Congrats");
    }
}
