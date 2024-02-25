#include <iostream>
#include <string>

using std::cout;
using std::cin;

int main()
{
	long long n=0;//처음 입력할 갯수
	cin >> n;
	long long n_sum = 1; //입력한 수의 n,n-1,n-2...0까지의 의 반복된 총합
	//앞선 조건에서 1과 n이 무조건 포함 즉 최소한 의 결과는 1를 출력 즉 결과값을 1로 초기화

	long long input=0;//miss number를 제외한 숫자를 입력받을 value

	long long input_sum=0;//입력 받은 수의 총합

	long long count = 0;//miss number 를 제외한 숫자를 입력받음 계속 (반복문 제어)

	while (1)
	{
		if (n < 2)
		{
			break;
		}
		cin >> input;//수 입력

		n_sum += (n - count);
		input_sum += input;
		//각각의 변수의 총합을 계산

		count++;//
		if (count == (n - 1))break;
	}

	cout << n_sum - input_sum;
}