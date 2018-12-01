using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTimer : MonoBehaviour
{
    public float timer;
    public Text timerText;
    public GameObject endOfLevelPanel;
    public Text endOfLevelText;

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

        var safeZone = FindObjectOfType<SafeZone>().GetComponent<Collider>();
        IEnumerable<PlayerUnit> units = FindObjectsOfType<PlayerUnit>();
        foreach (var playerUnit in units)
            if (!safeZone.bounds.Intersects(playerUnit.GetComponent<Collider>().bounds))
                Destroy(playerUnit.gameObject);

        enabled = false;

        units = FindObjectsOfType<PlayerUnit>().Where(unit => unit.isActiveAndEnabled);
        endOfLevelPanel.SetActive(true);
        endOfLevelText.text = string.Format("Congrats, you saved: {0} units!", units.Count());
    }
}
