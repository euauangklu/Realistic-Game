using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    public Transform playerPos;
    private Transform checkpointPos;
    [SerializeField] private List<Transform> ListPos;
    public int minilabLevel;
    
    public enum MiniLabType
    {
        MiniLab1, 
        MiniLab2,    
        MiniLab3,
        MiniLab4, 
        MiniLab5,
        MixedAll,
    }

    public MiniLabType MiniLabCurrent;
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        MiniLabCurrent = MiniLabType.MiniLab1;
        minilabLevel = 1;
        
        if (ListPos != null && ListPos.Count > 0)
        {
            checkpointPos = ListPos[0];
        }
    }

    void Update()
    {
        switch (MiniLabCurrent)
        {
            case MiniLabType.MiniLab1:
                checkpointPos.position = ListPos[0].position;
                break;
            case MiniLabType.MiniLab2:
                checkpointPos.position = ListPos[1].position;
                break;
            case MiniLabType.MiniLab3:
                checkpointPos.position = ListPos[2].position;
                break;
            case MiniLabType.MiniLab4:
                checkpointPos.position = ListPos[3].position;
                break;
            case MiniLabType.MiniLab5:
                checkpointPos.position = ListPos[4].position;
                break;
            case MiniLabType.MixedAll:
                checkpointPos.position = ListPos[5].position;
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CheckPointRespawn();
            ResetRotation();
        }

        if (playerPos.position.y <= -7f)
        {
            CheckPointRespawn();
            ResetRotation();
        }

        text.text = MiniLabCurrent.ToString();

        
    }

    private void ResetRotation()
    {
        playerPos.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void LevelCheck()
    {
        // level check
        if (minilabLevel == 1)
        {
            MiniLabCurrent = MiniLabType.MiniLab1;
        }
        else if (minilabLevel == 2)
        {
            MiniLabCurrent = MiniLabType.MiniLab2;
        }
        else if (minilabLevel == 3)
        {
            MiniLabCurrent = MiniLabType.MiniLab3;
        }
        else if (minilabLevel == 4)
        {
            MiniLabCurrent = MiniLabType.MiniLab4;
        }
        else if (minilabLevel == 5)
        {
            MiniLabCurrent = MiniLabType.MiniLab5;
        }
        else if (minilabLevel == 6)
        {
            MiniLabCurrent = MiniLabType.MixedAll;
        }
    }

    public void CheckPointRespawn()
    {
        playerPos.position = checkpointPos.position;
    }
}
