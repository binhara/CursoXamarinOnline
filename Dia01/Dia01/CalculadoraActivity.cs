using System;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace Dia01
{

    [Activity(Label = "Calculadora")]
    public class CalculadoraActivity : Activity
    {
        enum Operacao { Soma, Subtracao, Multiplicacao, Divisao }
        private static TextView _caixaResultado;
        private static string _resultadoEmString;
        private static float _valorJaArmazenado;
        private static bool _jaEstaExibindoResultado;
        private static Operacao _operacaoParaRealizar = Operacao.Soma;
        private Context _appContext;
        private Android.Content.Res.Resources _appResources;

        protected override void OnCreate(Bundle bundle)
        {
            _appContext = this;
            _appResources = _appContext.Resources;

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Calculadora);

            _valorJaArmazenado = 0;
            _jaEstaExibindoResultado = false;

            var metricasDoAparelho = Resources.DisplayMetrics;
            var larguraDoAparelho = ConverteMedidas(metricasDoAparelho.WidthPixels);
            var alturaDoAparelho = ConverteMedidas(metricasDoAparelho.HeightPixels);
            var larguraPretendida = (larguraDoAparelho / 4);
            var alturaPretendida = (alturaDoAparelho / 6);
            var fontPretendida = (alturaDoAparelho / 10);

            var table = FindViewById<TableLayout>(Resource.Id.table);
            for (var linhas = 0; linhas < table.ChildCount; linhas++)
            {
                var linha = table.GetChildAt(linhas) as TableRow;
                if (linha == null) continue;
                for (var coluna = 0; coluna < linha.ChildCount; coluna++)
                {
                    if (!(linha.GetChildAt(coluna) is Button)) continue;
                    var button = linha.GetChildAt(coluna) as Button;
                    if (button == null) continue;
                    button.SetHeight(alturaPretendida);
                    button.SetWidth(larguraPretendida);
                    button.SetTextSize(ComplexUnitType.Px, fontPretendida);
                    button.Click += ButtonClick;
                }
            }
            
            _caixaResultado = FindViewById<TextView>(Resource.Id.textResultado);
            _caixaResultado.SetHeight(alturaPretendida);
            _caixaResultado.SetTextSize(ComplexUnitType.Px, fontPretendida);
            _resultadoEmString = string.Empty;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            var v = sender as Button;

            if (_jaEstaExibindoResultado)
            {
                switch (v.Id)
                {
                    case Resource.Id.button0:
                    case Resource.Id.button1:
                    case Resource.Id.button2:
                    case Resource.Id.button3:
                    case Resource.Id.button4:
                    case Resource.Id.button5:
                    case Resource.Id.button6:
                    case Resource.Id.button7:
                    case Resource.Id.button8:
                    case Resource.Id.button9:
                    case Resource.Id.buttonPonto:
                        _resultadoEmString = string.Empty;
                        break;
                }
                _jaEstaExibindoResultado = false;
            }

            switch (v.Id)
            {
                case Resource.Id.button0: _resultadoEmString += _appResources.GetString(Resource.String.button0); break;
                case Resource.Id.button1: _resultadoEmString += _appResources.GetString(Resource.String.button1); break;
                case Resource.Id.button2: _resultadoEmString += _appResources.GetString(Resource.String.button2); break;
                case Resource.Id.button3: _resultadoEmString += _appResources.GetString(Resource.String.button3); break;
                case Resource.Id.button4: _resultadoEmString += _appResources.GetString(Resource.String.button4); break;
                case Resource.Id.button5: _resultadoEmString += _appResources.GetString(Resource.String.button5); break;
                case Resource.Id.button6: _resultadoEmString += _appResources.GetString(Resource.String.button6); break;
                case Resource.Id.button7: _resultadoEmString += _appResources.GetString(Resource.String.button7); break;
                case Resource.Id.button8: _resultadoEmString += _appResources.GetString(Resource.String.button8); break;
                case Resource.Id.button9: _resultadoEmString += _appResources.GetString(Resource.String.button9); break;
                case Resource.Id.buttonPonto:
                    if (!_resultadoEmString.Contains(_appResources.GetString(Resource.String.buttonPonto)))
                        _resultadoEmString += _appResources.GetString(Resource.String.buttonPonto);
                    break;
                case Resource.Id.buttonLimpar:
                    _resultadoEmString = string.Empty;
                    _valorJaArmazenado = 0;
                    break;
                case Resource.Id.buttonSoma:
                    _operacaoParaRealizar = Operacao.Soma;
                    _valorJaArmazenado = PegaValorResultado();
                    _resultadoEmString = string.Empty;
                    break;
                case Resource.Id.buttonSubtrair:
                    if (string.IsNullOrEmpty(_resultadoEmString))
                    {
                        _resultadoEmString = _appResources.GetString(Resource.String.buttonSubtrair);
                    }
                    else
                    {
                        _operacaoParaRealizar = Operacao.Subtracao;
                        _valorJaArmazenado = PegaValorResultado();
                        _resultadoEmString = string.Empty;
                    }
                    break;
                case Resource.Id.buttonMultiplicar:
                    _operacaoParaRealizar = Operacao.Multiplicacao;
                    _valorJaArmazenado = PegaValorResultado();
                    _resultadoEmString = string.Empty;
                    break;
                case Resource.Id.buttonDividir:
                    _operacaoParaRealizar = Operacao.Divisao;
                    _valorJaArmazenado = PegaValorResultado();
                    _resultadoEmString = string.Empty;
                    break;
                case Resource.Id.buttonIgualdade:
                    Resolver();
                    _jaEstaExibindoResultado = true;
                    _resultadoEmString = _valorJaArmazenado.ToString(CultureInfo.InvariantCulture);
                    break;
            }
            _caixaResultado.Text = _resultadoEmString;
        }

        static void Resolver()
        {
            switch (_operacaoParaRealizar)
            {
                case Operacao.Divisao: _valorJaArmazenado = _valorJaArmazenado / PegaValorResultado(); break;
                case Operacao.Subtracao: _valorJaArmazenado = _valorJaArmazenado - PegaValorResultado(); break;
                case Operacao.Multiplicacao: _valorJaArmazenado = _valorJaArmazenado * PegaValorResultado(); break;
                default: _valorJaArmazenado = _valorJaArmazenado + PegaValorResultado(); break;
            }
        }

        private int ConverteMedidas(float valor)
        {
            return (int)((valor) / Resources.DisplayMetrics.Density);
        }

        static float PegaValorResultado()
        {
            return !string.IsNullOrEmpty(_resultadoEmString) ? float.Parse(_resultadoEmString) : 0;
        }
    }
}