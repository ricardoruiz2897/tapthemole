using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;


namespace tapthemole2
{
	[Activity (Label = "TaptheMole", NoHistory=true)]
	public class MainActivity : Activity
	{
		int score = 0;
		int time = 0;
		int risa = 0;
		int count_risa = 0;
		int algo = 0;

		//string for saving score
		string old;
		int _oldhighscore; 
		int count = 0;

		string nuevoscore;

		bool _gameover = false;

		Random px = new Random();
		Random py = new Random();

		float position_x;
		float position_y;

		//MediaPlayer _jaja;

		ImageButton bomba_1; ImageButton bomba_2; ImageButton bomba_3;
		ImageButton bomba_4; ImageButton bomba_5; ImageButton bomba_6;
		ImageButton bomba_7; ImageButton bomba_8; ImageButton bomba_9;
		ImageButton bomba_10;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			ImageButton mole = FindViewById<ImageButton> (Resource.Id.myButton);
			ImageButton flecha = FindViewById<ImageButton> (Resource.Id.flechatras);

			//chronometer generate the event that makes the object move
			Chronometer m_move = FindViewById<Chronometer> (Resource.Id.mole_move);
			Chronometer cron_principal = FindViewById<Chronometer> (Resource.Id.principal);

			TextView text_score = FindViewById<TextView> (Resource.Id.score);
			TextView text_time = FindViewById<TextView> (Resource.Id.time);
			TextView time_over = FindViewById<TextView> (Resource.Id.time_over);

			/*
			bomba_1 = FindViewById <ImageButton> (Resource.Id.bomba1);
			bomba_2 = FindViewById <ImageButton> (Resource.Id.bomba2);
			bomba_3 = FindViewById <ImageButton> (Resource.Id.bomba3);
			bomba_4 = FindViewById <ImageButton> (Resource.Id.bomba4);
			bomba_5 = FindViewById <ImageButton> (Resource.Id.bomba5);
			bomba_6 = FindViewById <ImageButton> (Resource.Id.bomba6);
			bomba_7 = FindViewById <ImageButton> (Resource.Id.bomba7);
			bomba_8 = FindViewById <ImageButton> (Resource.Id.bomba8);
			bomba_9 = FindViewById <ImageButton> (Resource.Id.bomba9);
			bomba_10 = FindViewById <ImageButton> (Resource.Id.bomba10);
			*/

			if (count == 0) {
				old = Intent.GetStringExtra ("oldscore") ?? "0";
				_oldhighscore = Convert.ToInt32 (old); 
				_oldhighscore = int.Parse (old);
				count = count + 1;
			}


			//start chronometer and animation
			cron_principal.Start ();
			m_move.Start ();

			flecha.Enabled = false; 
			flecha.Activated = false;
			flecha.Click += delegate {
				newhighscore();
			};

			//event from chonometer
			cron_principal.ChronometerTick += delegate {
				text_time.Text = string.Format("Time: {0}", time++);
				if(time<10){
					deshabilitatodo();
				}
				if(time>10){
					unoydos();
				}
				if(time>20){
					tresycuatro();
				}
				if(time>30){
					cincoyseis();
				}
				if(time>40){
					sieteyocho();
				}
				if(time>50){
					nueveydiez();
				}
			};

			m_move.ChronometerTick += delegate {
				posicionaleatoria();
				laugh();
			};

			/******************************
               Click principal
               ****************************/
			mole.Click += delegate {
				score++;
				text_score.Text= string.Format("Score: {0}", score);
				posicionaleatoria();
				if(score>_oldhighscore){
					time_over.Visibility = ViewStates.Visible; //make timeover ad visible
				}
			};

			bomba_1.Click += delegate {
				gameover();
			};
			bomba_2.Click += delegate {
				gameover();
			};
			bomba_3.Click += delegate {
				gameover();
			};
			bomba_4.Click += delegate {
				gameover();
			};
			bomba_5.Click += delegate {
				gameover();
			};
			bomba_6.Click += delegate {
				gameover();
			};
			bomba_7.Click += delegate {
				gameover();
			};
			bomba_8.Click += delegate {
				gameover();
			};
			bomba_9.Click += delegate {
				gameover();
			};
			bomba_10.Click += delegate {
				gameover();
			};
		}

		public void posicionaleatoria(){
			ImageButton mole = FindViewById<ImageButton> (Resource.Id.myButton);

			var metrics = Resources.DisplayMetrics; //resource that has the function for sceen sizze

			int pixelestotales_y = metrics.HeightPixels; //height of screen
			int pixelestotales_x = metrics.WidthPixels; //width of screen

			pixelestotales_x -= 300; //We have to substract 300 to the screen size, that way the object wont go out of the screen
			pixelestotales_y -= 300;

			position_x = px.Next(0,pixelestotales_x);
			position_y = py.Next(0,pixelestotales_y);
			mole.SetX (position_x);
			mole.SetY (position_y);
		}

		public void laugh(){
			//_jaja = MediaPlayer.Create(this, Resource.Raw.jaja);<---activate when I want sound
			count_risa++;
			risa = count_risa % 5;
			if(risa==0){
				//_jaja.Start ();
			}
		}

