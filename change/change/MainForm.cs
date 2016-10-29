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
		public bool carpma()
		{
			
			bool[] b=new bool[3];
			b[2]=false;
			b[0]=button1.Location.X-hassas<button2.Location.X && button1.Location.X+hassas>button2.Location.X;
			b[1]=button1.Location.Y-hassas<button2.Location.Y && button1.Location.Y+hassas>button2.Location.Y;
			if(b[0]&&b[1]){
				b[2]=b[0]&&b[1];
			}
			return b[2];
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			timer1.Start();
			fa[0].sıcaklık=r.Next(100,101);
			if(fa[0].sıcaklık>99){
				fa[0].kutle.gaz=button1.Width*button1.Height/100;	
			}else if(fa[0].sıcaklık>0){
				fa[0].kutle.sıvı=button1.Width*button1.Height/100;
			}else if(fa[0].sıcaklık<0){
				fa[0].kutle.katı=button1.Width*button1.Height/100;
			}
			
			fa[1].sıcaklık=r.Next(-100,0);
			if(fa[1].sıcaklık>99){
				fa[1].kutle.gaz=button2.Width*button2.Height/100;	
			}else if(fa[1].sıcaklık>0){
				fa[1].kutle.sıvı=button2.Width*button2.Height/100;
			}else if(fa[1].sıcaklık<0){
				fa[1].kutle.katı=button2.Width*button2.Height/100;
			}
			

			x=(int)(fa[0].sıcaklık*2.55);
			y=(int)(fa[1].sıcaklık*2.55);
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			double enerji=0;
			if(carpma()){
				if(fa[0].sıcaklık>fa[1].sıcaklık){
					if(fa[0].sıcaklık>99 && (int)fa[0].kutle.gaz>0){
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
					
				}
			chartBirinciDerece.Series[0].Points.AddXY(x,fa[0].sıcaklık);
			chartBirinciDerece.Series[1].Points.AddXY(x,fa[1].sıcaklık);x++;
			}
			button1.Text=(int)fa[0].sıcaklık+" C"+"\nkatı"+fa[0].kutle.katı+" gr\nsıvı"+fa[0].kutle.sıvı+" gr\ngaz"+fa[0].kutle.gaz+" gr";
			button2.Text=(int)fa[1].sıcaklık+" C"+"\nkatı"+fa[1].kutle.katı+" gr\nsıvı"+fa[1].kutle.sıvı+" gr\ngaz"+fa[1].kutle.gaz+" gr";
			
		/*	x=(int)(fa[0].sıcaklık*2.55);
			y=(int)(fa[1].sıcaklık*2.55);
			button1.BackColor=Color.FromArgb(x,255,255);
			button2.BackColor=Color.FromArgb(y,255,255);*/
		}
		void Button1Click(object sender, EventArgs e)
		{
	
		}
	}
}
