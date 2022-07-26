using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'compressedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING message as parameter.
     */

    public static string compressedString(string message)
    {
        string compressedMessageTemp = message;
        int counttemp = 1;

        List<char> arrOctets = compressedMessageTemp.ToCharArray().ToList<Char>();
        List<string> arrOctetsNew = new List<string>();

        bool repet = false;
        int countArrOctets = arrOctets.Count;
        string compressedMessageResult;

        int countOctetsNew = 0;
        for (int i = 0; i < countArrOctets; i++)
        {
            if ((i + 1) < countArrOctets)
            {
                    if ((arrOctets[i] == arrOctets[i + 1]))
                    {



                        counttemp++;
                        repet = true;

                    }
            
                if ((arrOctets[i] != arrOctets[i + 1]) && (repet == true))
                {
                    arrOctetsNew.Add(arrOctets[i].ToString());
                    countOctetsNew++;
                    arrOctetsNew.Add(counttemp.ToString());
                    countOctetsNew++;
                    repet = false;
                    counttemp = 1;
                }
            }
            if ((i + 2) < countArrOctets) {
                if ((arrOctets[i] != arrOctets[i + 1]) && (arrOctets[i + 1] != arrOctets[i + 2]) && (repet == false))
                {
                    arrOctetsNew.Add(arrOctets[i + 1].ToString());
                    countOctetsNew++;
                }
            }
            if ((i + 1) >= countArrOctets)
            {
                if ((repet == false))
                {
                    arrOctetsNew.Add(arrOctets[i].ToString());
                    countOctetsNew++;
                }
                if ((repet == true))
                {
                    arrOctetsNew.Add(arrOctets[i].ToString());
                    countOctetsNew++;
                    arrOctetsNew.Add(counttemp.ToString());
                    countOctetsNew++;
                    repet = false;
                    counttemp = 1;
                }
            }
        }
         
                      

        compressedMessageResult = string.Join("", arrOctetsNew);
        

        return compressedMessageResult;

    }

}



class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string message = Console.ReadLine();

        string result = Result.compressedString(message);

        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}

