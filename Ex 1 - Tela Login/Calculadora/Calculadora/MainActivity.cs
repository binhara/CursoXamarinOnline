using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace Calculadora
{
	[Activity (Label = "Calculadora", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int Nro1 = 0;
		int Nro2 = 0;
		int Calculo = 0;
		string Sinal = "";
		//private TextView Resultado;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button btn1 = FindViewById<Button> (Resource.Id.btn1);
			Button btn2 = FindViewById<Button> (Resource.Id.btn2);
			Button btn3 = FindViewById<Button> (Resource.Id.btn3);
			Button btn4 = FindViewById<Button> (Resource.Id.btn4);
			Button btn5 = FindViewById<Button> (Resource.Id.btn5);
			Button btn6 = FindViewById<Button> (Resource.Id.btn6);
			Button btn7 = FindViewById<Button> (Resource.Id.btn7);
			Button btn8 = FindViewById<Button> (Resource.Id.btn8);
			Button btn9 = FindViewById<Button> (Resource.Id.btn9);
			Button btn0 = FindViewById<Button> (Resource.Id.btn0);
			Button btnPonto = FindViewById<Button> (Resource.Id.btnPonto);
			Button btnInverte = FindViewById<Button> (Resource.Id.btnInverte);
			Button btnDivide = FindViewById<Button> (Resource.Id.btnDivide);
			Button btnMultiplica = FindViewById<Button> (Resource.Id.btnMultiplica);
			Button btnDiminui = FindViewById<Button> (Resource.Id.btnDiminui);
			Button btnSoma = FindViewById<Button> (Resource.Id.btnSoma);
			Button btnIgual = FindViewById<Button> (Resource.Id.btnIgual);

			Button btnlimpa = FindViewById<Button> (Resource.Id.btnLimpa);
			TextView resultado = FindViewById<TextView> (Resource.Id.txtResultado);


			btn1.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "1"); };
			btn2.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "2"); };
			btn3.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "3"); };
			btn4.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "4"); };
			btn5.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "5"); };
			btn6.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "6"); };
			btn7.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "7"); };
			btn8.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "8"); };
			btn9.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "9"); };
			btn0.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "0"); };
			btnPonto.Click += delegate {
				resultado.Text = string.Format (resultado.Text + "."); };
			btnlimpa.Click += delegate {
				resultado.Text = string.Format (""); };
			btnInverte.Click += delegate {
				resultado.Text = string.Format (Convert.ToString (Convert.ToInt32 (resultado.Text) * -1)); };
			btnSoma.Click += delegate {
				Sinal = "+";
				Nro1 = Convert.ToInt32 (resultado.Text);
				resultado.Text = string.Format (""); 
			};
			btnDiminui.Click += delegate {
				Sinal = "-";
				Nro1 = Convert.ToInt32 (resultado.Text);
				resultado.Text = string.Format (""); 
			};
			btnMultiplica.Click += delegate {
				Sinal = "*";
				Nro1 = Convert.ToInt32 (resultado.Text);
				resultado.Text = string.Format (""); 
			};
			btnDivide.Click += delegate {
				Sinal = "/";
				Nro1 = Convert.ToInt32 (resultado.Text);
				resultado.Text = string.Format (""); 
			};


			btnIgual.Click += delegate {
				Nro2 = Convert.ToInt32 (resultado.Text);
				switch (Sinal)
					{
					case "+":
						Calculo = Nro1 + Nro2;
						break;
					case "-":
						Calculo = Nro1 - Nro2;
						break;
					case "*":
						Calculo = Nro1 * Nro2;
						break;
					case "/":
						Calculo = Nro1 / Nro2;
						break;
					};
				resultado.Text = string.Format (Convert.ToString (Calculo));
			};


//
//			SetContentView (Resource.Layout.Main);
//
//			//	Resultado.Text = "teste";//(TextView)this.FindViewById(Resource.Id.txtResultado);
//
//			// Criar botao para chamar tela de cliente 
//			Button btn1 = FindViewById<Button> (Resource.Id.btn1);
//			btn1.Click += new EventHandler(btn1_Click);
//
//			Button btnLimpa = FindViewById<Button> (Resource.Id.btnLimpa);
//			//			btnLimpa.Click += new EventHandler(btnLimpa_Click);
//
//			btnLimpa.Click += (sender, e) => {
//				Resultado.Text = "";
//			};
//
//			SetContentView (Resource.Layout.Main);
//
			//
//			var layout = new LinearLayout (this);
//			layout.Orientation = Orientation.Vertical;
//
//			var Resultado = new TextView (this);
//			Resultado.Text = "";
//			//			Resultado.backcolor  = "@color/white";
//
//			var Button1 = new Button (this);
//			Button1.Text = "1";
//			var Button2 = new Button (this);
//			Button2.Text = "2";
//			var Button3 = new Button (this);
//			Button3.Text = "3";
//			var Button4 = new Button (this);
//			Button4.Text = "4";
//			var Button5 = new Button (this);
//			Button5.Text = "5";
//			var Button6 = new Button (this);
//			Button6.Text = "6";
//			var Button7 = new Button (this);
//			Button7.Text = "7";
//			var Button8 = new Button (this);
//			Button8.Text = "8";
//			var Button9 = new Button (this);
//			Button9.Text = "9";
//			var Button0 = new Button (this);
//			Button0.Text = "0";
//			var ButtonPonto = new Button (this);
//			ButtonPonto.Text = ".";
//			var ButtonInverte = new Button (this);
//			ButtonInverte.Text = "+/-";
//
//			Button1.Click += delegate { Resultado.Text = Resultado.Text + "1"; };
//			Button2.Click += delegate { Resultado.Text = Resultado.Text + "2"; };
//			Button3.Click += delegate { Resultado.Text = Resultado.Text + "3"; };
//			// Ver com Binhara qual a melhor forma de utilizar e porque?
//			Button4.Click += (sender, e) => { Resultado.Text = Resultado.Text + "4"; };
//
//
//			layout.AddView (Resultado);
//			layout.AddView (Button1);
//			layout.AddView (Button2);
//			layout.AddView (Button3);
//
//			SetContentView (layout);
		}


//		private void btn1_Click(object sender, EventArgs e)
//		{
//			//var meiocadastrado = service.SelecionarMeioPagto (Convert.ToInt32 (MP_id.Text));
//			//			StartActivity(typeof(actMenuCadastros));
//		}
//
//		private void btnLimpa_Click(object sender, EventArgs e)
//		{
//			txtResultado = "";
//			//var meiocadastrado = service.SelecionarMeioPagto (Convert.ToInt32 (MP_id.Text));
//			//			StartActivity(typeof(actMenuCadastros));
//		}

	}
}


