using System.Collections;
using TMPro;
using UnityEngine;

public class NumbersCounter : Singleton<NumbersCounter>
{
    private const string NumberFormat = "N0";

    /// <summary>
    /// Change your text number to the target number using Counter Effect
    /// </summary>
    /// <param name="startingValue"> the starting number</param>
    /// <param name="newValue"> the target number</param>
    /// <param name="duration"> the duration the counter would take to reach target number</param>
    /// <param name="interval"> the highest this value is, the lower the added value will be </param>
    /// <param name="currentText"> pass the text you wanna change</param>
    public void SetNewValue(int startingValue, int newValue, float duration, int interval, TextMeshProUGUI currentText, string addedString)
    {
        StartCoroutine(CountText(startingValue, newValue, duration, interval, currentText, addedString));
    }

    private IEnumerator CountText(int startingValue, int newValue, float duration, int interval, TextMeshProUGUI currentText, string addedString)
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / interval);
        int previousValue = startingValue;
        int stepAmount;

        if (newValue - previousValue < 0)
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (interval * duration)); // newValue = -20, previousValue = 0. CountFPS = 30, and Duration = 1; (-20- 0) / (30*1) // -0.66667 (ceiltoint)-> 0
        else
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (interval * duration)); // newValue = 20, previousValue = 0. CountFPS = 30, and Duration = 1; (20- 0) / (30*1) // 0.66667 (floortoint)-> 0

        if (previousValue < newValue)
        {
            while (previousValue < newValue)
            {
                previousValue += stepAmount;
                if (previousValue > newValue)
                    previousValue = newValue;

                currentText.SetText(previousValue.ToString(NumberFormat) + addedString);
                yield return Wait;
            }
        }
        else
        {
            while (previousValue > newValue)
            {
                previousValue += stepAmount; // (-20 - 0) / (30 * 1) = -0.66667 -> -1              0 + -1 = -1
                if (previousValue < newValue)
                    previousValue = newValue;

                currentText.SetText(previousValue.ToString(NumberFormat) + " XP");
                yield return Wait;
            }
        }
    }

}