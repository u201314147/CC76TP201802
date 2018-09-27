#pragma once

#include "City.h"

#include <string>
#include <fstream>
#include <conio.h>
#include <ctime>

using std::vector;
using std::string;
using std::ifstream;

struct path {
	int parent;
	double w;

	path() {}
	path(int parent, double w) : parent(parent), w(w) {}
};

class PathFinder{
	vector<City> cities;

public:
	PathFinder();
	~PathFinder();

	void Load_adylst(ifstream *file);
	void Load_adylst(string filename);

	vector<path> Find_path(int s = 0);
	vector<path> Big_F_Search(int s, vector<path> path, vector<bool> visited, double actual_weight, int cities_left, int start_city, int total_cities);
};

double str_to_double(string str);
void print_path(vector<path> path, bool final = false);