using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPC
{
    public class TPCFollowTrackPosition : TPCFollow
    {
        public TPCFollowTrackPosition(Transform cameraTransform, Transform playertransform) : base(cameraTransform, playertransform)
        {

        }

        public override void Tick()
        {
            Quaternion initialRotation = Quaternion.Euler(PGGE.CameraConstants.CameraAngleOffset);

            cameraTransform.rotation = Quaternion.RotateTowards(cameraTransform.rotation, initialRotation, Time.deltaTime * PGGE.CameraConstants.Damping);
            base.Tick();
        }
    }
}
