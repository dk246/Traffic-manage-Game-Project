using System.Collections;
using UnityEngine;

public class panelDisapear : MonoBehaviour
{
    public GameObject targetObject;  // The GameObject you want to deactivate
    public float delay = 4f;         // Delay before deactivation (in seconds)

    void Start()
    {
        // Start the coroutine to deactivate the GameObject after the delay
        //StartCoroutine(DeactivateAfterDelay());
    }

    public void Hide()
    {
        StartCoroutine(DeactivateAfterDelay());
    }
    IEnumerator DeactivateAfterDelay()
    {
        // Wait for the specified delay time (4 seconds in this case)
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(false);
    }

}
