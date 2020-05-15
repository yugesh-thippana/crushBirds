using UnityEngine;

// this should be included for using scene manager.
using UnityEngine.SceneManagement;

// name bluebird should match the script in unity
public class blueBird : MonoBehaviour
{   
    // variables here.
    Vector3 _intialPos;
    
    // this function awakes whenever game is started
    void Awake(){
        
        // _ in the begining is used for variables which are private.
        // getcomponent is used to get components from unity and update them.
        _intialPos = GetComponent<Transform>().position;
    }

    // when mouse is clicked
    void OnMouseDown(){

        // for changing the color of the sprite
        GetComponent<SpriteRenderer>().material.color = Color.red;
    }

    // this gets updated at 1hz rate.
    private void Update() {
        if(GetComponent<Transform>().position.y > 7){

            // getactivescene is used to store the active scene in the form of string.
            // load scene reloads the scene which is put into it.
            string reloadScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(reloadScene);
        }
    }

    // onemouseup when the mouse click is released
    void OnMouseUp(){

        //changing back color to white when released
        GetComponent<SpriteRenderer>().material.color = Color.white;
        // setting force direction
        Vector2 direcToInitialPos = _intialPos - GetComponent<Transform>().position; 
        // adds the force vector to the sprite in the direction specified. multiplied 200 cause general force is very low
        GetComponent<Rigidbody2D>().AddForce(direcToInitialPos*200);
        // setting gravity after release
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    // when mouse is dragged
    void OnMouseDrag(){

        // getting input mouse position and changing them to world position.now the z-axis will be on camera.
        Vector3 birdPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // hence z-axis shouldnt be added to the new position which makes it invisble.
        GetComponent<Transform>().position = new Vector3(birdPos.x , birdPos.y);
    }
    

}