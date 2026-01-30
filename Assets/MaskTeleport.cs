using UnityEngine;

public class MaskTeleport : MonoBehaviour
{
    public GameObject world1, world2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(world1.activeInHierarchy)
            {
                world1.SetActive(false);
                world2.SetActive(true);
                transform.position += new Vector3(21, 0);
            }
            else if(world2.activeInHierarchy)
            {
                world2.SetActive(false);
                world1.SetActive(true);
                transform.position += new Vector3(-21, 0);
            }
        }
    }
}
