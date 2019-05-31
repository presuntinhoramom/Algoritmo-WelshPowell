namespace WindowsFormsApp1
{
    class Aresta
    {
        public No no1 { get; set; }//Primeiro nó da aresta
        public No no2 { get; set; }//Segundo nó da aresta

        public string nome { get; set; }//Texto da aresta no formato "No1 <> No2"

        public Aresta(No no1, No no2)//construtor da aresta
        {
            this.no1 = no1;
            this.no2 = no2;
            this.nome = no1.nome + " <> " + no2.nome;//constrói o nome da aresta no ato da criação dela
        }
    }
}
