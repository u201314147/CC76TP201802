#include "City.h"

City::City(){}
City::~City(){}



void City::add_connection(pair p) {
	for (pair pc : connections)
		if (pc.city == p.city)
			return;

	connections.push_back(p);
}