Reaktion
========

![Screenshot](http://keijiro.github.io/Reaktion/screenshot.png)

*Reaktion* is an audio reactive animation toolkit for Unity.

[Demo](https://vine.co/v/h2H5Iqi3e3V)

It provides several components for reacting to audio signals.

- *Reaktor* - processes audio signals and provides information to other components.
- *Reaktor To Transform* - controls a Transform component with information from a Reaktor.
- *Reaktor To ParticleSystem* - controls a Particle System component with information from
  a Reaktor.
- *Reaktor To Animator* - controls an Animator component with information from a Reaktor.
- *Reaktor To Message* - sends messages to Game Objects with information from a Reaktor.

![Chart](http://keijiro.github.io/Reaktion/abstract.png)

System Requirements
-------------------

- Mac OS X
- Unity Pro

Setting Up
----------

- Download [the package](http://keijiro.github.io/Reaktion/reaktion-0.5.unitypackage)
  and import it to a project.
- Create a game object and add *AudioJack* script component to it. For the detailed
  information about AudioJack, read [the documentation]
  (https://github.com/keijiro/AudioJack).
- Add Reaktor and controller components (Reaktor To XXX) to game objects. Controllers
  automatically search a Reaktor that is the closest to it.

Reaktor Component
-----------------

![Reaktor](http://keijiro.github.io/Reaktion/inspector-reaktor.png)

Basically the *Reaktor* component is a kind of audio level meter with an adaptive level
detection algorithm. It allows controllers to react to a wide range of audio signals
without requiring detailed calibrations.

The Reaktor component has several options below.

### Audio Source

It supports two types of audio sources -- *RMS Level* and *Frequency Band*. If the
controller needs to react to the audio level of a specific channel, use *RMS Level*.
If it needs to react to the level of a specific frequency band (which is provided from
the frequency spectrum analyzer in AudioJack), use *Frequency Band*.

### Curve

The *Curve* option gives a response curve to the output from the Reacktor.

### Gain Control

The Reaktor supports external MIDI controllers. In *Gain Control* option, it allows
to assign a MIDI CC value to the gain of the output from the Reaktor.

### Offset Control

The *Offset Control* option is another way to control the Reaktor with external MIDI
controllers. It offsets the output with a MIDI CC value (i.e. simply adds the CC value
to the output value).

### Sensibility

The *Sensibility* option determines the strength of the output low-pass filter in the
Reaktor. The lower the value is set, the smoother and slower it reacts. The filter can
be disabled when the value is set to 1.

### Audio Input Options

These options control the adaptive level detection algorithm.

- *Headroom* [dB] - gives a headroom to the dynamic range window.
- *Dynamic Range* [dB] - the width of the dynamic range window.
- *Lower Bound* [dB] - the window can move down to this level.
- *Falldown* [dB/Sec] - the fall-down speed of the window.

Reaktor To Transform Component
------------------------------

![ReaktorToTransform](http://keijiro.github.io/Reaktion/inspector-transform.png)

Reaktor To ParticleSystem Component
-----------------------------------

![ReaktorToParticleSystem](http://keijiro.github.io/Reaktion/inspector-particle.png)

Reaktor To Animator Component
-----------------------------

![ReaktorToAnimator](http://keijiro.github.io/Reaktion/inspector-animator.png)

Reaktor To Message Component
----------------------------

![ReaktorToMessage](http://keijiro.github.io/Reaktion/inspector-message.png)

License
-------

Copyright (C) 2013, 2014 Keijiro Takahashi

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
