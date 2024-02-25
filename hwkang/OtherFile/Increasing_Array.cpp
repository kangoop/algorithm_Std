#include <iostream>


int main()
{
	long long n;//배열의 갯수
	std::cin>>n;
	long long data[n];//배열의 내용
	
	for(long long i=0;i<n;i++)
	{
		std::cin>>data[i];
	}
	
	long long count=0;//배열의 증가 횟수
	long long j=0;//배열의 index 값
	while(1)
	{
		if(n==1||n<=j)
		{
			break;
		}
		
		if(data[j]<=data[j+1])
		{
			++j;//index값 증가
			continue;
		}
		else
		{
			count=count+(data[j]-data[j+1]);//이전 배열보다 같거나 크기 위한 값 계산후 이전 count와 합
			data[j+1]=data[j+1]+(data[j]-data[j+1]);//만약 이전값이 더 크다면 그 다음 index값을 이전 값보다 같거나 크게 만듬
			++j;//index값 증가
			continue;
		}
	}
	
	std::cout<<count;//증가 하는 배열을 위한 최소한의 횟수
}