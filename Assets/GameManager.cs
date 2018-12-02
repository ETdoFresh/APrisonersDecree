using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endOfLevelPanel;
    public Text endOfLevelText;
    public List<PlayerUnit> all;
    public List<PlayerUnit> safe;

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Add(PlayerUnit playerUnit) { all.Add(playerUnit); }

    public void Remove(PlayerUnit playerUnit)
    {
        all.Remove(playerUnit);
        CheckIfFinishLevel();
    }

    public void AddSafe(PlayerUnit playerUnit)
    {
        safe.Add(playerUnit);
        playerUnit.isBusy = true;
        CheckIfFinishLevel();
    }

    private void CheckIfFinishLevel()
    {
        if (safe.Count == all.Count)
        {
            endOfLevelPanel.SetActive(true);
            endOfLevelText.text = string.Format("Congrats, you saved: {0} units!", safe.Count);
        }
    }
}
