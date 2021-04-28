using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGrenade : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject grenade_launcher_prefab;
    public GameObject spawn_location;

    public Vector3 pill = new Vector3(0f, 3.81f,22.86f);//TF2's Grenade velocities.
    public float pillV = 23.1753252404f;//The magnitude of the grenade's velocity(test)
    public float pillA = 9.462322208f;//Upward angle of grenade's trajectory (test)
    private AudioSource audioSource;
    public AudioClip Grenade_launcher_shoot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawn_location.transform.Rotate(-pillA, 0.0f, 0.0f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){//0 is mouse1
            audioSource.PlayOneShot(Grenade_launcher_shoot);
            Debug.Log("Schutt");
            GameObject spawnedBullet = Instantiate(grenade_launcher_prefab, spawn_location.transform.position, spawn_location.transform.rotation * Quaternion.Euler(0f, 0f, 90f));//model is rotated
            Rigidbody grenaderigid = spawnedBullet.GetComponent<Rigidbody>();
            //Old code: uses force instead of velocity
            // grenaderigid.AddForce(-spawnedBullet.transform.up * 1500);
            // Quaternion rot = Quaternion.Euler(0, spawn_location.transform.rotation,0);

            grenaderigid.velocity = pillV * spawn_location.transform.right;

            // Vector3 upwards = Vector3.up;
            // grenaderigid.velocity = Quaternion.LookRotation(-spawn_location.transform.up, upwards) * pill;
            grenaderigid.AddTorque(Random.Range(-15.0f, 15.0f),Random.Range(-15.0f, 15.0f),0); //add tumble

            // * pill * Quaternion.Euler(0,pillA,0) (erased section of 32)
            // grenaderigid.velocity = Quaternion.Euler(spawn_location.transform.rotation.eulerAngles.x, 
            //                                             spawn_location.transform.rotation.eulerAngles.y,
            //                                             spawn_location.transform.rotation.eulerAngles.z)   
            //                                             * pill;//NOTE:Doesn't work properly: Pills seem to go off an angle. Also pill doesn't affect for some reason?
            
        }
    }
}
