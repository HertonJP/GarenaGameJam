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
    [SerializeField] private List<int> talentIndexList = new();
    [SerializeField] private GameObject pickTalentUI;
    // Start is called before the first frame update
    void Start()
    {
        RandomizeTalent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TalentButtonClicked()
    {
        talentManager.takenTalents[currSlot] = randomizedTalentList[currSlot];
        for(int i=0; i < talentList.Count; i++)
        {
            if(talentList[i].talentName == talentManager.takenTalents[currSlot].talentName)
            {
                talentList.RemoveAt(i);
            }
        }
        
        currSlot++;
        pickTalentUI.SetActive(false);
    }
    
    private void RandomizeTalent()
    {
        talentListCopy.Clear();
        talentListCopy.AddRange(talentList);
        for (int i = 0; i < 3; i++)
        {
            int randomizedResult = Random.Range(0, talentListCopy.Count);
            talentIndexList.Add(randomizedResult);
            randomizedTalentList[i] = talentListCopy[randomizedResult];
            talentListCopy.RemoveAt(randomizedResult);
            talentButtons[i].transform.GetChild(0).GetComponent<Image>().sprite = randomizedTalentList[i].talentSprite;
            talentButtons[i].transform.GetChild(1).GetComponent<TMP_Text>().text = randomizedTalentList[i].talentName;
            talentButtons[i].transform.GetChild(2).GetComponent<TMP_Text>().text = randomizedTalentList[i].talentDescription;
        }
    }
}
