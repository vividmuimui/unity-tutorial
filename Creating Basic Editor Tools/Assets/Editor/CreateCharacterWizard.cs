using UnityEngine;
using UnityEditor;

public class CreateCharacterWizard : ScriptableWizard {
	public Texture2D portraitTexture;
	public Color color = Color.white;
	public string nickname = "Default nickname";
	
	[MenuItem ("My Tools/Create character wizard...")]
	static void CreateWizard()
	{
		ScriptableWizard.DisplayWizard<CreateCharacterWizard>(
			"Create Character", 
			"Create new", 
			"Update Selected"
		);
	}

	void OnWizardCreate()
	{
		GameObject characterGO = new GameObject();
		Character characterComponent = characterGO.AddComponent<Character>();
		characterComponent.portrait = portraitTexture;
		characterComponent.nickname = nickname;
		characterComponent.color = color;

		PlayerMovement playerMovement = characterGO.AddComponent<PlayerMovement>();
		characterComponent.playerMovement = playerMovement;
	}

	void OnWizardOtherButton()
	{
		if(Selection.activeTransform != null)
		{
			Character characterComponent = Selection.activeTransform.GetComponent<Character>();
			if(characterComponent != null)
			{
				characterComponent.portrait = portraitTexture;
				characterComponent.nickname = nickname;
				characterComponent.color = color;
			}
		}
	}

	void OnWizardUpdate()
	{
		helpString = "Enter character details";
		errorString = "test error string";
	}
}
