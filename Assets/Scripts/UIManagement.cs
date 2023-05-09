using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Text tx1;
    public Text tx2;
    public Text tx3;

    public RectTransform border;

    // Border positions
    private float posX = 13.9f;
    private float posY1 = 4.44f;
    private float posY2 = 2.7f;
    private float posY3 = 0.90f;

    public static float cur;

    void Start() {
        cur = 0;
    }
    void Update() {
        tx1.text = "x" + LevelController.getNumLeft(0);
        tx2.text = "x" + LevelController.getNumLeft(1);
        tx3.text = "x" + LevelController.getNumLeft(2);

        if(cur == 0) {
            border.position = new Vector3(posX, posY1, 0.0f);
        }
        else if(cur == 1) {
            border.position = new Vector3(posX, posY2, 0.0f);
        }
        else if(cur == 2) {
            border.position = new Vector3(posX, posY3, 0.0f);
        }
    }

    public static void refresh(int num) {
        cur = num;
    }
}
