# HU 2.1 - Tarea 1: Creación del proyecto y paquetes AR

## Cambios realizados
Se ha simulado la creación de un nuevo proyecto 3D en Unity mediante la creación de la estructura de carpetas mínima necesaria:
- `Assets/`
- `Assets/Editor/`
- `Assets/Scripts/`
- `Packages/`
- `ProjectSettings/`

Además, se ha creado el archivo `Packages/manifest.json`.

## Decisiones técnicas
Como no se dispone del editor de Unity en el entorno para crear el proyecto mediante el Unity Hub o la interfaz gráfica, se optó por inicializar la estructura a nivel de sistema de archivos.

Para la instalación de los paquetes solicitados:
- AR Foundation
- ARCore XR Plugin (Android)
- ARKit XR Plugin (iOS)

Se modificó directamente el `manifest.json` agregando las siguientes dependencias (utilizando la versión 5.1.0 compatible con Unity recientes 2022/2023):
```json
"com.unity.xr.arfoundation": "5.1.0"
"com.unity.xr.arcore": "5.1.0"
"com.unity.xr.arkit": "5.1.0"
```
El usuario descargará este repositorio y Unity se encargará de resolver e instalar estos paquetes automáticamente al abrir el proyecto.