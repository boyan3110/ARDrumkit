using UnityEngine;

public class Drum : MonoBehaviour
    
{
    public Transform hitPoint;
    public AudioSource audioSource;

    public float hitDistance = 0.05f;
    public Transform stickTip;

    private float cooldown = 0.15f;
    private float lastHit = 0;

    void Start()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(stickTip.position, hitPoint.position);

        if (distance < hitDistance && Time.time - lastHit > cooldown)
        {
            lastHit = Time.time;
            Hit();
        }
    }

    public Renderer drumRenderer;
    void Hit()
    {
        Debug.Log("DRUM HIT: " + gameObject.name);

        Renderer r = GetComponentInChildren<Renderer>();

       
    }
}