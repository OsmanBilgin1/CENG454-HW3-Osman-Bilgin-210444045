using TMPro;
using UnityEngine;

public class WaveCountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text waveCountdownText;

    private void OnEnable()
    {
        WaveEvents.OnCountdownChanged += UpdateCountdownText;
    }

    private void OnDisable()
    {
        WaveEvents.OnCountdownChanged -= UpdateCountdownText;
    }

    private void UpdateCountdownText(float countdown)
    {
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
}