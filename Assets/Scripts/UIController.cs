using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTMP;

    public void UpdateScore(int score)
    {
        scoreTMP.text = score.ToString();
    }
}
