/* README CHECKPOINTS
 
 ****** Create a Empty Game Object
 * Rename it CheckpointMaster
 * Set Position to x:0 y:0 z:0
 * Add the EasyCheckpoint Script to CheckPointMaster
 * Add Rigidbody2D to CheckPointMaster
 * Set Rigidbody2D to Body Type - Static
 ******
 * Create a Child Object
 * Rename it Checkpoint_
 * Add BoxCollider2D
 * Duplicate and Spread them out in the level

****** Function
 * Each Child has a 2D collider
 * The Parent has a RigidBody2D
 * This means that the parent can register the collisions on the Children.
 * When a collision occurs, the players position is saved at the position of the Collider.

*/
