using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CellManager : MonoBehaviour
{
    [SerializeField] public int NumOfBlood = 1;
    [SerializeField] public int NumOfCancer = 1;

    [SerializeField] private Slider slider;
    [SerializeField] private GameObject warning;

    private void Start()
    {
        slider.maxValue = NumOfBlood + NumOfCancer;
    }

    private void Update()
    {
        SetHealth(NumOfBlood);

        if (GetLoseCondition())
        {
            StartCoroutine(WaitForGameOver());
        }
    }

    public void SetHealth(int cellsLeft)
    {
        slider.value = cellsLeft;
    }

    public bool GetLoseCondition()
    {
        if (NumOfBlood == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator WaitForGameOver()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }
}
