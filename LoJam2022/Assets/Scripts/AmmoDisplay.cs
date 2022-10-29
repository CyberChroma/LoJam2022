using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject[] PlayersArray;

    private int ammo = 0;
    private Queue<GameObject> PlayersQueue = new Queue<GameObject>();

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < PlayersArray.Length; i++)
        {
            PlayersQueue.Enqueue(PlayersArray[i]);
        }
    }

    void Update()
    {
        ammo = PlayersQueue.Peek().GetComponent<PlayerThrow>().curAmmo;
        string ammoS = ammo.ToString();
        text.SetText(ammoS);
    }

    public void Change()
    {
        GameObject popped = PlayersQueue.Dequeue();
        PlayersQueue.Enqueue(popped);
    }
}
