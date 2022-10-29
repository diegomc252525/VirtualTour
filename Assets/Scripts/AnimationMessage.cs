using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMessage : MonoBehaviour
{
    [SerializeField] RectTransform message;
    [SerializeField] float timeAnimation;
    [SerializeField] float scaleValue;
    Vector3 minScale;
    Vector3 maxScale;
    bool isActive = false;

    private void Start()
    {
        minScale = message.localScale;
        maxScale=scaleValue*minScale;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;
        if(isActive)
        {
            StartCoroutine(ScaleMessage(maxScale, minScale,false));
        }
        if (!isActive )
        {
            StartCoroutine(ScaleMessage(minScale,maxScale,true));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            StartCoroutine(ScaleMessage(maxScale, minScale,false));
        }
    }
    IEnumerator ScaleMessage(Vector3 start,Vector3 end,bool value)
    {
        float time = 0f;
        while (time < timeAnimation)
        {
            message.localScale = Vector3.Lerp(start,end,time/timeAnimation);
            time += Time.deltaTime;
            yield return null;
        }
        message.localScale = end;
        isActive = value;
    }
}
