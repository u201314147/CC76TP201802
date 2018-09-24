#include <iostream>

#include "PathFinder.h"

int main(int argc, char **argv) {
	setlocale(LC_ALL, "es_ES");

	PathFinder p_finder;

	p_finder.Load_adylst("adylst.al");

	vector<path> p_path = p_finder.Find_path();

	for(vector<path>::size_type i = 0; i< p_path.size(); ++i){
		std::cout << p_path[i].parent;
		if (i + 1 != p_path.size())
			std::cout << " -> ";
		else
			std::cout << std::endl << std::endl << "Total lenght: " << p_path[i].w;
	}

	int a;
	std::cin >> a;

	return 0;
}