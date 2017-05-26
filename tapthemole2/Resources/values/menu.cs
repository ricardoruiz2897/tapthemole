using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace tapthemole2
{
	[Activity (Label = "TaptheMole", MainLauncher=true)]			
	public class menu : Activity
	{
		int time = 60;
		int position_x;
		int position_y;
		string high = "0";

		Random px = new Random ();
		Random py = new Random ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.menu);
		
			ImageButton start = FindViewById<ImageButton> (Resource.Id.start);
			ImageButton mole = FindViewById<ImageButton> (Resource.Id.myButton);

			Chronometer crono_menu = FindViewById<Chronometer> (Resource.Id.crono);

			TextView text_time = FindViewById<TextView> (Resource.Id.crono_text);
			TextView highscore = FindViewById<TextView> (Resource.Id.n_highscore);


			var preference = GetSharedPreferences ("mysharedpreference", FileCreationMode.Private);


			high = preference.GetString ("preferencia","0");

			highscore.Text = string.Format ("Highscore: "+high);

			crono_menu.Start ();

			start.Click += delegate {
			
				var second = new Intent(this, typeof(MainActivity));
				second.PutExtra("oldscore",high);
				StartActivity(second);
			};

			crono_menu.ChronometerTick += delegate {
				text_time.Text = string.Format ("Time: {0}", time--);
				moleposition();
				mole.SetX(position_x);
				mole.SetY(position_y);
				//restart chronometer
				if(time==0){
					time=100;
				}
			};
		}

		public void moleposition(){
			var metrics = Resources.DisplayMetrics;

			//declara pixeles
			int pixelestotales_y = metrics.HeightPixels;
			int pixelestotales_x = metrics.WidthPixels;

			//resta para que quede bien en la pantallas
			pixelestotales_x -= 300;
			pixelestotales_y -= 300;

			//genera posicion aleatoria
			position_x = px.Next(0,pixelestotales_x);
			position_y = py.Next(0,pixelestotales_y);

		}

	}
}



