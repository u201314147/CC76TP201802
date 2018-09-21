#include "CityMap.h"

#include <sstream>
#include <iostream>
#include <iomanip>
#include <math.h>

using std::getline;
using std::istringstream;
using std::ostringstream;

CityMap::CityMap(){}

double Get_distance_orig(double x, double y){
    return sqrt(pow(x,2) + pow(y,2));
}

void merge(vector<City> &vec, int l, int m, int r){
    vector<City> L(m-l+1);
    vector<City> R(r-m);

    typedef vector<City>::size_type siztyp;

    for(siztyp i = 0; i < L.size(); ++i){
        L[i] = vec[l+i];
    }

    for(siztyp i = 0; i < R.size(); ++i){
        R[i] = vec[m+i+1];
    }

    siztyp i = 0;
    siztyp j = 0;
    siztyp k = l;

    for(; i < L.size() && j < R.size(); ++k){
        if(L[i].Get_d() <= R[j].Get_d()){
            vec[k] = L[i];
            ++i;
        }
        else{
            vec[k] = R[j];
            ++j;
        }
    }

    while (i < L.size()){
        vec[k] = L[i];
        i++;
        k++;
    }


    while (j < R.size()){
        vec[k] = R[j];
        j++;
        k++;
    }
}

void merge_sort(vector<City> &vec, int l, int r){
    if(l < r){
        int m = (l+r-1)/2;
        merge_sort(vec, l, m);
        merge_sort(vec, m+1, r);

        merge(vec, l, m, r);
    }
}

void CityMap::Sort_cities_by_orig(){
    merge_sort(map_cities, 0, number_cities - 1);
}

void CityMap::Connect_cities_by_distance_orig(){
    Sort_cities_by_orig();

    int c = 0;

    for(vector<City>::size_type i = 0; i < (number_cities - 4); ++i, ++c){
        for(int j = 1; j <= 4; ++j)
            map_cities[i].Connect_with_city(map_cities[i+j], i+j);

        if(c % (number_cities/20) == 0){
            int processes = static_cast<double>(c)/number_cities*100;
            std::cout << std::setprecision(2);
            std::cout << "Procesado el: " << processes << "% de ciudades." << '\n';
        }
    }

    for(vector<City>::size_type i = number_cities - 1; i >= (number_cities - 4); --i){
        for(int j = 1; j <= 4; ++j)
            map_cities[i].Connect_with_city(map_cities[i-j], i-j);
    }

    std::cout << "Procesado el: 100% de ciudades." << '\n';
}

void CityMap::Load_from_csv(string filename){
    ifstream *file = new ifstream;
    file->imbue(std::locale());
    file->open(filename);

    Load_from_csv(file);
}

void CityMap::Load_from_csv(ifstream *file){
    string line;

    getline(*file, line);
    while(getline(*file, line)){
        istringstream iss(line);

        for(int i = 0; i < 4; ++i)
            getline(iss, line, ',');

        getline(iss, line, ',');
        string code = line;

        getline(iss,line,',');
        string name = line;

        getline(iss,line,',');
        if(toupper(line[0]) != toupper(name[0])){
            name += line;
            getline(iss,line,',');
        }

        for(int i = 0; i < 8; ++i)
            getline(iss,line,',');

        getline(iss,line,',');
        double x = std::stod(line);

        getline(iss,line,',');
        double y = std::stod(line);

        ++number_cities;
        map_cities.push_back(City(std::stoi(code), name, x, y, Get_distance_orig(x,y)));
    }

    file->close();
    delete file;
}

void CityMap::Export_as_adylst(string filename, string filename2 = ""){
    ofstream file2(filename2);
    ostringstream data2;

    ofstream file(filename);

    ostringstream data;

    data << std::setprecision(15);
    data2 << std::setprecision(15);

    for(City c : map_cities){
        vector<int> c_list = c.Get_connected_cities();
        vector<double> d_list = c.Get_connected_distances();

        for(int i = 0; i < 4; ++i){
            data << c_list[i] << ',' << d_list[i];
            if(i != 3)
                data << ';';
        }

        data << '\n';

        if(filename2 != ""){
            data2 << c.Get_code() << ';';
            data2 << c.Get_name() << ';';
            data2 << c.Get_x() << ';';
            data2 << c.Get_y();
            data2 << '\n';
        }
    }

    if(filename2 != ""){
        file2 << data2.str();
    }

    file << data.str();
    file.close();
    file2.close();
}
