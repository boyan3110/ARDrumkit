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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("[DRUMTEST] HIT: " + hit.collider.gameObject.name); // logs in android logcat

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
                    Debug.Log("[DRUMTEST] NO DRUM SCRIPT"); //check logs in logcat
                }
            }
            else
            {
                Debug.Log("[DRUMTEST] NOTHING HIT"); //Check logs in logcat
            }
        }
    }

    IEnumerator ColorChange(Renderer rend)
    {
        Color originalColor = rend.material.color;

        rend.material.color = Color.cyan; // color change upon hit

        yield return new WaitForSeconds(0.2f); // time before color reset

        rend.material.color = originalColor; //Back to starting color
    }
}