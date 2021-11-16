using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystems : MonoBehaviour
{

    private bool fired = false;
    private List<Action> actions = new List<Action>();
    [SerializeField] private Event newEvent;
    MenuController menuController;


    public void Start()
    {
        menuController = GameObject.Find("Controllers").GetComponent<MenuController>();
        actions.Add(CometSighted);
        actions.Add(RulerInsanity);
        actions.Add(RulerEmbarresesThemselves);
        actions.Add(Scandal);
        actions.Add(DiplomaticInsult);
        actions.Add(ExpandingInfluence);
        actions.Add(TwoRulers);
        actions.Add(PeasantsAreUnhappy);
        actions.Add(GoldRush);
        actions.Add(MartialReforms);
        actions.Add(DiplomaticReforms);
        actions.Add(PoliticalTraitorGainsPower);
        actions.Add(AGrandPalace);
        actions.Add(NationalGloryRevised);
        actions.Add(PenVsSword);
        actions.Add(SmugglingGrowingOutOfControl);
        actions.Add(BountifulHarvest);
        actions.Add(CitizensDemandStability);
        actions.Add(QualityGoods);
        actions.Add(Plague);
    }

    #region Events

    public void Welcome()
    {
        Debug.Log("Welcome Event");
    }

    public void CometSighted()
    {
        //-100 Stab
        //-20% Manpower
        //-25% morale
        //-100 Prestiege
    }

    public void RulerInsanity()
    {
        //-25 Stab
        //-1 Diplo Rep (10 years)
        //-25 Prestiege

        //OR

        //-100 Gold
        //-5 Prestiege
    }

    public void RulerEmbarresesThemselves()
    {
        //-3 Diplo Rep (10 years)
        //-10 Prestiege
    }

    public void Scandal()
    {
        //-2 Diplo Rep (10 years)
        //-10 Stab
        //-10 Prestiege
    }
    public void DiplomaticInsult()
    {
        //-1 Diplo Rep (10 years)
        //+5% Morale
        //-5 Prestiege
    }
    public void ExpandingInfluence()
    {
        //+10 Stab
        //+1 Diplo Rep (10 years)
        //+10 Prestiege
    }
    public void TwoRulers()
    {
        //-50 Stab
        //-25 Prestiege
        //- Diplo Rep (10 years)
    }
    public void PeasantsAreUnhappy()
    {
        //-25 Stab
        //-5 Prestiege
        //-25 Gold
    }
    public void GoldRush()
    {
        //+5 Prestiege
        //+10x income influx (1 income = 10 gold)
    }
    public void MartialReforms()
    {
        //+10% Manpower
        //+15 Morale
    }
    public void DiplomaticReforms()
    {
        //+3 Diplo rep
    }
    public void PoliticalTraitorGainsPower()
    {
        //-15 Prestiege
        //-10 Stab
    }
    public void AGrandPalace()
    {
        //-100 Gold
        //+15 Prestiege
        //+15 Stab
        //+1 Diplo Rep
    }
    public void NationalGloryRevised()
    {
        //+15 Prestiege
        //+1 Diplo Rep
    }
    public void PenVsSword()
    {
        //-15 Morale
        //+2 Diplo Rep
        //OR
        //+5 Morale
        //-1 Diplo Rep
    }
    public void SmugglingGrowingOutOfControl()
    {
        //-100 Gold
        //-5 Prestiege
        //OR
        //+50 Gold
        //-20 Prestiege
        //-5 Stab
    }
    public void BountifulHarvest()
    {
        //+200% income at once
        //OR
        //+5 Stab
        //+5 Prestiege
    }
    public void CitizensDemandStability()
    {
        //-25 Stab
        //-25 Prestiege
        //OR
        //-100 Gold
        //+100 Stab
        //+25 Prestiege
    }
    public void QualityGoods()
    {
        //+50 Gold
        //+5 Prestiege
    }
    public void Plague()
    {
        //-100 Gold
        //-5 Stab
        //OR 
        //-15 Stab
        //-15 Prestiege
    }

    #endregion

    public void eventChance()
    {
        int val = UnityEngine.Random.Range(0,actions.Count);
        runFunction(val);
    }

    public void runFunction(int i)
    {
        if(i <= actions.Count)
        {
            actions[i]();
            Debug.Log("Action " + i + " ran");
        }
        else
        {
            Debug.LogError("Index out of range: " + i + " is greater than the given size of " + actions.Count);
        }
    }
}
