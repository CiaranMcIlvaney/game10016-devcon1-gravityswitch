#### **Design Rationale**
Gravity is by far one of the most important features to have inside of any video game. Most 3D platformers and exploration based games rely on predictable and logical gravity (9.8m/s²). By introducing a gravity switch mechanic, we want to test how changing the expectation of gravity can effect players navigation and problem solving puzzles. 

Games such as Mario Galaxy 1/2 experimented with gravity switching. For example in the first game inside of Good Egg Galaxy, where players must need to navigate twisting geometry by needing to understand how to go up and down using the mechanic, making them rethink their movements and orientation. Also inside of the second game there is a level called Upside Dizzy Galaxy with the same mechanic, but made into an entire level with more complex navigation, instead of just a little part of a certain level. In this stage, there are enemy's that can only be killed from one direction and every couple of seconds the gravity automatically switches with you having no control over it, forcing the players to adapt quickly.  Our prototype will be inspired by these moments but scaled down into a much smaller and simpler environment. 

The rationale is that gravity flipping could serve as a traversal method (similar to our first prototype) or as a puzzle solving challenge, making players think about orientation and how to approach certain obstacles. This mechanic could be a cool feature to have for puzzle solving, but it could also risk confusing players. We want to test and see if it improves puzzle solving and traversal, or disrupts it and causes more issues. 

#### **Objective**
Our main objective for this prototype is to test whether or not flipping gravity 180°
can better enhance player traveling, challenge as well as engagement inside a linear platforming environment. This prototype looks at player precision, control, and timing. We want to try our best to answer the question **"Can a gravity flip mechanic make platforming more exciting and engaging without becoming overly frustrating or disorienting for the players."**

To do this we will be making a small testing level (A very small obstacle course) where players are able to switch gravity 180° at will. This will allow them to walk on the ceilings and to reach inaccessible areas with regular gravity.

The prototype being simple makes sure we focus on the mechanic itself, not on a larger scale level creation. We will try to gather feedback on how some players think of our mechanic and whether or not it feels good or confusing. 

#### **Core Statement**
Is to create and develop a gravity switch mechanic where players can flip gravity 180° with a press of a button, allow to traverse on ceilings and floors. 

#### **Main Gameplay Overview**
The prototype is to allow the player to move freely inside of a small obstacle course, with walls and gaps that can only be navigated by flipping gravity. 

- Players will use WASD to move around
- Press the F key to flip gravity 180°
- When flipped the player and the camera will reorient so the ceiling becomes the floor
- Player camera and moving mechanics will be taken from last design prototype

#### **Team Roles** 
**Alice (Programmer):** Will be responsible for coding the gravity switch mechanic, including the player reorientation and making sure the player and camera transitions smoothly between the gravity states. 

**Ciaran (Designer/Documenter):** Will be responsible for fleshing out the design document, outlining the prototypes objectives, rationale, and core statements. Making sure that the projects vision is clearly communicated. Will also be responsible for implementing Jasmine's level ideas that were made on paper into unity using the assets she provided. 

**Jasmine (Asset Finder/Supporter):** Will be responsible for finding free or open source assets to be used inside of the prototype, and will contribute to the design document and planning support. 

#### **Prototype Level**
The level for our prototype is a somewhat short, linear obstacle course made to test the players ability to control and adapt to the gravity flip mechanic we have made. Invisible barriers prevent players from just jumping from platform to platform , which force the players to have to use the flip system to move forward. There is also hazards and timing challenges to test players control and spatial awareness. Some key features include invisible barriers to make flipping gravity mandatory. Spikes that reset the level when touched. Final challenge is similar to Geometry Dash's ship segments, where its a ton of spikes on both bottom and top and the player must continuously flip gravity to stay centered in the middle to ultimately reach a chest at the end. 

#### **Technical Notes**
- Engine: Unity 3D (RP) Version 2022.3.30f1
- Version Control: Git + Git LFS

#### **Playtesting**
To try and test our gravity flip mechanic we can do small playtesting sessions with classmates or peers. Where we can observe and record stuff like:
• Whether or not they understand how and when to use the flip mechanic 
• If they experience confusion or disorientation when gravity changes
• Whether or not they say the mechanic is fun, annoying, or intuitive 

We could also ask follow up questions like:
• "Did flipping gravity make the level feel more engaging or confusing?"
• "Were there any moments where you felt stuck or disoriented?"
• "Would you want to see this mechanic in a larger game (better optimized of course)"

