/** Unity Review C# 'Script' by Warren Ngoun --- Note this was written as reference and not with the intention of being able to run, so don't try that. */

// These are the default "imports" for each C# script in Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI; // This if for dealing w/ NavMeshes
using UnityEngine.SceneManagement; // This is for Scene transitions

public class UnityQuickReview : MonoBehaviour {

    // Int, Float, Bool are all familiar returning variable types
    private int whole_timer = 60;
    private float timer = 0.0f; // 0.0f means a float, this is just an extra "just incase" step
    private float speed = 1.0f;
    private bool flip;
    // Public means other scripts/Objs can interact w/ the variable. Also means we can directly mess w/ the Obj in the editor.
    public GameObject item;
    // Serializing a Field lets us "attach" a Obj to the script like w/ a private variable except that because it's still private other scripts can't access it.
    [SerializeField] private GameObject _enemy;
    // Vector3's are just the X Y Z coordinate system and is used to represent a point.
    private Vector3 enemy_coords;
    // BUT Vector3's are also a STRUCT meaning if we predeclare it like below we'll need to include the New Vector3 keywords.
    private Vector3 ally_coords = new Vector3 (0, 11, 1);
    // A Nav Mesh Agent allows our Player/Obj to Navigate the NavMesh to path around the "world"
    private NavMeshAgent player_controller;

    // Awake() or Start() runs ONCE per Obj only and is usually used for Initialization
    void Start() {
        // You can reference "this" as the Obj this script is attached too and grab it's components
        enemy_coords = this.transform.position;
        // Get component allows us to grab whatever components we need to on an Obj, in this case we grab this Objs Nav Mesh Agent
        player_controller = GetComponent<NavMeshAgent>();
    }

    // This also initializes like w/ Start() but triggers everytime the Obj is enabled
    void OnEnable() {
        // Currently idk the optimal use of this function over Update()
    }

    // Update() gets called on EVERY frame.
    void Update() {

        // Time.deltaTime lets us account for variable FPS and make FPS independent code for certain actions.
        timer += Time.deltaTime;
        if (timer >= whole_timer) Debug.Log("Timer reset!");

        // Input is how we grab direct input from something like the keyboard or mouse
        // GetMouseButtonDown takes either "0 = LMB" "1 = RMB" or "2 = MMB"
        if (Input.GetMouseButtonDown(0)) player_controller.SetDestination(ally_coords);
        // GetKeyDown checks for a Keyboard press. It returns a BOOL.
        // Debug.Log is our "echo" and method to print to console.
        if (Input.GetKeyDown("space")) Debug.Log("Space was pressed");

        // GetAxis gets "keybindings" for a certain controller type. Here "vertical" and "horizontal" mean WASD or the Arrow Keys on a KB.
        // GetAxis Unlike GetKey RETURNS a FLOAT so we need to compare it to a number in our Ifs
        if (Input.GetAxis("Vertical") != 0) {
            float moveX = Input.GetAxis("Vertical") * speed;
            // Translate lets us move the position of a Objs transform position.
            item.transform.Translate(0, 0, moveX * Time.deltaTime);
        } else if (Input.GetAxis("Horizontal") != 0) {
            // Time.deltaTime makes it so movement isn't dependent on FPS since Update calls once a frame
            item.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0); 
        }

        if (Input.GetKeyDown("p")) {
            // SceneManager will load a scene for us depending on what the scenes "Index" is under our build settings.
            // (Note: This is only the "Loading" and not any of the animation for the screen transition itself)
            SceneManager.LoadScene(0);
            // SceneManager ALSO can load a scene on it's name.
            SceneManager.LoadScene("Menu");
        }

