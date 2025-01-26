using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiliaseDomain_MainMenu : InitialiseDomain
{
    [SerializeField] private Canvas mainCanvas, levelSelectCanvas, settingsCanvas, exitCanvas;
    private Canvas[] canvases;
    private Canvas activeCanvas;

    public override void Initialise(SceneDataSO data)
    {
        canvases = new Canvas[] { mainCanvas, levelSelectCanvas, settingsCanvas, exitCanvas };

        UpdateActiveCanvas(mainCanvas);

        SoundManager.StartMusic(SoundType.MENUMUSIC);
    }

    #region Buttons

    public async void PlayGame()
    {
        SoundManager.PlaySound(SoundType.CHANGEMAG);

        SoundManager.StopMusic();

        await SceneToolManager.ChangeScene("scene_level_one"); // IMPLEMENT CORRECT SCENE
    }

    public void OpenLevelSelect()
    {
        UpdateActiveCanvas(levelSelectCanvas);
    }
    
    public void LoadScene(int sceneNum)
    {
        if (sceneNum <= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(sceneNum);
        }
        else
        {
            Debug.LogWarning("Scene " +  sceneNum + " not found.");
        }
    }

    public void OpenSettings()
    {
        UpdateActiveCanvas(settingsCanvas);
    }

    public void OpenExitMenu()
    {
        SoundManager.PlaySound(SoundType.BUBBLEPOP);

        exitCanvas.enabled = !exitCanvas.enabled;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMain()
    {
        UpdateActiveCanvas(mainCanvas);
    }

    #endregion

    private void UpdateActiveCanvas(Canvas canvas)
    {
        SoundManager.PlaySound(SoundType.BUBBLEPOP);

        activeCanvas = canvas;

        foreach (Canvas c in canvases)
        {
            c.enabled = (c == activeCanvas);
        }
    }
}
