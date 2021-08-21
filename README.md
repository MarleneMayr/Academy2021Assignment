# Academy2021Assignment

Most parameters and references that need to be set via the Unity Editor are marked as [SerializedField] private. In doing so, the fields show up in the Editor and can be saved by the system, while still behaving like private fields at runtime and can't be changed by unauthorized scripts.

The 4 custom colors were chosen to enable people with colorblindness to play the game easily. I aimed for a matching color palette and used this resource as a reference: https://davidmathlogic.com/colorblind/#%23325DD4-%23EA32AF-%23FE7D00-%23FFD81A

Obstacles, Stars and ColorSwitches are Prefabs. Prefabs can easily be extended for future use cases and will be updated everywhere they appear.

The jumping mechanic does not add force to the player's rigidbody because the force would accumulate from multiple clicks. Instead, on clicking the LMB the velocity is set upwards and gravity continuously pulls downwards.

Passed obstacles are instatiated from prefabs and destroyed when completely outside of the screen. This will not have a negative impact on the performance of this game. However, in complex games the objects could be handled more efficiently and be reused.

### Written part
Tell us what features would you like to add to the gameplay and how would you go about and implement them?

- prebuilt levels vs endless runner
- more colors -> more complex obstacles (the way I defined colors makes that possible with few changes)
- menu with instructions
- save highscore to show the player his improvements for motivation
- better indicate the movement of the camera. possibly through motion blur or texture in the background

#### classical features from similar games
- different ball sprites, optionally with different behavior
- powerups: small, big, slow, ...
