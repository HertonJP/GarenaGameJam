using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalentRandomizer : MonoBehaviour
{
    public int currSlot = 0;
    public TalentManager talentManager;
    [SerializeField] private List<TalentSO> talentList = new();
    [SerializeField] private List<TalentSO> talentListCopy = new();
    [SerializeField] private List<TalentSO> randomizedTalentList = new();
    [SerializeField] private List<GameObject> talentButtons = new();
    [SerializeField] private List<string> talentStringList = new();
    [SerializeField] private GameObject pickTalentUI;
    [SerializeField] private List<AudioClip> sfxList;
    bool shouldPlay;

    private void OnEnable()
    {
        GetComponent<AudioSource>().clip = sfxList[0];
        GetComponent<AudioSource>().Play();
        RandomizeTalent();
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeTalent();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldPlay)
        {
            
            GetComponent<AudioSource>().clip = sfxList[1];
            GetComponent<AudioSource>().Play();
            shouldPlay = false;
        }

    }

    public void TalentButtonClicked(ButtonData data)
    {
        shouldPlay = true;
        if (currSlot < 3)
        {
            for (int i = 0; i < talentList.Count; i++)
            {
                if (talentList[i].talentName == data.skillName)
                {
                    talentManager.takenTalents[currSlot] = talentList[i];
                    talentManager.pickedTalentUI[currSlot].sprite = talentList[i].talentSprite;
                    talentManager.pickedTalentUI[currSlot].color =new Color(255,255,255,255);
                }
            }
            currSlot++;
        }

        pickTalentUI.SetActive(false);
        Time.timeScale = 1;
    }
    
    private void RandomizeTalent()
    {
        if (currSlot < 3)
        {
            talentListCopy.Clear();
            talentListCopy.AddRange(talentList);
            for (int i = 0; i < 3; i++)
            {
                int randomizedResult = Random.Range(0, talentListCopy.Count);
                randomizedTalentList[i] = talentListCopy[randomizedResult];
                talentListCopy.RemoveAt(randomizedResult);
                talentButtons[i].transform.GetChild(0).GetComponent<Image>().sprite = randomizedTalentList[i].talentSprite;
                talentButtons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = randomizedTalentList[i].talentName;
                talentButtons[i].transform.GetChild(2).GetComponent<TMP_Text>().text = randomizedTalentList[i].talentDescription;
                talentButtons[i].GetComponent<ButtonData>().skillName = randomizedTalentList[i].talentName;
            }
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);
    }
}
