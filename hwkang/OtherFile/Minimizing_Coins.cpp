#include <iostream>
#include <algorithm>

int main()
{
	long long n;//동전 수 
	long long x;//합계
	std::cin>>n>>x;
	long long coin_val[n];//코인의 가치
	
	unsigned long long val_x[(x+1)];//합계의 순서
	
	unsigned long long INF=-10000;
	//무한대의 값을 표현 하지만 음수 제외를 했으므로 정수가 표현할수 있는 수를 위하여 여유롭게 -10000정도를 뺀다.
	
	for(int j=0;j<n;j++)
	{
		std::cin>>coin_val[j];
	}
	
	std::sort(coin_val,coin_val+n);//입력받은 동전의 가치를 정렬
	
	val_x[0]={0};//합이 0 인 경우는 동전을 쓰지 않은 경우
	
	for(long long i=1;i<=x;i++)
	{
		val_x[i]=INF;
		
		for(auto c : coin_val)//동전의 가치 대입
		{
			if((i-c)<0){break;}//합계가 음수일 경우는 있을수 없으므로 종료
			if((i-c)>=0)
			{
				val_x[i]=std::min(val_x[i],(val_x[i-c]+1));
			}
		}
	}
	
	if(val_x[x]==INF)
	{
		std::cout<<-1<<std::endl;
	}
	else
	{
		std::cout<<val_x[x]<<std::endl;
	}

}