#include "City.h"

#include <math.h>

double Get_distance(City a, City b){
    double diff_x = a.x - b.x;
    double diff_y = a.y - b.y;

    return sqrt(pow(diff_x,2) + pow(diff_y,2));
}

City::City(int c, string n, double x, double y, double d): name(n), code(c), x(x), y(y), d(d){
    connected_distances.resize(4, -1.);
    connected_cities.resize(4);
}

void City::Connect_with_city(City c){
    vector<int>::iterator a = connected_cities.begin();

    for(double &d : connected_distances){
        if(d == -1.){
            d = Get_distance(*this, c);
            *a = c.Get_code();
            break;
        }

        ++a;
    }
}
