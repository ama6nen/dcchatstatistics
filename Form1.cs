using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chtparse
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent( );
        }

       
        struct asd
        {
            int asd2;
            string memes;

        }
        private void main_Load( object sender , EventArgs e )
        {
            asd gamer = null;

            string path = "src.txt";

            Dictionary<string , ulong> messages = new Dictionary<string , ulong>( );
            Dictionary<string , ulong> words = new Dictionary<string , ulong>( );

            var lines = File.ReadAllLines( path );

            string last = "";
            foreach(var line in lines)
            {
                if(line.StartsWith("[") && line.Contains("]") && line.Contains( "#" ) && last == "")
                {
                   var name =  line.Substring( line.IndexOf( "]" ) + 1 );
                    name = name.Substring( 0 , name.Length - 5 );

                    bool exists = messages.TryGetValue( name , out ulong times );

                    if (exists)
                        messages[ name ] = times + 1;
                    else
                        messages.Add( name , 1 );
                }
                else if (last.StartsWith( "[" ) && last.Contains( "]" ) && last.Contains( "#" ))
                {
                    var w = line.Split( ' ' );

                    foreach(var word in w)
                    {
                        bool exists = words.TryGetValue( word , out ulong times );

                        if (exists)
                            words[ word ] = times + 1;
                        else
                            words.Add( word , 1 );
                    }
                }

                last = line;
            }
            var sortedmsgs = from entry in messages orderby entry.Value descending select entry;

            ulong fulltotal = 0;
            foreach (var pair in sortedmsgs)
            {
                fulltotal += pair.Value;
                richTextBox1.Text += pair.Key + " : " + pair.Value.ToString( ) + Environment.NewLine;
            }

            int cnt = 0;
            ulong totals = 0;
            foreach (var pair in sortedmsgs)
            {
                
                if(cnt >= (sortedmsgs.Count() / 5))
                {
                    break;
                }
                totals += pair.Value;
                cnt++;

            }
            double a = ((double)totals / fulltotal) * 100d;

            richTextBox1.Text = "20% of users make up " + a.ToString( ) + "% of msgs" + Environment.NewLine + richTextBox1.Text;

           int a5 = null;

            var sorted = from entry in words orderby entry.Value descending select entry ;


            ulong total = 0;
            foreach (var pair in sorted)
            {
                total += pair.Value;

                if (pair.Value < 200)
                    continue;

               
               
                richTextBox2.Text += pair.Key + " : " + pair.Value.ToString( ) + Environment.NewLine;
            }
            richTextBox2.Text = "total: " + total.ToString( ) + Environment.NewLine + richTextBox2.Text;

            double frequency_sum = 0;
            foreach (var pair in sorted)
            {


                if (pair.Value < 200)
                    continue;

                double frequency = ((double)pair.Value / total) * 100d;
                frequency_sum += frequency;

              

                richTextBox3.Text += pair.Key + " : " + Math.Round(frequency,3) .ToString( ) + "%" + Environment.NewLine;
            }

            ulong counter = 0;
            double frequency_20 = 0;
            foreach (var pair in sorted)
            {
              
                counter++;
                if (pair.Value < 200)
                    continue;

                if (counter >= (ulong)(sorted.Count( ) / 5))
                    break;
                double frequency = ((double)pair.Value / total) * 100d;
                frequency_20 += frequency;

            }

            richTextBox3.Text = "20% of items make up " + frequency_20.ToString() + "% of usage " + Environment.NewLine + "total %: " + frequency_sum.ToString( ) + Environment.NewLine + richTextBox3.Text;

            words.Clear( );
            sorted = null;
            messages.Clear( );
        }
    }
}
