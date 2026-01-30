using System;
using UnityEngine;

public class MaskingManager : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTransform;
    public MaskPosition currentMaskPosition;

    public float distance = 21;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchMask();
        }
    }

    private void SwitchMask()
    {
        if (currentMaskPosition == MaskPosition.Left)
        {
            currentMaskPosition = MaskPosition.Right;
            playerTransform.position = new Vector3(distance + playerTransform.localPosition.x, playerTransform.localPosition.y, playerTransform.localPosition.z);
            cameraTransform.position = new Vector3(distance + cameraTransform.localPosition.x, cameraTransform.localPosition.y, cameraTransform.localPosition.z);
        }
        else if (currentMaskPosition == MaskPosition.Right)
        {
            currentMaskPosition = MaskPosition.Left;
            playerTransform.position = new Vector3(playerTransform.localPosition.x - distance, playerTransform.localPosition.y, playerTransform.localPosition.z);
            cameraTransform.position = new Vector3(cameraTransform.localPosition.x - distance, cameraTransform.localPosition.y, cameraTransform.localPosition.z);

        }
    }
}


public enum  MaskPosition
{
    Left,
    Right
}
