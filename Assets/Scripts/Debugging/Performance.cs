using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Performance : MonoBehaviour
{
    public TextMeshProUGUI PerformanceTextBox;
    int sampleCount = 0;
    List<float> deltatimeSamples = new List<float>();
    
    // Start is called before the first frame update
    public void Update()
    {
        if(sampleCount >= 5)
        {
            float averageDeltatime = deltatimeSamples.Sum() / deltatimeSamples.Count();
            PerformanceTextBox.text = $"Performance\nFPS:   {1 / averageDeltatime}\nFrametime:   {averageDeltatime}";
            sampleCount = 0;
            deltatimeSamples.Clear();
        }
        else
        {
            deltatimeSamples.Add(Time.deltaTime);
            sampleCount++;
        }
    }
}
