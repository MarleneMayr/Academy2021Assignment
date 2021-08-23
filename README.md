# Academy 2021 Assignment

To start the game, please open Scenes/GameScene and set the Game view to a custom 9:16 aspect ratio.

The game and its UI are built for and work best on 9:16 portrait mode. However, it seems that in the Unity Editor, the aspect ratio of the game view has to be set locally. I found no way to add this to the settings without hardcoding it. The actual resolution of a game usually depends on the screen of the device. 

#### Colors and Accessibility

I chose the four custom colours to enable people with colourblindness to play the game easily. I aimed for a matching colour palette and used [this resource](https://davidmathlogic.com/colorblind/#%23325DD4-%23EA32AF-%23FE7D00-%23FFD81A) as a reference.

I implemented the colour palette as a Color[] on a singleton GameObject. This way, developers can easily choose colours via the Inspector, can add more than four colours, and the actual colours are decoupled from the logic. The colour of the ball and the obstacles is set to an integer that represents the index of the array. This index is used for applying the colour to the sprite and comparing the current colour. This implementation also means that developers can easily switch out the four colours for a completely new palette.

#### Code Decisions

Most parameters and references that need to be set via the Unity Editor are marked as [SerializedField] private. In doing so, the fields show up in the Editor and can be saved by the system. Meanwhile, these private fields can not be changed by unauthorized scripts at runtime.

Instead of referencing all the GameObjects that depend on specific circumstances in the Inspector, I used UnityEvent<> for major game events. This way, developers can easily add related actions to these events. Specifically for *playerDied*, *scoreChanged* and *colorChanged*.

I aimed at writing modular code but keeping it simple. In doing so, I tried to hardcode as few parameters as possible and instead work with thresholds and reference values that can be changed quickly.

## Mechanics

The **jumping** mechanic does not add force to the RigidBody of the player because the force would accumulate from multiple clicks. Instead, on clicking the LMB, the upwards velocity is set and gravity continuously pulls downwards. That results in a jump arch. The **camera** is moved along with the player whenever it reaches a certain threshold in the upper half of the screen.

**Obstacles, Stars and ColorSwitches** are Prefabs. Prefabs can easily be extended for future use cases and will be updated everywhere they appear. This also makes it easy to reference them from the **ItemSpawner** and randomly instantiate the Prefabs as GameObjects. However, only the obstacles are allowed to repeat while spawning. The randomness still sometimes results in spawning Star - ColorSwitch - Star - etc., which is not ideal for the gameplay and the high score fairness. The spawner is a GameObject which is moved vertically ahead of the player. It spawns the items depending on the distance travelled by the player.

- Obstacles:
  The colour of the player is chosen randomly. On the other hand, Obstacles are made up of four parts with pre-set colors (determined solely by an index). This way, I ensure that the obstacle will always contain the current player colour. To add some randomness, I created six variations of obstacles, and there is a 50% chance the spawner will flip the spawned obstacle.
  Passed obstacles are destroyed when entirely outside of the screen. This will not have a negative impact on the performance of this game. However, in more complex games, the objects could be handled more efficiently and be reused.
- ColorSwitch: this sprite is a png at the current state of the project. If the colour palette is replaced, this needs to be fixed manually.

On **player death**, the player GameObject is destroyed. The text message and particle system react to whether the player jumped into an obstacle or dropped to the floor. On mouse click, the SceneManager is used to reload the same scene, which resets everything to the initial state to start the game again.

I also added some of the **sounds** included in the template project. To keep it simple, I referenced them in a SpecialEffects script that plays the AudioClip at an AudioSource.

## Written part

#### Improvements

- Better indicate the camera's movement, possibly through motion blur on the objects while jumping or a tiled texture in the background. This feedback would help the player get a better sense of the movement and controls.
- At the start of the game: a main menu with basic options and instructions.
- Currently, the ball drops when the game starts. To give the player more time to get used to the game, the start could be improved. Either through a request to click or a countdown.

#### Features

- Save the high score to show the players their improvements and motivate them to become better.
- While this implementation is an endless runner, pre-built levels could be made with more precise object placement and challenges.
- More colours could be used to create more complex obstacles. The way I defined colours makes that possible with few changes, but this might need some changes in the game design.

#### Classical features from similar games

- Add different ball sprites, optionally with different behaviours.
- Power-ups: small or large ball, slow or fast, luck that switches more obstacle parts to the current player colour, and more.
