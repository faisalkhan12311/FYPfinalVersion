using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gunscript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadtime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
 
    public GameObject ImpactEffect;

    private float nextTimeToFire = 0f;
    public Text magazine;
    public Animator anim;
    
    public AudioSource ShootSound;
    

    void Start()
    {
        currentAmmo = maxAmmo;
        ShootSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>(); 
    }
    void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reload", false);
        anim.SetBool("Shoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        magazine.text = "Bullets: " + currentAmmo + "/" + maxAmmo;

        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time>=nextTimeToFire && !isReloading)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");


        anim.SetBool("Reload", true);

        yield return new WaitForSeconds(3f);

        anim.SetBool("Reload", false);

        
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;

    }

    void Shoot()
    {
        anim.SetTrigger("shoot");
        //anim.SetTrigger("shoot");
        MuzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject ImpactGo = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGo, 2f);
        }
         ShootSound.Play();
    }

    
}
