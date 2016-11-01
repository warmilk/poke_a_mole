using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Data.OleDb;
using System.Collections;

namespace poke_a_mole
{
    public partial class Form1 : Form
    {


        int score = 0;  //本关分数
        int scores = 0;  //总分
        int passscore = 1500;    //过关分数
        int[] rd = new int[3];
        int geshu = 0;     //出现地鼠个数
        int rank = 1;     //关卡
        int preparetime = 3;  //准备时间
        int pp = 0;
        int miss;
        int p;
        Random rds = new Random();
        PictureBox[] pb;
        string con;
        OleDbConnection connn;
        public Form1()
        {

            InitializeComponent();
            con = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=Leaderboards.mdb";
            connn = new OleDbConnection(con);
            label1.Parent = pictureBox10;
            label2.Parent = pictureBox10;
            passtext.Parent = pictureBox10;
            passlbl.Parent = passpib;
            label4.Parent = pictureBox11;
            label4.Location = new Point(500, 48);
            label4.Text = rank.ToString();
            pb = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 };
            pcbenabled();
            passtext.Text = passscore.ToString();
            label5.ForeColor = Color.FromArgb(232, 145, 86);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            for (int j = 0; j <= geshu; j++)
            {
                if (((sender as PictureBox).Name == pb[rd[j]].Name) && pp == 1)
                {
                    hit(j);
                }
            }
        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 1)
        //        {
        //            hit(j);
        //        }
        //    }
        //}

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 2)
        //        {
        //            hit(j);
        //        }
        //    }
        //}

        //private void pictureBox4_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 3)
        //        {
        //            hit(j);
        //        }
        //    }
        //}

        //private void pictureBox5_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 4)
        //        {
        //            hit(j);
        //        }
        //    }
        //}

        //private void pictureBox6_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 5)
        //        {
        //            hit(j);
        //        }
        //    }

        //}

        //private void pictureBox7_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 6)
        //        {
        //            hit(j);
        //        }
        //    }

        //}

        //private void pictureBox8_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 7)
        //        {
        //            hit(j);
        //        }
        //    }
        //}

        //private void pictureBox9_Click(object sender, EventArgs e)
        //{
        //    for (int j = 0; j <= geshu; j++)
        //    {
        //        if (rd[j] == 8)
        //        {
        //            hit(j);
        //        }
        //    }

        //}
        /// <summary>
        /// 控制地鼠
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //gamelevel();

            for (int j = 0; j <= geshu; j++)
            {
                miss += 1;
                pb[rd[j]].BackgroundImage = null;
                rd[j] = rds.Next(0, 9);
                //label5.Parent = pb[rd[j]];
                //label5.Visible = true;
                pb[rd[j]].BackgroundImage = global::poke_a_mole.Properties.Resources.地鼠;
                pp = 1;
                label5.Visible = true;
                //label5.Parent = pb[rd[j]];

                //pb[rd[j]].Enabled = true;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ccursorup();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            cursordowm();
        }

        /// <summary>
        /// 正常锤子
        /// </summary>
        public void cursordowm()
        {
            Image fn = poke_a_mole.Properties.Resources.锤子;
            Bitmap bitmap = new Bitmap(fn);
            IntPtr handle = bitmap.GetHicon();
            Cursor myCursor = new Cursor(handle);
            this.Cursor = myCursor;
        }
        /// <summary>
        /// 锤子落下
        /// </summary>
        public void ccursorup()
        {
            Image fn1 = poke_a_mole.Properties.Resources.锤子落下;
            Bitmap bitmap1 = new Bitmap(fn1);
            IntPtr handle1 = bitmap1.GetHicon();
            Cursor myCursor1 = new Cursor(handle1);
            this.Cursor = myCursor1;
        }
        /// <summary>
        /// 击中得分，地鼠变成被打后
        /// </summary>
        public void hit(int j)
        {
            //if (pb[rd[j]].BackgroundImage == global::poke_a_mole.Properties.Resources.地鼠)
            //{
            label5.Text = "+100";
            //for (int p=0; p < 105; p++)
            //    label5.Location = new Point(pb[rd[j]].Location.X + 105, pb[rd[j]].Location.Y + 171+p);

            miss -= 1;
            label1.Text = Convert.ToString(scores += 100);
            label2.Text = Convert.ToString(score += 100);
            label5.Parent = pb[rd[j]];
            //label5.Visible = true;

            pb[rd[j]].BackgroundImage = global::poke_a_mole.Properties.Resources.被打后;
            pp = 0;
            pb[rd[j]].SendToBack();
            label5.BringToFront();
            timer4.Enabled = true;
            //pb[rd[j]].Enabled = false;
            pa();
            //}

        }
        /// <summary>
        /// 判断是否过关
        /// </summary>
        ///   ArrayList name = new ArrayList();
        //ArrayList scoress = new ArrayList();
        public void gamelevel()
        {
            if (scores >= passscore)
            {
                pcbenabled();
                miss -= 1;
                passlbl.Text = "打中" + scores / 100 + "  " + "失误" + miss + "\t\n" + "总分    " + scores.ToString() + "    本关得分" + score.ToString() + "\t\n" + "恭喜通过第" + rank.ToString() + "关";
                passpib.Visible = true;
                passlbl.Visible = true;
                spacepib.Visible = true;
                score = 0;
                passscore += 1500;
                passtext.Text = passscore.ToString();
                label2.Text = score.ToString();

            }
            else
            {
                //string createdb = "INSERT INTO SS(name1,score1)VALUES('炫迈2','" + scores + "');";
                OleDbCommand cmd = new OleDbCommand("SELECT*FROM SS ", connn);
                connn.Open();
                //connn.Open();
                //int rec = cmd.ExecuteNonQuery();
                //cmd.CommandText = "SELECT*FROM SS";
                OleDbDataReader odr = cmd.ExecuteReader();
                ArrayList name = new ArrayList();
                ArrayList scoress = new ArrayList();
                while (odr.Read())
                {
                    scoress.Add(odr["score1"]);
                    name.Add(odr["name1"]);
                }
                connn.Close();
                for (int j = 0; j < scoress.Count; j++)
                {
                    if (scores > (int)scoress[j])
                    {
                        f2 f2 = new f2();
                        f2.ShowDialog(this);
                        string createdb = "INSERT INTO SS(name1,score1)VALUES('" + f2.aaa + "','" + scores + "');";
                        cmd = new OleDbCommand(createdb, connn);
                        connn.Open();
                        int k = cmd.ExecuteNonQuery();
                        //createdb = "DELETE FROM SS WHERE ID=" + scroess.Count + ";";
                        //cmd = new OleDbCommand(createdb, connn);
                        //k = cmd.ExecuteNonQuery();

                        cmd = new OleDbCommand("SELECT*FROM ss ORDER BY score1 DESC", connn);
                        
                        OleDbDataReader odr1 = cmd.ExecuteReader();
                        scoress.Clear();
                        name.Clear();
                        while (odr1.Read())
                        {
                            scoress.Add(odr1["score1"]);
                            name.Add(odr1["name1"]);
                        }
                        //int q = name.Count;
                        //while (odr.Read())
                        //{
                        //    scoress.Add(odr["score1"]);
                        //    name.Add(odr["name1"]);
                        //}
                        //name.Add(name[q-1]);
                        //scoress.Add(scoress[5]);
                        //for (; q >= j; q--)
                        //{
                        //    if (q >= j)
                        //    {
                        //        scoress[q-1] = scoress[q-2 ];
                        //        name[q-1] = name[q-2 ];
                        //    }
                        //    else
                        //    {
                        //        scoress[j] = score;
                        //        name[j] = f2.aaa;
                        //    }
                        //}
                        break;
                    }
                }
                //scroess.Clear();

                odr.Dispose();
                //OleDbDataReader odr1 = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                //while (odr1.Read())
                //{
                //    scroess.Add(odr1["score1"]);
                //    name.Add(odr1["name1"]);
                //}
                connn.Close();

                cmd.Clone();
                string sss = "";
                textBox1.Text = scoress.Count.ToString();
                for (int o = 0; o < scoress.Count; o++)
                {
                    sss += name[o] + "   " + scoress[o] + "\n\t";
                }
                name.Clone();
                scoress.Clear();
                MessageBox.Show(sss);
                //createdb = "SELECT*FROM ss";
                //cmd = new OleDbCommand(createdb, connn);
                //DataSet ds = new DataSet();
                //cmd.Fill()



                MessageBox.Show("Game Over！", "返回", MessageBoxButtons.OK);
                startinterface();
            }
            if (rank == 4)
            {
                geshu = 1;
            }
        }

        private void start_Click(object sender, EventArgs e)//新游戏
        {

            label3.Width = 300;
            rank = 1;
            geshu = 0;
            score = 0;
            scores = 0;
            miss = 0;
            prepare.Visible = prepare.Visible ? false : true;
            timer2.Enabled = timer2.Enabled ? false : true;
            startinterface();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("是否退出游戏?", "退出", MessageBoxButtons.OKCancel)) == DialogResult.OK)
            {
                Close();
            }


        }

        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            preparetime -= 1;
            if (preparetime == -1)
            {
                prepare.Visible = prepare.Visible ? false : true;
                for (int j = 0; j < 9; j++)
                {
                    pb[j].Enabled = true;
                }
                timer2.Enabled = false;
                timer3.Enabled = true;
                timer1.Enabled = true;
                label3.Visible = true;
                preparetime = 3;
            }
            //if (preparetime == 0)
            //{
            //    prepare.Text = "开始";
            //}
            //else
            //{
            prepare.Text = preparetime.ToString();
            //}
        }

        private void continue1_Click(object sender, EventArgs e)
        {
            prepare.Visible = prepare.Visible ? false : true;
            timer2.Enabled = true;
            startinterface();
        }
        /// <summary>
        /// 开始界面控件
        /// </summary>
        public void startinterface()
        {
            start.Visible = start.Visible ? false : true;
            pictureBox12.Visible = pictureBox12.Visible ? false : true;
            continue1.Visible = exit.Visible ? false : true;
            set.Visible = set.Visible ? false : true;
            explain.Visible = explain.Visible ? false : true;
            exit.Visible = exit.Visible ? false : true;
        }

        /// <summary>
        /// 地鼠是否可以打
        /// </summary>
        public void pcbenabled()
        {
            for (int j = 0; j < 9; j++)
            {
                pb[j].Enabled = pb[j].Enabled ? false : true;
            }
            pb[rd[0]].BackgroundImage = null;
            pb[rd[1]].BackgroundImage = null;
            //for (int j = 0; j <= geshu; j++)
            //{
            //    pb[rd[j]].Visible = false;
            //}
        }

        private void set_Click(object sender, EventArgs e)
        {
            returnmenu.Visible = returnmenu.Visible ? false : true;
            setmenu.Visible = setmenu.Visible ? false : true;
            startinterface();
        }

        private void returnmenu_Click(object sender, EventArgs e)
        {
            returnmenu.Visible = false;
            setmenu.Visible = false;
            startinterface();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Escape) && (timer1.Enabled == true))
            {
                pcbenabled();
                startinterface();
                timer1.Enabled = false;
                timer3.Enabled = false;
            }
        }

        private void spacepib_Click(object sender, EventArgs e)
        {
            spacepib.Visible = false;
            passlbl.Visible = false;
            passpib.Visible = false;
            rank++;
            label4.Text = rank.ToString();
            label3.Width = 300;
            prepare.Visible = true;
            timer2.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (label3.Width == 300)
                label3.BackColor = Color.FromArgb(45, 207, 75);
            label3.Width -= 1;
            if (label3.Width == 100)
                label3.BackColor = Color.FromArgb(207, 45, 79);
            if (label3.Width == 0)
            {
                label3.BackColor = Color.FromArgb(45, 207, 75);
                timer1.Enabled = false;
                timer3.Enabled = false;
                gamelevel();
            }
        }

        private void explain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("每关游戏时间30秒，打中地鼠加100分，不打中不扣分，\t\n时间结束后总分大于等于过分分数则通关。\t\n游戏过程中按左上角esc暂停游戏。\t\n");
        }

        /// <summary>
        /// 声音：啪
        /// </summary>
        public void pa()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"539034e1a52cf.wav";
            player.Load();
            player.Play();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //label5.Parent = pb[rd[0]];
            if (p < 92)
            {
                label5.Location = new Point(30, 92 - p);
                p++;
            }
            else
            {
                p = 0;
                timer4.Enabled = false;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            //string con;
            //con = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=Leaderboards.mdb";
            //OleDbConnection connn = new OleDbConnection(con);
            //string createdb = "INSERT INTO SS(name1,score1)VALUES('炫迈','" + scores + "');";
            //OleDbCommand cmd = new OleDbCommand(createdb, connn);
            //connn.Open();
            //int rec = cmd.ExecuteNonQuery();
            //connn.Close();
            //cmd = null;
            //connn.Dispose();
            //try
            //{
            //    int rec = cmd.ExecuteNonQuery();
            //    label6.Text = rec.ToString();
            //}
            //catch
            //{
            //    label6.Text = "失败";
            //}
            //finally
            //{
            //    connn.Close();
            //}



        }

    }
}
