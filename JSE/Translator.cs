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
        
        public static void translate()
        {
            var dict = new ConcurrentDictionary<string, string>();
            //Dictionary에 새로운 Thread를 생성해서 초기 실행시 문법구문을 가져옴
            Task a = Task.Factory.StartNew(() =>
            {
                dict.TryAdd("엔터","\n");
                dict.TryAdd("줄바꿈", "\n");
                dict.TryAdd("정수", "int");
                dict.TryAdd("정수형", "int");
                dict.TryAdd("자연수", "uint");
                dict.TryAdd("자연수형", "uint");
                dict.TryAdd("실수", "double");
                dict.TryAdd("실수형", "double");
                dict.TryAdd("문자", "char");
                dict.TryAdd("문자형", "char");
                dict.TryAdd("문자열", "string");
                dict.TryAdd("논리", "bool");
                dict.TryAdd("논리형", "bool");
                dict.TryAdd("이면", "");
                dict.TryAdd("아니면", "else");
                dict.TryAdd("판단", "switch");
                dict.TryAdd("경우", "case");
                dict.TryAdd("출력", "Console.Write");
                dict.TryAdd("입력","Console.ReadKey");
                dict.TryAdd("문장입력", "Console.ReadLine");
                dict.TryAdd("탈출", "break");
                dict.TryAdd("나머지", "default");
                dict.TryAdd("반복", "for");
            });
        }
    }
}
