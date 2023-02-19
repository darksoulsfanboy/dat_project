using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenFade : MonoBehaviour
{
    private Color startColor;
    private float runningTime;
    public bool isDead = false;

    [SerializeField] private float duration = 5f;
    [SerializeField] private Image target;
    [SerializeField] private Color targetColor;


    private void Start()
    {
        startColor = target.color;
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            if (runningTime <= duration)
            {
                runningTime += Time.deltaTime;

                float normalizeRunningTime = runningTime / duration;

                target.color = Color.Lerp(startColor, targetColor, normalizeRunningTime);
            }
        }
    }
}
