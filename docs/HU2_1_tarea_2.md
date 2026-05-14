# HU 2.1 - Tarea 2: Configurar la escena con XR Origin y AR Session

## Cambios realizados
Se ha creado un script de editor en la ruta `Assets/Editor/ARSceneSetup.cs`.

Este script añade una opción en el menú de Unity bajo "AR > Configurar Escena AR Base", el cual automatiza las siguientes tareas en la escena activa:
1.  Busca y elimina la `Main Camera` por defecto de la escena.
2.  Crea un nuevo objeto `XR Origin` con la jerarquía correspondiente (`Camera Offset` y `AR Camera`).
3.  Añade y configura los componentes necesarios en la `AR Camera` (`ARCameraManager`, `ARCameraBackground`, y `TrackedPoseDriver`).
4.  Crea el objeto `AR Session` con los componentes `ARSession` y `ARInputManager` para manejar el ciclo de vida de la sesión de Realidad Aumentada.

## Decisiones técnicas
Debido a la naturaleza "headless" de este entorno de desarrollo (sin acceso a la interfaz gráfica de Unity), se optó por programar un **Editor Script**.
Esto permite al desarrollador o tester que abra el proyecto posteriormente en Unity, ejecutar el comando desde el menú superior de forma rápida, evitando errores humanos de configuración en la jerarquía o componentes de AR Foundation. El usuario solo tendrá que abrir la escena predeterminada y pulsar "AR > Configurar Escena AR Base".