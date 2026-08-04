using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    public Renderer rend = null;

    void Start()
    {
        Debug.Log("[DRUMTEST] APP STARTED");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[DRUMTEST] TAP DETECTED");

            //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("[DRUMTEST] HIT: " + hit.collider.gameObject.name);

                rend = hit.collider.GetComponent<Renderer>();

                if (rend != null)
                {
                    Debug.Log("[DRUMTEST] COLOR CHANGE");
                    StartCoroutine(ColorChange());
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
    IEnumerator ColorChange()
    {
        var clr = rend.material.color;
        rend.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        rend.material.color = clr;
    }
}