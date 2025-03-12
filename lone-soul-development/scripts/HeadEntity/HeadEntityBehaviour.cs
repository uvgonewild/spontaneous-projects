using UnityEngine;
using Cinemachine;

public class HeadEntityBehaviour : MonoBehaviour
{
    private GameObject[] houseBehaviours;

    [Space(10)]
    [SerializeField] private VirtualCamFollow virtualCamFollow;
    [SerializeField] private CinemachineVirtualCamera virtualCam;

    private void Start()
    {
        // Starts The Head as soon as the Time is Paused in Game Manager
        Invoke("StartHeadEntity", FindObjectOfType<DialougePlayer>().pauseTime);
    }
    
    void StartHeadEntity()
    {
        houseBehaviours = GameObject.FindGameObjectsWithTag("House");

        float repeatRate = Random.Range(30, 50);
        InvokeRepeating("PerformChangeEffect", 8, repeatRate);
        InvokeRepeating("RevertChangeEffect", 12, repeatRate);
    }

    void ChangeHouseValues()
    {
        foreach (GameObject houseBehaviour in houseBehaviours)
        {
            houseBehaviour.GetComponent<HouseBehaviour>().RandomizeItems();
        }
    }

    void PerformChangeEffect()
    {
        virtualCamFollow.isHeadEntityTweeking = true;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 4f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 4f;
        GetComponent<AudioSource>().Play();
        ChangeHouseValues();
    }

    void RevertChangeEffect()
    {
        virtualCamFollow.isHeadEntityTweeking = false;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1.5f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
    }
    
}
