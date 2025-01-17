using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TPC
{
    public abstract class TPCFollow : TPCBase
    {
        public TPCFollow(Transform camera, Transform player) : base(camera, player)
        {

        }
        public override void Tick()
        {
            // Now we calculate the camera transformed axes. 
            // We do this because our camera's rotation might have changed 
            // in the derived class Update implementations. Calculate the new  
            // forward, up and right vectors for the camera. 

            Vector3 forward = cameraTransform.rotation * Vector3.forward;
            Vector3 right = cameraTransform.rotation * Vector3.right;
            Vector3 up = cameraTransform.rotation * Vector3.up;

            // We then calculate the offset in the camera's coordinate frame.  
            // For this we first calculate the targetPos 

            Vector3 targetPos = playerTransform.position;

            // Add the camera offset to the target position. 
            // Note that we cannot just add the offset. 
            // You will need to take care of the direction as well. 

            Vector3 desiredPosition = targetPos
                + forward * PGGE.CameraConstants.CameraPositionOffset.z
                + right * PGGE.CameraConstants.CameraPositionOffset.x
                + up * PGGE.CameraConstants.CameraPositionOffset.y;

            // Finally, we change the position of the camera,  
            // not directly, but by applying Lerp. 

            Vector3 position = Vector3.Lerp(cameraTransform.position,
                desiredPosition, Time.deltaTime * PGGE.CameraConstants.Damping);
            cameraTransform.position = position;
        }
    }
}
