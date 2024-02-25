#include <iostream>
#include <string>
int main() {
	std::string n;
	std::cin >> n;

	int total1 = 0;//첫번째 문자열 파악
	int total2 = 1;//두번째 문자열 파악이므로 1개가 무조건 존재
	int total3 = 0;//이후 나오는 문자열의 최대 갯수를 파악
	int i = 0, j = 1;
	long long max = 0;

	while (1) {
		if (n[i] == '\0')
		{
			if (total1 >= total3) { max = (long long)total1; }
			else { max = (long long)total3; }

			break;
		}//input data result 

		if (n[j] == '\0')
		{
			i++;
			total1++;
			continue;
		}//A,C,G,T 의 input data only one

		else if (n[i] == n[j])
		{
			total1++;
			i++;
			j++;
			continue;
		}//첫 연속된 문자열의 갯수 파악

		else
		{
			//i과j가 서로같은 문자열이 아님 그러나 i,j가  '\0'이 아님
			//그러므로 i,j증가식후 같은 문자열인지 파악하기 위한 code
			i++;
			j++;
			while (n[i] == n[j])
			{
				total2++;
				i++;
				j++;
			}
			if (total2 >= total3)
			{
				total3 = total2;
				total2 = 1;
				//이코드의 실행은 total1의 값이 존재 
				//또한 두번째로 연속되는 문자열이 존재 즉
				//이후 문자열은 1개가 무조건 존재한다는 증명
			}
			else total2 = 1;//반복문에 연속된 문자열은 total3보다 작음 즉 다시 count
		}
	}
	std::cout << max;
}
