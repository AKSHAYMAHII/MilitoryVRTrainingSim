using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rayLength = 100f;
    private RaycastHit hit;
    private GazeInteractable currentTarget;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            GazeInteractable interactable = hit.collider.GetComponent<GazeInteractable>();

            if (interactable != null)
            {
                if (currentTarget != interactable)
                {
                    if (currentTarget != null)
                        currentTarget.OnGazeExit();

                    currentTarget = interactable;
                    currentTarget.OnGazeEnter();
                }

                // 🔥 Check for controller button press (replace "Fire1" with your controller input later)
                if (Input.GetButtonDown("Fire1"))
                {
                    currentTarget.OnGazeClick();
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnGazeExit();
                currentTarget = null;
            }
        }
    }
}
