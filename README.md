Procedural Motion
=================

![gif](https://i.imgur.com/PaSmih8.gif)

The **Procedural Motion** package is a collection of small Unity scripts that
are useful to create motion without pre-authored data.

At the moment, it only contains the following scripts:

- **Brownian Motion**: Creates smooth random motion using a fractal Brownian
  motion function.
- **Cyclic Motion**: Moves/rotates an object with a sine wave.
- **Linear Motion**: Linearly moves/rotates an object.
- **Random Jump**: Moves/rotates an object randomly in a single-shot fashion.
- **Smooth Follow**: Follows a target object using non-framerate dependent
  interpolators.

How To Install
--------------

This package uses the [scoped registry] feature to resolve package
dependencies. Open the Package Manager page in the Project Settings window and
add the following entry to the Scoped Registries list:

- Name: `Keijiro`
- URL: `https://registry.npmjs.com`
- Scope: `jp.keijiro`

![Scoped Registry](https://user-images.githubusercontent.com/343936/162576797-ae39ee00-cb40-4312-aacd-3247077e7fa1.png)

Now you can install the package from My Registries page in the Package Manager
window.

![My Registries](https://user-images.githubusercontent.com/343936/162576825-4a9a443d-62f9-48d3-8a82-a3e80b486f04.png)

[scoped registry]: https://docs.unity3d.com/Manual/upm-scoped.html
