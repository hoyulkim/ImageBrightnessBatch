using Emgu.CV;
using Emgu.CV.Legacy;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImageBrightnessBatch
{
    public partial class Form1 : Form
    {
        private readonly string configPath = "config.json";
        private Settings settings = new Settings();

        public Form1()
        {
            InitializeComponent();
            cmbFormat.SelectedIndex = 0; // Default: jpg
            LoadSettings();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                    settings.SourceFolder = fbd.SelectedPath;
                    SaveSettings();
                }
            }
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTarget.Text = fbd.SelectedPath;
                    settings.TargetFolder = fbd.SelectedPath;
                    SaveSettings();
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text;
            string target = txtTarget.Text;
            string format = cmbFormat.SelectedItem?.ToString() ?? "jpg";
            double start = (double)numStart.Value;
            double end = (double)numEnd.Value;
            double step = (double)numStep.Value;

            // Validation
            if (!Directory.Exists(source) || !Directory.Exists(target))
            {
                MessageBox.Show("폴더를 모두 선택하세요.");
                return;
            }

            // Save current settings
            settings.SourceFolder = source;
            settings.TargetFolder = target;
            settings.SaveFormat = format;
            settings.Start = start;
            settings.End = end;
            settings.Step = step;
            SaveSettings();

            string[] files = Directory.GetFiles(source, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase)).ToArray();

            int total = files.Length * (int)Math.Ceiling((end - start) / step + 1);
            int count = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = total > 0 ? total : 1;
            foreach (var file in files)
            {
                // 이미지 불러오기
                using (var img = new Image<Gray, byte>(file))
                {
                    for (double mul = start; mul <= end + 0.0001; mul += step)
                    {
                        string mulStr = mul.ToString("0.0");

                        // 원본 미리보기 (첫 변환시만)
                        if (mul == start)
                            pictureBoxOriginal.Image = img.ToBitmap();

                        // 밝기 변경
                        var changed = img.Mul(mul);

                        // 변경 미리보기
                        pictureBoxChanged.Image = changed.ToBitmap();
                        pictureBoxChanged.Refresh();

                        // 파일 저장
                        string name = Path.GetFileNameWithoutExtension(file);
                        string saveName = $"{name}_{mulStr}.{format}";
                        string savePath = Path.Combine(target, saveName);
                        changed.Save(savePath);

                        // 가비지콜렉션
                        changed.Dispose();
                        

                        count++;
                        progressBar1.Value = Math.Min(count, progressBar1.Maximum);
                        Application.DoEvents(); // UI 응답성
                    }
                }
                GC.Collect();
            }
            MessageBox.Show("작업 완료!");
        }

        private void SaveSettings()
        {
            // 각 컨트롤의 현재 값을 읽어서 settings에 저장
            settings.SourceFolder = txtSource.Text;
            settings.TargetFolder = txtTarget.Text;
            settings.SaveFormat = cmbFormat.SelectedItem?.ToString() ?? "jpg";
            settings.Start = (double)numStart.Value;
            settings.End = (double)numEnd.Value;
            settings.Step = (double)numStep.Value;

            File.WriteAllText(configPath, Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented));
        }

        private void LoadSettings()
        {
            if (File.Exists(configPath))
            {
                try
                {
                    settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(configPath));
                    txtSource.Text = settings.SourceFolder ?? "";
                    txtTarget.Text = settings.TargetFolder ?? "";
                    cmbFormat.SelectedItem = settings.SaveFormat ?? "jpg";

                    numStart.Value = (decimal)(settings.Start == 0 ? 1.0 : settings.Start);

                    numEnd.Value = (decimal)(settings.End == 0 ? 4.0 : settings.End);

                    numStep.Value = (decimal)(settings.Step == 0 ? 1.0 : settings.Step);
                }
                catch { /* Ignore errors, use default values */ }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void numStart_ValueChanged(object sender, EventArgs e)
        {
            //SaveSettings();
        }

        private void numEnd_ValueChanged(object sender, EventArgs e)
        {
            //SaveSettings();
        }

        private void numStep_ValueChanged(object sender, EventArgs e)
        {
            //SaveSettings();
        }
    }

    public class Settings
    {
        public string SourceFolder { get; set; }
        public string TargetFolder { get; set; }
        public string SaveFormat { get; set; }
        public double Start { get; set; }
        public double End { get; set; }
        public double Step { get; set; }
    }
}
