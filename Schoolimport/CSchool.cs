using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Schoolimport
{
    class CSchool
    {
        public Int64 gsid { get; set; } = 0;
        public Int64 skolenhetskod { get; set; } = 0;
        public Int64 skolkod { get; set; } = 0;
        public Int64 skolid { get; set; } = 0;
        public Int64 x { get; set; } = 0;
        public Int64 y { get; set; } = 0;
        public Int64 svan_x { get; set; } = 0;
        public Int64 svan_y { get; set; } = 0;
        public int year { get; set; } = 0;
        public List<string> skolnamnsLista { get; set; }
        public bool lagstadie { get; set; }
        public bool mellanStadie { get; set; }
        public bool hogstadie { get; set; }
        public int lagstadieElever { get; set; } = 0;
        public int mellanStadieElever { get; set; } = 0;
        public int hogstadieElever { get; set; } = 0;
        public string geomMethod { get; set; }

        public CSchool() 
        {
            this.skolnamnsLista = new List<string>();
        }

        public static void fillSvanstromList(ref Dictionary<Int64, CSchool> aSchoolDic, string pathToInputfile)
        {
            var fileStream = new FileStream(pathToInputfile, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            int gsid_Col = -1;
            int skolenhetskod_Col = -1;
            int year_Col = -1;
            int skolkod_Col = -1;
            int skolid_Col = -1;
            int skolnamn_Col = -1;
            int lag_Col = -1;
            int mellan_Col = -1;
            int hog_Col = -1;
            int ant_1_3_Col = -1;
            int ant_4_6_Col = -1;
            int ant_7_9_Col = -1;
            int geom_year_Col = -1;

            int X_Col = -1;
            int Y_Col = -1;
            // Read first line of 
            string headline = streamReader.ReadLine();
            string[] headlineArray = headline.Split(';');
            Console.WriteLine();
            for (int i = 0; i < headlineArray.Length; i++)
            {

                if (headlineArray[i] == "gsid")
                {
                    gsid_Col = i;
                    Console.WriteLine("gsid Kolumn: " + i);
                }
                if (headlineArray[i] == "skolenhetskod")
                {
                    skolenhetskod_Col = i;
                    Console.WriteLine("skolenhetskod Kolumn: " + i);
                }
                if (headlineArray[i] == "skolkod")
                {
                    skolkod_Col = i;
                    Console.WriteLine("skolkod Kolumn: " + i);
                }
                if (headlineArray[i] == "skolid")
                {
                    skolid_Col = i;
                    Console.WriteLine("skolid name Kolumn: " + i);
                }
                if (headlineArray[i] == "skolnamn")
                {
                    skolnamn_Col = i;
                    Console.WriteLine("skolnamn Kolumn: " + i);
                }
                if (headlineArray[i] == "year")
                {
                    year_Col = i;
                    Console.WriteLine("year Kolumn: " + i);
                }
                if (headlineArray[i] == "lag")
                {
                    lag_Col = i;
                    Console.WriteLine("lag Kolumn: " + i);
                }
                if (headlineArray[i] == "mellan")
                {
                    mellan_Col = i;
                    Console.WriteLine("mellan name Kolumn: " + i);
                }
                if (headlineArray[i] == "hog")
                {
                    hog_Col = i;
                    Console.WriteLine("hog Kolumn: " + i);
                }
                if (headlineArray[i] == "ant_1_3")
                {
                    ant_1_3_Col = i;
                    Console.WriteLine("ant_1_3 Kolumn: " + i);
                }
                if (headlineArray[i] == "ant_4_6")
                {
                    ant_4_6_Col = i;
                    Console.WriteLine("ant_4_6 name Kolumn: " + i);
                }
                if (headlineArray[i] == "ant_7_9")
                {
                    ant_7_9_Col = i;
                    Console.WriteLine("ant_7_9 Kolumn: " + i);
                }
                if (headlineArray[i] == "geom_year")
                {
                    geom_year_Col = i;
                    Console.WriteLine("geom_year Kolumn: " + i);
                }
                if (headlineArray[i] == "x")
                {
                    X_Col = i;
                    Console.WriteLine(" x Kolumn: " + i);
                }
                if (headlineArray[i] == "y")
                {
                    Y_Col = i;
                    Console.WriteLine("Y Kolumn: " + i);
                }
            }
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] lineArray = line.Split(';');
                CSchool aSchool = new CSchool();

                if (gsid_Col != -1)
                {
                    if (lineArray[gsid_Col].Trim('"') != "") aSchool.gsid = Convert.ToInt64(lineArray[gsid_Col].Trim('"'));
                }
                if (skolenhetskod_Col != -1)
                {
                    if (lineArray[skolenhetskod_Col].Trim('"') != "") aSchool.skolenhetskod = Convert.ToInt64(lineArray[skolenhetskod_Col].Trim('"'));
                }
                if (skolkod_Col != -1)
                {
                    if (lineArray[skolkod_Col].Trim('"') != "") aSchool.skolkod = Convert.ToInt64(lineArray[skolkod_Col].Trim('"'));
                }
                if (skolid_Col != -1)
                {
                    if (lineArray[skolid_Col].Trim('"') != "") aSchool.skolid = Convert.ToInt64(lineArray[skolid_Col].Trim('"'));
                }
                if (X_Col != -1)
                {
                    if (lineArray[X_Col].Trim('"') != "") aSchool.svan_x = Convert.ToInt64(lineArray[X_Col].Trim('"'));
                }
                if (Y_Col != -1)
                {
                    if (lineArray[Y_Col].Trim('"') != "") aSchool.svan_y = Convert.ToInt64(lineArray[Y_Col].Trim('"'));
                }
                if (year_Col != -1)
                {
                    if (lineArray[year_Col].Trim('"') != "") aSchool.year = Convert.ToInt32(lineArray[year_Col].Trim('"'));
                }

                if (skolnamn_Col != -1)
                {
                    if (lineArray[skolnamn_Col].Trim('"') != "") aSchool.skolnamnsLista.Add(lineArray[skolnamn_Col].Trim('"'));
                }
                aSchoolDic[aSchool.skolenhetskod] = aSchool;
            }
        }

        public static void completeSchoolList(ref List<CSchool> aSchoolList, Dictionary<Int64, CSchool> aSvanstromSchoolDic)
        {
            //add skolenhetskod
            Console.WriteLine("Add skolenhetskod");
            foreach (CSchool aSchool in aSchoolList)
            {
                if (aSchool.skolenhetskod != 0)
                {
                    foreach (CSchool loopSchool in aSchoolList)
                    {
                        if (aSchool.gsid == loopSchool.gsid)
                        {
                            loopSchool.skolenhetskod = aSchool.skolenhetskod;
                        }
                    }
                }
            }
            //add skolid
            foreach (CSchool aSchool in aSchoolList)
            {
                if (aSchool.skolid != 0)
                {
                    foreach (CSchool loopSchool in aSchoolList)
                    {
                        if (aSchool.gsid == loopSchool.gsid)
                        {
                            loopSchool.skolid = aSchool.skolid;
                        }
                    }
                }
            }
            //add skolid
            foreach (CSchool aSchool in aSchoolList)
            {
                if (aSchool.skolkod != 0)
                {
                    foreach (CSchool loopSchool in aSchoolList)
                    {
                        if (aSchool.gsid == loopSchool.gsid)
                        {
                            loopSchool.skolkod = aSchool.skolkod;
                        }
                    }
                }
            }
            //add skolnamn
            foreach (CSchool aSchool in aSchoolList)
            {
                foreach (CSchool loopSchool in aSchoolList)
                {
                    if (aSchool.gsid == loopSchool.gsid)
                    {
                        bool inList = false;
                       
                        foreach (var schoolNameFirst in aSchool.skolnamnsLista)
                        {
                            if (schoolNameFirst == loopSchool.skolnamnsLista[0])
                            {
                                inList = true;
                            }
                        }

                        if (!inList)
                        {
                            aSchool.skolnamnsLista.Add(loopSchool.skolnamnsLista[0]);
                        }
                    }
                } 
            }
            //add 
            foreach (CSchool aSchool in aSchoolList)
            {
                if (aSchool.skolenhetskod != 0)
                {
                    if (aSvanstromSchoolDic.ContainsKey(aSchool.skolenhetskod))
                    {
                        aSchool.svan_x = aSvanstromSchoolDic[aSchool.skolenhetskod].svan_x;
                        aSchool.svan_y = aSvanstromSchoolDic[aSchool.skolenhetskod].svan_y;
                        aSchool.x = aSvanstromSchoolDic[aSchool.skolenhetskod].svan_x;
                        aSchool.y = aSvanstromSchoolDic[aSchool.skolenhetskod].svan_y;
                    }
                    // Om det ligger en svanströmskola inom 250m ge skolan svanströmkoord
                }
            }
        }
        public static void writeSchoollistToFile(string path, List<CSchool> aSchoolList)
        {
            if (File.Exists(path)) File.Delete(path);

            //using (StreamWriter sr = File.CreateText(path))
            using (StreamWriter sr = new StreamWriter(File.Open(path, FileMode.CreateNew), Encoding.GetEncoding("utf-8")))
            {
                // header
                sr.WriteLine("gsid;skolenhetskod;skolid;skolkod;lagstadie;lagstadieElever;mellanStadie;mellanStadieElever;hogstadie;hogstadieElever;year;x;y;svan_x;svan_y;skolnamn");
                foreach (CSchool aSchool in aSchoolList)
                {
                    sr.Write(aSchool.gsid.ToString() +";") ;
                    sr.Write(aSchool.skolenhetskod.ToString() + ";");
                    sr.Write(aSchool.skolid.ToString() + ";");
                    sr.Write(aSchool.skolkod.ToString() + ";");
                    sr.Write(aSchool.lagstadie.ToString() + ";");
                    sr.Write(aSchool.lagstadieElever.ToString() + ";");
                    sr.Write(aSchool.mellanStadie.ToString() + ";");
                    sr.Write(aSchool.mellanStadieElever.ToString() + ";");
                    sr.Write(aSchool.hogstadie.ToString() + ";");
                    sr.Write(aSchool.hogstadieElever.ToString() + ";");
                    sr.Write(aSchool.year.ToString() + ";");
                    sr.Write(aSchool.x.ToString() + ";");
                    sr.Write(aSchool.y.ToString() + ";");
                    sr.Write(aSchool.svan_x.ToString() + ";");
                    sr.Write(aSchool.svan_y.ToString() + ";");
                    foreach (string aName in aSchool.skolnamnsLista)
                    {
                        sr.Write(aName + " | ");
                    }
                    sr.Write("\r\n");

                }
            }
        }

        public static void fillSchoolList(ref List<CSchool> aSchoolList, string pathToInputfile)
        {
            var fileStream = new FileStream(pathToInputfile, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            int gsid_Col = -1;
            int skolenhetskod_Col = -1;
            int year_Col = -1;
            int skolkod_Col = -1;
            int skolid_Col = -1;
            int skolnamn_Col = -1;
            int lag_Col = -1;
            int mellan_Col = -1;
            int hog_Col = -1;
            int ant_1_3_Col = -1;
            int ant_4_6_Col = -1;
            int ant_7_9_Col = -1;
            int geom_year_Col = -1;

            int X_Col = -1;
            int Y_Col = -1;
            // Read first line of 
            string headline = streamReader.ReadLine();
            string[] headlineArray = headline.Split(';');
            Console.WriteLine();
            for (int i = 0; i < headlineArray.Length; i++)
            {

                if (headlineArray[i] == "gsid")
                {
                    gsid_Col = i;
                    Console.WriteLine("gsid Kolumn: " + i);
                }
                if (headlineArray[i] == "skolenhetskod")
                {
                    skolenhetskod_Col = i;
                    Console.WriteLine("skolenhetskod Kolumn: " + i);
                }
                if (headlineArray[i] == "skolkod")
                {
                    skolkod_Col = i;
                    Console.WriteLine("skolkod Kolumn: " + i);
                }
                if (headlineArray[i] == "skolid")
                {
                    skolid_Col = i;
                    Console.WriteLine("skolid name Kolumn: " + i);
                }
                if (headlineArray[i] == "skolnamn" || headlineArray[i] == "Skolenhetsnamn")
                {
                    skolnamn_Col = i;
                    Console.WriteLine("skolnamn Kolumn: " + i);
                }
                if (headlineArray[i] == "year")
                {
                    year_Col = i;
                    Console.WriteLine("year Kolumn: " + i);
                }
                if (headlineArray[i] == "lag")
                {
                    lag_Col = i;
                    Console.WriteLine("lag Kolumn: " + i);
                }
                if (headlineArray[i] == "mellan")
                {
                    mellan_Col = i;
                    Console.WriteLine("mellan name Kolumn: " + i);
                }
                if (headlineArray[i] == "hog")
                {
                    hog_Col = i;
                    Console.WriteLine("hog Kolumn: " + i);
                }
                if (headlineArray[i] == "ant_1_3")
                {
                    ant_1_3_Col = i;
                    Console.WriteLine("ant_1_3 Kolumn: " + i);
                }
                if (headlineArray[i] == "ant_4_6")
                {
                    ant_4_6_Col = i;
                    Console.WriteLine("ant_4_6 name Kolumn: " + i);
                }
                if (headlineArray[i] == "ant_7_9")
                {
                    ant_7_9_Col = i;
                    Console.WriteLine("ant_7_9 Kolumn: " + i);
                }
                if (headlineArray[i] == "geom_year")
                {
                    geom_year_Col = i;
                    Console.WriteLine("geom_year Kolumn: " + i);
                }
                if (headlineArray[i] == "x")
                {
                    X_Col = i;
                    Console.WriteLine(" x Kolumn: " + i);
                }
                if (headlineArray[i] == "y")
                {
                    Y_Col = i;
                    Console.WriteLine("Y Kolumn: " + i);
                }
            }
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] lineArray = line.Split(';');
                CSchool aSchool = new CSchool();

                if (lineArray[gsid_Col].Trim('"') != "") aSchool.gsid = Convert.ToInt64(lineArray[gsid_Col].Trim('"'));
                if (lineArray[skolenhetskod_Col].Trim('"') != "") aSchool.skolenhetskod = Convert.ToInt64(lineArray[skolenhetskod_Col].Trim('"'));
                if (lineArray[skolkod_Col].Trim('"') != "") aSchool.skolkod = Convert.ToInt64(lineArray[skolkod_Col].Trim('"'));
                if (lineArray[skolid_Col].Trim('"') != "") aSchool.skolid = Convert.ToInt64(lineArray[skolid_Col].Trim('"'));
                if (lineArray[X_Col].Trim('"') != "") aSchool.x = Convert.ToInt64(lineArray[X_Col].Trim('"'));
                if (lineArray[Y_Col].Trim('"') != "") aSchool.y = Convert.ToInt64(lineArray[Y_Col].Trim('"'));
                if (lineArray[year_Col].Trim('"') != "") aSchool.year = Convert.ToInt32(lineArray[year_Col].Trim('"'));
                if (lineArray[skolnamn_Col].Trim('"') != "") aSchool.skolnamnsLista.Add(lineArray[skolnamn_Col].Trim('"'));
                if (lineArray[lag_Col].Trim('"') != "")
                {
                    if (lineArray[lag_Col].Trim('"') == "L")
                    {
                        aSchool.lagstadie = true;
                    }
                    else
                    {
                        aSchool.lagstadie = false;
                    }
                }
                if (lineArray[mellan_Col].Trim('"') != "")
                    if (lineArray[mellan_Col].Trim('"') == "M")
                    {
                        aSchool.mellanStadie = true;
                    }
                    else
                    {
                        aSchool.mellanStadie = false;
                    }
                if (lineArray[hog_Col].Trim('"') != "")
                    if (lineArray[hog_Col].Trim('"') == "H")
                    {
                        aSchool.hogstadie = true;
                    }
                    else
                    {
                        aSchool.hogstadie = false;
                    }
                if (lineArray[ant_1_3_Col].Trim('"') != "") aSchool.lagstadieElever = Convert.ToInt32(lineArray[ant_1_3_Col].Trim('"'));
                if (lineArray[ant_4_6_Col].Trim('"') != "") aSchool.mellanStadieElever = Convert.ToInt32(lineArray[ant_4_6_Col].Trim('"'));
                if (lineArray[ant_7_9_Col].Trim('"') != "") aSchool.hogstadieElever = Convert.ToInt32(lineArray[ant_7_9_Col].Trim('"'));
                if (lineArray[geom_year_Col].Trim('"') != "") aSchool.geomMethod = lineArray[geom_year_Col].Trim('"');
                aSchoolList.Add(aSchool);
            }
        }
    }
}
