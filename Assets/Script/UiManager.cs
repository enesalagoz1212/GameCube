using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    
    public void SetPointText(int point)
    {
        pointText.text = point.ToString();
    }
}