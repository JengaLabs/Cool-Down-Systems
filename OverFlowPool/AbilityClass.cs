using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLimitBase
{
    #region Notes
    /*
     The ability limit base class is a system for keeping program modularity.
     All cooldowns have a amount left, maxAmount, a method to spend amount, refill amount

    */
    #endregion

    #region Class Properties 


    //How much the user has left of something
    public float AmountLeft { get; private set; }

    //Amount the user starts with and how much it can fill max
    public float maxAmount;

    #endregion

    #region Methods 

    //Suprisingly both these methods are similer but do the exact opposite of each other. 
    //Wonderful

    /// <summary>
    /// Spends amount and returns true when there is enough to spend.
    /// </summary>
    /// <param name="decrementAmount"></param>
    /// <returns></returns>
    public bool DecrementAmount(float decrementAmount)
    {
        /*Spend amount 
         * if not enough for a spend than set to zero and return false
         * else spend amount and return true
        */

        if (AmountLeft - decrementAmount >= 0)
        {
            //if there is enough to spend amount
            AmountLeft -= decrementAmount * Time.deltaTime;
            //spend amount
            return true;
        }
        else
        {
            //there is not enough to spend
            AmountLeft = 0;
            //set amount to zero
            return false;

        }
    }

    public bool IncrementAmount(float incrementAmount)
    {
        /*Refill amount specified
         * if amount will go over return false and set to max
         * else increase and return true
         */

        if (AmountLeft + incrementAmount > maxAmount)
        {
            //amount is greater than max
            AmountLeft = maxAmount;
            //set amount to max
            return false;
        }
        else
        {
            AmountLeft += incrementAmount;
            //add to amount left
            return true;
        }

    }



    #endregion


    public AbilityLimitBase(float maxAmount)
    {
        //constructor for ability limit base 
        this.AmountLeft = maxAmount;
        this.maxAmount = maxAmount;
    }

}
