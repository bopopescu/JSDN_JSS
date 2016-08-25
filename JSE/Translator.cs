using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace JSE
{
    class Translator
    {
        public static Dictionary<string, string> dict = new Dictionary<string, string>();
        private static readonly int BUFSIZE = 65535;
        private static int[] buf = new int[BUFSIZE];
        private static int ptr { get; set; }
        private bool echo { get; set; }
        public void Reset()
        {
            Array.Clear(buf, 0, buf.Length);
        }
        public static string Interpret_bf(string s)
        {
            
            ptr = 0;
            string translated = "";
            int i = 0;
            int right = s.Length;
            while (i < right)
            {
                switch (s[i])
                {
                    case '>':
                        {
                            ptr++;
                            if (ptr >= BUFSIZE)
                            {
                                ptr = 0;
                            }
                            break;
                        }
                    case '<':
                        {
                            ptr--;
                            if (ptr < 0)
                            {
                                ptr = BUFSIZE - 1;
                            }
                            break;
                        }
                    case '.':
                        {
                            translated += ((char)buf[ptr]);
                            break;
                        }
                    case '+':
                        {
                            buf[ptr]++;
                            break;
                        }
                    case '-':
                        {
                            buf[ptr]--;
                            break;
                        }
                    case '[':
                        {
                            if (buf[ptr] == 0)
                            {
                                int loop = 1;
                                while (loop > 0)
                                {
                                    i++;
                                    char c = s[i];
                                    if (c == '[')
                                    {
                                        loop++;
                                    }
                                    else
                                    if (c == ']')
                                    {
                                        loop--;
                                    }
                                }
                            }
                            break;
                        }
                    case ']':
                        {
                            int loop = 1;
                            while (loop > 0)
                            {
                                i--;
                                char c = s[i];
                                if (c == '[')
                                {
                                    loop--;
                                }
                                else
                                if (c == ']')
                                {
                                    loop++;
                                }
                            }
                            i--;
                            break;
                        }/*
                    case ',':
                        {
                            // read a key
                            ConsoleKeyInfo key = Console.ReadKey(echo);
                            buf[ptr] = (int)key.KeyChar;
                            break;
                        }*/
                }
                i++;
            }
            return translated;
        }


        public static void translate()
        {
            dict.Add("엔터", "\n");
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
            dict.Add("입력", "Console.ReadKey");
            dict.Add("문장입력", "Console.ReadLine");
            dict.Add("탈출", "break");
            dict.Add("나머지", "default");
            dict.Add("반복", "for");
            dict.Add("에", "=");
            dict.Add("대입", "");
        }
        public static string replace_word(string code)
        {
            bool isadd = false;
            string returnval = "";
            string[] split = { "" };
            string[] split_space = { "" };

            split[0] = code;
            if (code.Contains('"'))//string 처리
            {
                split = code.Split('"');//string 자르기
            }
            for (int j = 0; j < split.Length; j++) //string형으로 나눠질 경우 돌기
            {
                if (j % 2 == 0)  //인덱스가 짝수(string 외부 구문일때)
                {
                    if (split[j].Contains(" "))//띄어쓰기가 포함되었다면
                    {
                        split_space = split[j].Split(' '); //띄어쓰기 기준으로 나눔
                    }
                    else
                    {
                        split_space[0] = split[j]; //인덱스 0번만 남게됨 -> 띄어쓰기가 없으므로 문자열a=0; 이런경우는 없다.
                        //-> 따라서 그냥 Replace 써도 된다.
                        for (int i = 0; i < dict.Count; i++)
                        {
                            if(split_space[0].Contains(dict.Keys.ElementAt(i)))
                            {
                                split_space[0] = split_space[0].Replace(dict.Keys.ElementAt(i), dict.Values.ElementAt(i));
                                continue;
                            }
                        }
                    }
                    split[j] = "";//사용에 앞서서 값이 복제되었으므로 초기화
                    for (int k = 0; k < split_space.Length; k++)//분리된 구문의 길이만큼 돌면서
                    {
                        for (int i = 0; i < dict.Count; i++)//딕셔너리 전체를 돌면서
                        {
                            if (split_space[k] == dict.Keys.ElementAt(i))//이중에 대체할 내용이 있다면
                            {
                                split_space[k] = split_space[k].Replace(dict.Keys.ElementAt(k), dict.Values.ElementAt(i));//대체한다
                                split[j] += split_space[k];
                                isadd = true;
                                break;
                            }
                        }
                        if (!isadd)
                        {
                            split[j] += split_space[k];
                        }
                        isadd = false;
                        if (!(k == split_space.Length - 1))//마지막 구문이 아니라면
                        {
                            split[j] += " "; //빠진 띄어쓰기를 넣어준다.
                        }
                    }
                    if (!(j == split.Length - 1)) //string이 시작되야 하므로 넣어줌(마지막 구문이라면 제외)
                    {
                        split[j] += '"';
                    }
                }
                else
                {
                    split[j] += '"';
                    //인덱스가 홀수(string 내부)
                }
            }
            for (int i = 0; i < split.Length; i++)
            {
                returnval += split[i];
                returnval += " ";
            }

            return returnval;
        }
    }
}
