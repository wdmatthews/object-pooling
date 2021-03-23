# object-pooling
A simple object pooling system for the Unity game engine.
## Installation
You can download the entire Assets/Object Pooling folder,
or just the Assets/Object Pooling/LICENSE and Assets/Object Pooling/Scripts.
The 2D Sprite package is required for the demo to function.
It can be installed from the Unity Package Manager.
## Documentation
### ObjectPoolManager
To pool objects, you first need to add an ObjectPoolManager component to a GameObject in your scene.
Then, you can assign PoolObject prefabs to use with the ObjectPoolManager.
The file name of a PoolObject will be used as a string to spawn in instances of that object.
### Spawning
ObjectPoolManager is used to spawn in objects, using one of the ObjectPoolManager.Spawn methods.
NOTE: Spawn is an instance method, so make sure you are referencing an instance of
ObjectPoolManager when invoking the method, rather than the class.
If you want to get a component on the newly spawned object, use Spawn&lt;T&gt; instead of Spawn.
### Despawning
To despawn an object, invoke the PoolObject.Despawn method while referring to an instance of PoolObject.