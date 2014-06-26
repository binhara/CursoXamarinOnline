using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LoginCalculadora
{
    [Activity(Label = "LoginCalculadora", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var layout = new LinearLayout(this) {Orientation = Orientation.Vertical};

            var alblUsuario = new TextView(this) {Text = "Usuário"};

            var alblSenha = new TextView(this) {Text = "Senha"};

            var txtUsuario = new EditText(this) {Text = String.Empty};

            var txtSenha = new EditText(this)
            {
                InputType = InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText,
                Text = String.Empty
            };

            var aButtonNovaTela = new Button(this);


            aButtonNovaTela.Click += delegate
            {
                if (VerificaLogin(txtUsuario.Text, txtSenha.Text))
                {
                    var act = new Intent(this, typeof (Calculadora));
                    act.PutExtra("nomeUsuario", txtUsuario.Text);
                    StartActivity(act);
                }
                else
                {
                    var box = new AlertDialog.Builder(this);
                    box.SetMessage("Erro ao logar, tente novamente");
                    //TODO olhar uma forma de colocar o botão OK
                    box.Show();
                }
            };

            aButtonNovaTela.Text = "Logar";

            layout.AddView(alblUsuario);
            layout.AddView(txtUsuario);
            
            layout.AddView(alblSenha);
            layout.AddView(txtSenha);

            layout.AddView(aButtonNovaTela);

            SetContentView(layout);

            


        }

        private bool VerificaLogin(string usuario, string senha)
        {
            return (usuario.ToLower().Equals("teste") && senha.ToLower().Equals("123"));
        }
    }
}

