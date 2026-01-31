using System;
using UnityEngine;
using Random = System.Random;


public class MaskingManager : MonoBehaviour
{
    private Transform playerTransform;
    private Transform cameraTransform;
    private Animator animator;
    public RuntimeAnimatorController defaultController;
    public RuntimeAnimatorController maskController;


    public MaskPosition currentMaskPosition;
    public AudioClip[] teleportSounds;



    public float distance = 21;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = transform;
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int i = new Random().Next(0, teleportSounds.Length);
            AudioClip clip = teleportSounds[i];
            if (clip == null) return;
            SoundsManager.Instance.PlaySingle(clip);
            SwitchMask();
        }
    }

    private void SwitchMask()
    {
        if (currentMaskPosition == MaskPosition.Left)
        {
            currentMaskPosition = MaskPosition.Right;
            animator.runtimeAnimatorController = maskController;
            playerTransform.position = new Vector3(distance + playerTransform.localPosition.x, playerTransform.localPosition.y, playerTransform.localPosition.z);
            cameraTransform.position = new Vector3(distance + cameraTransform.localPosition.x, cameraTransform.localPosition.y, cameraTransform.localPosition.z);
            Transform trans = playerTransform;
            Transform key = trans.gameObject.GetComponent<PlayerMovement>().key;
            if(key) key.transform.position = playerTransform.position;
        }
        else if (currentMaskPosition == MaskPosition.Right)
        {
            currentMaskPosition = MaskPosition.Left;
            animator.runtimeAnimatorController = defaultController;
            playerTransform.position = new Vector3(playerTransform.localPosition.x - distance, playerTransform.localPosition.y, playerTransform.localPosition.z);
            cameraTransform.position = new Vector3(cameraTransform.localPosition.x - distance, cameraTransform.localPosition.y, cameraTransform.localPosition.z);
            Transform trans = playerTransform;
            Transform key = trans.gameObject.GetComponent<PlayerMovement>().key;
            if(key) key.transform.position = playerTransform.position;
        }
    }


}



public enum MaskPosition
{
    Left,
    Right
}
