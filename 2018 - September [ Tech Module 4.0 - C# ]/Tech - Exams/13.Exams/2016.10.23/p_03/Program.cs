using System;
using System.Text;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string damageSymbols = "0123456789+-.";

            for (int i = 0; i < text.Length; i++)
            {
                StringBuilder sbDamage = new StringBuilder();
                StringBuilder sbOthers = new StringBuilder();
                StringBuilder sbName = new StringBuilder();

                long health = 0;
                decimal damage = 0m;

                int multiplyCount = 0;
                int divideCount = 0;

                for (int e = 0; e < text[i].Length - 1; e++)
                {
                    if (damageSymbols.Contains(text[i][e]))
                    {
                        sbDamage.Append(text[i][e]);

                        if (damageSymbols.Contains(text[i][e + 1]) == false)
                        {
                            continue;
                        }

                        sbDamage.Append(text[i][e + 1]);
                        e++;
                    }
                    else
                    {
                        sbOthers.Append(text[i][e]);
                    }

                    if (e == text[i].Length - 2)
                    {
                        if (damageSymbols.Contains(text[i][e]))
                        {
                            sbDamage.Append(text[i][e]);
                        }
                        else
                        {
                            sbOthers.Append(text[i][e + 1]);
                        }
                    }
                }


                for (int e = 0; e < sbOthers.Length; e++)
                {
                    if (sbOthers[e] == '*')
                    {
                        multiplyCount++;
                    }
                    else if (sbOthers[e] == '/')
                    {
                        divideCount++;
                    }
                    else
                    {
                        sbName.Append(sbOthers[e]);
                        health += sbOthers[e];
                    }
                }

                for (int j = 0; j < sbDamage.Length; j++)
                {
                    damage = damage + decimal.Parse(sbDamage[j].ToString());
                }

                if (multiplyCount != divideCount)
                {
                    for (int j = 0; j < multiplyCount; j++)
                    {
                        damage = damage * 2;
                    }

                    for (int j = 0; j < divideCount; j++)
                    {
                        damage = damage / 2.0m;
                    }
                }


                ;
            }
        }
    }
}
