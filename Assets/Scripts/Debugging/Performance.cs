using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace LightJack.UnityTools.Debugging
{
    public static class Performance
    {
        public static float CurrentFps = 0;
        public static float CurrentDeltaTime = 0;
        static int sampleCount = 0;
        static List<float> deltatimeSamples = new List<float>();

        public static void UpdateData()
        {
            if (sampleCount >= 15)
            {
                float averageDeltatime = deltatimeSamples.Sum() / deltatimeSamples.Count();
                CurrentFps = 1 / averageDeltatime;
                CurrentDeltaTime = averageDeltatime;
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
}