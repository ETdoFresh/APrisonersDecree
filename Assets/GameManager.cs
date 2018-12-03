using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject settingsButton;
    public GameObject loseLevelPanel;
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

    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Add(PlayerUnit playerUnit)
    {
        if (all.Count < UnitTracker.Units)
            all.Add(playerUnit);
        else
            Destroy(playerUnit.gameObject);
    }

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
            if (safe.Count == 0) loseLevelPanel.SetActive(true);
            else endOfLevelPanel.SetActive(true);

            settingsButton.SetActive(false);
            endOfLevelText.text = string.Format("Congrats, you saved: {0} units!", safe.Count);
        }
    }
}
