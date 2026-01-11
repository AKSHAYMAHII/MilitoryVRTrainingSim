using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteractable : MonoBehaviour
{
    private Renderer objRenderer;
    private Color originalColor;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
    }

    // Called when gaze starts looking at this object
    public void OnGazeEnter()
    {
        objRenderer.material.color = Color.red;
    }

    // Called when gaze stops looking at this object
    public void OnGazeExit()
    {
        objRenderer.material.color = originalColor;
    }

    // Called when player presses the controller button while aiming
    public void OnGazeClick()
    {
        Debug.Log("Clicked on: " + gameObject.name);
    // Later, we will add shooting, opening doors, etc.
    }

}
