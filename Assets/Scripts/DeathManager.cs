using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private int lastSceneIndex = 0; // The index of the last scene to be loaded on game restart
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void setSceneIndex(int index) {
        lastSceneIndex = index;
    }

    public int getSceneIndex() {
        return lastSceneIndex;
    }
}
