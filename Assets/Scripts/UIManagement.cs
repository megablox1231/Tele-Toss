using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Text tx1;
    public Text tx2;
    public Text tx3;

    // Update is called once per frame
    void Update()
    {
        tx1.text = "x" + LevelController.getNumLeft(0);
        tx2.text = "x" + LevelController.getNumLeft(1);
        tx3.text = "x" + LevelController.getNumLeft(2);
    }
}
