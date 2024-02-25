#include <iostream>
#include <vector>
int main()
{
	long long n;//원하는 합계
	std::cin>>n;//합계 입력
	std::vector<int> conis{1,2,3,4,5,6};//주사위 값
	long long count_n[n+1]={1,1,2,4};//메모이제이션을 위한 배열
	long long m=1000000007;//모듈 연산을 위한 값

	for(long long x=4;x<=n;x++)
	{
		for(auto c: conis)
		{
			if(x-c>=0)
			{
				count_n[x]+=count_n[x-c];
				count_n[x]%=m;
			}
		}
	}
	
	std::cout<<count_n[n]<<std::endl;
	
	
	
}