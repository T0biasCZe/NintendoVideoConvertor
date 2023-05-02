using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using Microsoft.VisualBasic;
using System.Media;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        private System.Threading.Timer _timer;
        RadioButton DS_VF;
        RadioButton DS_3Dformat;
        RadioButton DS_OutputCodec;
        RadioButton filtr;
        RadioButton DS_Wii;
        RadioButton Wii_TV;
        RadioButton Wii_framerate;
        RadioButton Wii_codec;
        RadioButton stretch;
        RadioButton Wii_Aspect;
        SoundPlayer chordsound = new SoundPlayer();
        SoundPlayer exclamationsound = new SoundPlayer();
        SoundPlayer tadasound = new SoundPlayer();
        SoundPlayer logonsound = new SoundPlayer();
        SoundPlayer commandsound = new SoundPlayer();
        Process ffmpeg = new Process();
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        string verze = "dev v2.1.0";
        string vstup;
        string vstup2;
        string cesta;
        string outputnazev;
        string subtitles;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        public Form1() {
            InitializeComponent();
            /*using(Graphics graphics = this.CreateGraphics()) {
                float dpiX = graphics.DpiX;
                float dpiY = graphics.DpiY;
                this.AutoScaleDimensions = new SizeF(dpiX / 96, dpiY / 96);
            };
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;*/
            //SetProcessDPIAware();
            version.Text = verze;
            if(File.Exists(@"C:\Windows\Media\Windows Logon Sound.wav")) {
                logonsound.SoundLocation = @"C:\Windows\Media\Windows Logon Sound.wav";
            }
            else {
                logonsound.SoundLocation = ".\\dummy.wav";
            }
            if(File.Exists(@"C:\Windows\Media\Windows Menu Command.wav")) {
                commandsound.SoundLocation = @"C:\Windows\Media\Windows Menu Command.wav";
            }
            else {
                logonsound.SoundLocation = ".\\dummy.wav";
            }
            if(File.Exists(@"C:\Windows\Media\chord.wav")) {
                chordsound.SoundLocation = @"C:\Windows\Media\chord.wav";
            }
            else {
                logonsound.SoundLocation = ".\\dummy.wav";
            }
            if(File.Exists(@"C:\Windows\Media\Windows Exclamation.wav")) {
                exclamationsound.SoundLocation = @"C:\Windows\Media\Windows Exclamation.wav";
            }
            else {
                logonsound.SoundLocation = ".\\dummy.wav";
            }
            if(File.Exists(@"C:\Windows\Media\tada.wav")) {
                tadasound.SoundLocation = @"C:\Windows\Media\tada.wav";
            }
            else {
                logonsound.SoundLocation = ".\\dummy.wav";
            }
            logonsound.Play();
            textBox2.SetWatermark("custom bitrate (in Kb/s)");
            suboffset.SetWatermark("subtitles offset in seconds");
            cusresx.SetWatermark("Custom resolution width");
            cusresy.SetWatermark("Custom resolution height");
            custom_sar.SetWatermark("Custom SAR (wii only)");
        }
        public static void ScaleResolution(int sourceWidth, int sourceHeight, int targetWidth, int targetHeight, out int scaledWidth, out int scaledHeight, float percent, out int actualpercent) {
            //get source aspect
            double scaleX = (double)targetWidth / sourceWidth;
            double scaleY = (double)targetHeight / sourceHeight;
            //get whichever aspect is smaller
            double scale = Math.Min(scaleX, scaleY);
            //get variable for temp scale of Y, in case the resolution wants to get scalled vertically with the percent
            double skaledy;
            //get the new vertical resolution
            double scaledY = sourceHeight * scale;
        woomy:;
            //if percent is larger than 0, then scale the resolution vertically. if its larger than the maximum y, then it decreases the percent and tries again until it fits
            if(percent > 0) {
                skaledy = scaledY + (scaledY / 100 * percent);
                percent -= (float)0.1;
                if(skaledy > targetHeight) goto woomy;
                actualpercent = (int)percent;
            }
            //if percent is 0, use the normal scale
            else {
                skaledy = scaledY;
                actualpercent = 0;
            }
            scaledY = skaledy;
            scaledWidth = (int)Math.Round(sourceWidth * scale);
            scaledHeight = (int)Math.Round(scaledY);
            if(scaledWidth % 2 == 1) {
                scaledWidth++;
                if(scaledWidth > targetWidth) {
                    scaledWidth -= 2;
                }
            }
            if(scaledHeight % 2 == 1) {
                scaledHeight++;
                if(scaledHeight > targetHeight) {
                    scaledHeight -= 2;
                }
            }
        }
        private void message_error(string zprava, int miliseconds) {
            chordsound.Play();
            MessageBox.Show(zprava, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int message_prompt(string zprava) {
            exclamationsound.Play();
            DialogResult dialogResult = MessageBox.Show(zprava, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        woomy:
            if(dialogResult == DialogResult.Yes) {
                return 1;
            }
            else if(dialogResult == DialogResult.No) {
                return 0;
            }
            else {
                exclamationsound.Play();
                dialogResult = MessageBox.Show(zprava, "ANSWER!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                goto woomy;
            }
        }
        private int message_prompt2(string zprava) {
            exclamationsound.Play();
            DialogResult dialogResult = MessageBox.Show(zprava, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        woomy:
            if(dialogResult == DialogResult.OK) {
                return 1;
            }
            else if(dialogResult == DialogResult.Cancel) {
                return 0;
            }
            else {
                exclamationsound.Play();
                dialogResult = MessageBox.Show(zprava, "ANSWER!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                goto woomy;
            }
        }
        private async void woomy(object sender, EventArgs e) { //tohle se vola při kliknuti tlačika
            await convert(0);
        }
        private async Task convert(UInt16 fromfolder) { //tohle se vola z woomy nebo z funkce která konvertuje složku
            if(vstup == null) {
                message_error("Error: You didnt choose input video!", 0);
                goto skipaa;
            }
            string custom_sar_str = "";
            if(custom_sar != null && custom_sar.Text != "") {
                double customsarnum;
                if(double.TryParse(custom_sar.Text, out customsarnum)) {
                    custom_sar_str = ",setsar=" + custom_sar.Text;
                }
                else {
                    message_error("Error: Custom SAR is not a number!", 0);
                }
            }
            string subtitlepath = cesta + "\\" + Path.GetFileNameWithoutExtension(vstup);
            string subtitleinput = "";
            string subtitlemapall = "";
            string subtitlemapsub = "";
            string subtitlemaps0 = "";
            string subtitlemaps1 = "";
            string subtitlemaps2 = "";
            if(File.Exists(subtitlepath + ".srt")) {
                string subtimingoffset;
                if(suboffset.Text == "") subtimingoffset = "0";
                else subtimingoffset = suboffset.Text;
                //subtitles = " -itsoffset " + suboffset.Text + " -i \"" + subtitlepath + "\" -c:s copy -map 1:s -map 0:v -map 0:a";
                //listBox3.Items.Add(subtitlepath);
                subtitleinput = " -itsoffset " + subtimingoffset + " -i \"" + subtitlepath + ".srt \"";
                subtitlemapall = " -map 0:a:0? -map 0:v:0? ";
                subtitlemaps0 = " -map 0:s:0? ";
                subtitlemaps1 = " -map 1:s:0? ";
                subtitlemaps2 = " -map 2:s:0? ";
            }
            else {
                subtitleinput = "";
                subtitlemapall = "";
                subtitlemapsub = "";
                subtitlemaps0 = "";
                subtitlemaps1 = "";
                subtitlemaps2 = "";
                if(subtitle_notfound_error.Checked) message_error("Subtitle file not found!", 500);
            }
            if(embeddedsubs.Checked == true) {
                subtitlemapall = " -map 0:a:0? -map 0:v:0? ";
                subtitlemaps0 = " -map 0:s:0? ";
            }
            Enabled = false;
            if(true) {
                DS_Wii = this.panel_ds_or_wii.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();

                DS_VF = this.panel_ds_vf.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
                DS_3Dformat = this.panel_ds_leftright.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
                DS_OutputCodec = this.panel_ds_outcodec.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();

                Wii_TV = this.panel_wii_tv_out.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
                Wii_Aspect = this.panel_wii_aspect.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
                Wii_framerate = this.panel_wii_fps.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
                Wii_codec = this.wii_output_codec.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();


                filtr = this.panel_scalefilter.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
                stretch = this.panel_stretch.Controls.OfType<RadioButton>().Where(x => x.Checked).FirstOrDefault();
            }
            var clip = player.newMedia(vstup);
            player.currentMedia = clip;
            UInt16 duration = 0;
            player.controls.play();
            UInt16 bitrate;
            UInt32 max_bitrate = 0;

            for(uint i = 0; i < 50; i++) {
                duration = Convert.ToUInt16(clip.duration);
                if(duration == 0) {
                    if(vstup == null) {
                        message_error("Error: You didnt choose input video!", 0);
                        goto skipaa;
                    }
                    await Task.Delay(100); //<-- kvůli tomuhle řádku to musí být async ta funkce....
                }
                else if(player.currentMedia.imageSourceHeight == 0) {
                    if(vstup == null) {
                        message_error("Error: You didnt choose input video!", 0);
                        goto skipaa;
                    }
                    await Task.Delay(100); //<-- kvůli tomuhle řádku to musí být async ta funkce....
                }
                else break;
            }
            UInt16 vstup_vyska = Convert.ToUInt16(player.currentMedia.imageSourceHeight);
            UInt16 vstup_sirka = Convert.ToUInt16(player.currentMedia.imageSourceWidth);
            if(duration == 0) {
                message_error("Error loading video: duration is detected as 0. Using default bitrate of 2000Kb/s. It might be caused by bad input filename\nYou can specify custom bitrate in the debug menu", 0);
                bitrate = 2000;
                player.controls.stop();
                //goto skipaa;
                max_bitrate = 4000;
                goto bitrateskip;
            }
            UInt32 fourGBinKb = 32000000;
            max_bitrate = fourGBinKb / duration;
        bitrateskip:;
            player.controls.stop();
            string surrounddownmix;
            if(surround.Checked) {
                surrounddownmix = " -af \"pan=stereo|c0=0.5*c2+0.707*c0+0.707*c4+0.5*c3|c1=0.5*c2+0.707*c1+0.707*c5+0.5*c3\" ";
            }
            else surrounddownmix = "";
            if(DS_Wii != null) {
                if(DS_Wii.Name == "Wii3DS_radio_3DS") {
                    string codec = "";
                    int ds_outputtype = 4;
                    string argumenty = "";
                    string output = "";
                    string puttogether = "";
                    bool abort = false;
                    if(vstup == null) {
                        message_error("Error: You didnt choose input video!", 0);
                    }
                    if(DS_VF == null) {
                        message_error("Error: You didnt choose output format!", 0);
                        abort = true;
                    }
                    if(DS_3Dformat == null) {
                        if(DS_VF != null) {
                            if(DS_VF.Name == "ds_vf_3d") {
                                message_error("Error: You didnt choose input 3D format!", 0);
                                abort = true;
                            }
                        }
                    }
                    if(DS_OutputCodec == null) {
                        message_error("Error: You didnt choose output codec!", 0);
                        abort = true;
                    }
                    if(filtr == null) {
                        message_error("Error: You didnt choose which scaling filter!", 0);
                        abort = true;
                    }
                    if(stretch == null && cusresx == null && cusresy == null) {
                        message_error("Error: You didnt choose stretch!", 0);
                        abort = true;
                    }
                    if(abort) goto abortion;
                    switch(DS_VF.Name) {
                        case "ds_vf_standard":
                            ds_outputtype = 0;
                            vstup2 = vstup;
                            break;
                        case "ds_vf_horihd":
                            vstup2 = vstup;
                            ds_outputtype = 1;
                            break;
                        case "ds_vf_3d":
                            ds_outputtype = 2;
                            break;
                        default:
                            break;
                    }
                    if(ds_outputtype == 2) switch(DS_3Dformat.Name) {
                            case "ds_3dformat_leftright":
                                vstup2 = vstup;
                                break;
                            case "ds_3dformat_updown":
                                vstup2 = "convertedtoleftright.mkv";
                                ffmpeg.StartInfo.FileName = "cmd.exe";
                                ffmpeg.StartInfo.Arguments = "/k " + "ffmpeg -y -i " + vstup + " -vf stereo3d=abl:sbsl -crf 10 -c:a copy convertedtoleftright.mkv" + " && ping 1.1.1.1  & exit";
                                debug_textbox.Text += "ffmpeg -y -i " + vstup + " -vf stereo3d=abl:sbsl -crf 10 -c:a copy convertedtoleftright.mkv" + " && ping 1.1.1.1  & exit";
                                ffmpeg.Start();
                                ffmpeg.WaitForExit();
                                break;
                            default:
                                break;
                        }
                    switch(DS_OutputCodec.Name) {
                        case "ds_out_h264":
                            codec = "libx264 ";
                            break;
                        case "ds_out_mpeg":
                            codec = "mpeg2video ";
                            break;
                        case "ds_out_mjpeg":
                            codec = "mjpeg -huffman optimal ";
                            break;
                        default:
                            break;
                    }

                    string bframes = "";
                    if(codec == "libx264 ") {
                        if(nobframes.Checked && nodeblock.Checked) {
                            bframes = "-x264opts \"b-pyramid=0:b-adapt=0:no-deblock:bframes=0\" ";
                        }
                        else if(nobframes.Checked && !nodeblock.Checked) {
                            bframes = "-x264opts \"b-pyramid=0:b-adapt=0:bframes=0\" ";
                        }
                        else if(!nobframes.Checked && nodeblock.Checked) {
                            bframes = "-x264opts \"no-deblock\" ";
                        }
                    }
                    if(codec == "libx264 " && DS_VF.Name == "ds_vf_3d") {
                        if(message_prompt2("Video Player 1.5.1 and 1.5.2 has bug with h264 3D video and plays it too fast. \n Use Video Player 1.5.0 or use mpeg2video codec instead.") == 0) {
                            goto skipaa;
                        }
                    }
                    if(DS_VF.Name == "ds_vf_3d" || DS_VF.Name == "ds_vf_horihd") {
                        if(codec == "libx264 ") {
                            if(max_bitrate > 2000) {
                                bitrate = 2000;
                            }
                            else if(max_bitrate > 1000) {
                                bitrate = Convert.ToUInt16(max_bitrate - 100);
                            }
                            else {
                                bitrate = (Convert.ToUInt16(max_bitrate - 100));
                                message_error("bitrate is small, the output quality may be poor", 0);
                            }
                        }
                        else {
                            if(max_bitrate > 4000) {
                                bitrate = 4000;
                            }
                            else if(max_bitrate > 2000) {
                                bitrate = Convert.ToUInt16(max_bitrate - 100);
                            }
                            else {
                                bitrate = (Convert.ToUInt16(max_bitrate - 100));
                                message_error("bitrate is small, the output quality may be poor", 0);
                            }
                        }
                    }
                    else if(DS_VF.Name == "ds_vf_standard") {
                        if(codec == "libx264 ") {
                            if(max_bitrate > 1000) {
                                bitrate = 1000;
                            }
                            else if(max_bitrate > 500) {
                                bitrate = Convert.ToUInt16(max_bitrate - 60);
                            }
                            else {
                                bitrate = (Convert.ToUInt16(max_bitrate - 50));
                                message_error("bitrate is small, the output quality may be poor", 0);
                            }
                        }
                        else {
                            if(max_bitrate > 4000) {
                                bitrate = 4000;
                            }
                            else if(max_bitrate > 2000) {
                                bitrate = Convert.ToUInt16(max_bitrate - 100);
                            }
                            else {
                                bitrate = (Convert.ToUInt16(max_bitrate - 100));
                                message_error("bitrate is small, the output quality may be poor", 0);
                            }
                        }
                    }
                    else {
                        message_error("Unknown error occured when selecting bitrate!", 0);
                        goto abortion;
                    }
                    if(textBox2.Text != null) try {
                            bitrate = Convert.ToUInt16(textBox2.Text);
                        }
                        catch { };
                    string res_normal = "";
                    string res_double = "";
                    string res_hd = "";
                    string res_hd_double = "";
                    int x;
                    int y;
                    int actualpercent;
                    if(stretch.Name == "stretch_no") {
                        ScaleResolution(vstup_sirka, vstup_vyska, 400, 240, out x, out y, 0, out actualpercent);
                        res_normal = x.ToString() + ":" + y.ToString();
                        res_hd = (2 * x).ToString() + ":" + y.ToString();
                        res_double = (2 * x).ToString() + ":" + (2 * y).ToString();
                        res_hd_double = (4 * x).ToString() + ":" + (2 * y).ToString();
                    }
                    else if(stretch.Name == "stretch_10") {
                        ScaleResolution(vstup_sirka, vstup_vyska, 400, 240, out x, out y, 10, out actualpercent);
                        res_normal = x.ToString() + ":" + y.ToString();
                        res_hd = (2 * x).ToString() + ":" + y.ToString();
                        res_double = (2 * x).ToString() + ":" + (2 * y).ToString();
                        res_hd_double = (4 * x).ToString() + ":" + (2 * y).ToString();
                    }
                    else if(stretch.Name == "stretch_full") {
                        res_normal = "400:240";
                        res_hd = "800:240";
                        res_double = "800:480";
                        res_hd_double = "1600:480";
                    }
                    UInt16? cuswidth = null;
                    UInt16? cusheight = null;
                    if(cusresx.Text != "") {
                        if(cusresy.Text != "") {
                            try {
                                cuswidth = Convert.ToUInt16(cusresx.Text);
                                cusheight = Convert.ToUInt16(cusresy.Text);
                            }
                            catch { message_error("custom resolution contains invalid character", 0); }
                        }
                        else message_error("custom resolution width is set but height not", 0);
                    }
                    else if(cusresy.Text != "") {
                        if(cusresx.Text != "") {
                            try {
                                cuswidth = Convert.ToUInt16(cusresx.Text);
                                cusheight = Convert.ToUInt16(cusresy.Text);
                            }
                            catch { message_error("custom resolution contains invalid character", 0); }
                        }
                        else message_error("custom resolution height is set but width not", 0);
                    }
                    if(cuswidth.HasValue) {
                        res_normal = cuswidth.ToString() + ":" + cusheight.ToString();
                        res_hd = cuswidth.ToString() + ":" + cusheight.ToString();
                        res_double = (2 * cuswidth).ToString() + ":" + (2 * cusheight).ToString();
                        res_hd_double = (2 * cuswidth).ToString() + ":" + (2 * cusheight).ToString();
                    }
                    debug_textbox.Text = "bitrate\t" + bitrate.ToString() + "Kb/s\n";
                    debug_textbox.Text += "maxbitrate\t" + max_bitrate.ToString() + "Kb/s\n";
                    debug_textbox.Text += "duration\t" + duration.ToString() + "s\n";
                    debug_textbox.Text += "height\t" + vstup_vyska.ToString() + "px\n";
                    debug_textbox.Text += "width\t" + vstup_sirka.ToString() + "p\n";
                    debug_textbox.Text += "res_normal\t" + res_normal + "\n";
                    debug_textbox.Text += "res_hd\t" + res_hd + "\n";
                    debug_textbox.Text += "res_double\t" + res_double + "\n";
                    debug_textbox.Text += "bframes:\t" + bframes + "\n";
                    debug_textbox.Text += "sub_in:\t" + subtitleinput + "\n";
                    debug_textbox.Text += "subtitles:\t" + subtitlemapall + "\n";
                    if(DS_VF.Name == "ds_vf_3d") bitrate = (UInt16)(bitrate / 2);
                    string audiomix3d;
                    string audiomix;
                    if(dualaudiotracks.Checked) {
                        audiomix3d = " -map 0:a ";
                        audiomix = " -map 0:a -map 0:v ";
                    }
                    else {
                        audiomix = "";
                        audiomix3d = " -map 0:a:0 ";
                    }
                    
                    if(ds_outputtype == 0) {
                        if(filtr.Name == "scale_linear") {
                            argumenty = " -vf \"scale=" + res_normal + ":flags=lanczos,setsar=1\" ";
                        }
                        else if(filtr.Name == "scale_nearest") {
                            argumenty = " -vf \"scale=" + res_normal + ":flags=neighbor,setsar=1\" ";
                        }
                        else {
                            argumenty = " -vf \"scale=" + res_double + ":flags=lanczos,scale=" + res_normal + ":flags=neighbor,setsar=1\" "; //-aspect 40:24
                        }
                        argumenty = subtitleinput + argumenty;
                        output = " -c:v " + codec + " -b:a 128k" + surrounddownmix + " -c:a aac  -b:v " + bitrate + "k " + bframes + audiomix;
                    }
                    else if(ds_outputtype == 1) {
                        if(filtr.Name == "scale_linear") {
                            argumenty = " -vf \"scale=" + res_hd + ":flags=Lanczos,setsar=1/2\" ";
                        }
                        else if(filtr.Name == "scale_nearest") {
                            argumenty = " -vf \"scale=" + res_hd + ":flags=neighbor,setsar=1/2\" ";
                        }
                        else {
                            argumenty = " -vf \"scale=" + res_hd_double + ":flags=lanczos,scale=" + res_hd + ":flags=neighbor,setsar=1/2\" ";
                        }
                        argumenty = subtitleinput + argumenty;

                        output = " -c:v " + codec + " -b:a 128k " + surrounddownmix + "-c:a aac -b:v " + bitrate + "k " + bframes + audiomix;
                    }
                    else if(ds_outputtype == 2) {
                        if(filtr.Name == "scale_linear") {
                            argumenty = "-filter_complex \"split[l][r];[l]stereo3d=sbsl:ml[left];[left]scale=" + res_normal + ":flags=lanczos[left];[r]stereo3d=sbsl:mr[right];[right]scale=" + res_normal + ":flags=lanczos,setsar=1[right]\" ";
                        }
                        else if(filtr.Name == "scale_nearest") {
                            argumenty = "-filter_complex \"split[l][r];[l]stereo3d=sbsl:ml[left];[left]scale=" + res_normal + ":flags=neighbor[left];[r]stereo3d=sbsl:mr[right];[right]scale=" + res_normal + ":flags=neighbor,setsar=1[right]\" ";
                        }
                        else {
                            argumenty = "-filter_complex \"split[l][r];[l]stereo3d=sbsl:ml[left];[left]scale=" + res_double + ":flags=lanczos[left];[left]scale=" + res_normal + ":flags=neighbor[left];[r]stereo3d=sbsl:mr[right];[right]scale=" + res_double + ":flags=lanczos,setsar=1[right];[right]scale=" + res_normal + ":flags=neighbor,setsar=1[right]\" ";
                        }
                        output = " -map [left] -map 0:a -c:a aac -b:a 128k  " + surrounddownmix + " -b:v " + bitrate + "k -c:v " + codec + bframes + audiomix3d + " left.mkv -map [right] -an -b:v " + bitrate + "k -c:v " + codec + bframes + " right.mkv";
                        debug_textbox.Text += "Uvíííííííííííííííííí:\n";
                        puttogether = " && ffmpeg -n -i left.mkv -i right.mkv " + subtitleinput + " -map 0:v:0 -map 0:a:0 -map 1:v:0 " + subtitlemaps2 + "-c:v copy -c:a copy ";
                    }
                    
                    ffmpeg.StartInfo.FileName = "cmd.exe";
                    ffmpeg.StartInfo.Arguments = "/k " + "ffmpeg -y -i \"" + vstup2 + "\" " + argumenty + output + puttogether + " \"" + cesta + "\\" + outputnazev + ".mkv\" " + "&& ping 1.1.1.1 -n 1 && exit 1";
                    debug_textbox.Text += ffmpeg.StartInfo.Arguments;
                    ffmpeg.Start();
                    ffmpeg.WaitForExit();
                    tadasound.Play();
                abortion:;
                }
                else {
                    byte framerate = 0;
                    string codec = "";
                    int aaa = 4;
                    string argumenty = "";
                    string output = "";
                    string puttogether = "";
                    bool abort = false;
                    if(vstup == null) {
                        message_error("Error: You didnt choose input video!", 0);
                        abort = true;
                    }
                    if(Wii_TV == null) {
                        message_error("Error: You didnt choose output video!", 0);
                        abort = true;
                    }
                    if(Wii_framerate == null) {
                        message_error("Error: You didnt choose framerate!", 0);
                        abort = true;
                    }
                    if(Wii_codec == null) {
                        message_error("Error: You didnt choose codec!", 0);
                        abort = true;
                    }
                    if(filtr == null) {
                        message_error("Error: You didnt choose scale filter!", 0);
                        abort = true;
                    }
                    if(abort == true) goto skipaa;

                    switch(Wii_codec.Name) {
                        case "wii_h263":
                            codec = "h263p";
                            break;
                        case "wii_xvid":
                            codec = "libxvid";
                            break;
                        case "wii_mjpeg":
                            codec = "mjpeg";
                            break;
                    }

                    string res = "";
                    string res_double = "";
                    UInt16 vyska;
                    UInt16 sirka;
                    if(stretch.Name == "stretch_no") {
                        if(Wii_TV.Name == "w480p") {
                            if(Wii_Aspect.Name == "wii_43") {
                                vyska = (UInt16)((vstup_vyska * 640) / vstup_sirka);
                                if(vstup_vyska <= 480) {
                                    res = "640:-1";
                                    res_double = "1280:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 480) / vstup_vyska);
                                    res_double = sirka * 2 + ":480";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":480";
                                }
                            }
                            else if(Wii_Aspect.Name == "wii_169") {
                                vyska = (UInt16)((vstup_vyska * 720) / vstup_sirka);
                                if(vstup_vyska <= 480) {
                                    res = "720:-1";
                                    res_double = "1440:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 480) / vstup_vyska);
                                    res_double = sirka * 2 + ":480";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":480";
                                }
                            }
                            else {
                                message_error("error occured at wii 480p aspect, no stretch", 0);
                                goto exitttttt;
                            }
                        }
                        else if(Wii_TV.Name == "w576p") {
                            if(Wii_Aspect.Name == "wii_43") {
                                vyska = (UInt16)((vstup_vyska * 640) / vstup_sirka);
                                if(vstup_vyska <= 576) {
                                    res = "640:-1";
                                    res_double = "1280:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 576) / vstup_vyska);
                                    res_double = sirka * 2 + ":576";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":576";
                                }
                            }
                            else if(Wii_Aspect.Name == "wii_169") {
                                vyska = (UInt16)((vstup_vyska * 720) / vstup_sirka);
                                if(vstup_vyska <= 576) {
                                    res = "720:-1";
                                    res_double = "1440:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 576) / vstup_vyska);
                                    res_double = sirka * 2 + ":576";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":576";
                                }
                            }
                            else {
                                message_error("error occured at wii 576i aspect, no stretch", 0);
                                goto exitttttt;
                            }
                        }
                    }
                    else if(stretch.Name == "stretch_10") {
                        if(Wii_TV.Name == "w480p") {
                            if(Wii_Aspect.Name == "wii_43") {
                                vyska = (UInt16)((vstup_vyska * 640) / vstup_sirka * 1.1);
                                if(vstup_vyska <= 480) {
                                    res = "640:-1";
                                    res_double = "1280:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 480) / vstup_vyska / 1.1);
                                    res_double = sirka * 2 + ":960";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":480";
                                }
                            }
                            else if(Wii_Aspect.Name == "wii_169") {
                                vyska = (UInt16)((vstup_vyska * 720) / vstup_sirka * 1.1);
                                if(vstup_vyska <= 480) {
                                    res = "720:-1";
                                    res_double = "1440:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 480) / vstup_vyska);
                                    res_double = sirka * 2 + ":960";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":480";
                                }
                            }
                            else {
                                message_error("error occured at wii 480p aspect, 10% stretch", 0);
                                goto exitttttt;
                            }
                        }
                        else if(Wii_TV.Name == "w576p") {
                            if(Wii_Aspect.Name == "wii_43") {
                                vyska = (UInt16)((vstup_vyska * 640) / vstup_sirka * 1.1);
                                if(vstup_vyska <= 576) {
                                    res = "640:-1";
                                    res_double = "1280:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 576) / vstup_vyska);
                                    res_double = sirka * 2 + ":1152";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":576";
                                }
                            }
                            else if(Wii_Aspect.Name == "wii_169") {
                                vyska = (UInt16)((vstup_vyska * 720) / vstup_sirka * 1.1);
                                if(vstup_vyska <= 576) {
                                    res = "720:-1";
                                    res_double = "1440:-1";
                                }
                                else {
                                    sirka = (UInt16)((vstup_sirka * 576) / vstup_vyska);
                                    res_double = sirka * 2 + ":1152";
                                    if(sirka % 2 == 1) sirka++;
                                    res = sirka + ":576";
                                }
                            }
                            else {
                                message_error("error occured at wii 576i aspect, 10% stretch", 0);
                                goto exitttttt;
                            }
                        }
                        else {
                            message_error("error occured at wii tv out selection", 0);
                            goto exitttttt;
                        }
                    }
                    UInt16? cuswidth = null;
                    UInt16? cusheight = null;
                    if(cusresx.Text != "") {
                        if(cusresy.Text != "") {
                            try {
                                cuswidth = Convert.ToUInt16(cusresx.Text);
                                cusheight = Convert.ToUInt16(cusresy.Text);
                            }
                            catch { message_error("custom resolution contains invalid character", 0); }
                        }
                        else message_error("custom resolution width is set but height not", 0);
                    }
                    else if(cusresy.Text != "") {
                        if(cusresx.Text != "") {
                            try {
                                cuswidth = Convert.ToUInt16(cusresx.Text);
                                cusheight = Convert.ToUInt16(cusresy.Text);
                            }
                            catch { message_error("custom resolution contains invalid character", 0); }
                        }
                        else message_error("custom resolution height is set but width not", 0);
                    }
                    if(cuswidth.HasValue) {
                        res = cuswidth.ToString() + ":" + cusheight.ToString();
                        res_double = (2 * cuswidth).ToString() + ":" + (2 * cusheight).ToString();
                    }


                    if(Wii_framerate.Name == "wii_6050") {
                        if(Wii_TV.Name == "w480p") framerate = 60;
                        else if(Wii_TV.Name == "w576p") framerate = 50;
                        else message_error("error occured at wii tv out selection (resolution w480p)", 0);
                    }
                    else if(Wii_framerate.Name == "wii_3025") {
                        if(Wii_TV.Name == "w480p") framerate = 30;
                        else if(Wii_TV.Name == "w576p") framerate = 25;
                        else message_error("error occured at wii tv out selection (resolution w480p)", 0);
                    }
                    else message_error("error occured at wii framerate selection", 0);
                    exitttttt:;
                    string bitrate_wii;
                    if(textBox2.Text != "") bitrate_wii = textBox2.Text + "k ";
                    else bitrate_wii = "1600k ";

                    debug_textbox.Text = "res: " + res + "\n";
                    debug_textbox.Text += "resd: " + res_double + "\n";
                    debug_textbox.Text += "framerate: " + framerate + "\n";
                    debug_textbox.Text += "codec: " + codec + "\n";
                    string scale = " ";
                    switch(filtr.Name) {
                        case "scale_linear":
                            scale = " -vf scale=" + res + ":flags=lanczos" + custom_sar_str + " ";
                            break;
                        case "scale_nearest":
                            scale = " -vf scale=" + res + ":flags=neighbor" + custom_sar_str + " ";
                            break;
                        case "scale_mix":
                            scale = " -vf scale=" + res_double + ":flags=lanczos,scale=" + res + ":flags=neighbor" + custom_sar_str + " ";
                            break;

                    }
                    string framerate_set = "";
                    if(wii_fps_notchange.Checked == false) framerate_set = " -r " + framerate.ToString() + " ";
                    debug_textbox.Text += "scale: " + scale + "\n";
                    ffmpeg.StartInfo.FileName = "cmd.exe";
                    ffmpeg.StartInfo.Arguments = "/k " + "ffmpeg -y -i \"" + vstup + "\"" + subtitleinput + subtitlemapall + subtitlemaps0 + framerate_set + scale + argumenty + " -c:v " + codec + " -b:v " + bitrate_wii + output + " \"" + cesta + "\\" + outputnazev + ".mkv\" " + "&& ping 1.1.1.1 -n 1 && exit 1";
                    debug_textbox.Text += ffmpeg.StartInfo.Arguments;
                    //ffmpeg.StartInfo.Arguments = "/k" + "echo " + vf + threed + codec;
                    //-hide_banner -v warning -stats
                    ffmpeg.Start();
                    ffmpeg.WaitForExit();
                    tadasound.Play();
                }
            }
            else message_error("Error: 3DS/Wii mode not selected!", 0);
            skipaa:;
            Enabled = true;
            //handle.Set();
        }
        private void ds3dshow() {
            if(ds_vf_3d.Checked) {
                ds_3dformat_leftright.Enabled = true;
                ds_3dformat_swap.Enabled = true;
                ds_3dformat_updown.Enabled = true;
            }
            else {
                ds_3dformat_leftright.Enabled = false;
                ds_3dformat_swap.Enabled = false;
                ds_3dformat_updown.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            test(null, null);
            openFileDialog1.InitialDirectory = "%userprofile%\\Videos";
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                textBox1.Text = openFileDialog1.FileName;
                vstup = openFileDialog1.FileName;
                outputnazev = "3ds_" + Path.GetFileNameWithoutExtension(vstup);
                cesta = Path.GetDirectoryName(vstup);
            }
        }




        private void ds_vf_standard_CheckedChanged(object sender, EventArgs e) {
            ds3dshow();
        }

        private void ds_vf_3d_CheckedChanged(object sender, EventArgs e) {
            ds3dshow();
        }

        private void ds_vf_horihd_CheckedChanged(object sender, EventArgs e) {
            ds3dshow();
        }
        private void test(object sender, EventArgs e) {
            commandsound.Play();
        }

        private void version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://gbatemp.net/threads/nintendo-video-convertor-video-convertor-for-3ds-and-wii.622972");
        }

        private async void button2_Click(object sender, EventArgs e) {
            Enabled = false;
            //create new queue
            var queue = new Queue<string>();
            if(cesta != null) {
                //add all files in directory "cesta" to listBox1
                listBox1.Items.Clear();
                foreach(var file in Directory.GetFiles(cesta)) {
                    //if file begins with "3ds_" then skip it
                    if(Path.GetFileName(file).StartsWith("3ds_")) continue;
                    //if file is srt then skip it
                    if(!(Path.GetExtension(file) == ".mp4" || Path.GetExtension(file) == ".avi" || Path.GetExtension(file) == ".mkv" || Path.GetExtension(file) == ".webm")) continue;
                    //if file with same name exists, but it has "3ds_" prefix, then skip
                    if(File.Exists(cesta + "\\3ds_" + Path.GetFileNameWithoutExtension(file) + ".mkv")) continue;

                    listBox1.Items.Add(file);
                    queue.Enqueue(file);
                }
            }
            else message_error("Musis vybrat soubor pro konvertovani složky", 0);
            while(queue.Count != 0) {
                vstup = queue.Dequeue();
                outputnazev = "3ds_" + Path.GetFileNameWithoutExtension(vstup);
                cesta = Path.GetDirectoryName(vstup);
                /*string subtitle = cesta + "\\" + Path.GetFileNameWithoutExtension(vstup);
                if(File.Exists(subtitle + ".srt")) {
                    subtitles = " -itsoffset " + suboffset.Text + " -i \"" + subtitle + ".srt\" -c:s copy -map 1:s ";
                    listBox3.Items.Add(subtitle + ".srt");
                }
                else {
                    subtitle = "";
                    message_error("Subtitle file not found!");
                }
                if(embeddedsubs.Checked) {
                    subtitles = " -map 0:s ";
                }
                else {
                    subtitles = "";
                }*/
                await convert(1);
                listBox2.Items.Add(outputnazev);
            }
            Enabled = true;
        }
    }
    public static class TextBoxWatermarkExtensionMethod {
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetWatermark(this TextBox textBox, string watermarkText) {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }
    }
}
