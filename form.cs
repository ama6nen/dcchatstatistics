using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chtparse
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ParetoContent.Text = "";
            SearchResult.Text = "";
            AnalyzeButton.Enabled = false;
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
                FileToAnalyze.Text = FileDialog.FileName;
        }

        private void FileToAnalyze_DragEnter(object sender, DragEventArgs e)
        { //set mouse icon on file drag enter
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void FileToAnalyze_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length < 1)
                return;
            FileToAnalyze.Text = files[0]; //only take one file
        }

        Dictionary<string, ulong> Messages = new Dictionary<string, ulong>();
        Dictionary<string, ulong> Words = new Dictionary<string, ulong>();

        private void LoadContent(string filename)
        {
            var lines = File.ReadAllLines(filename);

            string last = "";
            var lineTotal = lines.Length;

            for (int i = 0; i < lineTotal; i++)
            {
                if (i % 1500 == 0) //delegate invoking for every item, ghetto
                {
                    AnalysisBar.Invoke((MethodInvoker)delegate
                    {
                        AnalysisBar.Value = (int)((float)(i) / lineTotal * 31.25f); // 5/16
                    });
                }

                var line = lines[i];
                if (line == "") //skip empty lines for performance
                {
                    last = "";
                    continue;
                }
                if (line.StartsWith("[") && line.Contains("]") && line.Contains("#") && last == "")
                { //line contains someones name, aka a message from them
                    var name = line.Substring(line.IndexOf("]") + 1);
                    name = name.Substring(1, name.Length - 1);

                    bool exists = Messages.TryGetValue(name, out ulong times);

                    if (exists)
                        Messages[name] = ++times; //increment the mesage count of the user
                    else
                        Messages.Add(name, 1); //add dict item 1 st time for this user
                }
                else if (last.StartsWith("[") && last.Contains("]") && last.Contains("#"))
                { //last line contains someones name, therefore this one has the message

                    if (IgnoreLinks.Checked && line.Contains("://"))   //this contains a link (possibly), so we are removing last message counter
                    {
                        var name = last.Substring(last.IndexOf("]") + 1);
                        name = name.Substring(0, name.Length - 5);
                        bool exists = Messages.TryGetValue(name, out ulong times);

                        if (exists)
                            Messages[name] = --times;
                        last = line;
                        continue;
                    }
                    var w = line.Split(' ');

                    foreach (var word in w)
                    {
                        bool exists = Words.TryGetValue(word, out ulong times);

                        if (exists)
                            Words[word] = ++times; //increment word counter
                        else
                            Words.Add(word, 1); //unique word, for now at least
                    }
                }

                last = line;
            }
        }

        private void AnalyzeUsers()
        {
            var SortedMessages = from entry in Messages orderby entry.Value descending select entry;
            ulong TotalMessageCount = 0;
            foreach (var pair in SortedMessages)
                TotalMessageCount += pair.Value;

            foreach (var pair in SortedMessages)
            {

                double frequency = ((double)pair.Value / TotalMessageCount) * 100d;
                string percentage = Math.Round(frequency, 2).ToString() + "%";
                UsersBox.Text += $"{pair.Key}   {pair.Value} ({percentage})\n";

            }
            UsersBox.Text = "total messages sent    " + TotalMessageCount + Environment.NewLine + UsersBox.Text;
            AnalysisBar.Invoke((MethodInvoker)delegate
            {
                AnalysisBar.Value = 38; //6/16
            });

            int counter = 0;
            ulong Top20UserCount = 0;
            foreach (var pair in SortedMessages)
            {
                //since we are sorting in descending order, just checking if our user counter is bigger than 20%, will give us how many messages top 20 people wrote
                if (counter >= (SortedMessages.Count() / 5))
                    break;

                Top20UserCount += pair.Value;
                counter++;
            }
            AnalysisBar.Invoke((MethodInvoker)delegate
            {
                AnalysisBar.Value = 44; //7/16
                ParetoContent.Text += $"20% of users make up {Math.Round(((double)Top20UserCount / TotalMessageCount * 100.0), 2)}% of msgs { Environment.NewLine}";
            });

        }

        ulong TotalWordsCount = 0;
        private void AnalyzeWords()
        {
            var WordsSorted = from entry in Words orderby entry.Value descending select entry;
            ulong TotalWordsThreshold = 0;
            TotalWordsCount = 0;
            bool brake = false;
            foreach (var pair in WordsSorted)
            {
                TotalWordsCount += pair.Value;
                if (brake)
                    continue;
                if (pair.Value < (ulong)SkipThreshold.Value)
                    brake = true;
                TotalWordsThreshold++;
            }

            int count = WordsSorted.Count();
            double WordFrequency = 0.0;
            ulong counter = 0;
            ulong TotalWordsSent = 0;
            foreach (var pair in WordsSorted)
            {
                if (counter > TotalWordsThreshold)
                    break;

                if (counter % 50 == 0)
                {
                    AnalysisBar.Invoke((MethodInvoker)delegate
                    {
                        float fraction = (float)counter / TotalWordsThreshold * 56.25f;
                        AnalysisBar.Value = 44 + (int)fraction; //totals to 100%
                    });
                }
                counter++;
                TotalWordsSent += pair.Value;
                double frequency = ((double)pair.Value / TotalWordsCount) * 100d;
                string percentage = Math.Round(frequency, 2).ToString() + "%";
                WordsBox.Text += $"{pair.Key}   {pair.Value} ({percentage}){Environment.NewLine}";
                if (counter < (ulong)(count / 5))
                    WordFrequency += frequency;
            }
            WordsBox.Text = "total words sent   " + TotalWordsSent.ToString() + Environment.NewLine + WordsBox.Text;

            AnalysisBar.Invoke((MethodInvoker)delegate
            {
                AnalysisBar.Value = 100;
                ParetoContent.Text += $"20% of words make up {Math.Round(WordFrequency, 2)}% of usage {Environment.NewLine}";
            });
        }

        //invoking due to multithreading
        private void BeginAnalyze()
        {
            AnalysisBar.Invoke((MethodInvoker)delegate
            {
                AnalysisBar.Visible = true;
                AnalysisBar.Value = 0;
                UsersBox.Text = "";
                WordsBox.Text = "";
                ParetoContent.Text = "";
                IgnoreLinks.Visible = false;
                Words.Clear();
                Messages.Clear();
                SkipThresholdLabel.Visible = false;
                SkipThreshold.Visible = false;
                AnalyzeButton.Enabled = false;
            });
        }
        private void EndAnalyze()
        {
            MessageBox.Show("Analysis complete!", "DC Chat Statistics Analyzer");
            AnalysisBar.Visible = false;
            IgnoreLinks.Visible = true;
            SkipThresholdLabel.Visible = true;
            SkipThreshold.Visible = true;
            AnalyzeButton.Enabled = true;
        }
        private void AnalyzeFile(string fileName)
        {
            BeginAnalyze();
            if (File.Exists(fileName))
            {
                LoadContent(fileName);
                AnalyzeUsers();
                AnalyzeWords();
            }
            EndAnalyze();
        }
        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() => AnalyzeFile(FileToAnalyze.Text));
            thread.Start();
        }

        private void FileToAnalyze_TextChanged(object sender, EventArgs e)
        => AnalyzeButton.Enabled = File.Exists(FileToAnalyze.Text);

        private void SearchWordButton_Click(object sender, EventArgs e)
        {
            if (!Words.ContainsKey(SearchWord.Text))
                SearchResult.Text = "Could not find word.";
            else if (TotalWordsCount > 0)
            {
                ulong times = Words[SearchWord.Text];
                double frequency = ((double)times / TotalWordsCount) * 100d;
                string percentage = Math.Round(frequency, 2).ToString() + "%";
                SearchResult.Text = $"{times} ({percentage})";
            }
        }
    }
}
