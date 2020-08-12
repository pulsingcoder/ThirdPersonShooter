using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Vector3 cameraoffset;
    [SerializeField] float damping;

   Transform cameraLookTarget;
   Player localPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");
        if (cameraLookTarget == null)
        {
            cameraLookTarget = localPlayer.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraoffset.z +
                localPlayer.transform.up * cameraoffset.y + localPlayer.transform.right * cameraoffset.x;
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);


        transform.position = Vector3.Lerp(transform.position, targetPosition, damping*Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
                                    
    }
}
