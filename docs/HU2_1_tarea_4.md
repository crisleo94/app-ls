# HU 2.1 - Tarea 4: Implementación del script de Raycaster

## Cambios realizados
Se ha implementado el script `Assets/Scripts/ARRaycastPlacer.cs`.

Este script se encarga de:
1. Detectar cuándo el usuario toca la pantalla del dispositivo móvil (usando `Input.GetTouch`).
2. Utilizar `ARRaycastManager` para lanzar un rayo desde la posición del toque en la pantalla hacia el mundo real.
3. Detectar si el rayo colisiona con un plano detectado por el `ARPlaneManager` (`TrackableType.PlaneWithinPolygon`).
4. Instanciar (o mover, si ya existe) un objeto 3D anclado a las coordenadas del impacto del raycast.

## Decisiones técnicas
- **Requerimiento del componente:** El script requiere el componente `ARRaycastManager` a través del atributo `[RequireComponent(typeof(ARRaycastManager))]`, asegurando que el XR Origin contenga este manager esencial para que funcione.
- **Manejo del Prefab:** Se ha dejado una propiedad pública `placementPrefab` para poder arrastrar desde el inspector de Unity el modelo final de la pantalla del intérprete.
- **Fallback a un Quad nativo:** En caso de que no se haya asignado ningún prefab, el código genera un `PrimitiveType.Quad` por defecto utilizando las herramientas nativas de Unity (`GameObject.CreatePrimitive`), lo que cumple exactamente con el requisito de la HU: "...se instanciará un objeto 3D (un Quad)".
- **Gestión de instancias:** Se ha decidido mantener una referencia al `spawnedObject` para que la "pantalla virtual" no se clone repetidamente. Al tocar la pantalla nuevamente, la pantalla actual se moverá a la nueva posición elegida, ofreciendo una mejor experiencia de usuario.