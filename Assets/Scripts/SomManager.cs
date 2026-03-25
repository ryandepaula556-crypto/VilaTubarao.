using UnityEngine;

public class SomManager : MonoBehaviour {
    public static SomManager instance;
    public AudioSource fonteAudio;
    public AudioClip somMoeda;
    public AudioClip somClique;

    void Awake() { instance = this; }

    public void TocarMoeda() {
        fonteAudio.PlayOneShot(somMoeda);
    }

    public void TocarClique() {
        fonteAudio.PlayOneShot(somClique);
    }
}
