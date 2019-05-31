using System.Drawing;

namespace WindowsFormsApp1
{
    class No
    {
        public Point p { get; set; }//coordenadas x, y do nó na tela para fins de visualização
        public string nome { get; set; }//Conteúdo de texto do Nó
        public Color c { get; set; }//cor a ser atribuída pelo algoritmo

        public int grau { get; set; }//grau do nó a ser calculado pelo algoritmo

        public No(Point p, string text)//contrutor do nó recebe as coodenadas e o texto
        {
            this.p = p;
            this.nome = text;
            this.c = Color.White;
        }
    }
}
