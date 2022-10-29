using UnityEngine.UI;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] public int NumOfBlood = 1;
    [SerializeField] public int NumOfCancer = 1;

    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.maxValue = NumOfBlood + NumOfCancer;
    }

    private void Update()
    {
        SetHealth(NumOfBlood);
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
}
