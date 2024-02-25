#include <iostream>
using std::cin;
using std::cout;
using std::endl;
/*
문제 해설
행 x ,열 y 를 입력
이에 대한 숫자 나선형으로 숫자 배열이 만들어진다
ex)5층 경우
1	2	9	10	25
4	3	8	11	24
5	6	7	12	23
16	15	14	13	22
17	18	19	20	21

테스트 횟수  t번


행과 열을 비교 하여 더 큰수 ex) x일 경우
짝수 일경우 (x,1) 의 값은 x^2
홀수 일경우 (1,x) 의 값은 x^2 이다.

이때 행과 열의 값이 같을 경우 변수 x 라면 (x,x)의 값은 x*x-(x-1)
이때 x가 홀수 이면 (x-n,x)일수록 증가 (x,x-n)일수록 감소
	짝수이면 (x-n,x)일수록 감소	(x,x-n) 일수록 증가

*/
int main()
{

	int t;//테스트 횟수 변수
	long long x,y;x=y=0;//x:행 y:열
	long long x__y=0;//x==y일때 계산값을 저장
	long long diff_xy=0;//x와y의 차이값
	cin>>t;
	
	for(int i=t;i>0;i--)//테스트값 횟수 반복문
	{
		
		cin>>x>>y;
		
		diff_xy=x-y;//(행==열)의 기준에서 자리값 계산
		
		if(x<y)
		{
			x__y=(y*y)-(y-1);//행==열 일때 자리 값 -> x==y 이므로 결국 y^2-(y-1) 의 값이 나온다.
			
			if(y&1)//홀수
			{
				if(diff_xy<0)
				{
					cout<<x__y-diff_xy<<endl;
				}
				else
				{
					cout<<x__y-diff_xy<<endl;
				}
			}
			else//짝수
			{
				if(diff_xy<0)
				{
					cout<<x__y+diff_xy<<endl;
				}
				else
				{
					cout<<x__y+diff_xy<<endl;
				}
			}
				
		}
		else//x>y
		{
			x__y=(x*x)-(x-1);//행==열 일때 자리 값
			
			if(x&1)//x는 홀수
			{
				if(diff_xy<0)//diff는 음수
				{
					cout<<x__y-diff_xy<<endl;
				}
				else
				{
					cout<<x__y-diff_xy<<endl;
				}
			}
			else//y는 짝수
			{
				if(diff_xy<0)
				{
					cout<<x__y+diff_xy<<endl;
				}
				else
				{
					cout<<x__y+diff_xy<<endl;
				}
			}
		
		}

	}
}
	