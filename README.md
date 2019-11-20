Procedural Motion
=================

![gif](https://i.imgur.com/PaSmih8.gif)

The **Procedural Motion** package is a collection of small Unity scripts that
are useful to create motion without pre-authored data.

At the moment, it only contains the following scripts:

- **Brownian Motion**: Creates smooth random motion using a fractal Brownian
  motion function.
- **Linear Motion**: Linearly moves/rotates an object.
- **Random Jump**: Moves/rotates an object randomly in a single-shot fashion.
- **Smooth Follow**: Follows a target object using non-framerate dependent
  interpolators.

How To Install
--------------

This package uses the [scoped registry] feature to resolve package
dependencies. Please add the following sections to the manifest file
(Packages/manifest.json).

[scoped registry]: https://docs.unity3d.com/Manual/upm-scoped.html

To the `scopedRegistries` section:

```
{
  "name": "Keijiro",
  "url": "https://registry.npmjs.com",
  "scopes": [ "jp.keijiro" ]
}
```

To the `dependencies` section:

```
"jp.keijiro.klak.motion": "1.0.1"
```

After changes, the manifest file should look like below:

```
{
  "scopedRegistries": [
    {
      "name": "Keijiro",
      "url": "https://registry.npmjs.com",
      "scopes": [ "jp.keijiro" ]
    }
  ],
  "dependencies": {
    "jp.keijiro.klak.motion": "1.0.1"
    ...
```
