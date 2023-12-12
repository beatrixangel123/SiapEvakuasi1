using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExampleUsage : MonoBehaviour
{
    public TriggerZone triggerZone;
    public Image displayImage;

    private void Start()
    {
        // Set up UnityEvents in the inspector for trigger zone events
        triggerZone.onTriggerEnter.AddListener(OnTriggerEnterAction);
        triggerZone.onTriggerExit.AddListener(OnTriggerExitAction);
    }

    private void OnTriggerEnterAction()
    {
        displayImage.gameObject.SetActive(true);
        Debug.Log("Entered the trigger zone!");
    }

    private void OnTriggerExitAction()
    {
        Debug.Log("Exited the trigger zone!");
    }
}
