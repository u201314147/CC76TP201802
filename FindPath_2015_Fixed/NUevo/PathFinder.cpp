#include "PathFinder.h"

#include <iostream>
#include <sstream>
#include <cmath>

using std::string;
using std::ifstream;
using std::istringstream;

extern time_t start_time;
extern time_t end_time;

time_t end_time;

PathFinder::PathFinder(){}
PathFinder::~PathFinder(){}

void PathFinder::Load_adylst(string filename) {
	ifstream *file = new ifstream;
	file->imbue(std::locale());
	file->open(filename);

	Load_adylst(file);
}

void print_path(vector<path> p, bool final) {
	std::cout << "Camino: " << std::endl;
	for (vector<path>::size_type i = 0; i < p.size(); ++i) {
		std::cout << p[i].parent;
		if (i + 1 != p.size())
			std::cout << " -> ";
	}

	std::cout << "\n\nDistancias: " << std::endl;

	for (vector<path>::size_type i = 0; i < p.size(); ++i) {
		std::cout << p[i].w;
		if (i + 1 != p.size())
			std::cout << " -> ";
		else
			std::cout << "\n\nDistancia Total: " << p[i].w;
	}

	if(final == false){
		time_t actual_time;
		time(&actual_time);

		std::cout << "\n\nTiempo de ejecucion (hasta el momento): " << actual_time - start_time << "s";
	}
	else {
		std::cout << "\n\nTiempo de ejecucion total: " << end_time - start_time << "s";;
	}
}

double str_to_double(string str){
	int p_pos = 0;

	for (char s : str){
		if (s == '.')
			break;

		++p_pos;
	}

	double n = 0.;

	--p_pos;
	for (string::size_type i = 0; i < str.size(); ++i, --p_pos) {
		if (str[i] == '.'){
			++p_pos;
			continue;
		}

		int an = str[i] - '0';
		n += an * pow(10, p_pos);
	}

	return n;
}

void PathFinder::Load_adylst(ifstream *file) {
	string line;

	for(vector<City>::size_type i = 0; getline(*file, line); ++i){
		while (cities.size() <= i)
			cities.push_back(City());
		istringstream iss(line);

		while (getline(iss, line, ';')){
			istringstream css(line);

			getline(css, line, ',');
			int city = std::stoi(line);

			while (cities.size() <= city)
				cities.push_back(City());

			getline(css, line, ',');
			double weight = str_to_double(line);

			cities[i].add_connection(pair(city, weight));
			cities[city].add_connection(pair(i, weight));
		}
	}

	file->close();
	delete file;
}

/*
using std::priority_queue;

vector<int> PathFinder::Find_path(int s) {

	int left = cities.size();
	vector<bool> visited(cities.size(), false);
	vector<double> W(cities.size(), -1);
	priority_queue<pair> queue;

	std::cout << cities.size() << std::endl;

	vector<int> path(cities.size(), -1);

	W[s] = 0;

	queue.push(pair(s, 0));

	while (queue.size() > 0) {
		pair p = queue.top();
		queue.pop();

		visited[p.city] = true;
		--left;

		if (p.city == 0 && left == 0)
			break;

		for (pair p_pair : cities[p.city].Get_connections()) {
			double n_weight = p.w + p_pair.w;

			std::cout << "C: " << p_pair.city << " W: " << p_pair.w << " " << p.w << std::endl;

			if (W[p_pair.city] == -1 || n_weight < W[p_pair.city]){
				W[p_pair.city] = n_weight;
				path[p_pair.city] = p.city;
				queue.push(pair(p_pair.city, n_weight));
			}
		}
		std::cout << std::endl;
	}

	return path;
}
*/

vector<path> PathFinder::Find_path(int s) {
	return Big_F_Search(s, vector<path>(0), vector<bool>(cities.size(), false), 0, cities.size(), s, cities.size());
}

vector<path> PathFinder::Big_F_Search(int s, vector<path> p_path, vector<bool> visited, double actual_weight, int cities_left, int start_city, int total_cities) {
	p_path.push_back(path(s, actual_weight));

	if (_kbhit()){
		char key = _getch();

		//if (key == 's' || key == 'S'){
			print_path(p_path);
			int total = total_cities - cities_left + 1;
			if (cities_left == 0)
				total -= 1;
			std::cout << "\n\nTotal de ciudades en el camino: " << total;
			std::cout << std::endl << std::endl;
		//}
	}

	vector<path> temp_path;
	vector<path> temp_path_2(1, path(0,-1));

	if(s != start_city)
		visited[s] = true;

	//std::cout << cities_left << " ";
	if (s == start_city && cities_left == 0){
		return p_path;
	}
	//else if (cities_left != total_cities && s == start_city && cities_left != 0)
	//	return vector<path>(1, path(0, -1.));

	//vector<bool> temp_visited = visited;
	for (pair p : cities[s].Get_connections()){
		//visited = temp_visited;
		if (visited[p.city] == false) {
			if (p.city == start_city && cities_left != 1)
				continue;

			//if(p.city != start_city)

			temp_path = Big_F_Search(p.city, p_path, visited, actual_weight + p.w, cities_left - 1, start_city, total_cities);

			if (temp_path_2[temp_path_2.size() - 1].w == -1 || (temp_path[temp_path.size() - 1].w < temp_path_2[temp_path_2.size() - 1].w)) {
				temp_path_2 = temp_path;
			}
		}
	}

	if (cities_left == total_cities) {
		time(&end_time);
	}

	return temp_path_2;
}

//void UCS(vector<City> cities, int s)

/*

def ucs(G, s, t):
	n = len(G)
	visited = [False]*n
	weights = [math.inf]*n
	path = [-1]*n
	queue = []
	weights[s] = 0
	hq.heappush(queue, (0, s))
	while len(queue) > 0:
		g, u = hq.heappop(queue)
		if visited[u]: continue
		visited[u] = True
		if (u == t): break
		for v, h in G[u]:
			f = g + h
			if f < weights[v]:
				weights[v] = f
				path[v] = u
				hq.heappush(queue, (f, v))

	return path, weights

*/