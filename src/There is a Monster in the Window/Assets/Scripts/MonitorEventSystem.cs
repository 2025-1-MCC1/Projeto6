using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class MonitorEventSystem : MonoBehaviour
{
    [SerializeField] GameObject generatorStatusBox;
    [SerializeField] GameObject cameraStatusBox;
    [SerializeField] GameObject movementStatusBox;


    [SerializeField] PowerEnergy powerEnergyScript;

    public MotionDetectorCameras cam1;
    public MotionDetectorCameras cam2;
    public MotionDetectorCameras cam3;
    
    public MotionDetector movSensor1;
    public MotionDetector movSensor2;
    public MotionDetector movSensor3;


    private TMP_Text generatorStatusText;
    private TMP_Text cameraStatusText;
    private TMP_Text movementStatusText;

    void Start()
    {
        generatorStatusText = generatorStatusBox.GetComponent<TMP_Text>();
        cameraStatusText = cameraStatusBox.GetComponent<TMP_Text>();
        movementStatusText = movementStatusBox.GetComponent<TMP_Text>();

    }

    void Update()
    {
        if (powerEnergyScript.geradorQuebrado)
        {
            generatorStatusText.text = "Generator_status  >> ERROR";
            generatorStatusText.color = Color.red;
        }
        else if(!powerEnergyScript.geradorQuebrado)
        {
            generatorStatusText.text = "Generator_status  >> OK";
            generatorStatusText.color = Color.green;
        }

        if (cam1.spotted || cam2.spotted || cam3.spotted)
        {
            cameraStatusText.text = "Camera_status     >> ERROR";
            cameraStatusText.color = Color.red;
        }
        else if (!cam1.spotted && !cam2.spotted && !cam3.spotted)
        {
            cameraStatusText.text = "Camera_status     >> OK";
            cameraStatusText.color = Color.green;
        }
        
        if (movSensor1.spotted || movSensor2.spotted || movSensor3.spotted)
        {
            movementStatusText.text = "Movement_status >> ERROR";
            movementStatusText.color = Color.red;
        }
        else if (!movSensor1.spotted && !movSensor2.spotted && !movSensor3.spotted)
        {
            movementStatusText.text = "Movement_status >> OK";
            movementStatusText.color = Color.green;
        }

    }
}
