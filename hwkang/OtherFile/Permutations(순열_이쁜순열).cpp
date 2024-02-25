#include <iostream>
using std::cout;
using std::cin;
/*
순열 프로그램
다만 주변의 값의 차이가 1 초과 해야 한다=> 2 4 6 ... (짝수가 연속) 1 3 5 ... (홀수연속) 이 경우에도 알고리즘의 조건을 만족 
함정에 빠진 이유 : 이 알고리즘은 해결책은 여러개 이나 
어떤 입력값에 따라 공통적으로 적용해되는 규칙이 존재했음
그것을 알아채지 못함
*/

int main()
{
	long long n;//수 입력
	int num_1;//홀수
	int num_2;//짝수

	cin >> n;

	if (1 < n&&n < 4)
	{
		cout << "NO SOLUTION";
		return 0;
	}//2,3일때는 해결책없음
	else if (n == 1)
	{
		cout << 1;
		return 0;
	}//1일때는 1하나만 존재 가능

	//위 경우 에는 프로그램 종료

	if (n & 1)
	{
		num_1 = (int)n / 2;
		num_2 = num_1 + 1;

	}
	else num_1 = num_2 = n / 2;
	//입력 받은 수가 짝수 인경우 홀수 와 짝수의 갯수가 동일 
	//홀수 일 경우 1,3,5.. 의 갯수가 한개 더 많음

		for (int i = 2; i <= n;)
		{
			cout << i << " ";
			i = i + 2;
		}
		for (int i = 1; i <= n;)
		{
			cout << i << " ";
			i = i + 2;
		}
		//출력 및 <=n 의 경우 에는 출력되는 수가 n보다 같은수는 있으나 넘지는 못한다.



}