		public void unoydos(){
			bomba_1 = FindViewById <ImageButton> (Resource.Id.bomba1);
			bomba_2 = FindViewById <ImageButton> (Resource.Id.bomba2);

			bomba_1.Enabled = true; bomba_1.Visibility = ViewStates.Visible;
			bomba_2.Enabled = true; bomba_2.Visibility = ViewStates.Visible;

			var metrics = Resources.DisplayMetrics;

			//bomba1
			int bomba1_y = metrics.HeightPixels;
			int bomba1_x = metrics.WidthPixels;

			//bomba2
			int bomba2_y = metrics.HeightPixels;
			int bomba2_x = metrics.WidthPixels;

			Random b1_x = new Random ();
			Random b1_y = new Random ();

			Random b2_y = new Random ();
			Random b2_x = new Random ();

			int b1x = b1_x.Next (0, (bomba1_x-300));
			int b1y = b1_y.Next (0, (bomba1_y-300));	

			int b2x = b1_x.Next (0, (bomba2_x-300));
			int b2y = b1_y.Next (0, (bomba2_y-300));	

			bomba_1.SetX (b1x);
			bomba_1.SetY (b1y);

			bomba_2.SetX (b2x);
			bomba_2.SetY (b2y);

		}

		public void tresycuatro(){
			bomba_3 = FindViewById <ImageButton> (Resource.Id.bomba3);
			bomba_4 = FindViewById <ImageButton> (Resource.Id.bomba4);

			bomba_3.Enabled = true; bomba_3.Visibility = ViewStates.Visible;
			bomba_4.Enabled = true; bomba_4.Visibility = ViewStates.Visible;

			var metrics = Resources.DisplayMetrics;

			//bomba1
			int bomba3_y = metrics.HeightPixels;
			int bomba3_x = metrics.WidthPixels;

			//bomba2
			int bomba4_y = metrics.HeightPixels;
			int bomba4_x = metrics.WidthPixels;

			Random b3_x = new Random ();
			Random b3_y = new Random ();

			Random b4_y = new Random ();
			Random b4_x = new Random ();

			int b3x = b3_x.Next (0, (bomba3_x-300));
			int b3y = b3_y.Next (0,(bomba3_y-300));	

			int b4x = b4_x.Next (0, (bomba4_x-300));
			int b4y = b4_y.Next (0, (bomba4_y-300));	

			bomba_3.SetX (b3x);
			bomba_3.SetY (b3y);

			bomba_4.SetX (b4x);
			bomba_4.SetY (b4y);

		}
		public void cincoyseis(){
			bomba_5 = FindViewById <ImageButton> (Resource.Id.bomba5);
			bomba_6 = FindViewById <ImageButton> (Resource.Id.bomba6);

			bomba_5.Enabled = true; bomba_5.Visibility = ViewStates.Visible;
			bomba_6.Enabled = true; bomba_6.Visibility = ViewStates.Visible;

			var metrics = Resources.DisplayMetrics;

			//bomba1
			int bomba5_y = metrics.HeightPixels;
			int bomba5_x = metrics.WidthPixels;

			//bomba2
			int bomba6_y = metrics.HeightPixels;
			int bomba6_x = metrics.WidthPixels;

			Random b5_x = new Random ();
			Random b5_y = new Random ();

			Random b6_y = new Random ();
			Random b6_x = new Random ();

			int b5x = b5_x.Next (0, (bomba5_x-300));
			int b5y = b5_y.Next (0, (bomba5_y-300));	

			int b6x = b6_x.Next (0, (bomba6_x-300));
			int b6y = b6_y.Next (0, (bomba6_y-300));	

			bomba_5.SetX (b5x);
			bomba_5.SetY (b5y);

			bomba_6.SetX (b6x);
			bomba_6.SetY (b6y);

		}
		public void sieteyocho(){
			bomba_7 = FindViewById <ImageButton> (Resource.Id.bomba7);
			bomba_8 = FindViewById <ImageButton> (Resource.Id.bomba8);

			bomba_7.Enabled = true; bomba_7.Visibility = ViewStates.Visible;
			bomba_8.Enabled = true; bomba_8.Visibility = ViewStates.Visible;

			var metrics = Resources.DisplayMetrics;

			//bomba1
			int bomba7_y = metrics.HeightPixels;
			int bomba7_x = metrics.WidthPixels;

			//bomba2
			int bomba8_y = metrics.HeightPixels;
			int bomba8_x = metrics.WidthPixels;

			Random b7_x = new Random ();
			Random b7_y = new Random ();

			Random b8_y = new Random ();
			Random b8_x = new Random ();

			int b7x = b7_x.Next (0, (bomba7_x-300));
			int b7y = b7_y.Next (0, (bomba7_y-300));	

			int b8x = b8_x.Next (0, (bomba8_x-300));
			int b8y = b8_y.Next (0, (bomba8_y-300));	

			bomba_7.SetX (b7x);
			bomba_7.SetY (b7y);

			bomba_8.SetX (b8x);
			bomba_8.SetY (b8y);

		}
		public void nueveydiez(){
			bomba_9 = FindViewById <ImageButton> (Resource.Id.bomba9);
			bomba_10 = FindViewById <ImageButton> (Resource.Id.bomba10);

			bomba_9.Enabled = true; bomba_9.Visibility = ViewStates.Visible;
			bomba_10.Enabled = true; bomba_10.Visibility = ViewStates.Visible;

			var metrics = Resources.DisplayMetrics;

			//bomba1
			int bomba9_y = metrics.HeightPixels;
			int bomba9_x = metrics.WidthPixels;

			//bomba2
			int bomba10_y = metrics.HeightPixels;
			int bomba10_x = metrics.WidthPixels;

			Random b9_x = new Random ();
			Random b9_y = new Random ();

			Random b10_y = new Random ();
			Random b10_x = new Random ();

			int b9x = b9_x.Next (0, (bomba9_x-300));
			int b9y = b9_y.Next (0, (bomba9_y-300));	

			int b10x = b10_x.Next (0, (bomba10_x-300));
			int b10y = b10_y.Next (0, (bomba10_y-300));	

			bomba_9.SetX (b9x);
			bomba_9.SetY (b9y);

			bomba_10.SetX (b10x);
			bomba_10.SetY (b10y);

		}
		public void deshabilitatodo(){
			ImageButton bomba_1; ImageButton bomba_2; ImageButton bomba_3;
			ImageButton bomba_4; ImageButton bomba_5; ImageButton bomba_6;
			ImageButton bomba_7; ImageButton bomba_8; ImageButton bomba_9;
			ImageButton bomba_10;

			bomba_1 = FindViewById <ImageButton> (Resource.Id.bomba1);
			bomba_2 = FindViewById <ImageButton> (Resource.Id.bomba2);
			bomba_3 = FindViewById <ImageButton> (Resource.Id.bomba3);
			bomba_4 = FindViewById <ImageButton> (Resource.Id.bomba4);
			bomba_5 = FindViewById <ImageButton> (Resource.Id.bomba5);
			bomba_6 = FindViewById <ImageButton> (Resource.Id.bomba6);
			bomba_7 = FindViewById <ImageButton> (Resource.Id.bomba7);
			bomba_8 = FindViewById <ImageButton> (Resource.Id.bomba8);
			bomba_9 = FindViewById <ImageButton> (Resource.Id.bomba9);
			bomba_10 = FindViewById <ImageButton> (Resource.Id.bomba10);

			ImageButton flecha = FindViewById<ImageButton> (Resource.Id.flechatras);

			bomba_1.Enabled = false; bomba_1.Visibility = ViewStates.Invisible;
			bomba_2.Enabled = false; bomba_2.Visibility = ViewStates.Invisible;
			bomba_3.Enabled = false; bomba_3.Visibility = ViewStates.Invisible;
			bomba_4.Enabled = false; bomba_4.Visibility = ViewStates.Invisible;
			bomba_5.Enabled = false; bomba_5.Visibility = ViewStates.Invisible;
			bomba_6.Enabled = false; bomba_6.Visibility = ViewStates.Invisible;
			bomba_7.Enabled = false; bomba_7.Visibility = ViewStates.Invisible;
			bomba_8.Enabled = false; bomba_8.Visibility = ViewStates.Invisible;
			bomba_9.Enabled = false; bomba_9.Visibility = ViewStates.Invisible;
			bomba_10.Enabled = false; bomba_10.Visibility = ViewStates.Invisible;

			//la flecha se activa para poder regresar 
			if(algo==1){
				flecha.Enabled = true; flecha.Visibility = ViewStates.Visible; flecha.Activated = true;
			}
		}

