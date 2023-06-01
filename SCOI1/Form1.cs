using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.LinkLabel;
using System.Numerics;





namespace SCOI1
{
    public partial class Form1 : Form
    {
        int height = 1;
        int width = 2;
        private Bitmap image = null;
        Bitmap img1 = null;
        Bitmap img2 = null;
       
        Bitmap sum(Bitmap img1, Bitmap img2)
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var img1_pix = img1.GetPixel(j, i);
                    var img2_pix = img2.GetPixel(j, i);

                    var img1_r = img1_pix.R;
                    var img1_g = img1_pix.G;
                    var img1_b = img1_pix.B;
                    var img2_r = img2_pix.R;
                    var img2_g = img2_pix.G;
                    var img2_b = img2_pix.B;

                    var img_r = (int)Clamp(img1_r + img2_r, 0, 255);
                    var img_g = (int)Clamp(img1_g + img2_g, 0, 255);
                    var img_b = (int)Clamp(img1_b + img2_b, 0, 255);
                    var pix = Color.FromArgb(img_r, img_g, img_b);
                    imageOut.SetPixel(j, i, pix);
                }
            }
            return imageOut;
        }

        Bitmap mult(Bitmap img1, Bitmap img2)
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var img1_pix = img1.GetPixel(j, i);
                    var img2_pix = img2.GetPixel(j, i);

                    var img1_r = img1_pix.R;
                    var img1_g = img1_pix.G;
                    var img1_b = img1_pix.B;
                    var img2_r = img2_pix.R;
                    var img2_g = img2_pix.G;
                    var img2_b = img2_pix.B;

                    var img_r = (int)Clamp((img1_r * img2_r) / 255, 0, 255);
                    var img_g = (int)Clamp((img1_g * img2_g) / 255, 0, 255);
                    var img_b = (int)Clamp((img1_b * img2_b) / 255, 0, 255);
                    var pix = Color.FromArgb(img_r, img_g, img_b);
                    imageOut.SetPixel(j, i, pix);
                }
            }

            return imageOut;
        }

        Bitmap min(Bitmap img1, Bitmap img2)
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var img1_pix = img1.GetPixel(j, i);
                    var img2_pix = img2.GetPixel(j, i);

                    var img1_r = img1_pix.R;
                    var img1_g = img1_pix.G;
                    var img1_b = img1_pix.B;
                    var img2_r = img2_pix.R;
                    var img2_g = img2_pix.G;
                    var img2_b = img2_pix.B;

                    var img_r = Math.Min(img1_r, img2_r);
                    var img_g = Math.Min(img1_g, img2_g);
                    var img_b = Math.Min(img1_b, img2_b);
                    var pix = Color.FromArgb(img_r, img_g, img_b);
                    imageOut.SetPixel(j, i, pix);
                }
            }

            return imageOut;
        }

        Bitmap max(Bitmap img1, Bitmap img2)
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var img1_pix = img2.GetPixel(j, i);
                    var img2_pix = img2.GetPixel(j, i);

                    var img1_r = img1_pix.R;
                    var img1_g = img1_pix.G;
                    var img1_b = img1_pix.B;
                    var img2_r = img2_pix.R;
                    var img2_g = img2_pix.G;
                    var img2_b = img2_pix.B;

                    var img_r = Math.Max(img1_r, img2_r);
                    var img_g = Math.Max(img1_g, img2_g);
                    var img_b = Math.Max(img1_b, img2_b);
                    var pix = Color.FromArgb(img_r, img_g, img_b);
                    imageOut.SetPixel(j, i, pix);
                }
            }
            
            return imageOut;
        }

        Bitmap average(Bitmap img1, Bitmap img2)
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var img1_pix = img1.GetPixel(j, i);
                    var img2_pix = img2.GetPixel(j, i);

                    var img1_r = img1_pix.R;
                    var img1_g = img1_pix.G;
                    var img1_b = img1_pix.B;
                    var img2_r = img2_pix.R;
                    var img2_g = img2_pix.G;
                    var img2_b = img2_pix.B;

                    var img_r = (int)Clamp((img1_r + img2_r) / 2, 0, 255);
                    var img_g = (int)Clamp((img1_g + img2_g) / 2, 0, 255);
                    var img_b = (int)Clamp((img1_b + img2_b) / 2, 0, 255);
                    var pix = Color.FromArgb(img_r, img_g, img_b);
                    imageOut.SetPixel(j, i, pix);
                }
            }

            return imageOut;
        }
        Bitmap scrollActivate(Bitmap img1, int alpha) 
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var img1_pix = img1.GetPixel(j, i);
                    //var img2_pix = img2.GetPixel(j, i);

                    int r = img1_pix.R;
                    int g = img1_pix.G;
                    int b = img1_pix.B;

                    var pix = Color.FromArgb(alpha , r, g, b);

                    imageOut.SetPixel(j, i, pix);
                }
            }

            return imageOut;
        }

        Bitmap rCheckPressed(Bitmap img1)
        {
            var h = img1.Height;
            var w = img1.Width;

            Bitmap imageOut = new Bitmap(w, h);

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    var img1_pix = img1.GetPixel(j, i);

                    int r = img1_pix.R;
                    int g = img1_pix.G;
                    int b = img1_pix.B;
                    int r1 = img1_pix.R;
                    int g1 = img1_pix.G;
                    int b1 = img1_pix.B;

                    if (!checkBox1.Checked)
                    {
                        r = 0;
                        
                    } else
                    {
                        r = r1;
                    }

                    if (!checkBox2.Checked)
                    {
                        g = 0;
                    }
                    else
                    {
                        g = g1;
                    }

                    if (!checkBox3.Checked)
                    {
                        b = 0;
                    }
                    else
                    {
                        b = b1;
                    }

                    var pix = Color.FromArgb(r, g, b);

                    imageOut.SetPixel(j, i, pix);

                }

            return imageOut;
        }

    
         Bitmap circleMask(Bitmap image1, Bitmap image2)
        {
            var imageOut = new Bitmap(image1.Width, image1.Height);
            var graphics = Graphics.FromImage(imageOut);

            graphics.DrawImage(image1, 0, 0);
            var path = new GraphicsPath();

            path.AddEllipse(0, 0, image2.Width, image2.Height);
            Region region = new Region(path);
            graphics.SetClip(region, CombineMode.Replace);
            graphics.DrawImage(image2, 0, 0);
            graphics.Dispose();
            region.Dispose();

            return imageOut;

        }



        public Form1()
        {
            InitializeComponent();

            var canvas1 = new MyCanvas();

            //Клапдем ее в панель на окне (чтобы было удобно управлять ее размерами)
            //this.pLeft.Controls.Add(canvas1);

            //Даем есть установку - всегда заполнять всю возможную область
            canvas1.Dock = DockStyle.Fill;
            canvas1.img = pictureBox1.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.ShowDialog();// открываем окно
            string FileName = openFile.FileName;// берем полный адрес картинки            
            pictureBox2.ImageLocation = FileName;
            if (image != null)
            {
                pictureBox2.Image = null;
                image.Dispose();
            }

            image = new Bitmap(openFile.FileName);
            pictureBox2.Image = image;
            img1 = image;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string FileName = openFile.FileName;// берем полный адрес картинки            
            pictureBox3.ImageLocation = FileName;
           
                if (image != null)
                {
                    pictureBox3.Image = null;
                    image.Dispose();
                }

                image = new Bitmap(openFile.FileName);
                pictureBox3.Image = image;
                img2 = image;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex);
            var image1 = new Bitmap(pictureBox2.Image);
            var image2 = new Bitmap(pictureBox3.Image);


            if (pictureBox3.Image != null)
            {
                switch(comboBox1.SelectedIndex)
                {
                    case 0 : 
                        pictureBox1.Image =  sum(image1, image2); 
                        break;
                    case 1 : 
                        pictureBox1.Image = mult(image1, image2); 
                        break;
                    case 2:
                        pictureBox1.Image = average(image1, image2);
                        break;
                    case 3:
                        pictureBox1.Image = min(image1, image2);
                        break;
                    case 4:
                        pictureBox1.Image = max(image1, image2);
                        break;
                    case 5:
                        pictureBox1.Image = circleMask(image1, image2);
                        break;
                    default : 
                        pictureBox3.Image.Dispose(); 
                        break;
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }

            
        }

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {
            Console.WriteLine("sdfdg");
            pictureBox2.Image.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                {
                    pictureBox1.Image.Save(saveFileFialog.FileName);
                }
            }
        }
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox2.ImageLocation);
            pictureBox2.Image = rCheckPressed(image1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox2.ImageLocation);
            pictureBox2.Image = scrollActivate(img1, trackBar1.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox2.ImageLocation);
            pictureBox2.Image = rCheckPressed(image1);

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox2.ImageLocation);
            pictureBox2.Image = rCheckPressed(image1);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox3.ImageLocation);
            pictureBox3.Image = scrollActivate(img1, trackBar2.Value);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox3.ImageLocation);
            pictureBox3.Image = rCheckPressed(image1);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox3.ImageLocation);
            pictureBox3.Image = rCheckPressed(image1);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            var image1 = new Bitmap(pictureBox3.ImageLocation);
            pictureBox3.Image = rCheckPressed(image1);
        }

        private void myCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            var image1 = new Bitmap(pictureBox3.ImageLocation);
            var image2 =  myCanvas1.DrawNewImage(image1);
            pictureBox1.Image = image2;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            var img = image2;
            var image = makeHistogram(new Bitmap(pictureBox1.Image));
            pictureBox5.Image = makeHistogram(new Bitmap(pictureBox1.Image));
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
         
            pictureBox5.Refresh();
        }

        Bitmap makeHistogram(Bitmap inputImg)
        {

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);

            var img = inputImg;
            var layer = Graphics.FromImage(img);


            var arr = new int[256];
            for (int i = 0; i < 256; i++)
            {
                arr[i] = 0;
            }
            var hi = inputImg.Height;
            var wi = inputImg.Width;
            Bitmap outImg = new Bitmap(777, pictureBox5.Height);
            var layer2 = Graphics.FromImage(outImg);

            for (int y = 0; y < hi; y++)
            {
                for (int x = 0; x < wi; x++)
                {
                    var c = (inputImg.GetPixel(x, y).R + inputImg.GetPixel(x, y).G + inputImg.GetPixel(x, y).B) / 3;
                    arr[c] += 1;
                }
            }
            Console.WriteLine(arr);

            var max = arr.Max();

            var k = (decimal)((decimal)pictureBox5.Height / max);
            //var k = 50;

            for (int i = 0; i < 255; i++)
            {
                Point A = new Point(i * 3, pictureBox5.Height - 1);
                Point B = new Point(i * 3, (int)(pictureBox5.Height - 1 - (decimal)arr[i] * k));
                layer2.DrawLine(pen, A, B);
            }

            return outImg;
        }

        int cLamp(int a, int min, int max)
        {
            if (a < min) a = min;
            if (a > max) a = max;

            return a;
        }

        Bitmap GavrBinarise(Bitmap inputImg)
        {
            var hi = inputImg.Height;
            var wi = inputImg.Width;
            var monoImg = new double[wi, hi];
            Bitmap outImg = new Bitmap(wi, hi);
            var summ = 0;
            var t = 0;

            for (int y = 0; y < hi; y++)
            {
                for (int x = 0; x < wi; x++)
                {
                    var pixel = inputImg.GetPixel(x, y);
                    monoImg[x, y] = 0.2125 * pixel.R + 0.7154 * pixel.G + 0.0721 * pixel.B;
                   
                    //img.SetPixel(x, y, newPixel);
                }
            }

            for (int y = 0; y < hi; y++)
            {
                for (int x = 0; x < wi; x++)
                {
                    summ += (int)monoImg[x, y];
                }
            }

            t = summ / (hi * wi);

            for (int y = 0; y < hi - 1; y++)
            {
                for (int x = 0; x < wi - 1; x++)
                {
                    if (monoImg[x, y] > t)
                    {
                        outImg.SetPixel(x, y, Color.FromKnownColor(KnownColor.White));
                    } else
                    {
                        outImg.SetPixel(x, y, Color.FromKnownColor(KnownColor.Black));
                    }
                }
            }

            return outImg;
        }

        Bitmap OtsuBinarise(Bitmap inputImg)
        {
            var hi = inputImg.Height;
            var wi = inputImg.Width;
            var monoImg = new double[wi, hi];
            Bitmap outImg = new Bitmap(wi, hi);
            var summ = 0;
            var t = 0;
            var N = new double[256];
            var max = -1;

            for (int y = 0; y < hi; y++)
            {
                for (int x = 0; x < wi; x++)
                {
                    var pixel = inputImg.GetPixel(x, y);
                    monoImg[x, y] = 0.2125 * pixel.R + 0.7154 * pixel.G + 0.0721 * pixel.B;
                    if (0.2125 * pixel.R + 0.7154 * pixel.G + 0.0721 * pixel.B > max ) {
                        max = (int)(0.2125 * pixel.R + 0.7154 * pixel.G + 0.0721 * pixel.B);
                    }
                }
            }

            for (int i = 0; i < 256; i++)
            {
                N[i] = 0;
            }
            
            for (int y = 0; y < hi; y++)
            {
                for (int x = 0; x < wi; x++)
                {
                    //var c = (inputImg.GetPixel(x, y).R + inputImg.GetPixel(x, y).G + inputImg.GetPixel(x, y).B) / 3;
                    var c = (int)(0.2125 * inputImg.GetPixel(x, y).R + 0.7154 * inputImg.GetPixel(x, y).G + 0.0721 * inputImg.GetPixel(x, y).B);
                    N[c] += 1;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                N[i] /= (wi * hi);
            }
           
            var v1 = 0.0;
            var v2 = 0.0;
            var u1 = 0.0;
            var u2 = 0.0;
            var ut = 0.0;
            var oldSigma = -1.0;
            var newigma = -1.0;
            var sigmas = new double[max+1];
           // var t = -1;

            for (int i=0; i <= max; i++)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    v1 += N[j];
                }

                v2 = 1 - v1;

                var summm = 0.0;
                for (int j = 0; j <= i-1; j++)
                {
                    summm += (j * N[j]);

                }

                u1 = summm / v1;
                if (summm == 0 && v1 == 0)
                {
                    u1 = 0;
                }

                for (int j = 0; j <= max; j++)
                {
                    ut += (j * N[j]);
                }

                u2 = (ut - u1 * v1) / v2;
                oldSigma = v1 * v2 * (u1 - u2) * (u1 - u2);

               // sigmas[i] = oldSigma;
               if (oldSigma > newigma)
                {
                    newigma = oldSigma;
                    t = i;
                }

                 v1 = 0.0;
                 v2 = 0.0;
                 u1 = 0.0;
                 u2 = 0.0;
                 ut = 0.0;
                oldSigma = -1.0;
            }

            for (int y = 0; y < hi - 1; y++)
            {
                for (int x = 0; x < wi - 1; x++)
                {
                    if (monoImg[x, y] > t)
                    {
                        outImg.SetPixel(x, y, Color.FromKnownColor(KnownColor.White));
                    }
                    else
                    {
                        outImg.SetPixel(x, y, Color.FromKnownColor(KnownColor.Black));
                    }
                }
            }


            return outImg;
        }

        Bitmap makeMono(Bitmap img)
        {
            Bitmap result = new Bitmap(img);

            int monoPx = 0;

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    var pix = result.GetPixel(i, j);

                    monoPx = (int)cLamp((int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721), 0, 255);

                    result.SetPixel(i, j, Color.FromArgb(monoPx, monoPx, monoPx));
                }
            }

            return result;
        }

        Bitmap NiblekBinarise(Bitmap inputImg)
        {
            var hi = inputImg.Height;
            var wi = inputImg.Width;
            var monoImg = makeMono(inputImg);
            Bitmap outImg = new Bitmap(wi, hi);

            double sensitivity = -0.2;
            int n = 15;
            int[,] pix_matrix = new int[n, n];
            int n_forMatrix = (int)Math.Floor((double)n / 2);
            for (int i = 0; i < hi; i++)
                for (int j = 0; j < wi; j++)
                {
                   
                    var pix = monoImg.GetPixel(j, i);
                    pix_matrix[n_forMatrix, n_forMatrix] = pix.R;

                    double math_expec = 0.0;
                    double math_expec_powered = 0.0;
                    double math_dispersion = 0.0;

                    for (int i_matrix = 0; i_matrix < n; i_matrix++)
                    {
                        for (int j_matrix = 0; j_matrix < n; j_matrix++)
                        {
                            if ((i - n_forMatrix + i_matrix) == n_forMatrix && (j - n_forMatrix + j_matrix) == n_forMatrix)
                                continue;

                            if ((j - n_forMatrix + j_matrix) >= 0 && (j - n_forMatrix + j_matrix) < wi)

                                if ((i - n_forMatrix + i_matrix) >= 0 && (i - n_forMatrix + i_matrix) < hi)

                                    pix_matrix[i_matrix, j_matrix] = monoImg.GetPixel(j - n_forMatrix + j_matrix, i - n_forMatrix + i_matrix).R;

                                else { pix_matrix[i_matrix, j_matrix] = 0; }
                            else { pix_matrix[i_matrix, j_matrix] = 0; }


                            math_expec += pix_matrix[i_matrix, j_matrix];
                            math_expec_powered += Math.Pow(pix_matrix[i_matrix, j_matrix], 2);
                        }
                    }

                    math_expec /= (n * n);
                    math_expec_powered /= (n * n);
                    math_dispersion = math_expec_powered - Math.Pow(math_expec, 2);

                    double avg_deviation = Math.Sqrt(math_dispersion);

                    int local_threshold = cLamp((int)(math_expec + sensitivity * avg_deviation), 0, 255);

                    outImg.SetPixel(j, i, pix.R <= local_threshold ? Color.Black : Color.White);


                }

            return outImg;
        }

        static void LineFilter(byte[] bgrAValues, int[] size, double[] M, int a, int b, double[] out_test)
        {
            Queue<List<byte>> S = new Queue<List<byte>>();
            for (int i = 0; i < size[0]; ++i)
            {
                for (int j = 0; j < size[1]; ++j)
                {
                    if (i > (a - 1) / 2)
                    {
                        byte[] front = S.First().ToArray();
                        bgrAValues[4 * ((i - (a - 1) / 2 - 1) * size[1] + j)] = front[0];
                        bgrAValues[4 * ((i - (a - 1) / 2 - 1) * size[1] + j) + 1] = front[1];
                        bgrAValues[4 * ((i - (a - 1) / 2 - 1) * size[1] + j) + 2] = front[2];
                        S.Dequeue();
                    }
                    double[] sum = { 0, 0, 0 };
                    for (int it = 0; it < a; ++it)
                    {
                        for (int jt = 0; jt < b; ++jt)
                        {
                            int iter = i - (a - 1) / 2 + it; iter = (iter < 0) ? (0 - iter) : iter;
                            iter = (iter > (size[0] - 1)) ? (2 * (size[0] - 1) - iter) : iter;
                            int jter = j - (b - 1) / 2 + jt;
                            jter = (jter < 0) ? (0 - jter) : jter;
                            jter = (jter > (size[1] - 1)) ? (2 * (size[1] - 1) - jter) : jter;
                            sum[0] += (double)bgrAValues[4 * (iter * size[1] + jter)] * M[it * b + jt];
                            sum[1] += (double)bgrAValues[4 * (iter * size[1] + jter) + 1] * M[it * b + jt];
                            sum[2] += (double)bgrAValues[4 * (iter * size[1] + jter) + 2] * M[it * b + jt];
                        }
                    }
                    List<byte> tmpS = new List<byte> {
                                                        (byte)Math.Min(Math.Max(Math.Round(sum[0]), byte.MinValue), byte.MaxValue),
                                                        (byte)Math.Min(Math.Max(Math.Round(sum[1]), byte.MinValue), byte.MaxValue),
                                                        (byte)Math.Min(Math.Max(Math.Round(sum[2]), byte.MinValue), byte.MaxValue)
                                                                                                                                   };

                    out_test[i * size[1] + j] = tmpS[0];
                
                    S.Enqueue(tmpS);
                }
            }
            for (int i = size[0] - (a - 1) / 2 - 1; i < size[0]; ++i)
            {
                for (int j = 0; j < size[1]; ++j)
                {
                    byte[] front = S.First().ToArray();
                    bgrAValues[4 * (i * size[1] + j)] = front[0];
                    bgrAValues[4 * (i * size[1] + j) + 1] = front[1];
                    bgrAValues[4 * (i * size[1] + j) + 2] = front[2];
                    S.Dequeue();
                }
            }
        }

        public  System.Drawing.Image MakeLineFilter(System.Drawing.Image image)
        {
           
            List<double> M = getCore();

            Bitmap Bimage = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, Bimage.Width, Bimage.Height);
            BitmapData bmpData =
                Bimage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * Bimage.Height;
            byte[] bgrAValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, bgrAValues, 0, bytes);

            double[] test = new double[Bimage.Height * Bimage.Width];

            LineFilter(bgrAValues, new int[2] { Bimage.Height, Bimage.Width }, M.ToArray(), 3, 3, test);

            System.Runtime.InteropServices.Marshal.Copy(bgrAValues, 0, ptr, bytes);

            Bimage.UnlockBits(bmpData);

            return Bimage;
        }

        static Byte partition(Byte[] arr, int l, int r)
        {
            int x = arr[r], i = l;
            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++;
                }
            }
            (arr[i], arr[r]) = (arr[r], arr[i]);
            return Convert.ToByte(i);
        }

        static Byte kthSmallest(Byte[] arr, int l, int r, int k)
        {
            if (k > 0 && k <= r - l + 1)
            {

                int index = partition(arr, l, r);

                if (index - l == k - 1)
                    return arr[index];

                if (index - l > k - 1)
                    return kthSmallest(arr, l, index - 1, k);

                return kthSmallest(arr, index + 1, r,
                    k - index + l - 1);
            }

            return Convert.ToByte(int.MaxValue);
        }

       static void MedianFilter(Byte[] bgrAValues, int[] size, int a, int b, double[] out_test)
        {
            Queue<byte[]> S = new Queue<byte[]>();

            for (int i = 0; i < size[0]; ++i)
            {
                for (int j = 0; j < size[1]; ++j)
                {
                    if (i > (a - 1) / 2)
                    {
                        bgrAValues[4 * ((i - (a - 1) / 2 - 1) * size[1] + j)] = S.Peek()[0];
                        bgrAValues[4 * ((i - (a - 1) / 2 - 1) * size[1] + j) + 1] = S.Peek()[1];
                        bgrAValues[4 * ((i - (a - 1) / 2 - 1) * size[1] + j) + 2] = S.Peek()[2];
                        S.Dequeue();
                    }

                    List<byte> data1 = new List<byte>();
                    List<byte> data2 = new List<byte>();
                    List<byte> data3 = new List<byte>();

                    for (int it = 0; it < a; ++it)
                    {
                        for (int jt = 0; jt < b; ++jt)
                        {
                            int iter = i - (a - 1) / 2 + it;
                            iter = (iter < 0) ? (0 - iter) : iter;
                            iter = (iter > (size[0] - 1)) ? (2 * (size[0] - 1) - iter) : iter;

                            int jter = j - (b - 1) / 2 + jt;
                            jter = (jter < 0) ? (0 - jter) : jter;
                            jter = (jter > (size[1] - 1)) ? (2 * (size[1] - 1) - jter) : jter;

                            data1.Add(bgrAValues[4 * (iter * size[1] + jter)]);
                            data2.Add(bgrAValues[4 * (iter * size[1] + jter) + 1]);
                            data3.Add(bgrAValues[4 * (iter * size[1] + jter) + 2]);
                        }
                    }

                    kthSmallest(data1.ToArray(), 0, data1.Count - 1, (data1.Count - 1) / 2 + 1);
                    S.Enqueue(new byte[] {
            kthSmallest(data1.ToArray(), 0, data1.Count - 1, (data1.Count - 1) / 2 + 1),
            kthSmallest(data2.ToArray(), 0, data2.Count - 1, (data2.Count - 1) / 2 + 1),
            kthSmallest(data3.ToArray(), 0, data3.Count - 1, (data3.Count - 1) / 2 + 1) });

                    data1.Clear();
                    data1 = null;
                    data2.Clear();
                    data2 = null;
                    data3.Clear();
                    data3 = null;
                }
            }

            for (int i = size[0] - (a - 1) / 2 - 1; i < size[0]; ++i)
            {
                for (int j = 0; j < size[1]; ++j)
                {
                    bgrAValues[4 * (i * size[1] + j)] = S.Peek()[0];
                    bgrAValues[4 * (i * size[1] + j) + 1] = S.Peek()[1];
                    bgrAValues[4 * (i * size[1] + j) + 2] = S.Peek()[2];

                    S.Dequeue();
                }
            }
        }

        public static System.Drawing.Image MakeMedianFilter(System.Drawing.Image image, int a, int b)
        {
            Bitmap Bimage = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, Bimage.Width, Bimage.Height);
            BitmapData bmpData =
                Bimage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * Bimage.Height;
            byte[] bgrAValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, bgrAValues, 0, bytes);

            double[] test = new double[Bimage.Height * Bimage.Width];

            MedianFilter(bgrAValues, new int[2] { Bimage.Height, Bimage.Width }, a, b, test);

            System.Runtime.InteropServices.Marshal.Copy(bgrAValues, 0, ptr, bytes);

            Bimage.UnlockBits(bmpData);

            return Bimage;
        }

        public List<double> getCore()
        {
                List<double> Core = new List<double>();
                int a = richTextBox1.Lines.Length;
                int b = richTextBox1.Lines[0].Split(' ').Length;
                bool error = false;
                foreach (string str in richTextBox1.Lines)
                {
                    if (b != str.Split(' ').Length)
                        error = true;
                    foreach (string item in str.Split(' '))
                    {
                       Core.Add(Convert.ToDouble(item));
                    }
                }

            return Core;
        }

        void GetGauss(double[] out_val, double sig, int a, int b)
        {
            for (int i = 0; i < a; ++i)
            {
                int it = i - (a - 1) / 2;
                for (int j = 0; j < b; ++j)
                {
                    int jt = j - (b - 1) / 2;
                    out_val[i * b + j] = (1.0 / (2 * Math.PI * sig * sig)) * Math.Exp(-(it * it + jt * jt) / (2 * sig * sig));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = GavrBinarise(new Bitmap(pictureBox1.Image));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = OtsuBinarise(new Bitmap(pictureBox1.Image));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var newImg = NiblekBinarise(new Bitmap(pictureBox1.Image));
            if (newImg != pictureBox1.Image)
            {
                pictureBox1.Image = newImg;
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = MakeLineFilter(new Bitmap(pictureBox1.Image));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var a = numericUpDown1.Value;
            pictureBox1.Image = MakeMedianFilter(new Bitmap(pictureBox1.Image), (int)a, (int)a);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            double[] rez = new double[(int)numericUpDown1.Value * (int)numericUpDown1.Value];
            GetGauss(rez, (double)numericUpDown2.Value, (int)numericUpDown1.Value, (int)numericUpDown1.Value);

            List<string> str = new List<string>();
            for (int i = 0; i < (int)numericUpDown1.Value; ++i)
            {
                string tmp = "";
                for (int j = 0; j < (int)numericUpDown1.Value; ++j)
                {
                    tmp += Math.Round(rez[i * (int)numericUpDown1.Value + j], 4).ToString();
                    if (j != (int)numericUpDown1.Value - 1)
                        tmp += " ";
                }
                str.Add(tmp);
            }

            richTextBox1.Clear();
            richTextBox1.Lines = str.ToArray();
        }


        double color(double c)
        {
            double ty = c;
            if (c > 255) { ty = 255; }
            if (c < 0) ty = 0;
            return ty;
        }

        private Bitmap furie(Bitmap bitmap)
        {
            var w = bitmap.Width;
            var h = bitmap.Height;

            double[,] iznr = new double[w, h];
            double[,] izng = new double[w, h];
            double[,] iznb = new double[w, h];

            Complex[,] fiznr = new Complex[w, h];
            Complex[,] fizng = new Complex[w, h];
            Complex[,] fiznb = new Complex[w, h];

            Complex[,] fiznr1 = new Complex[h, w];
            Complex[,] fizng1 = new Complex[h, w];
            Complex[,] fiznb1 = new Complex[h, w];

            var fr = new Complex[w * h];
            var fb = new Complex[w * h];
            var fg = new Complex[w * h];
            var fr1 = new Complex[h, w];
            var fb1 = new Complex[h, w];
            var fg1 = new Complex[h, w];
            var start = new Bitmap(w, h);
            var finish = new Bitmap(w, h);
            var Fstart = new Bitmap(w, h);
            var Ffinish = new Bitmap(w, h);

            //заполнение черным
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    Fstart.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                    Ffinish.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                }
            }

            //массив чисел

            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix = bitmap.GetPixel(j, i);
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    iznr[j, i] = r * Math.Pow(-1, i + j);
                    izng[j, i] = g * Math.Pow(-1, i + j);
                    iznb[j, i] = b * Math.Pow(-1, i + j);
                    start.SetPixel(j, i, pix);

                }
            }


            for (int i = 0; i < h; ++i)
            {
                double[] diznr = new double[w];
                double[] dizng = new double[w];
                double[] diznb = new double[w];
                for (int j = 0; j < w; ++j)
                {
                    diznr[j] = iznr[j, i];
                    dizng[j] = izng[j, i];
                    diznb[j] = iznb[j, i];
                }

                var c_iznr = diznr.Select(x => new Complex(x, 0)).ToArray();
                var c_iznb = diznb.Select(x => new Complex(x, 0)).ToArray();
                var c_izng = dizng.Select(x => new Complex(x, 0)).ToArray();
                var fur = DFT(c_iznr, 1.0 / w);
                var fub = DFT(c_iznb, 1.0 / w);
                var fug = DFT(c_izng, 1.0 / w);

                for (int j = 0; j < w; ++j)
                {
                    fiznr[j, i] = fur[j];
                    fizng[j, i] = fug[j];
                    fiznb[j, i] = fub[j];
                }
            }


            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    fiznr1[i, j] = fiznr[j, i];
                    fiznb1[i, j] = fiznb[j, i];
                    fizng1[i, j] = fizng[j, i];
                }
            }

            for (int i = 0; i < w; ++i)
            {
                Complex[] diznr = new Complex[h];
                Complex[] diznb = new Complex[h];
                Complex[] dizng = new Complex[h];
                for (int j = 0; j < h; ++j)
                {
                    diznr[j] = fiznr1[j, i];
                    diznb[j] = fiznb1[j, i];
                    dizng[j] = fizng1[j, i];
                }

                var fur = DFT(diznr, 1.0 / h);
                var fub = DFT(diznb, 1.0 / h);
                var fug = DFT(dizng, 1.0 / h);


                for (int j = 0; j < h; ++j)
                {
                    fr1[j, i] = fur[j];
                    fb1[j, i] = fub[j];
                    fg1[j, i] = fug[j];
                    fr[i + j * w] = fur[j];
                    fb[i + j * w] = fub[j];
                    fg[i + j * w] = fug[j];
                }
            }


            int[] yr = new int[w * h];
            int[] yb = new int[w * h];
            int[] yg = new int[w * h];
            int cg = 0;
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    fr[cg] = fr1[i, j];
                    fb[cg] = fb1[i, j];
                    fg[cg] = fg1[i, j];
                    cg++;
                }


            double er = 5.0;
            var mar = fr[1].Real;
            var mag = fg[1].Real;
            var mab = fb[1].Real;
            //Чисто визуализация
            for (int i = 0; i < fr.Length; i++)
            {
                var gh = Math.Log(fr[i].Imaginary + 1);
                if (gh > mar) mar = gh;
                gh = Math.Log(fb[i].Imaginary + 1);
                if (gh > mab) mab = gh;
                gh = Math.Log(fg[i].Imaginary + 1);
                if (gh > mag) mag = gh;

            }
            var po = 255.0 / er;
            var gi = 1.0;
            if (po < 100) { gi = gi + 0.5 * er; }
            for (int i = 0; i < w * h; ++i)
            {
                yr[i] = (int)color(gi * Math.Log(fr[i].Magnitude + 1) * 255 / mar);
                yb[i] = (int)color(gi * Math.Log(fb[i].Magnitude + 1) * 255 / mab);
                yg[i] = (int)color(gi * Math.Log(fg[i].Magnitude + 1) * 255 / mag);

            }
            yr = yr.Select((x, i) => (x < po) ? (x = 0) : x).ToArray();
            yb = yb.Select((x, i) => (x < po) ? (x = 0) : x).ToArray();
            yg = yg.Select((x, i) => (x < po) ? (x = 0) : x).ToArray();

            for (int j = 0; j < h; ++j)
            {
                for (int i = 0; i < w; ++i)
                {
                    iznr[i, j] = yr[i + j * w];
                    iznb[i, j] = yb[i + j * w];
                    izng[i, j] = yg[i + j * w];
                }
            }

            for (int j = 0; j < w; ++j)
            {
                for (int i = 0; i < h; ++i)
                {
                    var pix = Fstart.GetPixel(j, i);
                    int r = (int)iznr[j, i];
                    int b = (int)iznb[j, i];
                    int g = (int)izng[j, i];
                    Ffinish.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }

            return Ffinish;

        }

        Complex[] DFT(Complex[] x, double n1)
        {
            int N = x.Length;
            Complex[] G = new Complex[N];
            for (int u = 0; u < N; ++u)
            {
                for (int v = 0; v < N; ++v)
                {
                    double fi = -2.0 * Math.PI * u * v / N;
                    G[u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * x[v]);
                }
                G[u] = n1 * G[u];
            }
            return G;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = furie(new Bitmap(pictureBox1.Image));
        }
    }


    public class MyCanvas : Control
    {
        bool PaintComplete = false; 
        public System.Drawing.Image img { get; set; }

        List<int> Values = new List<int>();
        public List<Point> points = new List<Point>() { new Point(0, 0), new Point(255, 255) };
        private Point currentPoint;

        //Таймер для ее обновления
        private Timer timer;

        //битмапы на которых будем рисовать в 2 слоя.
        //На первом будет само содержаение
        //На втором курсор.
        private Bitmap layer1;
        private Bitmap layer2;

        //Графиксы для этих битмапов
        private Graphics g_layer1;
        private Graphics g_layer2;

        private bool painting_mode = false;

        Pen pen = new Pen(Color.FromArgb(255, 0, 80, 0), 1);

        public MyCanvas()
        {
            //Включаем режим двойной буферизации, чтобы рисовка не мерцала.
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            //Опеределяем в нашей канве события
            this.Paint += MyCanvas_Paint;
            this.MouseDown += MyCanvas_MouseDown;
            this.MouseUp += MyCanvas_MouseUp;
            this.MouseMove += MyCanvas_MouseMove;

            this.SizeChanged += MyCanvas_SizeChanged;

            //Запускаем таймер на перерисовку
            timer = new Timer();
            timer.Interval = 25;
            timer.Tick += (s, a) => this.Refresh();
            timer.Start();
        }


        ~MyCanvas()
        {
            if (g_layer1 != null)
                layer1.Dispose();
            if (g_layer2 != null)
                layer2.Dispose();

            if (layer1 != null)
                layer1.Dispose();
            if (layer2 != null)
                layer2.Dispose();

            timer.Dispose();
            pen.Dispose();
        }

        public Bitmap DrawNewImage(Bitmap imageIn)
        {
            var h = imageIn.Height;
            var w = imageIn.Width;

            Bitmap imageOut = new Bitmap(w, h);

           

                for (int i = 0; i < h; i++)
                {
                for (int j = 0; j < w; j++)
                {
                    var img_pix = imageIn.GetPixel(j, i);
                    var r = img_pix.R;
                    var g = img_pix.G;
                    var b = img_pix.B;
                    var currentBrightness = 0.0;
                    Console.WriteLine( (float)currentBrightness);

                    //for (int k = 0; k < points.Count; ++k)
                    //{
                    //    if (points[k].X > j)
                    //    {


                    //        currentBrightness = (float)(j - points[k - 1].X) * (float)((float)(points[k].Y - points[k - 1].Y) / (float)(points[k].X - points[k - 1].X));


                    //        break;
                    //    }
                    //     }



                    var newR = 0;
                    var newB = 0;
                    var newG = 0;

                    //if (r + (int)((currentBrightness - img_pix.GetBrightness()) / 3) > 255)
                    //{
                    //    newR = 255;
                    //}
                    //else if (r + (int)((currentBrightness - img_pix.GetBrightness()) / 3) < 0)
                    //{
                    //    newR = 0;
                    //}
                    //else
                    //{
                    //    newR = r + (int)((currentBrightness - img_pix.GetBrightness()) / 3);
                    //}


                    //if (g + (int)((currentBrightness - img_pix.GetBrightness()) / 3) > 255)
                    //{
                    //    newG = 255;
                    //}
                    //else if (g + (int)((currentBrightness - img_pix.GetBrightness()) / 3) < 0)
                    //{
                    //    newG = 0;
                    //}
                    //else
                    //{
                    //    newG = g + (int)((currentBrightness - img_pix.GetBrightness()) / 3);
                    //}


                    //if (b + (int)((currentBrightness - img_pix.GetBrightness()) / 3) > 255)
                    //{
                    //    newB = 255;
                    //}
                    //else if (b + (int)((currentBrightness - img_pix.GetBrightness()) / 3) < 0)
                    //{
                    //    newB = 0;
                    //}
                    //else
                    //{
                    //    newB = b + (int)((currentBrightness - img_pix.GetBrightness()) / 3);
                    //}

                    if (r + Values[r] > 255)
                    {
                        newR = 255;
                    }
                    else if (r + Values[r] < 0)
                    {
                        newR = 0;
                    }
                    else
                    {
                        newR = r + Values[r];
                    }


                    if (g + Values[g] > 255)
                    {
                        newG = 255;
                    }
                    else if (g + Values[g] < 0)
                    {
                        newG = 0;
                    }
                    else
                    {
                        newG = g + Values[g];
                    }


                    if (b + Values[b] > 255)
                    {
                        newB = 255;
                    }
                    else if (b + Values[b] < 0)
                    {
                        newB = 0;
                    }
                    else
                    {
                        newB = b + Values[b];
                    }

                    imageOut.SetPixel(j, i, Color.FromArgb(newR, newG, newB));
                }
                }

            return imageOut;
        }

        private void MyCanvas_SizeChanged(object sender, EventArgs e)
        {
            var _sender = sender as MyCanvas;

            //При изменении размера у нас должны пересоздатся битмапы (так как нельзя изменить
            // размер битмапа во время работы)
            //По этому мы сначала создаем новые, если старые есть (при создании конвы их нет,
            //вот тут они и создадутся при первом отображении) - рисуем их содержимое на новых, удаляем старые.

            Bitmap new_layer1 = new Bitmap(_sender.Size.Width, _sender.Size.Height, PixelFormat.Format32bppArgb);
            Bitmap new_layer2 = new Bitmap(_sender.Size.Width, _sender.Size.Height, PixelFormat.Format32bppArgb);
            Graphics new_g_layer1 = Graphics.FromImage(new_layer1);
            Graphics new_g_layer2 = Graphics.FromImage(new_layer2);

            if (g_layer1 != null)
            {
                new_g_layer1.DrawImageUnscaled(layer1, 0, 0);
                layer1.Dispose();
            }
            if (layer1 != null)
                layer1.Dispose();


            if (g_layer2 != null)
                layer2.Dispose();
            if (layer2 != null)
                layer2.Dispose();

            layer1 = new_layer1;
            g_layer1 = new_g_layer1;
            layer2 = new_layer2;
            g_layer2 = new_g_layer2;

            LinearGradientBrush linGrBrushVert = new LinearGradientBrush(
               new Point(0, this.Size.Height),
               new Point(this.Size.Width, this.Size.Height - 5),
               Color.FromArgb(255, 0, 0, 0),
               Color.FromArgb(255, 255, 255, 255));

            LinearGradientBrush linGrBrushGor = new LinearGradientBrush(
                new Point(0, this.Size.Height),
                new Point(5, 0),
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 255, 255, 255));

            g_layer1.FillRectangle(linGrBrushVert, new Rectangle(0, this.Size.Height - 5, this.Size.Width, 5));
            g_layer1.FillRectangle(linGrBrushGor, new Rectangle(0, 0, 5, this.Size.Height));
        }

        private void MyCanvas_Paint(object sender, PaintEventArgs e)
        {           
            var mouse_pos = PointToClient(MousePosition);
            int r = 2;
            g_layer2.Clear(Color.FromArgb(0, 0, 0, 0));
            g_layer2.DrawEllipse(pen, mouse_pos.X - r / 2, mouse_pos.Y - r / 2, r, r);

            points = points.OrderBy(p => p.X).ToList();
            for (int i = 0; i < points.Count - 1; ++i)
                if (points[i].X == points[i + 1].X)
                {

                    if (currentPoint == points[i + 1])
                    {
                        Point tmp = new Point(points[i + 1].X + 1, points[i + 1].Y);
                        currentPoint = new Point(tmp.X, tmp.Y);
                        points[i + 1] = tmp;
                    }
                    else
                    {
                        Point tmp = new Point(points[i].X - 1, points[i].Y);
                        currentPoint = new Point(tmp.X, tmp.Y);
                        points[i] = tmp;
                    }

                }

            Values.Clear();

            for (int i = 0; i < points.Count - 1; ++i)
            {
                Point one = PointToMine(points[i]);
                Point two = PointToMine(points[i + 1]);
                g_layer2.DrawLine(pen, one, two);
            }
            for (int i = 0; i < points.Count - 1; ++i)
            {
                float dy = (float)(points[i + 1].Y - points[i].Y) / (points[i + 1].X - points[i].X);
                for (int v = 0; v < points[i + 1].X - points[i].X; ++v)
                {
                    Values.Add(points[i].Y + (int)(dy * v));
                }
            }
            Values.Add(points[points.Count - 1].Y);
            

            Size pointSize = new Size(15, 15);

            for (int i = 0; i < points.Count; ++i)
            {
                Point point = PointToMine(points[i]);
                g_layer2.FillRectangle(Brushes.Red, new Rectangle(new Point(point.X - pointSize.Width / 2, point.Y - pointSize.Height / 2), pointSize));
            }

            e.Graphics.DrawImageUnscaled(layer1, 0, 0);
            e.Graphics.DrawImageUnscaled(layer2, 0, 0);
            
           
        }

        public Point PointToMine(Point pnt)
        {
            return new Point(
                (int)(pnt.X * (float)this.Size.Width / 255),
                (int)((float)this.Size.Height - pnt.Y * (float)this.Size.Height / 255));
        }

        private void MyCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            //при отпускании ЛКМ отключаем режим рисования
            if (e.Button == MouseButtons.Left)
                painting_mode = false;
          

        }

        private static bool PointInRectangle(Point pnt1, Point pnt2, Size size)
        {
            bool result = false;
            if (pnt1.X < pnt2.X + size.Width / 2 && pnt1.X > pnt2.X - size.Width / 2 &&
                pnt1.Y < pnt2.Y + size.Height / 2 && pnt1.Y > pnt2.Y - size.Height / 2)
                result = true;
            return result;
        }

        private Point PointOutOfMine(Point pnt)
        {
            return new Point(
                (int)(((float)pnt.X / this.Size.Width) * 255),
                (int)(((float)(this.Size.Height - pnt.Y) / this.Size.Height) * 255));
        }

        private void MyCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            //при нажании ЛКМ включаем режим рисования
            if (e.Button == MouseButtons.Left)
            {
                PaintComplete = false;
                painting_mode = true;

                bool pointFinded = false;

                var mouse_pos = PointToClient(MousePosition);
                for (int i = 0; i < points.Count; ++i)
                {
                    if (PointInRectangle(mouse_pos, PointToMine(points[i]), new Size(20, 20)))
                    {
                        currentPoint = points[i];
                        pointFinded = true;
                        break;
                    }
                }
                if (!pointFinded &&  points.Count < 13)
                {
                    currentPoint = PointOutOfMine(mouse_pos);
                    points.Add(PointOutOfMine(mouse_pos));
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                PaintComplete = false;
                painting_mode = true;

                var mouse_pos = PointToClient(MousePosition);
                for (int i = 1; i < points.Count - 1; ++i)
                {
                    if (PointInRectangle(mouse_pos, PointToMine(points[i]), new Size(20, 20)))
                    {
                        points.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Если есть режим рисования, то нарисовать красный круг под мышкой.
            //ф-ция вызывается при движении мыши по канве
            if (painting_mode && e.Button != MouseButtons.Right)
            {
                var mouse_pos = PointToClient(MousePosition);

               
                    if (PointInRectangle(mouse_pos, new Point(173, 173), new Size(347, 348)))
                        if (points.IndexOf(currentPoint) == 0 || points.IndexOf(currentPoint) == points.Count - 1)
                        {
                            int index = points.IndexOf(currentPoint);
                            points[index] = new Point(points[index].X, PointOutOfMine(mouse_pos).Y);
                            currentPoint = new Point(points[index].X, PointOutOfMine(mouse_pos).Y);
                        Console.WriteLine("sdf");
                        }
                        else
                        {
                            int index = points.IndexOf(currentPoint);
                            points[index] = PointOutOfMine(mouse_pos);
                            currentPoint = PointOutOfMine(mouse_pos);
                        Console.WriteLine("sdf");
                    }
            }
        }
    }
}


