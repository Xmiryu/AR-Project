using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialMeshController : MonoBehaviour
{
    private IMixedRealitySpatialAwarenessMeshObserver observer;

    private void Awake ()
    {
        observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
    }


    public void Show ()
    {
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Occlusion;
    }

    public void Hide()
    {
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
    }
}
