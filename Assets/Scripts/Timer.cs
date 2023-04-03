using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    [SerializeField] TMP_Text currentTimeText;

    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        currentTimeText.text = currentTime.ToString("0.000");
    }
}
