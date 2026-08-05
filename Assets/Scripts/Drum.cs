using UnityEngine;

public class Drum : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Hit()
    {
        Debug.Log("DRUM HIT: " + gameObject.name);

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}