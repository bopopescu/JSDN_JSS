using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JSE
{
    class Translator
    {
        public static Dictionary<string, string> dict = new Dictionary<string, string>();
        public static void translate()
        {

                dict.Add("엔터","\n");
                dict.Add("줄바꿈", "\n");
                dict.Add("정수", "int");
                dict.Add("정수형", "int");
                dict.Add("자연수", "uint");
                dict.Add("자연수형", "uint");
                dict.Add("실수", "double");
                dict.Add("실수형", "double");
                dict.Add("문자", "char");
                dict.Add("문자형", "char");
                dict.Add("문자열", "string");
                dict.Add("논리", "bool");
                dict.Add("논리형", "bool");
                dict.Add("이면", "");
                dict.Add("아니면", "else");
                dict.Add("판단", "switch");
                dict.Add("경우", "case");
                dict.Add("출력", "Console.Write");
                dict.Add("입력","Console.ReadKey");
                dict.Add("문장입력", "Console.ReadLine");
                dict.Add("탈출", "break");
                dict.Add("나머지", "default");
                dict.Add("반복", "for");

        }
        public static string replace_word(string code,string output)
        {
            string[] split_code = code.Split(' ');
            for(int i = 0;i<split_code.Length;i++)
            {
                if(dict.ContainsKey(split_code[i]))
                {
                    split_code[i] = dict[split_code[i]];
                }
            }
            string returnval = "";
            for (int i = 0; i < split_code.Length; i++)
            {
                returnval += split_code[i];
                returnval += " ";
            }
            return returnval;
        }
    }
}
