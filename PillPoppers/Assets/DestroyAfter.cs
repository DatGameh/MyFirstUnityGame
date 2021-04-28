using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float delay = 2.3f;
    public float exKnockback = 1000f;
    public float exRadius = 100.78f;
    private AudioSource audioSource;
    public AudioClip Airstrike_small_explosion_02;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Explosion()); 
        // audioSource.PlayOneShot(Airstrike_small_explosion_02);

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Explosion(){
        
        yield return new WaitForSeconds(delay);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, exRadius);//create a new collider
        print("pew");
        Kaboom();
        // audioSource.PlayOneShot(Airstrike_small_explosion_02);// AUDIO NOT WORKING
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null){//has "valid" rigidbody
                print("DETECTED ENTITY");
                rb.AddExplosionForce(exKnockback, gameObject.transform.position, exRadius, 3000F);
            }

        }
        Destroy(gameObject,0f);
    }

    void Kaboom(){
        audioSource.PlayOneShot(Airstrike_small_explosion_02);// AUDIO NOT WORKING
    }
}
