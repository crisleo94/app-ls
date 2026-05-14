# HU 2.1 - Tarea 3: Añadir AR Plane Manager

## Cambios realizados
Se ha modificado el script de editor `Assets/Editor/ARSceneSetup.cs` para que, como parte de su ejecución de configuración, agregue automáticamente el componente `ARPlaneManager`.

El componente es añadido al `GameObject` que contiene el `XROrigin`.

## Decisiones técnicas
Se ha configurado la propiedad `requestedDetectionMode` en el `ARPlaneManager` a través del código, estableciendo el valor en `PlaneDetectionMode.Horizontal | PlaneDetectionMode.Vertical`.
Esto asegura que, de acuerdo a los requerimientos de la historia de usuario ("detectar planos verticales (paredes) u horizontales"), la aplicación pueda identificar paredes en el mundo real donde colocar la "pantalla virtual".

Todo este proceso está automatizado, por lo que el desarrollador final no necesita configurar el `PlaneDetectionMode` manualmente en el Inspector.