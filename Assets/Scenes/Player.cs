using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
[Tooltip("In ms^-1")][SerializeField] float Speed = 4f;
[Tooltip("In ms^-1")][SerializeField] float xRange = 4f;
[Tooltip("In ms^-1")][SerializeField] float yRange = 2.5f;


    [SerializeField] float positionPitchFactor = -5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
       
    }


        private void ProcessRotation()
        {

        float pitch = transform.localPosition.y * positionPitchFactor;
        float yaw = 0f;
        float roll = 0f;
            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }


    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");


        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;
        

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, +xRange);

        
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, +yRange);




        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
