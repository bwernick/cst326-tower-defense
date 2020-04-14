using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public GameObject enemyManager;
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(StartLevel);
    }

    public void StartLevel()
    {
        Instantiate(enemyManager, transform.position, transform.rotation);
        btn.interactable = false;
        StartCoroutine(ButtonUpdates());
    }

    IEnumerator ButtonUpdates()
    {
        yield return new WaitForSeconds(2.0f);
        ButtonManager.levelStarted = true;
        btn.gameObject.SetActive(false);
    }

}
