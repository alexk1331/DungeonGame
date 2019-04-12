using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace DungeonGame
{
    [DataContract]
    class ProgramSett
    {
        [DataMember]
        public int res_height;
        [DataMember]
        public int res_width;
        [DataMember]
        public bool fullscreen;
        [DataMember]
        public string lang;
        

        public ProgramSett()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ProgramSett));
            string path = Directory.GetCurrentDirectory() + @"\settings.json";     
            if(File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            ProgramSett ps = (ProgramSett)jsonFormatter.ReadObject(fs);
                            this.res_height = ps.res_height;
                            this.res_width = ps.res_width;
                            this.lang = ps.lang;
                            this.fullscreen = ps.fullscreen;
                        }
                    }
            else
                {
                    this.res_height = 720;
                    this.res_width = 1280;
                    this.lang = "english";
                    this.fullscreen = false;
                }
        }



        public void setsettings(string wh, string l, bool f)
        {
            string temp = "";
            for(int i=0;i<wh.Length;i++)
            {
                if(wh[i]=='x')
                {
                    this.res_width = Int32.Parse(temp);
                    temp = "";
                    i++;
                }
                temp = temp + wh[i];
            }
            this.res_height = Int32.Parse(temp);
            this.fullscreen = f;
            this.lang = l;
            savesettings();
        }

        private void savesettings()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ProgramSett));
            using (FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, this);
            }
        }

        public Dictionary<string, string> returndict(string name)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
            string path = Directory.GetCurrentDirectory() + @"\languages\"+Properties.Settings.Default.Language+@"\"+name+".json";
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    temp = (Dictionary<string, string>)jsonFormatter.ReadObject(fs);
                }
            }
            return temp;
        }

       
    }
}
