#include <iostream>

int main(){

	long long n;
	std::cin>>n;
	while(1)
	{
	std::cout<<n<<" ";
	if(n==1)break;
	if(n&1)n=n*3+1;
	else n/=2;
	}
		
}