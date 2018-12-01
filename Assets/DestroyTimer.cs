using UnityEngine;
using UnityEngine.UI;

public class DestroyTimer : MonoBehaviour
{
    public float timer;
    public Text timerText;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            OnFinishTimer();

        timerText.text = timer.ToString("0.000");
    }

    public void StartTimer()
    {
        enabled = true;
    }

    private void OnFinishTimer()
    {
        timer = 0;
        foreach (var playerUnit in FindObjectsOfType<PlayerUnit>())
            Destroy(playerUnit.gameObject);
        enabled = false;
    }
}
