using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonobehavior<LevelManager>
{
    private bool gameActive;
    [HideInInspector] public float timer;
    public float waitToShowEndScreen = 1f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        gameActive = true;
    }

    private void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            UIController.Instance.UpdateTimer(timer);
        }
    }

    public void EndLevel()
    {
        gameActive = true;

        StartCoroutine(EndLevelProcess());
    }

    private IEnumerator EndLevelProcess()
    {
        yield return new WaitForSeconds(waitToShowEndScreen);

        float minutes = Mathf.FloorToInt(timer / 60f);
        float second = Mathf.FloorToInt(timer % 60);

        UIController.Instance.endTimeText.text = minutes.ToString() + " mins " + second.ToString("00" + " secs");
        UIController.Instance.levelEndScreen.SetActive(true);
    }
}
