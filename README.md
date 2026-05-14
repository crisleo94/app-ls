# HU
## Historia de Usuario 2.1: Detección del Entorno AR
Como usuario, quiero apuntar con la cámara de mi móvil a una pared para colocar la "pantalla virtual" del intérprete en el mundo real.
Tareas:
- [x] Crear un nuevo proyecto 3D en Unity e instalar los paquetes AR Foundation, ARCore XR Plugin (Android) y ARKit XR Plugin (iOS).
- [x] Configurar la escena reemplazando la cámara principal con un XR Origin y añadiendo un AR Session.
- [x] Añadir el componente AR Plane Manager para detectar planos verticales (paredes) u horizontales.
- [x] Implementar un script con un Raycaster: cuando el usuario toque la pantalla, se instanciará un objeto 3D (un Quad) anclado a la coordenada del plano detectado.
