using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBobing : MonoBehaviour
{
    public float frequency = 30f;
    public float intensity = 3f;

    private Vector3 position;

    private void Start()
    {
        position = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = position + Vector3.up * Mathf.Cos(Time.time * (frequency * 0.1f)) * (intensity * 0.01f);
    }
}
