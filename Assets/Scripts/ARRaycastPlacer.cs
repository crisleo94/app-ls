using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARRaycastPlacer : MonoBehaviour
{
    [Tooltip("Prefab del Quad a instanciar al tocar.")]
    public GameObject placementPrefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedObject;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Detectar toque en la pantalla
        // Nota: Unity ARFoundation a menudo se usa con el nuevo Input System,
        // pero para compatibilidad universal usamos Touch de Input normal.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Realizar un Raycast contra los planos (polígonos detectados)
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    // Obtener el primer resultado (el más cercano)
                    Pose hitPose = hits[0].pose;

                    // Si no se ha instanciado un objeto aún, instanciarlo
                    if (spawnedObject == null)
                    {
                        if (placementPrefab != null)
                        {
                            spawnedObject = Instantiate(placementPrefab, hitPose.position, hitPose.rotation);
                        }
                        else
                        {
                            // Si no se ha asignado un prefab desde el editor, crear un Quad por defecto
                            spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                            spawnedObject.transform.position = hitPose.position;
                            spawnedObject.transform.rotation = hitPose.rotation;
                            // Escalar el quad a un tamaño razonable para una "pantalla virtual" (ej. 1x1 metro)
                            spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                    }
                    else
                    {
                        // Si ya existe, simplemente moverlo a la nueva posición y rotación
                        spawnedObject.transform.position = hitPose.position;
                        spawnedObject.transform.rotation = hitPose.rotation;
                    }
                }
            }
        }
    }
}
