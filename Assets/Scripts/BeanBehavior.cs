using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private bool _triggered;
    public Transform mainBlock;
    private AudioSource _audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        BeanSpawnerBehavior.CanSpawn = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        tag = "Bean";
        sphereCollider.enabled = true;
        transform.localScale = new Vector3(.5f, .5f, .5f);
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.localPosition.y <= -4.0f)
            GameUIBehavior.HasFailed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "oldBean")
            return;
        if (collision.gameObject.tag == "Main")
        {
            transform.parent = collision.transform;
            rb.isKinematic = true;
            rb.useGravity = false;
            BeanSpawnerBehavior.CanSpawn = true;
            tag = "oldBean";
        }
        if (collision.gameObject.tag == "oldBean")
        {
            transform.parent = mainBlock;
            rb.isKinematic = true;
            rb.useGravity = false;
            BeanSpawnerBehavior.CanSpawn = true;
            tag = "oldBean";
        }

        transform.localScale = new Vector3(.5f, .5f, .5f);
        sphereCollider.radius = .2f;
        _audio.Play();
        GameUIBehavior.Score++;
    }
}
