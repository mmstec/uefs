using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Genius
{
    /// <summary>
    /// Classe Viewer: Camada UI princiapal
    /// Criador: Marcos Morais
    /// Criada em 15/11/2021
    /// Contato: marcosmoraisjr@yahoo.com.br
    /// </summary>
    public partial class frmGenius : Form
    {
        [DllImport("kernel32.dll")]      
        
        public static extern bool Beep(UInt32 frequency, UInt32 duration);
        const float brilho = 0.9f;									//define intensidade do brilho
        string zeros = "0000000";									//preencher string com zeros
        int[] cores;												//cor sorteada aleatóriamente
        int corAtual = 0;											//cor atual
        int pontos = 0;												//última cor que foi sorteada e mostrada
        Stopwatch cronometro = new Stopwatch();                     //obj cronometro 
        
        SoundPlayer[] audios = {
            new SoundPlayer(Properties.Resources.som_verde),
            new SoundPlayer(Properties.Resources.som_vermelho),
            new SoundPlayer(Properties.Resources.som_amarelo),
            new SoundPlayer(Properties.Resources.som_azul),
            new SoundPlayer(Properties.Resources.som_gameover),
            new SoundPlayer(Properties.Resources.som_iniciar)
        };

        /// <summary>
        /// Inicializa os componente principais
        /// </summary>
        public frmGenius()
        {
            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);
            InitializeComponent();
            //t.Abort();
        }

        /// <summary>
        /// Carrega o formul[ario splasscreen
        /// </summary>
        public void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }

        /// <summary>
        /// Carrega o menu de opções
        /// </summary>
        private void meuMenu(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            switch (menu.Text)
            {
                case "Jogar":
                    if (rbFacil.Checked == true)
                    {
                        cores = new int[8];
                    }
                    else if (rbMedio.Checked == true)
                    {
                        cores = new int[14];
                    }
                    else if (rbDificil.Checked == true)
                    {
                        cores = new int[20];
                    }
                    else if (rbExpert.Checked == true)
                    {
                        cores = new int[31];
                    }
                    gbNivel.Enabled = false;
                    btnJogar.Enabled = false;
                    novoJogo();
                    break;
                case "Sobre":
                    //string info = "Nome do Jogo: Genius \n Desenvolvido por: Marcos Morais";
                    //MessageBox.Show(info);
                    frmSobre frm = new frmSobre();
                    frm.Show();
                    break;
                case "Sair":
                    Application.Exit();
                    break;

            }
        }

        /// <summary>
        /// Inicia o jogo propiamente dito
        /// </summary>
        /// <param name="sender, e">campo de ordenação</param>
        /// <returns>sem retorno</returns>
        private void Jogar(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            cronometro.Start();              //iniciar cronometro
            tmrCronometro.Enabled = true;    //ativar  timer
            InitializeTimer();
            pontos = 0;
            
            //lblSegundos.ForeColor = System.Drawing.Color.DarkCyan;
            //lblMilliseconds.ForeColor = System.Drawing.Color.DarkCyan;
            toolStripStatusLabelPontos.ForeColor = System.Drawing.Color.DarkCyan;
            toolStripStatusLabelSegundos.ForeColor = System.Drawing.Color.DarkCyan;
            toolStripStatusLabeMilliseconds.ForeColor = System.Drawing.Color.DarkCyan;

            //intervalo entre cores/sons
            if (rbFacil.Checked == true)
            {
                cores = new int[8];
                tmrCores.Interval = 1665;  //1000
            }
            else if (rbMedio.Checked == true)
            {
                cores = new int[14];
                tmrCores.Interval = 1332;    //233
            }
            else if (rbDificil.Checked == true)
            {
                cores = new int[20];
                tmrCores.Interval = 999;   //133
            }
            else if (rbExpert.Checked == true)
            {
                cores = new int[31];        
                tmrCores.Interval = 666;  //31
            }
            btnJogar.Enabled = false;
            gbNivel.Enabled = false;
            novoJogo();
        }

        /// <summary>
        /// Provca o efeito piscar ao clicar 
        /// </summary>
        private void Piscar()
        {
            //lblSegundos.Visible = true;
            //lblMilliseconds.Visible = true;

            //zerar a variavel corAtual
            corAtual = 0;
            tmrCores.Enabled = true;

            // resetar o cronômetro
            cronometro.Reset();
            
            // iniciar cronometro
            cronometro.Start();
        }

        /// <summary>
        /// Inicia procedimento para permitir continuar no jogo
        /// </summary>
        /// <param name="novaCor">chama cor diferente da atual</param>
        /// <returns>sem retorno</returns>
        private void novaResposta(int novaCor)
        {
            //acertou parcialmente, pode continuar
            if (novaCor == cores[corAtual] && corAtual < pontos)
            {
                corAtual++;
            }
            //acertou sequencia, incrementa o ponto e sortea uma cor nova
            else if (novaCor == cores[corAtual] && corAtual >= pontos)
            {
                if (rbFacil.Checked == true && corAtual + 1 == 8)
                {
                    MessageBox.Show("Parabéns! Nível fácil concluído!", 
                        "Fim de jogo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    rbMedio.Select();
                    finalizarJogo();
                    pontos = 0;
                }
                else if (rbMedio.Checked == true && corAtual + 1 == 14)
                {
                    MessageBox.Show("Parabéns! Nível médio concluído!", 
                        "Fim de jogo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    rbDificil.Select();
                    finalizarJogo();
                    pontos = 0;
                }
                else if (rbDificil.Checked == true && corAtual + 1 == 20)
                {
                    MessageBox.Show("Parabéns! Nível difícil concluído!", 
                        "Fim de jogo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    rbExpert.Select();
                    finalizarJogo();
                    pontos = 0;
                }
                else if (rbExpert.Checked == true && corAtual + 1 == 31)
                {
                    MessageBox.Show("Parabéns! Nível avançado concluído!", 
                        "Fim de jogo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    finalizarJogo();
                    //lbPontos.Text = pontos.ToString(zeros);
                    toolStripStatusLabelPontos.Text = pontos.ToString(zeros);
                    pontos = 0;
                }
                else
                {
                    pontos++;
                    //lbPontos.Text = pontos.ToString(zeros);
                    toolStripStatusLabelPontos.Text = pontos.ToString(zeros);
                    Piscar();
                }
            }
            //Errou = Fim de Jogo e exibe pontos !
            else if (novaCor != cores[corAtual])
            {
                tmrLabels.Enabled = false;
                tocarSom(5);
                MessageBox.Show("Fim de jogo. Você marcou " + pontos.ToString() + " pontos.", 
                    "Fim de jogo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                //lbPontos.Text = pontos.ToString(zeros);
                toolStripStatusLabelPontos.Text = pontos.ToString(zeros);
                pontos = 0;
                finalizarJogo();
            }
            //mostrar a cor atual e exibe pontos 
            //lblPontos.Text = pontos.ToString(zeros);
            //Thread.Sleep(250);
        }

        /// <summary>
        /// Inicia procedimento iniciar um novo jogo e escolhe uma cor randomicamente
        /// </summary>
        private void novoJogo()
        {
            //sortear a cor do indice 0
            Random rd1 = new Random();
            cores[0] = rd1.Next(1, 5);
            //lbPontos.Text = "0000000";
            toolStripStatusLabelPontos.Text = "0000000";
            tocarSom(6);
            Thread.Sleep(2000);
            int i = 1;
            while (i <= cores.Length - 1)
            {
                Random rd2 = new Random(DateTime.Now.Millisecond);
                int temp = rd2.Next(1, 5);
                //cor atual não pode ser igual a cor anterior
                if (temp != cores[i - 1])
                {
                    cores[i] = temp;
                    i++;
                }
            }
            //piscar a primeira cor
            Piscar();
        }

        /// <summary>
        /// Inicia procedimento randomico para sorteio de cores, de acordo a dificuldade do jogo
        /// </summary>
        /// <param name="sender, e">sorteio de cores diferente da anterior</param>
        /// <returns>sem retorno</returns>
        private void sortearCor(object sender, EventArgs e)
        {
            //desabilitar botões enquanto está passando as cores
            pbAmarelo.Enabled = false;
            pbAzul.Enabled = false;
            pbVerde.Enabled = false;
            pbVermelho.Enabled = false;

            //voltar todas as cores para o padrão
            pbAmarelo.Image = Properties.Resources.amarelo;
            pbAzul.Image = Properties.Resources.azul;
            pbVerde.Image = Properties.Resources.verde;
            pbVermelho.Image = Properties.Resources.vermelho;

            //se corAtual for maior que o último então está na hora de responder e parar de sortear as cores
            if (corAtual > pontos)
            {
                pbAmarelo.Enabled = true;
                pbAzul.Enabled = true;
                pbVerde.Enabled = true;
                pbVermelho.Enabled = true;
                tmrCores.Enabled = false;
                corAtual = 0;
            }
            //senão continua sorteando...
            else
            {

                //pisca a cor que está no indice "corAtual"
                switch (cores[corAtual])
                {
                    case 1:
                        {
                            pbAmarelo.Image = Properties.Resources.amarelo_aceso;
                            tocarSom(1);
                            break;
                        }
                    case 2:
                        {
                            pbAzul.Image = Properties.Resources.azul_aceso;
                            tocarSom(2);
                            break;
                        }
                    case 3:
                        {
                            pbVerde.Image = Properties.Resources.verde_aceso;
                            tocarSom(3);
                            break;
                        }
                    case 4:
                        {
                            pbVermelho.Image = Properties.Resources.vermelho_aceso;
                            tocarSom(4);
                            break;
                        }
                }
                corAtual++;
            }
        }

        /// <summary>
        /// Bloco de código envolvendo contagem de tempo
        /// </summary>

        private void InitializeTimer()
        {
            tmrLabels.Interval = 1000;      
            tmrLabels.Enabled = true;
        }
        
        private void timerCronometro(object sender, EventArgs e)
        {
            /*
            if (cronometro.Elapsed.Hours < 10)
                lblHoras.Text = "0" + cronometro.Elapsed.Hours.ToString();
            else
                lblHoras.Text = cronometro.Elapsed.Hours.ToString();

            if (cronometro.Elapsed.Minutes < 10)
                lblMinutos.Text = "0" + cronometro.Elapsed.Minutes.ToString();
            else
                lblMinutos.Text = cronometro.Elapsed.Minutes.ToString();
            */

        if (cronometro.Elapsed.Seconds < 10)
        {
            //lblSegundos.Text = "0" + cronometro.Elapsed.Seconds.ToString();
            toolStripStatusLabelSegundos.Text = cronometro.Elapsed.Seconds.ToString("00");
            toolStripStatusLabeMilliseconds.Text = cronometro.Elapsed.Milliseconds.ToString("000");
            }
        else
        {
            //lblSegundos.Text = cronometro.Elapsed.Seconds.ToString();
            //lblMilliseconds.Text = cronometro.Elapsed.Milliseconds.ToString();

            toolStripStatusLabelSegundos.Text = cronometro.Elapsed.Seconds.ToString("00");
            toolStripStatusLabeMilliseconds.Text = cronometro.Elapsed.Milliseconds.ToString("000");
        }
    }
        private void timerPlacar(object sender, System.EventArgs e)
        {
            if (toolStripStatusLabelSegundos.Text == "19")
            {
                // Saia do código do loop.
                //lblSegundos.Text = "10";
                //lblSegundos.ForeColor = System.Drawing.Color.Red;
                //lblMilliseconds.Text = "000";
                //lblMilliseconds.ForeColor = System.Drawing.Color.Red;

                toolStripStatusLabelSegundos.Text = "20";
                toolStripStatusLabeMilliseconds.Text = "000";
                toolStripStatusLabelSegundos.ForeColor = System.Drawing.Color.Red;
                toolStripStatusLabeMilliseconds.ForeColor = System.Drawing.Color.Red;

                tmrLabels.Enabled = false;
                tocarSom(5);
                //lbPontos.Text = pontos.ToString(zeros);
                toolStripStatusLabelPontos.Text = pontos.ToString(zeros);
                finalizarJogo();
                MessageBox.Show("Fim de jogo. Seja mais rápido nas respostas!", "Fim de jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void tocarSom(int cor)
        {
            switch (cor)
            {
                case 1:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.som_amarelo);
                        player.Load();
                        player.Play();
                        break;
                    }
                case 2:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.som_azul);
                        player.Load();
                        player.Play();
                        break;
                    }
                case 3:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.som_verde);
                        player.Load();
                        player.Play();
                        break;
                    }
                case 4:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.som_vermelho);
                        player.Load();
                        player.Play();
                        break;
                    }
                case 5:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.som_gameover);
                        player.Load();
                        player.Play();
                        break;
                    }
                case 6:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.som_iniciar);
                        player.Load();
                        player.Play();
                        break;
                    }


            }
        }
        private void finalizarJogo()
        {
            pictureBox1.Visible = true;
            cronometro.Stop();              //parar cronometro
            tmrCronometro.Enabled = false;  //desativar timer
            pbAmarelo.Enabled = false;
            pbAzul.Enabled = false;
            pbVerde.Enabled = false;
            pbVermelho.Enabled = false;
            gbNivel.Enabled = true;
            btnJogar.Enabled = true;
        }
        #region acende a imagem ao clicar

        private void pbAmarelo_MouseDown(object sender, MouseEventArgs e)
        {
            pbAmarelo.Image = Properties.Resources.amarelo_aceso;
            tocarSom(1);
        }

        private void pbAmarelo_MouseUp(object sender, MouseEventArgs e)
        {
            pbAmarelo.Image = Properties.Resources.amarelo;
            novaResposta(1);
        }

        private void pbAzul_MouseDown(object sender, MouseEventArgs e)
        {
            pbAzul.Image = Properties.Resources.azul_aceso;
            tocarSom(2);
        }

        private void pbAzul_MouseUp(object sender, MouseEventArgs e)
        {
            pbAzul.Image = Properties.Resources.azul;
            novaResposta(2);
        }

        private void pbVerde_MouseDown(object sender, MouseEventArgs e)
        {
            pbVerde.Image = Properties.Resources.verde_aceso;
            tocarSom(3);
        }

        private void pbVerde_MouseUp(object sender, MouseEventArgs e)
        {
            pbVerde.Image = Properties.Resources.verde;
            novaResposta(3);
        }

        private void pbVermelho_MouseDown(object sender, MouseEventArgs e)
        {
            pbVermelho.Image = Properties.Resources.vermelho_aceso;
            tocarSom(4);
        }

        private void pbVermelho_MouseUp(object sender, MouseEventArgs e)
        {
            pbVermelho.Image = Properties.Resources.vermelho;
            novaResposta(4);
        }
        #endregion

        private void frmGenius_Load(object sender, EventArgs e)
        {
            //lblHoras.Visible = false;
            //lblMinutos.Visible = false;
            //lblSegundos.Visible = false;
            //lblMilliseconds.Visible = false;

        }

        private void frmGenius_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void iniciarUsabilidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string path = @"C:\Program Files (x86)\Enable Viacam\bin\eviacam.exe";
            bool result = File.Exists(path);
            if (result == true)
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("eViacam não econtrado no caminho padrão! \nExecute manualmente!");
            }
        }
    }
}