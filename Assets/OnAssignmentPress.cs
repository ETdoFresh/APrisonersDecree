using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnAssignmentPress : MonoBehaviour {
    public void OnMinusPress()
    {
        var textComponent = GetComponent<Text>();
        int count = int.Parse(textComponent.text);
        count--;
        textComponent.text = count.ToString();
    }

    public void OnPlusPress()
    {
        var textComponent = GetComponent<Text>();
        int count = int.Parse(textComponent.text);
        count++;
        textComponent.text = count.ToString();
    }
}
