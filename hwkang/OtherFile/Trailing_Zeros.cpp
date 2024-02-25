#include <iostream>
long long f_5zero(long long data,long long value,long long zero_count)
{
	if(data/value<1)
	{
		return 0;
	}
	zero_count=f_5zero(data,value*5,zero_count);
	return data/value+zero_count;
	//zero_count 앞선 n!/5^n+1의 값
	//data/value 값은 현재 함수의 n!/5^n의 값 입니다.
}
int main()
{
	/*
	후행 제로
	n!의 후행 제로를 구하는 방법은
	n!/5^1+n!/5^2+...n!/5^n의 합은 n!의 후행 제로의 갯수를 구할수 있습니다.
	재귀 연산 사용
	*/
	long long n;
	std::cin>>n;
	
	long long zero_count=0;
	
	zero_count=f_5zero(n,5,0);
	std::cout<<zero_count;
	
}