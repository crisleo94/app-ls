using UnityEngine;
using UnityEditor;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;

public class ARSceneSetup : Editor
{
    [MenuItem("AR/Configurar Escena AR Base")]
    public static void SetupARScene()
    {
        // 1. Eliminar la Main Camera si existe
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            DestroyImmediate(mainCamera.gameObject);
            Debug.Log("Main Camera eliminada.");
        }

        // 2. Añadir XR Origin
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        if (xrOrigin == null)
        {
            GameObject xrOriginGO = new GameObject("XR Origin");
            xrOrigin = xrOriginGO.AddComponent<XROrigin>();

            // Configuración básica del XR Origin
            GameObject cameraOffset = new GameObject("Camera Offset");
            cameraOffset.transform.SetParent(xrOriginGO.transform);

            GameObject arCameraGO = new GameObject("AR Camera");
            arCameraGO.transform.SetParent(cameraOffset.transform);
            arCameraGO.tag = "MainCamera";

            Camera arCamera = arCameraGO.AddComponent<Camera>();
            arCamera.clearFlags = CameraClearFlags.Color;
            arCamera.backgroundColor = Color.black;
            arCamera.nearClipPlane = 0.1f;
            arCamera.farClipPlane = 20f;

            arCameraGO.AddComponent<ARCameraManager>();
            arCameraGO.AddComponent<ARCameraBackground>();

            // Tracked Pose Driver (necesario para movimiento de cámara)
            // Se usa el nombre completo porque depende de la versión de Input System o Legacy
            UnityEngine.SpatialTracking.TrackedPoseDriver tpd = arCameraGO.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();

            xrOrigin.Camera = arCamera;
            xrOrigin.Origin = xrOriginGO;
            xrOrigin.CameraFloorOffsetObject = cameraOffset;

            Debug.Log("XR Origin creado.");
        }

        // 3. Añadir AR Plane Manager al XR Origin
        ARPlaneManager planeManager = xrOrigin.GetComponent<ARPlaneManager>();
        if (planeManager == null)
        {
            planeManager = xrOrigin.gameObject.AddComponent<ARPlaneManager>();
            // Configurar para detectar planos horizontales y verticales
            planeManager.requestedDetectionMode = PlaneDetectionMode.Horizontal | PlaneDetectionMode.Vertical;
            Debug.Log("AR Plane Manager añadido al XR Origin.");
        }

        // 4. Añadir AR Session
        ARSession arSession = FindObjectOfType<ARSession>();
        if (arSession == null)
        {
            GameObject arSessionGO = new GameObject("AR Session");
            arSessionGO.AddComponent<ARSession>();
            arSessionGO.AddComponent<ARInputManager>();
            Debug.Log("AR Session creado.");
        }
    }
}
