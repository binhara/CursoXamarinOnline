using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace Dia01 {

    [Activity(Label = "Dia 1 - vitoravale", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity {

        private Context _appContext;
        private Android.Content.Res.Resources _appResources;

        protected override void OnCreate(Bundle bundle) {
            _appContext = this;
            _appResources = _appContext.Resources;

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.buttonEntrar);
            button.Click += AcaoEntrar;
        }

        protected void AcaoEntrar(object sender, EventArgs e) {
            string usuarioNome, usuarioSenha;
            
            using (var nome = FindViewById<EditText>(Resource.Id.textNome)) {
                if (string.IsNullOrEmpty(nome.Text.Trim())) {
                    EnviarAlerta(_appResources.GetString(Resource.String.LoginInformeNome), _appResources.GetString(Resource.String.LoginErroTitulo));
                    nome.RequestFocus();
                    return;
                }
                usuarioNome = nome.Text.Trim();
            }

            using (var senha = FindViewById<EditText>(Resource.Id.textSenha)){
                if (string.IsNullOrEmpty(senha.Text.Trim())) {
                    EnviarAlerta(_appResources.GetString(Resource.String.LoginInformeSenha), _appResources.GetString(Resource.String.LoginErroTitulo));
                    senha.RequestFocus();
                    return;
                }
                usuarioSenha = senha.Text.Trim().ToLower();
            }

            if (!usuarioSenha.Equals(_appResources.GetString(Resource.String.LoginSenhaEsperada).ToLower())) {
                EnviarAlerta(_appResources.GetString(Resource.String.LoginSenhaInvalida), _appResources.GetString(Resource.String.LoginSenhaInvalidaTitulo));
                return;
            }

            var builder = new AlertDialog.Builder(this);
            builder.SetTitle(string.Format(_appResources.GetString(Resource.String.LoginSenhaCorreta), usuarioNome));
            builder.SetPositiveButton(_appResources.GetString(Resource.String.LoginSenhaCorretaBotao), IniciarCalculadora);
            builder.SetCancelable(false);
            builder.Show();
        }

        protected void IniciarCalculadora(object sender, EventArgs e) {
            StartActivity(new Intent(this, typeof(CalculadoraActivity)));
        }

        protected void EnviarAlerta(string mensagem, string titulo = "") {
            new AlertDialog.Builder(this).SetTitle(titulo).SetMessage(mensagem).Show();
        }
    }
}

