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
    [SerializeField] private int numberOfCharacters = 6;

    [Header("References")]
    [SerializeField] private Transform characterSpawnTransform;
    [SerializeField] private Transform characterSetTransform;
    [SerializeField] private CharacterSelection charSelection;
    [SerializeField] private GameObject[] characterPrefabs;

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

                LoadCharacter( ES3.Load<int>(keyName) );
                #region old code
                /*
                if (characterSetTransform != null)
                {


                    int selectedCharacterIndex = ES3.Load<int>(keyName);

                    // set transform position
                    float xVal = -1 * ( 5 * selectedCharacterIndex );
                    characterSetTransform.position = new Vector3( xVal, characterSetTransform.position.y, characterSetTransform.position.z );

                    #region disable other characters in the set

                    GameObject[] otherCharacters = new GameObject[ numberOfCharacters - 1 ];

                    Transform[] allChildTransforms = characterSetTransform.gameObject.GetComponentsInChildren<Transform>();
                    int currentCharacter = -1;
                    int indexer = 0;
                    for( int i = 0; i < allChildTransforms.Length; i++ )
                    {
                        // check if current gameobject is a character game object
                        if ( allChildTransforms[i].gameObject.name.StartsWith( characterGameObjectPrefix ) )
                        {
                            // disable character if it is not the character selected by the player
                            if( ++currentCharacter != selectedCharacterIndex )
                            {
                                // allChildTransforms[i].gameObject.get;
                                otherCharacters[indexer++] = allChildTransforms[i].gameObject;
                            }
                        }
                    }

                    for( int i = 0; i < otherCharacters.Length; i++ )
                    {
                        GameObject.Destroy( otherCharacters[ i ] );
                    }

                    #endregion

                }
                else
                {
                    print("unable to load save data. check references.");
                }

                */
                
                #endregion
            }
        }
        else
        {
            print("no save data exists. loading default character");
            LoadCharacter(0);
        }
    }

    public void SaveSelection()
    {
        ES3.Save<int>( keyName, charSelection.characterIndex );
        print( "character selection saved" );
    }

    private void LoadCharacter( int characterIndex )
    {
        if (characterSpawnTransform != null && characterPrefabs.Length == numberOfCharacters)
        {
            GameObject.Instantiate(characterPrefabs[characterIndex], characterSpawnTransform.position, Quaternion.Euler(0f, 180f, 0f));
        }
        else
        {
            print("failed to load character. check references.");
        }
    }
}