These things can help us determine whether gravity flipping improves player engagement and navigation or whether it disrupts the player flow.

#### **Reflection / Future Improvements**
From this prototype, we aimed to better understand how gravity flipping can enhance puzzle design as well as traversal inside a game space. If we had more time to work on this idea we would like to add:

• Smooth camera transitions to help reduce motion sickness, like screen a smooth screen rotation animation each time flipped
• Objects and puzzles that also react to gravity
• Levels that challenge players to plan flips more strategically instead of just using them freely

These improvement could help the mechanic feel more natural and easy to use, making it feel more integrated into being used in a larger game rather than just a small prototype.

#### **Scripts**
For this prototype we again used previous code to start as a basis for this prototype. The previous code just provides us with basic player movement and camera functionality. For this prototype however, Alice modified the eyeball script to add in gravity flipping and making sure that both the player and camera correctly change during flipping. 

The script below is the eyeball script and manages camera movement and mouse looking, and now also detects when the player presses F to flip gravity. When F is pressed is updates both the player rotation and the GravityFlip script.

````csharp
/*
 * Name: Ciaran McIlvaney
 * Student Number: 000945633
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeballs : MonoBehaviour
{
    // Mouse movement variables 
    public float mouseSensitivity = 5f;
    public float smoothing = 1.5f; // Smoother mouse movement 

    // Vectors to store the calculations
    private Vector2 mouseLook;
    private Vector2 smoothMovement;

    // Reference to the player
    private GameObject player;
    public bool isFlipped;
    public int flipflop = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Call reference to the player
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // This will make your cursor invisible in the game
        // Press ESC to get cursor back
        Cursor.lockState = CursorLockMode.Locked;

        // Variable for mouse movemment
        Vector2 mouseDirection = new Vector2(Input.GetAxis("Mouse X"),
                                Input.GetAxis("Mouse Y"));

        // Times the mouse input by the mouseSensitivity and smoothing
        mouseDirection.x *= mouseSensitivity * smoothing;
        mouseDirection.y *= mouseSensitivity * smoothing;


        // Linear interpolation between two positions. Moving between where the mouse is currently looking as well as the calculations done above
        smoothMovement.x = Mathf.Lerp(smoothMovement.x, mouseDirection.x, 1f / smoothing);
        smoothMovement.y = Mathf.Lerp(smoothMovement.y, mouseDirection.y, 1f / smoothing);



        // Add these calculations together
        mouseLook += smoothMovement;

        // Restrict the mouse position to make sure the player cannot rotate forever on the x-axis
        mouseLook.y = Mathf.Clamp(mouseLook.y, -50f, 40f);

        // Move the camera to the newest calculated position.
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.localPosition = new Vector3(transform.localPosition.x, 1f + mouseLook.y / -40, transform.localPosition.z);
        // Move the player object on the x-axis only
        Quaternion rotation = player.transform.rotation;
        Quaternion rotation3 = Quaternion.AngleAxis(180, player.transform.forward);
        
        // i dont want to talk about it but it works
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlipped = !isFlipped;
            if (isFlipped)
            {
                flipflop = 180;
            }
            else
            {

                flipflop = 0;
            }
            player.GetComponent<GravityFlip>().isFlipped = isFlipped;
        }
        player.transform.rotation = Quaternion.Euler(0f, mouseLook.x, flipflop);
           
        //player.transform.rotation = rotation2;




    }


}

````

This script GravityFlip made by Alice, controls the actual physics behing flipping gravity 180°. It check whether or not gravity should be inverted, disables Unity's built in gravity when flipped, and also adds upward acceleration to simulate the reverse gravity. It makes sure that the player remains in tact and grounded when upside down. 

````csharp
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public bool isFlipped;
    public GameObject cameraa;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = cameraa.GetComponent<Eyeballs>().isFlipped;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipped)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            if (!this.GetComponent<CharacterMove>().isGrounded)
            {
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Acceleration);
            }
            
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

````

This minimal script made by Ciaran, detects collision between the player and any object tagged with "Reset". When a collision occurs the level is automatically reloaded from the beginning. This was attached to the player object in order to handle instant respawning when touching hazards like spikes. In a real game, the CollisionManager would be its own script and not put on any objects, as it would need to detect more collisions then just player with "Reset", however with this just being a simple prototype, putting it on the player works just fine. 

````csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reset"))
        {
            // If the player collides with an object that has the tag "Reset" then reload the scene from the begining
            SceneManager.LoadScene(0);

        }
    }
}

````