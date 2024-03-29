﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;
    public static CameraShake instance;

    void Awake()
    {
        

        instance = this;
    }

    public  void Shake(float duration, float amount)
    {
        
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration, amount));
    }

    public IEnumerator cShake(float duration, float amount)
    {
        originalPos = transform.localPosition;
        float endTime = Time.time + duration;
        
        while (Time.time < endTime)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;  

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