		public void gameover(){
			ImageButton mole = FindViewById<ImageButton> (Resource.Id.myButton);

			Chronometer m_move = FindViewById<Chronometer> (Resource.Id.mole_move);
			Chronometer cron_principal = FindViewById<Chronometer> (Resource.Id.principal);

			TextView text_score = FindViewById<TextView> (Resource.Id.score);
			TextView text_time = FindViewById<TextView> (Resource.Id.time);
			TextView time_over = FindViewById<TextView> (Resource.Id.time_over);

			time_over.Text = string.Format ("Game over!!!");
			cron_principal.Stop();
			m_move.Stop();
			mole.Enabled = false;
			_gameover = true;
			algo = algo + 1;
			deshabilitatodo ();
		}

		public void newhighscore(){
			if(score>_oldhighscore && _gameover == true){
				_oldhighscore = score;
			}
			passdatabetweenactivities ();
		}

		public void passdatabetweenactivities(){
			nuevoscore = Convert.ToString(_oldhighscore);

			//salvar record permanente
			var preference = GetSharedPreferences ("mysharedpreference", FileCreationMode.Private);
			var editpreference = preference.Edit ();
			editpreference.PutString ("preferencia",nuevoscore);
			editpreference.Commit ();

			var men = new Intent(this, typeof(menu));
			StartActivity (men);
		}
	}		
}





