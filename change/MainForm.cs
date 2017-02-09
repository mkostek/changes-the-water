/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: massi
 * Tarih: 25.10.2016
 * Zaman: 14:12
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace change
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		public bool hulle=false;
		public struct hal{
			public double katı;
			public double sıvı;
			public double gaz;
			public void y(){
				katı=0;
				sıvı=0;
				gaz=0;
			}
		};
		public struct cisim
		{
			public hal kutle;
			public double sıcaklık;
		};
		cisim[] fa=new cisim[2];
		Random r=new Random();
		int x=0;
		int y=0;
		int hassas=25;
		bool suruklenmedurumu = false; //Class seviyesinde bir field(değişken) tanımlıyoruz ki,MouseDown da biz bunu true yapacağız,MouseUpta false değerini alacak ve MouseMove eventında true ise hareket edecek.
		Point ilkkonum; //Global bir değişken tanımlıyoruz ki, ilk tıkladığımız andaki konumunu çıkarmadığımızda buton mouse imlecinden daha aşağıdan hareket edecektir.
		private void Down(object sender, MouseEventArgs e)
		{
			suruklenmedurumu = true; //işlemi burada true diyerek başlatıyoruz.
			((Button)sender).Cursor = Cursors.SizeAll; //SizeAll yapmamımızın amacı taşırken hoş görüntü vermek için
			ilkkonum = e.Location; //İlk konuma gördüğünüz gibi değerimizi atıyoruz.
		}
		private void Move(object sender, MouseEventArgs e)
		{
			if (suruklenmedurumu) // suruklenmedurumu==true ile aynı.
			{
				((Button)sender).Left = e.X + ((Button)sender).Left - (ilkkonum.X);
				// button.left ile soldan uzaklığını ayarlıyoruz. Yani e.X dediğimizde buton üzerinde mouseun hareket ettiği pixeli alacağız + butonun soldan uzaklığını ekliyoruz son olarakta ilk mouseın tıklandığı alanı çıkarıyoruz yoksa butonun en solunda olur mouse imleci. Alttakide aynı şekilde Y koordinati için geçerli
				((Button)sender).Top = e.Y + ((Button)sender).Top - (ilkkonum.Y);
			}
		}
		private void Up(object sender, MouseEventArgs e)
		{
			suruklenmedurumu = false; //Sol tuştan elimizi çektik artık yani sürükle işlemi bitti.
			((Button)sender).Cursor = Cursors.Default; //İmlecimiz(Cursor) default değerini alıyor.
		}
		public bool kontrol(Button b1,Button b2)
		{
			int a,b,c,d;
			a=(b1.Right-b2.Left)*(b2.Bottom-b1.Top);
			b=(b1.Bottom-b2.Top)*(b1.Right-b2.Left);
			c=(b1.Bottom-b2.Top)*(b2.Right-b1.Left);
			d=(b2.Bottom-b1.Top)*(b2.Right-b1.Left);
			if(a>0&&b>0&&c>0&&d>0)
				return true;
			else return false;
		}
		public void hesapla(){
			if(fa[0].sıcaklık>99){
				fa[0].kutle.gaz=button1.Width*button1.Height/100;
				fa[0].kutle.sıvı=0;
				fa[0].kutle.katı=0;
			}else if(fa[0].sıcaklık>0){
				fa[0].kutle.sıvı=button1.Width*button1.Height/100;
				fa[0].kutle.gaz=0;
				fa[0].kutle.katı=0;
			}else if(fa[0].sıcaklık<=0){
				fa[0].kutle.katı=button1.Width*button1.Height/100;
				fa[0].kutle.gaz=0;
				fa[0].kutle.sıvı=0;
			}
			
			
			if(fa[1].sıcaklık>99){
				fa[1].kutle.gaz=button2.Width*button2.Height/100;
				fa[1].kutle.sıvı=0;
				fa[1].kutle.katı=0;
			}else if(fa[1].sıcaklık>0){
				fa[1].kutle.sıvı=button2.Width*button2.Height/100;
				fa[1].kutle.gaz=0;
				fa[1].kutle.katı=0;
			}else if(fa[1].sıcaklık<=0){
				fa[1].kutle.katı=button2.Width*button2.Height/100;
				fa[1].kutle.gaz=0;
				fa[1].kutle.sıvı=0;
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			//comboBox3
			comboBox1.SelectedIndex=0;
			comboBox2.SelectedIndex=0;
			timer1.Start();
			
			
			

			x=(int)(fa[0].sıcaklık*2.55);
			y=(int)(fa[1].sıcaklık*2.55);
		}
		public void donusum(){
			double enerji=0;
			if(fa[0].sıcaklık>fa[1].sıcaklık&&!hulle){
				enerji=0;
				if(fa[0].sıcaklık==100 && fa[1].sıcaklık<100 && (int)fa[0].kutle.gaz>0){
					fa[0].kutle.gaz--;
					fa[0].kutle.sıvı++;
					enerji=540;
				}else{
					enerji=fa[0].kutle.sıvı;
					fa[0].sıcaklık--;
				}
				if(fa[1].sıcaklık<0){
					fa[1].sıcaklık+=enerji/(fa[1].kutle.katı*0.5);
					if(fa[1].sıcaklık>0){
						fa[1].sıcaklık=0;
					}
				}else if((int)fa[1].sıcaklık==0 && (int)fa[1].kutle.katı>0){
					double miktar=enerji/80;
					fa[1].kutle.katı-=miktar;
					fa[1].kutle.sıvı+=miktar;
				}else{
					fa[1].sıcaklık+=enerji/fa[1].kutle.sıvı;
				}

			}else if(fa[0].sıcaklık<fa[1].sıcaklık&&hulle){
				enerji=0;
				if(fa[1].sıcaklık==100 && fa[0].sıcaklık<100 && (int)fa[1].kutle.gaz>0){
					fa[1].kutle.gaz--;
					fa[1].kutle.sıvı++;
					enerji=540;
				}else{
					enerji=fa[1].kutle.sıvı;
					fa[1].sıcaklık--;
				}
				if(fa[0].sıcaklık<0){
					fa[0].sıcaklık+=enerji/(fa[0].kutle.katı*0.5);
					if(fa[0].sıcaklık>0){
						fa[0].sıcaklık=0;
					}
				}else if((int)fa[0].sıcaklık==0 && (int)fa[0].kutle.katı>0){
					double miktar=enerji/80;
					fa[0].kutle.katı-=miktar;
					fa[0].kutle.sıvı+=miktar;
				}else{
					fa[0].sıcaklık+=enerji/fa[0].kutle.sıvı;
				}

			}
			chartBirinciDerece.Series[0].Points.AddXY(x,fa[1].sıcaklık);
			chartBirinciDerece.Series[1].Points.AddXY(x,fa[0].sıcaklık);x++;
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			
			if(kontrol(button1,button2)){
				donusum();
			}
			button1.Text=(int)fa[0].sıcaklık+" C"+"\nkatı"+(int)fa[0].kutle.katı+" gr\nsıvı"+(int)fa[0].kutle.sıvı+" gr\ngaz"+(int)fa[0].kutle.gaz+" gr";
			button2.Text=(int)fa[1].sıcaklık+" C"+"\nkatı"+(int)fa[1].kutle.katı+" gr\nsıvı"+(int)fa[1].kutle.sıvı+" gr\ngaz"+(int)fa[1].kutle.gaz+" gr";
			
			/*	x=(int)(fa[0].sıcaklık*2.55);
			y=(int)(fa[1].sıcaklık*2.55);
			button1.BackColor=Color.FromArgb(x,255,255);
			button2.BackColor=Color.FromArgb(y,255,255);*/
		}

		

		
		void Button3Click(object sender, EventArgs e)
		{
				int a;
			int c=0;
			a=Convert.ToInt32(textBox1.Text);
			switch(comboBox2.SelectedIndex)
			{
					case 0:c=0;break;
					case 1:c=1;break;
					default:break;
			}
			if(a is int){
				switch(comboBox1.SelectedIndex){
					case 0:
						if(a>0)
							MessageBox.Show("katı halde sıcaklık 0 veya daha düşük olmalıdır..");
						else fa[c].sıcaklık=a;break;
					case 1:
						if(a>99||a<=0)MessageBox.Show("sıvı halde sıcaklık 0 dan küçük  ve 100 den büyük olmamalıdır..");
						else fa[c].sıcaklık=a;break;
					case 2:
						if(a!=100)MessageBox.Show("gaz halde sıcaklık 100 den farklı değer giremezsiniz...");
						else fa[c].sıcaklık=a;break;
				}
			}
			double ci=Math.Sqrt(Convert.ToInt32(textBox2.Text))*10;
			if(!Convert.ToBoolean(c)){
				button1.Width=(int)ci;
				button1.Height=(int)ci;
			}else{
				button2.Width=(int)ci;
				button2.Height=(int)ci;
			}
			if(fa[0].sıcaklık>fa[1].sıcaklık){
				hulle=false;
			}else{
				hulle=true;
			}
			hesapla();
			chartBirinciDerece.Series[0].Points.Clear();
			chartBirinciDerece.Series[1].Points.Clear();
		}
	}
}
