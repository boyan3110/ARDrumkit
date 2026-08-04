using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        Debug.Log("[DRUMTEST] APP STARTED");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[DRUMTEST] TAP DETECTED");

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("[DRUMTEST] HIT: " + hit.collider.gameObject.name);

                Renderer rend = hit.collider.GetComponent<Renderer>();

                if (rend != null)
                {
                    Debug.Log("[DRUMTEST] COLOR CHANGE");
                    rend.material.color = Color.red;
                }
                else
                {
                    Debug.Log("[DRUMTEST] NO RENDERER");
                }
            }
            else
            {
                Debug.Log("[DRUMTEST] NOTHING HIT");
            }
        }
    }
}