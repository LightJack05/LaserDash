using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJack.UnityTools.Debugging;
using TMPro;
using Unity.VisualScripting;

namespace LightJack.UnityTools.Debugging
{
    public class DebugManager : MonoBehaviour
    {
        public TextMeshProUGUI DebugMenuText;
        public GameObject DebugMenu;
        public GameObject Player;
        public bool DebugModeInitialized = false;
        GameObject velocityLineX;
        GameObject velocityLineY;


        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("NOTE: You are running a pre-release build! \nPress Ctrl + Alt + D for debug mode.");
        }

        void Update()
        {
            // Control Debug Mode
            if(!DebugModeInitialized && DebugState.DebugModeEnabled)
            {
                DebugState.EnableDebugMode(DebugMenu, Player);
                InitializeVelocityLines();
                DebugModeInitialized = true;
            }

            if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.D) && !DebugState.DebugModeEnabled)
            {
                Debug.Log("Enabled Debug Mode");
                DebugState.EnableDebugMode(DebugMenu,Player);
                InitializeVelocityLines();
                DebugModeInitialized = true;
            }
            else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.D) && DebugState.DebugModeEnabled)
            {
                Debug.Log("Disabled Debug Mode");
                DebugState.DisableDebugMode(DebugMenu,Player);
                Player.GetComponent<PlayerDeath>().enabled = true;
                DebugModeInitialized = false;
            }

            if (DebugState.DebugModeEnabled)
            {
                Performance.UpdateData();
                UpdateDebugMenuDisplay();
                UpdateVelocityLines();
            }

            if(DebugState.DebugModeEnabled && Input.GetKeyDown(KeyCode.Escape))
            {
                if(Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }

            if(DebugState.DebugModeEnabled && Input.GetKeyDown(KeyCode.G))
            {
                Player.GetComponent<PlayerDeath>().enabled = !Player.GetComponent<PlayerDeath>().enabled;
            }
        }

        public void DebugUIButtonTapped()
        {
            if (!DebugState.DebugModeEnabled)
            {
                Debug.Log("Enabled Debug Mode");
                DebugState.EnableDebugMode(DebugMenu, Player);
                InitializeVelocityLines();
                DebugModeInitialized = true;
            }
            else if (DebugState.DebugModeEnabled)
            {
                Debug.Log("Disabled Debug Mode");
                DebugState.DisableDebugMode(DebugMenu, Player);
                Player.GetComponent<PlayerDeath>().enabled = true;
                DebugModeInitialized = false;
            }
        }

        public void UpdateDebugMenuDisplay()
        {
            DebugMenuText.text = $"Performance Monitoring" + "\n" + "\n" +
                $"FPS: {System.Math.Round(Performance.CurrentFps,1)}" + "\n" +
                $"Frametime (ms): {System.Math.Round(Performance.CurrentDeltaTime * 1000,3)}" + "\n\n"+
                $"Movement Monitoring" + "\n" + "\n"+
                $"X: {System.Math.Round(Player.GetComponent<Rigidbody2D>().velocity.x,5)}" + "\n" +
                $"Y: {System.Math.Round(Player.GetComponent<Rigidbody2D>().velocity.y,5)}" + "\n";
        }

        public void InitializeVelocityLines()
        {
            GameObject lineX = new("VelocityLineX");
            lineX.transform.parent = Player.transform;
            lineX.AddComponent<LineRenderer>();
            lineX.GetComponent<LineRenderer>().startWidth = 0.1f;
            lineX.GetComponent<LineRenderer>().endWidth = 0.1f;
            lineX.GetComponent<LineRenderer>().startColor = Color.green;
            lineX.GetComponent<LineRenderer>().endColor = Color.green;
            lineX.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new(0, 0, 0), new(0, 0, 0) });
            velocityLineX = lineX;

            GameObject lineY = new("VelocityLineY");
            lineY.transform.parent = Player.transform;
            lineY.AddComponent<LineRenderer>();
            lineY.GetComponent<LineRenderer>().startWidth = 0.1f;
            lineY.GetComponent<LineRenderer>().endWidth = 0.1f;
            lineY.GetComponent<LineRenderer>().startColor = Color.blue;
            lineY.GetComponent<LineRenderer>().endColor = Color.blue;
            lineY.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new(0, 0, 0), new(0, 0, 0) });
            velocityLineY = lineY;

        }

        public void UpdateVelocityLines()
        {
            velocityLineX.GetComponent<LineRenderer>().SetPositions(new Vector3[] { Player.transform.position, new(Player.GetComponent<Rigidbody2D>().velocity.x * 0.5f + Player.transform.position.x, Player.transform.position.y, Player.transform.position.z) });
            velocityLineY.GetComponent<LineRenderer>().SetPositions(new Vector3[] { Player.transform.position, new(Player.transform.position.x, Player.GetComponent<Rigidbody2D>().velocity.y * 0.2f + Player.transform.position.y, Player.transform.position.z) });
        }
        
    }
}


