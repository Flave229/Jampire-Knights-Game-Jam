using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	public void ChangeScene(int scene)
    {
        Application.LoadLevel(scene);
    }
}
