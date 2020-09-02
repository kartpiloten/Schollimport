using System;
using System.Collections.Generic;
using System.Diagnostics;


//GITHUB MAP https://github.com/kartpiloten/Schollimport
namespace Schoolimport
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            List<CSchool> aSchoolList = new List<CSchool>();
            CSchool.fillSchoolList(ref aSchoolList, @"D:\Source\Schollimport\data\alla_skolor_RapidGeo2.csv");
            Dictionary<Int64,CSchool> aSvanstromSchoolDic = new Dictionary<Int64, CSchool>();
            CSchool.fillSvanstromList(ref aSvanstromSchoolDic, @"D:\Source\Schollimport\data\Svanstromfil_med_koord.csv");
            //CSchool.fillSchoolList(ref aSchoolList, @"D:\Source\Schollimport\data\alla_skolor_RapidGeo_2000First.csv");
            sw.Start();
            CSchool.completeSchoolList(ref aSchoolList,aSvanstromSchoolDic);
            sw.Stop();
            Console.WriteLine("It took {0} to run app", sw.Elapsed);

            CSchool.writeSchoollistToFile(@"D:\Source\Schollimport\data\outputFile.txt", aSchoolList);


            Console.WriteLine("Done");
        }
    }
}
