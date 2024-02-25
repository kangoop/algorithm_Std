#include <iostream>
#include <algorithm>
using namespace std;
int main()
{
	long long n, m, k;//신청자수, 아파트수, 아파트크기허용범위

	cin >> n >> m >>k;

	long long n_num[n];//신청자가 원하는 아파트의 크기
	long long m_num[m];//아파트의 크기

	long long app_num = 0;//분양받을 신청자수
	int i, j=0;

	for (i = 0; i < n; i++)
	{
		std::cin >> n_num[i];
	}//신청자가 원하는 아파트크기를 입력 랜덤데이터

	sort(n_num,n_num+n);//신청자가 원하는 아파트의 크기 정렬_오름차순

	for (i = 0; i < m; i++)
	{
		std::cin >> m_num[i];
	}//아파타의 크기를 입력 랜덤데이터

	sort(m_num,m_num+m);//아파트의 크기 정렬_오름차순
	
	i=j=0;//인덱스 초기화
	
	while (j<m)
	{
		/*
		위에 증감 했으므로 이제 신청자의 희망 아파트 크기와 아파트의 크기는 정렬 완료
		이후 에는 비교하며 증감을 시작
		*/

		if ((n_num[i]-k<= m_num[j]) && (m_num[j] <= n_num[i]+k))
		{
			++app_num; ++i; ++j; continue;
		}//아파트의 크기가 신청자의 허용 범위에 들어가면 모두 증감

		if (n_num[i] - k > m_num[j])
		{
			++j; continue;
		}//만약 신청자의 허용범위보다 너무 작다면 아파트크기의 인덱스를 증가

		if (n_num[i] + k < m_num[j])
		{
			++i; continue;
		}//만약 신청자의 허용범위보다 너무 크다면 신청자의 인덱스를 증가
	}

	cout<<app_num;//아파트를 분양받을 신청자의 수
}
