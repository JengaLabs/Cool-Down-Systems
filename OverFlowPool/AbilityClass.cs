using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLimitBase
{
    #region Class Properties 


    //How much the user has left of something
    public float AmountLeft { get; private set; }

    //Amount the user starts with and how much it can fill max
    public float maxAmount;

    #endregion

    #region Methods 

    public bool SmoothDecrementAmount(float decrementAmount)
    {
        //Smooth decrement decreases amount with time, used for decrease over time. 

        //take away amount with time
        AmountLeft -= decrementAmount * Time.deltaTime;

        return AmountLeft >= 0 || SetAsEmpty();
    }

    public bool DecrementAmount(float decrementAmount)
    {
        //Decrement amount instantly for spending resources.

        AmountLeft -= decrementAmount;

        //check if amount left won't be empy.
        return AmountLeft >= 0 || SetAsEmpty();
    }

    private bool SetAsEmpty()
    {
        AmountLeft = 0;
        return false;
    }


    public bool IncrementAmount(float incrementAmount)
    {
        //Increment amount instantly

        AmountLeft += incrementAmount;

        //check if above max amount
        return AmountLeft <= maxAmount || SetAsFull();
    }

    private bool SetAsFull()
    {
        AmountLeft = maxAmount;
        return false;
    }



    #endregion


    public AbilityLimitBase(float maxAmount)
    {
        //constructor for ability limit base 
        this.AmountLeft = maxAmount;
        this.maxAmount = maxAmount;
    }

}
