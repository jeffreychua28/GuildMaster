
using System;

public class NumberConverter
{
    //accessed by other scripts to get string back
    public string numberConverter(double number)
    {
        string numberConverted = string.Format((number < 100000) ? "{0: 0}" : "{0:0.00e0}", number);

        return numberConverted;
    }
}
