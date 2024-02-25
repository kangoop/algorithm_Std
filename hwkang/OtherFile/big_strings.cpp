#include <iostream>
//재귀 함수와 나머지 연산을 이용한 풀이법 사용
/*
long long 자료형을 사용할 경우 64bit로 2^63-1까지 표현 가능함
하지만 이는 n이 어떤값이 나올지 모르는 조건에 부합하지 못함
또한 2^n이므로 출력값을 그냥 출력하기에는 너무 큰수
그래서 mod 연산을 이용한 출력을 사용함

(a*b)mod m = (a mod m * b mod m) mod m 이 성립

ex) 2^255 mod m 에서 2^255값을 long long 자료형에서 표현 불가능 함으로 더 작게 쪼갬

(2^127 mod m * 2^128 mod m)mod m // 이때도 long long 자료형에서 표현 불가능
((2^63 mod m * 2^64 mod m)mod m)*((2^64 mod m * 2^64 mod m)mod m)
//거의 비슷하나 아직 표현 불가능(long long 자료형에서) 더 작게 쪼갬
((2^31 mod m * 2^32 mod m)mod m)*((2^32 mod m * 2^32 mod m)mod m) *
((2^32 mod m * 2^32 mod m)mod m)*((2^32 mod m * 2^32 mod m)mod m)
//long long 자료형으로 충분히 계산 가능
여기서 알수 있는것은 짝수 일경우 >>1 한 후의 값을 지수로 갖는다는것을 알수 있다.
*/
long long big_mod(long long n,long long mod)
{
	long long x,y;//n이 62초과 일때 사용
	
	long long data=1;//데이터 값
	if(n<62)
	{
		data=data<<n;
		data=data%mod;
		return data;
	}
	//재귀 함수를 끝내기 위한 제어코드
	//long long 자료형을 이용한 비트수로 62이하  값을 mod 연산
	
	if(n&1)
	{
		x=n>>1;
		y=x+1;
	}
	//n이 62 초과이며 홀수 일 경우 mod 연산을 이용한 값
	//ex) n=127 일경우 63,64로 나눔
	else
	{
		x=y=n>>1;
	}
	//n이 62 초과이며 짝수 일 경우 mod 연산을 이용한 값
	//ex) n=128 일 경우 64,64로 나눔
	
	
	data=big_mod(x,mod)*big_mod(y,mod);
	//재귀 함수를 사용한 계산
	
	data=data%mod;
	//mod 연산의 공식을 이용
	
	return data;
}

int main()
{
	long long data_mod=1000000007;//나미저 연산을 위한 값
	long long n;//문자열의 크기를 입력 받는 값
	long long data=1;//2^n이 나올 값
	std::cin>>n;
	
	data=big_mod(n,data_mod);
	
	std::cout<<data;
	
}