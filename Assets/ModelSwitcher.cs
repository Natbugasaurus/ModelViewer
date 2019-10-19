using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitcher : MonoBehaviour {

    public List<GameObject> models = new List<GameObject>();

    public int currentModel;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            currentModel -= 1;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            currentModel += 1;
        }

        if (currentModel > (models.Count-1)) {
            currentModel = 0;
        } else if (currentModel < 0) {
            currentModel = (models.Count-1);
        }

        foreach (GameObject x in models) {
            x.SetActive(false);
        }

        models[currentModel].SetActive(true);
    }

    public void ChangeModel(int nextModel) {
        currentModel = nextModel;
    }
}
