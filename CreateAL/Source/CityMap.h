#ifndef CITYMAP_H
#define CITYMAP_H

#include <string>
#include <vector>
#include <fstream>

#include "City.h"

using std::string;
using std::vector;
using std::ifstream;
using std::ofstream;

//Creamos la clase CityMap, que contendrá un arreglo de objetos City.
class CityMap{
    vector<City> map_cities;
    int number_cities = 0;
public:
    CityMap();

    void Connect_cities_by_distance_orig();

    void Sort_cities_by_orig();

    void Load_from_csv(string filename);
    void Load_from_csv(ifstream *file);
    void Export_as_adylst(string filename, string filename2);
};

double Get_distance_orig(double x, double y);

void merge(vector<City> &vec, int l, int m, int r);
void merge_sort(vector<City> &vec, int l, int r);

#endif // CITYMAP_H
