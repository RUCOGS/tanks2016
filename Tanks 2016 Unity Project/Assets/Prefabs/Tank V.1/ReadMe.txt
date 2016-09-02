Last Change: 8/10/16

Tank Assets:
This folder currently contains a blender file With Mesh Assets for the tank.
This Model is not finished and needs tweakng and input before it can be used well.

List of Meshes in the file:

1) Tank_Body
	A simple mesh that comprises the body of the tank.

2) Treads_Static
	The tank's treads, These are currently not part of the body mesh, but are a separate mesh instead, and do not move.
	this is so that if we decide to replace the treads with animated ones, we can easily do so without changing the body mesh.
	These static treads will fit onto the Tank_Body as long as they're parented correctly in unity.

3) Tank_Turret
	a Mesh comprising the gun turret.I plan to rig the turret with bones so that it can be animated easily.

5)Tank_Turret_Simple
	a Mesh comprising a simple gun turret. This one is not rigged and is a simpler alternative to the other turret if rigging and animation is too much work.
	  

4) Tank_shell 
	Mesh for the Tank's projectile.

8/10/16: Added .fbx versions of the Tank.blend file, Tank.fbx. This format is accepted by unity,
	but the scale and rotation of the meshes might need tweaking when they get dragged into the scene.


   