#include <iostream>
#include <algorithm>

int main()
{
	long long n;//입력받을 정수의 개수
	std::cin>>n;//입력받을 정수 입력
	long long array_data[n];//두번째 입력한 정수의 내용
	long long value_count=0;//출력할 고유값
	
	for(int i=0;i<n;i++)
	{
		std::cin>>array_data[i];
	}//두번째 줄에 입력받은 고유값들
	
	std::sort(array_data,array_data+n);//배열 정렬
	
	for(int i=0;i<n;i++)
	{
		if(array_data[i]!=array_data[i+1])
		{
			value_count++;
			continue;
		}
	}//만약 배열의 목록값이 서로 다르면 고유값 카운터를 증가
	
	std::cout<<value_count<<std::endl;//고유값의 개수를 출력
	
}