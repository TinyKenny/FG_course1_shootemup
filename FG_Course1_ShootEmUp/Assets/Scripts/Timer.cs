using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent<float> onTimerChanged;
    
    private float timeLeft = 0.0f;
    
    public void StartTimer(float duration)
    {
        timeLeft = duration;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
