using System.Collections;
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
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("[DRUMTEST] HIT: " + hit.collider.gameObject.name);

                Drum drum = hit.collider.GetComponent<Drum>();

                if (drum != null)
                {
                    drum.Hit();

                    Renderer rend = hit.collider.GetComponent<Renderer>();

                    if (rend != null)
                    {
                        StartCoroutine(ColorChange(rend));
                    }
                }
                else
                {
                    Debug.Log("[DRUMTEST] NO DRUM SCRIPT");
                }
            }
            else
            {
                Debug.Log("[DRUMTEST] NOTHING HIT");
            }
        }
    }

    IEnumerator ColorChange(Renderer rend)
    {
        Color originalColor = rend.material.color;

        rend.material.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        rend.material.color = originalColor;
    }
}