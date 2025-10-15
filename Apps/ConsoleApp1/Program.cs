// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, Seung Woo");

Console.Write("zzzz");
Console.Write("zzzz312312");

int a = 0;
Console.WriteLine(a);

Console.WriteLine();
if (a == 0)
    Console.WriteLine("a가 0이야");
else Console.WriteLine("a가 0이아니야");

for(int i =0;i<99;i++)
{
    Console.WriteLine(i);
}

for (int i = 0; i < 99; i++)
{
    Console.WriteLine(i);
    if (i > 40)
        break; // break는 가장가까운 '반복문'을 벗어난다.
}

List<String> seungList = new List<String>();
seungList.Add("정");
seungList.Add("승");
seungList.Add("우");
// seungList 정 승 우 

foreach (String s in seungList)
{
    Console.WriteLine(s);
    if (s.Equals("정"))
    {
        Console.WriteLine("정 은 성이다.");
    }
    else
    {
        Console.WriteLine("정 말고는 이름이다.");
    }
    // 정
    // 승
    // 우
}

// 테스트 종료


