using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureTest
{
    public partial class frmPicTest : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        [DllImport("fileCopyDll.dll", EntryPoint = "FileToBytes", SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern byte* FileToBytes(string path, ref int size);

        [DllImport("fileCopyDll.dll", EntryPoint = "Release", SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void Release(byte* values);

        public frmPicTest()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 20201112
        /// 画像をコピーする(BtimapData + C++のDLL)
        /// ボトルネックとなるストレージへのアクセスをC++で作成
        /// それ以外にもアンマネージドメモリ・BitmapData等で高速化
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public unsafe static Image CopyImage_DLLAndBitmapData(string path)
        {
            Bitmap _ret = null;
            byte* _res = null;
            try
            {
                int _size = 0;
                _res = FileToBytes(path, ref _size);
                using (UnmanagedMemoryStream _mems = new UnmanagedMemoryStream(_res, _size))
                {
                    using (Bitmap _fromFile = new Bitmap(_mems))
                    {
                        _ret = new Bitmap(_fromFile.Width, _fromFile.Height, _fromFile.PixelFormat);
                        BitmapData _bmp1 = _fromFile.LockBits(new Rectangle(0, 0, _fromFile.Width, _fromFile.Height), ImageLockMode.ReadOnly, _fromFile.PixelFormat);
                        BitmapData _bmp2 = _ret.LockBits(new Rectangle(0, 0, _fromFile.Width, _fromFile.Height), ImageLockMode.WriteOnly, _ret.PixelFormat);
                        CopyMemory(_bmp2.Scan0, _bmp1.Scan0, (uint)(_bmp1.Stride * _bmp1.Height));
                        _ret.UnlockBits(_bmp2);
                        _fromFile.UnlockBits(_bmp1);
                    }

                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
            finally
            {
                if(_res != null)
                {
                    Release(_res);
                }
                _res = null;
            }
            return _ret;
        }


        /// <summary>
        /// 20201112
        /// 画像をコピーする(BtimapData + ReadAllBytes)
        /// ボトルネックとなるストレージへのアクセスの高速化を検討
        /// 画像のコピーもBitmapDataで高速化
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public unsafe static Image CopyImage_ReadAllBytes(string path)
        {
            Bitmap _ret = null;
            byte[] _res = null;
            try
            {
                _res = File.ReadAllBytes(path);
                using (MemoryStream _mems = new MemoryStream(_res))
                {
                    using (Bitmap _fromFile = new Bitmap(_mems))
                    {
                        _ret = new Bitmap(_fromFile.Width, _fromFile.Height, _fromFile.PixelFormat);
                        BitmapData _bmp1 = _fromFile.LockBits(new Rectangle(0, 0, _fromFile.Width, _fromFile.Height), ImageLockMode.ReadOnly, _fromFile.PixelFormat);
                        BitmapData _bmp2 = _ret.LockBits(new Rectangle(0, 0, _fromFile.Width, _fromFile.Height), ImageLockMode.WriteOnly, _ret.PixelFormat);
                        CopyMemory(_bmp2.Scan0, _bmp1.Scan0, (uint)(_bmp1.Stride * _bmp1.Height));
                        _ret.UnlockBits(_bmp2);
                        _fromFile.UnlockBits(_bmp1);
                    }

                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
            finally
            {
                _res = null;
            }
            return _ret;
        }

        /// <summary>
        /// 20201112
        /// 画像をコピーする(Usingを小さくする)
        /// (サイズ等、一部の情報が欲しいだけなら、これが速い)
        /// 画像バッファそのものはStreamが閉じると取得できない。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image CopyImage_Using(string path)
        {
            Graphics _gra = null;
            Image _fromFile = null;
            Image _ret = null;
            try
            {
                using (FileStream _fileStream = new FileStream(path, FileMode.Open))
                {
                    _fromFile = Image.FromStream(_fileStream, false, false);
                }
                _ret = new Bitmap(_fromFile.Width, _fromFile.Height);
                _gra = Graphics.FromImage(_ret);
                _gra.DrawImage(_fromFile, new Point(0, 0));
            }
            catch (Exception _ex)
            {
            }
            finally
            {
                if (_gra != null)
                {
                    _gra.Dispose();
                }
                if (_fromFile != null)
                {
                    _fromFile.Dispose();
                    _fromFile = null;
                }

            }
            return _ret;
        }

        /// <summary>
        /// 20201112
        /// 画像をコピーする
        /// FromStreamで高速化できるという情報だったが効果なし
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image CopyImage(string path)
        {
            Graphics _gra = null;
            Image _fromFile = null;
            Image _ret = null;
            try
            {
                using (FileStream _fileStream = new FileStream(path, FileMode.Open))
                {
                    _fromFile = Image.FromStream(_fileStream, false, false);
                    _ret = new Bitmap(_fromFile.Width, _fromFile.Height);
                    _gra = Graphics.FromImage(_ret);
                    _gra.DrawImage(_fromFile, new Point(0, 0));
                }

            }
            catch (Exception _ex)
            {
            }
            finally
            {
                if (_gra != null)
                {
                    _gra.Dispose();
                }
                if (_fromFile != null)
                {
                    _fromFile.Dispose();
                    _fromFile = null;
                }

            }
            return _ret;
        }

        /// <summary>
        /// 20201112
        /// 画像をコピーする(初期)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image CopyImage_Old(string path)
        {
            Graphics _gra = null;
            Image _fromFile = null;
            Image _ret = null;
            try
            {
                _fromFile = Image.FromFile(path);
                _ret = new Bitmap(_fromFile.Width, _fromFile.Height);
                _gra = Graphics.FromImage(_ret);
                _gra.DrawImage(_fromFile, new Point(0, 0));

            }
            catch (Exception _ex)
            {
            }
            finally
            {
                if (_gra != null)
                {
                    _gra.Dispose();
                }
                if (_fromFile != null)
                {
                    _fromFile.Dispose();
                    _fromFile = null;
                }

            }
            return _ret;
        }


        /// <summary>
        /// 画像コピー(初期)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo _dr = new DirectoryInfo(textBox1.Text);
                List<long> _timeList = new List<long>();
                Stopwatch _sw = new Stopwatch();

                foreach (FileInfo _file in _dr.GetFiles("*.bmp", SearchOption.AllDirectories))
                {
                    _sw.Restart();
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Image = CopyImage_Old(_file.FullName);
                    _sw.Stop();
                    _timeList.Add(_sw.ElapsedMilliseconds);
                }
                lblMax1.Text = _timeList.Max().ToString();
                lblAve1.Text = _timeList.Average().ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 画像コピー(ImageFromStream)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo _dr = new DirectoryInfo(textBox1.Text);
                List<long> _timeList = new List<long>();
                Stopwatch _sw = new Stopwatch();
                foreach (FileInfo _file in _dr.GetFiles("*.bmp", SearchOption.AllDirectories))
                {
                    _sw.Restart();
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Image = CopyImage(_file.FullName);
                    _sw.Stop();
                    _timeList.Add(_sw.ElapsedMilliseconds);
                }
                lblMax2.Text = _timeList.Max().ToString();
                lblAve2.Text = _timeList.Average().ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 画像コピー(ImageFromStream+Usingを小さくする)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo _dr = new DirectoryInfo(textBox1.Text);
                List<long> _timeList = new List<long>();
                Stopwatch _sw = new Stopwatch();
                foreach (FileInfo _file in _dr.GetFiles("*.bmp", SearchOption.AllDirectories))
                {
                    _sw.Restart();
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Image = CopyImage_Using(_file.FullName);
                    _sw.Stop();
                    _timeList.Add(_sw.ElapsedMilliseconds);
                }
                lblMax3.Text = _timeList.Max().ToString();
                lblAve3.Text = _timeList.Average().ToString();
            }
            catch
            {

            }
        }
        
        /// <summary>
        /// C++DLL と　BitmapData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo _dr = new DirectoryInfo(textBox1.Text);
                List<long> _timeList = new List<long>();
                Stopwatch _sw = new Stopwatch();
                foreach (FileInfo _file in _dr.GetFiles("*.bmp", SearchOption.AllDirectories))
                {
                    _sw.Restart();

                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Image = CopyImage_DLLAndBitmapData(_file.FullName);
                    _sw.Stop();
                    _timeList.Add(_sw.ElapsedMilliseconds);
                }
                lblMax6.Text = _timeList.Max().ToString();
                lblAve6.Text = _timeList.Average().ToString();
            }
            catch
            {
            }

        }

        /// <summary>
        /// ReadAllBytes+BitmapData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo _dr = new DirectoryInfo(textBox1.Text);
                List<long> _timeList = new List<long>();
                Stopwatch _sw = new Stopwatch();
                foreach (FileInfo _file in _dr.GetFiles("*.bmp", SearchOption.AllDirectories))
                {
                    _sw.Restart();

                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Image = CopyImage_ReadAllBytes(_file.FullName);
                    _sw.Stop();
                    _timeList.Add(_sw.ElapsedMilliseconds);
                }
                lblMax4.Text = _timeList.Max().ToString();
                lblAve4.Text = _timeList.Average().ToString();
            }
            catch
            {
            }
        }
    }
}
