# Academy2021Assignment

Most parameters and references that need to be set via the Unity Editor are marked as [SerializedField] private. In doing so, the fields show up in the Editor and can be saved by the system, while still behaving like private fields at runtime and can't be changed by unauthorized scripts.

The 4 colors were chosen to enable people with colorblindness to play the game easily.
This resource was taken as a reference where I chose custom colors: https://davidmathlogic.com/colorblind/#%23325DD4-%23EA32AF-%23FE7D00-%23FFD81A

Obstacles, Stars and ColorSwitches are Prefabs.
!!!!!!!!!This way, the spawning script does not need to be aware of the object. Besides that, they can easily be extended for future use cases and will be updated everywhere they appear.

The jumping mechanic does not add force to the player's rigidbody because the force would accumulate from multiple clicks. Instead, on clicking the LMB the velocity is set upwards and gravity continuously pulls downwards.