using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<No> nos = new List<No>();//Estrutura em lista para armazenagem dos nós
        private List<Aresta> arestas = new List<Aresta>();//Estrutura em lista para armazenagem das arestas

        BindingSource bs1 = new BindingSource();//Bindingsources para atrelar os Comboboxes da interface
        BindingSource bs2 = new BindingSource();//automaticamente com a lista de nós e arestas
        BindingSource bs3 = new BindingSource();
        BindingSource bs4 = new BindingSource();

        private bool canAddPt = false;//controle para realizar a adição de nós utilizando o mouse
        Rectangle tela = new Rectangle(260, 20, 600, 600);//àrea da tela em que podem existir elementos do grafo

        public Form1()//inicialização da interface
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)//método que é chamado para desenhar o grafo ou atualizar
        {
            Graphics g = e.Graphics;//obtem o componente gráfico

            g.FillRectangle(Brushes.White, tela);//desenha um painel branco
            g.DrawRectangle(Pens.Black, tela);//a borda desse painel


            foreach (Aresta ar in arestas)//percorre a lista de arestas
            {
                g.DrawLine(Pens.Black, ar.no1.p.X, ar.no1.p.Y, ar.no2.p.X, ar.no2.p.Y);//uma linha preta para cada aresta
            }

            foreach (No no in nos)//percorre a lista de nós
            {
                g.FillEllipse(new SolidBrush(no.c), no.p.X - 15, no.p.Y - 15, 30, 30);//desenha o nó como uma elipse com a cor designada
                g.DrawEllipse(Pens.Black, no.p.X - 15, no.p.Y - 15, 30, 30);//a borda do nó
                g.DrawString(no.nome, new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, no.p.X - 15 + 5, no.p.Y - 15 + 5);//escreve o nome dentro do nó
            }

            g.Dispose();//libera os recursos graficos

        }

        private void Form1_Load(object sender, EventArgs e)//ao carregar o formulário
        {
            bs1.DataSource = nos;//atrela todos os bindingsources às listas correspondentes
            bs2.DataSource = nos;
            bs3.DataSource = nos;
            bs4.DataSource = arestas;
            comboBox1.DisplayMember = "nome";//define qual elemento será exibido no combobox
            comboBox1.DataSource = bs1;//define a origem dos dados do combobox

            comboBox2.DisplayMember = "nome";
            comboBox2.DataSource = bs2;

            comboBox3.DisplayMember = "nome";
            comboBox3.DataSource = bs3;

            comboBox4.DisplayMember = "nome";
            comboBox4.DataSource = bs4;
        }

        private void GrafoCompleto(int v)//cria um grafo completo com V nós
        {
            nos.Clear();//exclui os nós existentes
            arestas.Clear();//exclui as arestas existentes

            char letra = 'A';//começa os nomes dos nós pela letra A
            int xx = 564, yy = 322, total = v;//espaçamento do inicio das coordenadas
            double x = 0, y = -250, e, r;//coordenadas do primeiro nó
            double a = -2 * Math.PI/total;//calculo do angulo de espaçamento dos nós em radianos

            for (int i=0;i<total;i++)//loop de criação dos nós
            {
                nos.Add(new No(new Point((int) x + xx, (int) y + yy), ""+letra));//cria nó com as coordenadas e letra designada
                letra = (char)(((int)letra) + 1);//muda para a proxima letra

                e = y * Math.Cos(a) - x * Math.Sin(a);//calcula a próxima coordenada a partir do angulo
                r = y * Math.Sin(a) + x * Math.Cos(a);

                x = r;//copia das variáveis temporárias
                y = e;
            }

            for (int i=0;i<total;i++)//cria todas as arestas possíveis
            {
                for (int j = i+1;j<total;j++)
                {
                    arestas.Add(new Aresta(nos[i], nos[j]));
                }
            }
        }

        private void AddMapaBrasil()//método que define um grafo pré-carregado do mapa de fronteiras do Brasil
        {
            nos.Clear();//exclui os nós existentes
            arestas.Clear();//exclui as arestas existentes
            int xx = 264, yy = 22;//espaçamento do inicio das coordenadas

            //Cria os nós dos estados
            nos.Add(new No(new Point(79 + xx, 28 + yy), "RR"));
            nos.Add(new No(new Point(128 + xx, 123 + yy), "AM"));
            nos.Add(new No(new Point(23 + xx, 190 + yy), "AC"));
            nos.Add(new No(new Point(135 + xx, 210 + yy), "RO"));
            nos.Add(new No(new Point(278 + xx, 25 + yy), "AP"));
            nos.Add(new No(new Point(282 + xx, 104 + yy), "PA"));
            nos.Add(new No(new Point(365 + xx, 106 + yy), "MA"));
            nos.Add(new No(new Point(328 + xx, 182 + yy), "TO"));
            nos.Add(new No(new Point(406 + xx, 127 + yy), "PI"));
            nos.Add(new No(new Point(472 + xx, 109 + yy), "CE"));
            nos.Add(new No(new Point(521 + xx, 100 + yy), "RN"));
            nos.Add(new No(new Point(514 + xx, 136 + yy), "PB"));
            nos.Add(new No(new Point(490 + xx, 164 + yy), "PE"));
            nos.Add(new No(new Point(495 + xx, 199 + yy), "AL"));
            nos.Add(new No(new Point(478 + xx, 231 + yy), "SE"));
            nos.Add(new No(new Point(414 + xx, 233 + yy), "BA"));
            nos.Add(new No(new Point(262 + xx, 249 + yy), "MT"));
            nos.Add(new No(new Point(332 + xx, 274 + yy), "GO"));
            nos.Add(new No(new Point(284 + xx, 364 + yy), "MS"));
            nos.Add(new No(new Point(394 + xx, 308 + yy), "MG"));
            nos.Add(new No(new Point(435 + xx, 306 + yy), "ES"));
            nos.Add(new No(new Point(431 + xx, 341 + yy), "RJ"));
            nos.Add(new No(new Point(365 + xx, 386 + yy), "SP"));
            nos.Add(new No(new Point(343 + xx, 437 + yy), "PR"));
            nos.Add(new No(new Point(329 + xx, 491 + yy), "SC"));
            nos.Add(new No(new Point(295 + xx, 554 + yy), "RS"));



            //Cria as arestas das fronteiras existentes
            arestas.Add(new Aresta(nos.Find(x => x.nome == "RR"), nos.Find(x => x.nome == "PA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "RR"), nos.Find(x => x.nome == "AM")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AP"), nos.Find(x => x.nome == "PA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AC"), nos.Find(x => x.nome == "AM")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AC"), nos.Find(x => x.nome == "RO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AM"), nos.Find(x => x.nome == "RO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AM"), nos.Find(x => x.nome == "PA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AM"), nos.Find(x => x.nome == "MT")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "RO"), nos.Find(x => x.nome == "MT")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MT"), nos.Find(x => x.nome == "PA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "TO"), nos.Find(x => x.nome == "PA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MT"), nos.Find(x => x.nome == "TO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MA"), nos.Find(x => x.nome == "PA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PI"), nos.Find(x => x.nome == "MA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MA"), nos.Find(x => x.nome == "TO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PI"), nos.Find(x => x.nome == "TO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "TO"), nos.Find(x => x.nome == "GO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "TO"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PI"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PE"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AL"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "SE"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "GO"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MG"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "ES"), nos.Find(x => x.nome == "BA")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PI"), nos.Find(x => x.nome == "CE")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "CE"), nos.Find(x => x.nome == "RN")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "CE"), nos.Find(x => x.nome == "PB")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "RN"), nos.Find(x => x.nome == "PB")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "CE"), nos.Find(x => x.nome == "PE")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PI"), nos.Find(x => x.nome == "PE")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PE"), nos.Find(x => x.nome == "AL")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PE"), nos.Find(x => x.nome == "PB")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "AL"), nos.Find(x => x.nome == "SE")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MT"), nos.Find(x => x.nome == "GO")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MT"), nos.Find(x => x.nome == "MS")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "GO"), nos.Find(x => x.nome == "MS")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "GO"), nos.Find(x => x.nome == "MG")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MS"), nos.Find(x => x.nome == "MG")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "SP"), nos.Find(x => x.nome == "MG")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "RJ"), nos.Find(x => x.nome == "MG")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "ES"), nos.Find(x => x.nome == "MG")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "ES"), nos.Find(x => x.nome == "RJ")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "RJ"), nos.Find(x => x.nome == "SP")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MS"), nos.Find(x => x.nome == "SP")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "MS"), nos.Find(x => x.nome == "PR")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "SP"), nos.Find(x => x.nome == "PR")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "PR"), nos.Find(x => x.nome == "SC")));
            arestas.Add(new Aresta(nos.Find(x => x.nome == "SC"), nos.Find(x => x.nome == "RS")));

        }

        private void Colorir()//método que implementa o algoritmo de Welsh-Powell
        {
            List<No> nosOrdenados = new List<No>(nos);//cria uma cópia da lista de nós
            List<Color> cores = new List<Color>();//cria lista de cores
            cores.Add(Color.Crimson);
            cores.Add(Color.Cyan);
            cores.Add(Color.LightGreen);
            cores.Add(Color.Yellow);
            cores.Add(Color.Fuchsia);
            cores.Add(Color.Brown);
            cores.Add(Color.Coral);
            cores.Add(Color.ForestGreen);
            cores.Add(Color.BlueViolet);
            cores.Add(Color.Lavender);

            cores.Add(Color.White);

            foreach (No no in nosOrdenados)//percorre a lista de nós
            {
                //calcula o grau de cada nó
                no.grau = arestas.FindAll(x => (x.no1 == no) || (x.no2 == no)).Count;
                no.c = Color.White;//retira qualquer cor existente nos nós
            }

            //ordena os nós em ordem descrescente de grau
            nosOrdenados.Sort((no1, no2) => no2.grau.CompareTo(no1.grau));

            int indexcor = 0;//indice da cor atual
            No primeiroNoCor = null;//primeiro nó a receber a nova cor
            bool completo = false;//indicador de se os nós já foram totalmente coloridos
            bool interrompido = false;//indicador de que o algoritmo teve que ser interrompido
            while (!completo) {
                completo = true;
                
                primeiroNoCor = null;
                
                foreach (No no in nosOrdenados)
                {
                    
                    if (no.c == Color.White) {//verifica se o nó tem alguma cor atribuída
                        if(primeiroNoCor == null)
                        {
                            no.c = cores[indexcor];
                            primeiroNoCor = no;
                        }
                        else
                        {//verifica se o nó atual é  adjacente a algum nó já colorido com a cor atual
                            Aresta ar1 = arestas.Find(x => (x.no1 == no) && (x.no2.c == primeiroNoCor.c));
                            Aresta ar2 = arestas.Find(x => (x.no1.c == primeiroNoCor.c) && (x.no2 == no));
                            if ((ar1 == null) && (ar2 == null))//caso negativo, colore com a cor atual
                            {
                                no.c = cores[indexcor];
                            }else{
                                completo = false;//um nó será deixado sem colorir, então ainda não terminará a execução
                            }
                        }
                    }
                }
                if (indexcor < 10)//se ainda não tem 10 cores, troca para a próxima cor
                {
                    indexcor++;
                }
                else//caso positivo, interrompe a coloração
                {
                    indexcor = 10;
                    completo = true;
                    interrompido = true;
                }
            }
            Atualizar();
            if (interrompido)
            {
                MessageBox.Show("Este grafo necessita de mais de 10 cores, o algoritmo foi interrompido");
            }
        }

        private void canAdd(object sender, EventArgs e)//método de ação do botão criar Nó
        {
            if (canAddPt)
            {
                canAddPt = false;
                button1.Text = "Criar Nó";
            }
            else
            {
                canAddPt = true;
                button1.Text = "Cancelar";
            }
            
        }

        private void Form1_Click(object sender, EventArgs e)//método de tratamento dos cliques do mouse
        {
            MouseEventArgs e2 = (MouseEventArgs) e;//transforma o argumento de evento, em evento de mouse
            Point pointClicked = new Point(e2.X, e2.Y);//extrai as coordenadas do mouse

            //verifica se a posição do mouse era na tela de desenho e se o botão criar nó foi pressionado
            if (tela.Contains(pointClicked) && canAddPt) {
                nos.Add(new No(pointClicked, textBox1.Text));//adiciona o nó no local desejado e define o nome como o texto do textbox
                Atualizar();
            }

            canAddPt = false;//cancela a ação do botão criar nó, caso seja clicado em uma parte inválida
            button1.Text = "Criar Nó";
        }

        private void Atualizar()//atualiza os componentes visuais do formulário
        {
            this.Refresh();
            bs1.ResetBindings(false);
            bs2.ResetBindings(false);
            bs3.ResetBindings(false);
            bs4.ResetBindings(false);
        }

        private void Button2_Click(object sender, EventArgs e)//método de ação do botão criar Aresta
        {
            //verifica se os nós selecionado são iguais
            if ((No) comboBox1.SelectedItem != (No)comboBox2.SelectedItem) {
                //realiza pesquisa nas arestas existentes se já existe aresta com os mesmos nós
                Aresta ar1 = arestas.Find(x => (x.no1 == (No)comboBox1.SelectedItem) && (x.no2 == (No)comboBox2.SelectedItem));
                Aresta ar2 = arestas.Find(x => (x.no2 == (No)comboBox1.SelectedItem) && (x.no1 == (No)comboBox2.SelectedItem));

                //caso a pesquisa não retorne nada, prosseguir com a criação, caso contrário avisar o user
                if ((ar1 == null) && (ar2 == null)) {
                    //cria a aresta com os dois nós selecionados
                    arestas.Add(new Aresta((No)comboBox1.SelectedItem, (No)comboBox2.SelectedItem));
                    Atualizar();
                }
                else
                {
                    //exibe mensagem de erro e não cria a aresta
                    MessageBox.Show("Aresta já existente, não é permitido a criação de arestas paralelas");
                }
            }
            else
            {
                //exibe mensagem de erro e não cria a aresta
                MessageBox.Show("Não é permitido arestas do tipo laço (liga um nó a ele mesmo)");
            }
            //
        }

        private void Button3_Click(object sender, EventArgs e)//método de ação do botão remover nó
        {
            nos.Remove((No) comboBox3.SelectedItem);//remove o nó
            arestas.RemoveAll(x => x.no1 == (No) comboBox3.SelectedItem);//remove arestas associadas
            arestas.RemoveAll(x => x.no2 == (No) comboBox3.SelectedItem);//remove arestas associadas
            Atualizar();
        }

        private void Button4_Click(object sender, EventArgs e)//método de ação do botão remover aresta
        {
            arestas.Remove((Aresta) comboBox4.SelectedItem);//remove a aresta
            Atualizar();
        }

        private void Button7_Click(object sender, EventArgs e)//metodo de ação do botão limpar tudo
        {
            nos.Clear();
            arestas.Clear();
            textBox1.Clear();
            Atualizar();
        }

        private void Button6_Click(object sender, EventArgs e)//método de ação do botão Mapa do Brasil
        {
            
            AddMapaBrasil();
            Atualizar();
        }

        private void Button5_Click(object sender, EventArgs e)//método de ação do botão Executar Algoritmo
        {
            Colorir();
        }

        private void Button8_Click(object sender, EventArgs e)//método de ação do botão Grafo Completo
        {
            GrafoCompleto((int) numericUpDown1.Value);//cria um grafo completo com o numero de nós escolhido
            Atualizar();
        }
    }
}
