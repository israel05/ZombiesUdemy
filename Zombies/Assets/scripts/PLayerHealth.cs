using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 10f;
    [SerializeField] Collider collisionMesh;
    AudioSource myAudioSource;
    [SerializeField] AudioClip playerHitSFX;
    [SerializeField] AudioClip playerDeathSFX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            KillPLayer();
        }
    }

    public void takeDamage(float damage)
    {
        hitPoints -= damage;
       // AudioSource.PlayClipAtPoint(enemyHitSFX, Camera.main.transform.position);
        print("AGHH ME QUEDA " + hitPoints + " DE VIDA");
    }


    private void KillPLayer()
    {
       // AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
       // Destroy(gameObject);
    }
}
