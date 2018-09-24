#pragma once

#include <vector>

using std::vector;

struct pair {
	int city = -1;
	double w = -1.;

	pair() {}
	pair(int city, double w) : city(city), w(w) {}

};

class City{
	vector<pair> connections;
public:
	City();
	~City();

	void add_connection(pair p);
	vector<pair> Get_connections() { return connections; }
};

inline bool operator <(pair p1, pair p2) { return p2.w < p1.w; }