        if (_enemy == null) {
            // Instantiate creates this prefab onto the world i.e. Spawns them. Instantiate creates them as a generic type, so we typecase with "as GameObject" to make it not generic.
            GameObject enemyPrefab = (GameObject) Instantiate(_enemy);
            // All Objs in the scene view have a transform, here you can modify that transforms position depending on a Vector3
            _enemy.transform.position = enemy_coords;
            enemyPrefab.GetComponent<NavMeshAgent>();
        }

		if (Input.GetMouseButtonDown(1)) {
			// Creates a Ray Obj (which is a infinite line from one point to another) and creates it from the Main Camera (Which NEEDS to be set as the Main Camera or else this won't work) to the point where the Player clicked their mouse 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit; 
            // Physics.Raycast returns True if the Ray has intersected a collider, False if something w/out a collider. This lets us determine if our Ray from earlier is a valid point on the screen.
			if (Physics.Raycast(ray, out rayHit)) {
                GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                // NavMeshAgents have multiple components we can grab, Speed here is an example of grabbing one.
                GetComponent<NavMeshAgent>().speed = 2.0f;
                // We can compile an array of GameObjects by looking for them by Tag OR
                GameObject[] items = GameObject.FindGameObjectsWithTag("Sweets");
                Destroy(items[0]);
                // We can find just a single GameObject by using the singular function
                GameObject item = GameObject.FindGameObjectWithTag("Sweets");
                Destroy(item);
                // Tags are useful for marking certain GameObjects to belong in certain categories, like marking all the ground Objects as "Ground" to make sure that you can't interact/click/etc. with something that isn't that.
                // In this case, we can also take the TAG from a Raycast Hit to quickly verify what we hit is correct
                if (rayHit.transform.tag == "Ground") {
                    Debug.Log("This is the ground?");
                } else {
                    Debug.Log("No this is Sweets!");
                }
            }
		}
    }

    // OnTriggerEnter() gets called when this GameObject collides with another GameObject. The parameter Collider it takes is the OTHER collider not THIS.
    void OnTriggerEnter(Collider other) {

        // GameObjects have components, name here is an example of how to call one
        Debug.Log(other.gameObject.name);
        // PlayerCharacter here is a name of a script we've attached to another GameObj. Here we check to see if the OTHER thing we've collided w/ has that script attached to it (by checking it's components to see if the script name is there).
        ClickMove player = other.GetComponent<ClickMove>();
        // So we'd just check if that component was null or not to test collision.
        if (player != null) {
            Debug.Log("Hit a player");
            // This is us calling the takeDamage function from the attached PlayerCharacter script
            player.painedScreaming();
        }
        // Destroys whatever GameObjs is in the parameter, in this case it kills itself.
        Destroy (this);
        // This is also an example of destroying the GAMEOBJECT the script is attached to
        Destroy (gameObject);
    }

    // You can also create public functions other scripts/Objs can trigger or make it Private and use it only for this Obj instead.
    public static Vector3 RandomNavSpherePoint(Vector3 origin, float radius) {
        // Random.insideUnitSphere gets a random point from the normal Unit sphere (radius of 1) using dist here lets us enlargen the result to a desired radius size.
        Vector3 randDirection = (Random.insideUnitSphere * radius) + origin;
        NavMeshHit navHit;
        // This function samples the NavMesh and finds the closest point on the NavMesh from our random point we found earlier (out navHit is similar to Raycast testing).
        NavMesh.SamplePosition(randDirection, out navHit, radius, -1);
        // Then we return the sampled NavMesh point (a Vector3) by using its position component
        return navHit.position;
    }

    public void EndGame() {
        // This function Kills the program, In Editor it does nothing but in Builds it does
        Application.Quit();
    }

    public void SimplePathMovement() {
        bool flip = false;
        Vector3 test_point = new Vector3(0, 0, 0);

        if (flip) {
            // In Vector3, there is a function that lets you move from one point to another in stepped increments
            transform.position = Vector3.MoveTowards(transform.position, test_point, Time.deltaTime);
        } else {
            Debug.Log("Something else?");
        }
    }
}