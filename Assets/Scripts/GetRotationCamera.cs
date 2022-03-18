using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRotationCamera : MonoBehaviour
{

    public ActivateWebcam activeWebcam;

    // Start is called before the first frame update
    void Start()
    {
        RawImage image = GetComponent<RawImage>();

        var rotationVector = image.transform.rotation.eulerAngles;

        #if (UNITY_EDITOR && !UNITY_ANDROID)
            // rotationVector.z = -90;
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(1280, 960);
        #elif UNITY_ANDROID
            rotationVector.z = -90;
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080);
        #endif
        image.transform.rotation = Quaternion.Euler(rotationVector);

        activeWebcam.StartLaunch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
