
#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

using std::cin;
using std::cout;
using std::getline;
using std::string;

int main(int argc, char *argv[]){
    setlocale(LC_ALL, "es_ES");

    std::ifstream arch;
    arch.imbue(std::locale());
    arch.open(argv[1]);
    
    std::ostringstream oss;

    std::string line;
    while(getline(arch, line)){
        std::istringstream ss(line);

        for(int i = 0; i < 5; ++i)
        getline(ss,line,',');
        string code = line;

        getline(ss,line,',');
        string name = line;

        for(int i = 0; i < 10; ++i)
            getline(ss,line,',');
        string x = line;

        getline(ss,line,',');
        string y = line;
        
        oss << code << ',' << name << ',' << x << ',' << y << std::endl;
    }

    arch.close();
    std::ofstream file("data.csv");

    file << oss.str();
    file.close();

    return 0;
}