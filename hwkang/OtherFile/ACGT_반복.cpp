#include <iostream>
#include <string>
int main() {
	std::string n;
	std::cin >> n;

	int total1 = 0;//ù��° ���ڿ� �ľ�
	int total2 = 1;//�ι�° ���ڿ� �ľ��̹Ƿ� 1���� ������ ����
	int total3 = 0;//���� ������ ���ڿ��� �ִ� ������ �ľ�
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
		}//A,C,G,T �� input data only one

		else if (n[i] == n[j])
		{
			total1++;
			i++;
			j++;
			continue;
		}//ù ���ӵ� ���ڿ��� ���� �ľ�

		else
		{
			//i��j�� ���ΰ��� ���ڿ��� �ƴ� �׷��� i,j��  '\0'�� �ƴ�
			//�׷��Ƿ� i,j�������� ���� ���ڿ����� �ľ��ϱ� ���� code
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
				//���ڵ��� ������ total1�� ���� ���� 
				//���� �ι�°�� ���ӵǴ� ���ڿ��� ���� ��
				//���� ���ڿ��� 1���� ������ �����Ѵٴ� ����
			}
			else total2 = 1;//�ݺ����� ���ӵ� ���ڿ��� total3���� ���� �� �ٽ� count
		}
	}
	std::cout << max;
}
