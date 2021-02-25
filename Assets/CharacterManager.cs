using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private string characterGameObjectPrefix = "Characters_";
    [SerializeField] private string gameLoopSceneName = "Gameplay_Loop";
    [SerializeField] private string characterSelectionSceneName = "CharacterSelection";

    [Header("References")]
    [SerializeField] private Transform characterSetTransform;
    [SerializeField] private CharacterSelection charSelection;

    private string keyName = "selectedCharacterIndex";

    private void Start()
    {
        if( ES3.KeyExists( keyName ) )
        {
            print( "save data exists" );
            if ( SceneManager.GetActiveScene().name == characterSelectionSceneName)
            {
                if (charSelection != null)
                {
                    charSelection.SetSelectedCharacter(ES3.Load<int>(keyName));
                }
                else
                {
                    print( "unable to load save data. check references." );
                }
            }
            else if( SceneManager.GetActiveScene().name == gameLoopSceneName )
            {
                if (characterSetTransform != null)
                {
                    int selectedCharacterIndex = ES3.Load<int>(keyName);

                    // set transform position
                    float xVal = -1 * ( 5 * selectedCharacterIndex );
                    characterSetTransform.position = new Vector3( xVal, characterSetTransform.position.y, characterSetTransform.position.z );

                    #region disable other characters in the set

                    Transform[] allChildTransforms = characterSetTransform.gameObject.GetComponentsInChildren<Transform>();
                    int currentCharacter = -1;
                    for( int i = 0; i < allChildTransforms.Length; i++ )
                    {
                        // check if current gameobject is a character game object
                        if ( allChildTransforms[i].gameObject.name.StartsWith( characterGameObjectPrefix ) )
                        {
                            // disable character if it is not the character selected by the player
                            if( ++currentCharacter != selectedCharacterIndex )
                            {
                                allChildTransforms[i].gameObject.SetActive(false);
                            }
                        }
                    }

                    #endregion

                }
                else
                {
                    print("unable to load save data. check references.");
                }
            }
        }
        else
        {
            print( "no save data exists" );
        }
    }

    public void SaveSelection()
    {
        ES3.Save<int>( keyName, charSelection.characterIndex );
        print( "character selection saved" );
    }
}
