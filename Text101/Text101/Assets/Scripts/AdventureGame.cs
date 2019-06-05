using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * Order for putting fields together.
 * 1. Right click in Hierarchy menu, create Empty. This is a blank GameObject we can customize.
 * 2. We want to use it for scripts. Select Game in Hierarchy menu, then Add Component. Select New Script, enter a name.
 * 3. We now have a script, except it isn't link. Open it in VS (here). Then enter the SerializeField line. This makes the field appear in the Unity UI.
 * 4. Since we label it as Text, we can only select Text elements. Select the text field we want to dynamically update.
 * 5. Now we can reference the textComponent and update the text programmatically.
 */

/*
 * You wake up in a room with white walls and a blinding light that immediately strains your eyes. You don't remember
 * who you are or how you got there. You notice a light switch and a note pinned to the wall.
 * 
 * 1. Flip the light switch.
 * 2. Read the note.
 */

public class AdventureGame : MonoBehaviour {

    // [SerializeField] allows this variable to be seen in the Unity UI inspector.
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

	// Use this for initialization
	void Start () {
        state = startingState;
        textComponent.text = state.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        for (int i = 0; i < nextStates.Length; i++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                state = nextStates[i];
            }
        }
        textComponent.text = state.GetStateStory();
    }
}
