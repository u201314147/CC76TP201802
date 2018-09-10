#ifndef CITY_H
#define CITY_H

#include <string>
#include <vector>

using std::string;
using std::vector;

//Creamos la clase City, que contendrá los datos de cada ciudad de la base de datos.
class City{
    friend double Get_distance(City a, City b);

    int code = 0;
    string name;
    double x = 0.;
    double y = 0.;
    double d = 0.;

    vector<int> connected_cities;
    vector<double> connected_distances;
public:
    City(int c, string n, double x, double y, double d);

    void Connect_with_city(City c);

    int Get_code(){ return code; }
    string Get_name(){ return name; }
    double Get_x(){ return x; }
    double Get_y(){ return y; }
    double Get_d(){ return d; }
    vector<int> Get_connected_cities(){ return connected_cities; }
    vector<double> Get_connected_distances(){ return connected_distances; }
};

#endif // CITY_H
